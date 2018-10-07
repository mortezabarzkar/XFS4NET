using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.Command
{
    public class OpenCommand : XfsCommand
    {
        public string ServiceName { get; set; }
        public IntPtr Result { get; set; }
        public List<int> AcceptEvents { get; set; }
    }
}
