using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Wrapper
{
    public class XFS_DevicesCollection
    {
        public IDC.IDC IDC;
        public PIN.PIN PIN;
        public PTR.PTR PTR;
        public SIU.SIU SIU;

        public bool IsStartup
        {
            get
            {
                return _IsStartup;
            }
            set
            {
                _IsStartup = value;
            }
        }
        private bool _IsStartup = false;

        private static XFS_DevicesCollection _instance;
        public static XFS_DevicesCollection Instance
        {
            get
            {
               
                if (_instance == null)
                {
                    _instance = new XFS_DevicesCollection();
                    
                }
                return _instance;
            }
        }

        public void Init()
        {
            //IDC.Startup();
        }
        public XFS_DevicesCollection()
        {
            L4Logger.Info("ctor XFS_DevicesCollection");
            IDC = new IDC.IDC();
            PIN = new PIN.PIN();
            PTR = new PTR.PTR();
            SIU = new SIU.SIU();
        }
    }
}
