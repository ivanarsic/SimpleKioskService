using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using KioskWebService.Interface;

namespace KioskWebService
{
    [ServiceBehavior(Namespace = "urn:ivan_arsic:test:evaluation:Frame2")]
    public class KioskService : IKioskService
    {
        public void SetKioskMode(string appPath)
        {
            //TODO
        }

        public void ResetKioskMode()
        {
            //TODO
        }

        public bool GetKioskMode()
        {
            return true;
        }
    }
}
