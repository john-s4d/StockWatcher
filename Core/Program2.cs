using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using QuestradeApi;
//using QuestradeApi.Events;

namespace StockWatcher.Core
{
    class Program2
    {/*
        // HACK: Needs to be securely stored
        private const string OAUTH_CLIENT_ID = "rtk-eYc9sKDPwAXDe91lc-3_k9sAHA";
        private const string SYMBOL_ID = "5953026";

        private static Questrade _questrade;

        //private static Task _afterSuccessfulAuthTask = new Task(() => AfterSuccessfulAuth());
        private static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        static void Main2(string[] args)
        {



            //Console.Write("Refresh token: ");
            //string refreshToken = Console.ReadLine();
            //string refreshToken = REFRESH_TOKEN;

            _questrade = new Questrade();

            _questrade.OnSuccessfulAuthentication += QTrade_OnSuccessfulAuthentication;
            _questrade.OnUnsuccessfulAuthentication += QTrade_OnUnsuccessfulAuthentication;
            _questrade.OnAccountsRecieved += QTrade_OnAccountsRecieved;
            _questrade.OnQuoteStreamRecieved += QTrade_OnStreamRecieved;
            _questrade.OnOrderNotificationRecieved += QTrade_OnOrderNotifRecieved;


            //Task.Run(() => _questrade.Authenticate(refreshToken)); 

            System.Diagnostics.Process.GetCurrentProcess().WaitForExit();
        }

        private static void QTrade_OnUnsuccessfulAuthentication(object sender, UnsuccessfulAuthArgs e)
        {
            Console.WriteLine("Authentication unsuccessful: " + e.resp.ReasonPhrase);
            if (e.resp.StatusCode == HttpStatusCode.BadRequest)
            {
                Console.Write("Enter a valid token: ");
                Task.Run(() => _questrade.Authenticate(Console.ReadLine()));
            }
        }

        private static void QTrade_OnSuccessfulAuthentication(object sender, SuccessAuthEventArgs e)
        {
            Console.WriteLine(string.Format("Access token will expire on: {0} {1}", e.TokenExpiry.ToLongDateString(), e.TokenExpiry.ToLongTimeString()));

            Task.Run(() => _questrade.GetAccountsAsync(_cancellationTokenSource));
            Task.Run(() => _questrade.SubscribeToNotificationsAsync(_cancellationTokenSource));
            Task.Run(() => _questrade.StreamQuoteAsync(SYMBOL_ID, _cancellationTokenSource));
        }

        private static void QTrade_OnAccountsRecieved(object sender, APIAccountsReturnArgs e)
        {
            Console.WriteLine("Received Accounts:");

            for (int i = 0; i < e.accounts.accounts.Length; i++)
            {
                Console.WriteLine(string.Format("{0} {1} : {2}", e.accounts.accounts[i].clientAccountType, e.accounts.accounts[i].type, e.accounts.accounts[i].number));
            }
        }

        private static void QTrade_OnStreamRecieved(object sender, APIStreamQuoteRecievedArgs e)
        {
            var quoteResp = e.quotes;
            for (int i = 0; i < quoteResp.quotes.Length; i++)
            {
                Console.WriteLine(string.Format("{0} - Bid: {1}, BidSize: {2}, Ask: {3}, AskSize: {4}",
                e.time.ToString("HH:mm:ss"), quoteResp.quotes[i].bidPrice, quoteResp.quotes[i].bidSize, quoteResp.quotes[i].askPrice, quoteResp.quotes[i].askSize));
            }
        }

        private static void QTrade_OnOrderNotifRecieved(object sender, APIOrderNotificationRecievedArg e)
        {
            for (int i = 0; i < e.OrderNotif.orders.Length; i++)
            {
                Console.WriteLine(string.Format("{0} - Account: {1}, Symbol: {2}", e.time.ToString("HH:mm:ss"), e.OrderNotif.accountNumber, e.OrderNotif.orders[i].symbol));
            }
        }

        private static void QTrade_OnOrderProcessingErrorRecieved(object sender, OrderProcessingErrorEventArgs e)
        {
            Console.WriteLine(string.Format("Error code: {0}. {1} Order ID: {2}", e.OrderProcesssingErrorResp.code, e.OrderProcesssingErrorResp.message, e.OrderProcesssingErrorResp.orderId));
        }

        private static void QTrade_OnGeneralErrorRecieved(object sender, GeneralErrorEventArgs e)
        {
            Console.WriteLine(string.Format("Error code: {0}. {1}", e.GeneralErrorResp.code, e.GeneralErrorResp.message));
        }*/
    }
}
