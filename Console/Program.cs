using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using KioskWebService;

namespace ConsoleService
{
    internal static class Program
    {
        static ServiceHost KioskWs;

        private static void Main()
        {
            try
            {
                OpenHost();

                DisplayInfo();

                var run = true;
                do
                {
                    var input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input))
                        continue;

                    switch (Char.ToLower(input[0]))
                    {
                        case 'y':
                        case 'q':
                            run = false;
                            break;
                    }

                    Thread.Sleep(10);
                } while (run);

            }
            catch (Exception ex)
            {
                var msgText = "Unhandled fatal application exception occured.";
                Console.WriteLine(msgText);
                throw new ApplicationException(msgText, ex);
            }
            finally
            {
                CloseHosts();
            }
        }

        static void DisplayInfo()
        {
            Console.WriteLine(new String('-', 40) + "\r\nKiosk Service (console mode) ready.\r\n");
            Console.WriteLine("Available options:\r\n q - quit\r\n");
            Console.WriteLine(new String('-', 40) + "\r\n");
        }

        private static void OpenHost()
        {
            KioskWs = new ServiceHost(typeof(KioskService));
            KioskWs.Open();
            Console.WriteLine("\"Kiosk\" web service is started");
        }

        static void CloseHosts()
        {
            if (KioskWs != null)
                KioskWs.Close();
        }
    }
}
