using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace KioskWebService.Interface
{
    [ServiceContract(Name = "KioskWs", Namespace = "urn:ivan_arsic:test:evaluation:Frame2")]
    public interface IKioskService
    {
        [OperationContract]
        void SetKioskMode(string appPath);
        [OperationContract]
        void ResetKioskMode();
        [OperationContract]
        bool GetKioskMode();
    }
}
