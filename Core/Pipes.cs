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
        /*
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
        }*/
        
        internal static async Task SendText(string text, string pipeName, int timeout)
        {
            using (var client = new NamedPipeClientStream(pipeName))
            {
                try
                {   
                    await client.ConnectAsync(timeout);
                }
                catch (Exception e)
                {
                    throw e;
                    //onSendFailed();
                    //return;
                }                

                using (StreamWriter writer = new StreamWriter(client))
                {
                    writer.Write(text);
                    writer.Flush();
                    writer.Close();
                }
                client.Close();
            }
        }


        /*
        internal static async Task<string> ReceiveText(string pipeName, CancellationToken cancelToken)
        {
            PipeSecurity ps = new PipeSecurity();
            System.Security.Principal.SecurityIdentifier sid = new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, null);
            PipeAccessRule par = new PipeAccessRule(sid, PipeAccessRights.ReadWrite, System.Security.AccessControl.AccessControlType.Allow);
            ps.AddAccessRule(par);

            using (var server = new NamedPipeServerStream(pipeName, PipeDirection.In, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous, 4096, 4096, ps))
            {
                await server.WaitForConnectionAsync(cancelToken);

                using (var reader = new StreamReader(server))
                {
                    return reader.ReadToEndAsync().Result;
                }
            }
        }*/

        internal static async Task<string> ReceiveText(string pipeName, CancellationToken cancellationToken)
        {
            string receivedText;

            PipeSecurity ps = new PipeSecurity();
            System.Security.Principal.SecurityIdentifier sid = new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, null);
            PipeAccessRule par = new PipeAccessRule(sid, PipeAccessRights.ReadWrite, System.Security.AccessControl.AccessControlType.Allow);
            ps.AddAccessRule(par);

            using (var pipeStream = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous, 4096, 4096, ps))
            {
                await pipeStream.WaitForConnectionAsync(cancellationToken);

                using (var streamReader = new StreamReader(pipeStream))
                {
                    receivedText = await streamReader.ReadToEndAsync();
                }
            }

            return receivedText;
        }
    }
}
