using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.Command
{
    public class LightControlCommand
    {
        public ushort ExecuteSIU { get; set; }
        public ushort CompleteSIU { get; set; }
        public ushort ErrorSIU { get; set; }
    }
}
