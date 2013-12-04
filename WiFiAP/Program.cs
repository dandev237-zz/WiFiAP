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
        static string ApplicationName = "WiFiAP";

        [STAThread]
        static void Main()
        {
            // Before start, checks if program has been run as admin

            if (!checkAdmin())
            {
                MessageBox.Show(ApplicationName + " has not been run with admin privileges",
                    "Admin check failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());

                //WifiController wc = new WifiController();
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
            System.Console.WriteLine("funciona");
            string arguments = "wlan stop hostednetwork";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);

            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            System.Console.WriteLine(Process.Start(procStartInfo));
        }
    }
}
