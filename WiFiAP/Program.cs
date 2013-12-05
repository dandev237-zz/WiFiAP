using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace WiFiAP
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        // Added global string to refer the name of this application.
        public static string ApplicationName = "WiFiAP";

        [STAThread]
        static void Main()
        {
            // Before start, checks if program has been run as admin

            if (false /*!checkAdmin()*/)
            {
                MessageBox.Show(ApplicationName + " has not been run with admin privileges",
                    "Admin check failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                WifiController wc = new WifiController();
                Application.Run(new Form1());
                
            }      
        }

        static bool checkAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }

    public class WifiController
    {
        public WifiController()
        {
            Console.WriteLine(getStatus());
        }

        /// <summary>
        /// This function calls "netsh wlan" + args through cmd
        /// </summary>
        /// <param name="args">arguments</param>
        /// <returns></returns>
        public String controller(string args)
        {
            string res = "FAIL";

            var pProcess = new System.Diagnostics.Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    Arguments = "/C netsh wlan " + args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = "C:\\"
                }
            };
            pProcess.Start();
            res = pProcess.StandardOutput.ReadToEnd();
            pProcess.Close();

            return res;
        }

        /// <summary>
        /// Starts WiFi AP by using "start hostednetwork"
        /// </summary>
        public String StartAP()
        {
            string res = "FAIL";

            res = controller("start hostednetwork");

            return res;
        }

        /// <summary>
        /// Returns Status using "show hostednetwork"
        /// </summary>
        public String getStatus()
        {
            string res = "UNKNOWN";

            res = controller("show hostednetwork");

            string status = "Estado                 : ";

            int aux = res.IndexOf(status) + status.Length;
            res = res.Substring(aux);
            
            return res;
        }

    }
}
