using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockWatcher.UI
{
    internal class GlobalExceptionHandler

    {
        public void Thread_UnhandledException(object sender, ThreadExceptionEventArgs e)
        {
            Do_HandleException(sender, e.Exception, false);
        }

        public void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Do_HandleException(sender, (Exception)e.ExceptionObject, e.IsTerminating);
        }

        public void Do_HandleException(object sender, Exception e, bool isTerminating)
        {
            try
            {
                //Logger.Write(LogLevel.ERROR, e);
            }
            catch (Exception e2)
            {
                try
                {
                    if (!EventLog.SourceExists(e.Source))
                    {
                        EventLog.CreateEventSource(e.Source, "Application");
                    }
                    EventLog.WriteEntry(e.Source, GetExceptionData(e), EventLogEntryType.Error); // Original Exception
                    EventLog.WriteEntry(e2.Source, GetExceptionData(e2), EventLogEntryType.Error); // Why logging failed
                }
                catch
                {
                    // Hmm this is a real problem...
                }
            }
            finally
            {

                DialogResult result = DialogResult.Cancel;
                try
                {
                    result = MessageBox.Show("Failure: " + e.Message, "StockWatcher.UI " + e.Source, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                catch
                {
                    try
                    {
                        MessageBox.Show("Fatal Error", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    finally
                    {
                        DoTerminate();
                    }
                }
                if (isTerminating || result == DialogResult.Abort)
                {
                    DoTerminate();
                }
            }
        }

        private static void DoTerminate()
        {
            //http://www.codeproject.com/Articles/16164/Managed-Application-Shutdown                    

            //Scanner.ScannerService.Close();

            // Prepare cooperative async shutdown from another thread
            Thread t = new Thread(delegate ()
            {
                try
                {
                    //Logger.Write(LogLevel.ERROR, "Terminating");
                }
                finally
                {
                    Environment.Exit(1);
                }
            });

            t.Start();
            t.Join(); // wait until we have exited
        }

        private static string GetExceptionData(Exception e)
        {
            string data = e.Message + "\r\n" + "Target: " + e.TargetSite + "\r\n" + "StackTrace: " + e.StackTrace;
            if (e.InnerException != null)
            {
                data += "\r\n";
                data += GetExceptionData(e.InnerException);
            }
            // TODO: Truncate message to 64k, dump to file?
            return data;
        }


    }
}
