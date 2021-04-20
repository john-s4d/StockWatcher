using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using StockWatcher.Common;

namespace StockWatcher.Core
{
    class OAuth
    {

        static readonly string _appName = "stockwatcher";
        static readonly string _uriScheme = "stockwatcher";

        readonly HttpClient client = new HttpClient();

        internal async static Task<bool> OAuthHook(IEnumerable<IOAuth> oauths, string[] args, int timeout)
        {
            foreach(IOAuth oauth in oauths)
            {
                if (args.Length > 0 && args[0].StartsWith(BuildRedirectUri(oauth)))
                {
                    Uri callbackParam = new Uri(args[0]);

                    string callbackState = HttpUtility.ParseQueryString(callbackParam.Query).Get("state");
                    string outboundPipeName = HttpUtility.ParseQueryString(HttpUtility.UrlDecode(callbackState)).Get("p");

                    await Pipes.SendText(args[0], outboundPipeName, timeout);

                    return true;
                }
            }
            return false;
        }

        private static string BuildRedirectUri(IOAuth oauth)
        {
            string callbackHost = $"callback.{oauth.CallbackHostId}";
            return new UriBuilder(_uriScheme, callbackHost).Uri.AbsoluteUri;
        }

        internal async Task<string> GetRefreshToken(IOAuth oauth, CancellationToken cancelToken)
        {
            string location = Assembly.GetEntryAssembly().Location;

            string redirectUrl = BuildRedirectUri(oauth);

            RegistryManager registry = new RegistryManager();
            registry.EnsureKeyExists(RootKey.CurrentUser, $"Software/Classes/{_appName}", $"URL:{_uriScheme}");
            registry.EnsureValueExists(RootKey.CurrentUser, $"Software/Classes/{_appName}", "URL Protocol", string.Empty);
            registry.EnsureKeyExists(RootKey.CurrentUser, $"Software/Classes/{_appName}/shell/open/command", $"\"{location}\" \"%1\"");

            string authorizationEndpoint = new Uri(oauth.AuthorizationEndpoint).AbsoluteUri;

            string inboundPipeName = Guid.NewGuid().ToString();
            string state = HttpUtility.UrlEncode($"p={inboundPipeName}");

            string authorizationUrl = $"{authorizationEndpoint}?" +
                $"client_id={HttpUtility.UrlEncode(oauth.ClientId)}&" +
                $"response_type=code&" +
                $"redirect_uri={HttpUtility.UrlEncode(redirectUrl)}&" +
                $"state={HttpUtility.UrlEncode(state)}";

            Process.Start(authorizationUrl);

            string callbackResponse = await Pipes.ReceiveText(inboundPipeName, cancelToken);

            Uri callbackUri = new Uri(callbackResponse);
            string tokenEndpoint = new Uri(oauth.TokenEndpoint).AbsoluteUri;
            string authCode = HttpUtility.ParseQueryString(callbackUri.Query).Get("code");

            List<KeyValuePair<string, string>> formParams = new List<KeyValuePair<string, string>>();
            formParams.Add(new KeyValuePair<string, string>("client_id", oauth.ClientId));
            formParams.Add(new KeyValuePair<string, string>("code", authCode));
            formParams.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            formParams.Add(new KeyValuePair<string, string>("redirect_uri", redirectUrl));
            FormUrlEncodedContent content = new FormUrlEncodedContent(formParams);

            var response = await client.PostAsync(tokenEndpoint, content);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
