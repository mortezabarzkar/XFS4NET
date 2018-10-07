using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Wrapper.Common
{
    public class XFSEventArgs : EventArgs
    {
        public int RequestID { get; protected set; }
        public int ServiceID { get; protected set; }
        public int CommandCodeOrEventID { get; protected set; }
        public DateTime Timestamp { get; protected set; }
    }
}
