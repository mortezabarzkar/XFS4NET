using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.Common
{
    public interface IXFSDevice
    {
        void Open(string logicName, bool paramAutoRegister = true, string appID = "Citydi XFS", string lowVersion = "3.0", string highVersion = "3.0");
        void Close();
        void Reset();
        //event Action OpenComplete;
        //event Action RegisterComplete;
    }
}
