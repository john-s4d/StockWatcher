using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockWatcher.Core
{
    class Pipes
    {
        internal static async Task SendText(string text, string pipeName, int timeout)
        {
            using (var client = new NamedPipeClientStream(pipeName))
            {
                await client.ConnectAsync(timeout);

                using (StreamWriter writer = new StreamWriter(client))
                {
                    writer.Write(text);
                }
            }
        }

        internal static async Task<string> ReceiveText(string pipeName, CancellationToken cancelToken)
        {
            using (var server = new NamedPipeServerStream(pipeName))
            {
                await server.WaitForConnectionAsync(cancelToken);

                using (var reader = new StreamReader(server))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
    }
}
