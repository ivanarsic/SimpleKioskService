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
            throw new NotImplementedException();
        }

        public void ResetKioskMode()
        {
            throw new NotImplementedException();
        }

        public bool GetKioskMode()
        {
            throw new NotImplementedException();
        }
    }
}
