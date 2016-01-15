using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using KioskWebService;

namespace WinService
{
    public partial class WindowsService : ServiceBase
    {
        static ServiceHost KioskWs;

        public WindowsService()
        {
            InitializeComponent();
            ServiceName = "KioskWindowsService";
        }

        protected override void OnStart(string[] args)
        {
            OpenHost();
        }

        protected override void OnStop()
        {
            CloseHost();
        }

        private static void OpenHost()
        {
            KioskWs = new ServiceHost(typeof(KioskService));
            KioskWs.Open();
        }

        private static void CloseHost()
        {
            if (KioskWs != null)
                KioskWs.Close();
        }
    }
}
