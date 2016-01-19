using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using KioskWebService.Interface;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace KioskWebService
{
    [ServiceBehavior(Namespace = "urn:ivan_arsic:test:evaluation:Frame2")]
    public class KioskService : IKioskService
    {
        [DllImport("FakeDesktop.dll")]
        public static extern void GetScreenResolution(out int x, out int y);
        [DllImport("FakeDesktop.dll")]
        public static extern bool SetScreenResolution(int x, int y);

        [DllImport("FakeDesktop.dll", CharSet = CharSet.Unicode)]
        public static extern void ShowDesktopWindow(string backgroundLocation);

        [DllImport("FakeDesktop.dll")]
        public static extern void KillDesktopWindow();

        private static bool kioskModeSet = false;
        private static int height = 0;
        private static int width = 0;
        public void SetKioskMode(string appPath)
        {
            if (kioskModeSet)
                return;
            try
            {
                GetScreenResolution(out width, out height);
                SetScreenResolution(1024, 768);
                Process.Start("taskkill", string.Format("/F /IM {0}", "explorer.exe"));
                var cancelTokenSource = new CancellationTokenSource();
                var task = Task.Factory.StartNew(DoTask, cancelTokenSource.Token);
                if (!string.IsNullOrEmpty(appPath))
                    Process.Start(appPath);
                kioskModeSet = true;
            }
            catch
            {
                kioskModeSet = false;
            }
            
        }

        public void ResetKioskMode()
        {
            //C:\Windows\explorer.exe
            if (!kioskModeSet)
                return;
            SetScreenResolution(width, height);
            Process.Start(@"C:\Windows\explorer.exe");
            KillDesktopWindow();
            kioskModeSet = false;
        }

        public bool GetKioskMode()
        {
            return kioskModeSet;
        }

        private static void DoTask()
        {
            ShowDesktopWindow(@"C:\Kiosk\background.jpg");
        }
    }
}
