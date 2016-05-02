using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailKuldo;
using System.ServiceModel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace EmailKuldoHost
{
    class Program
    {
        [DllImport("user32.dll")]
        internal static extern bool SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, Int32 lParam);
        static Int32 WM_SYSCOMMAND = 0x0112;
        static Int32 SC_MINIMIZE = 0x0F020;

        static void Main(string[] args)
        {
            SendMessage(Process.GetCurrentProcess().MainWindowHandle, WM_SYSCOMMAND, SC_MINIMIZE, 0);
            using (ServiceHost h = new ServiceHost(typeof(EmailKuldoService)))
            {
                h.Open();
                Console.WriteLine(h.BaseAddresses.First().AbsoluteUri);
                Console.ReadLine();
            }
        }
    }
}
