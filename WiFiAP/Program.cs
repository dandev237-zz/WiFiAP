using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WiFiAP
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //WifiController wc = new WifiController();
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
