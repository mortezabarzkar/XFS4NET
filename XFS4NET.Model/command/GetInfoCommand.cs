using XFS4NET.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.Command
{
    public class GetInfoCommand : XfsCommand
    {
        public int CommandCode { get; set; }
        public object Status { get; set; }
        public Type StatusType { get; set; }

        public object StatusModel { get; set; }
        public Type StatusTypeModel { get; set; }

        public IntPtr Result { get; set; }
    }
}
