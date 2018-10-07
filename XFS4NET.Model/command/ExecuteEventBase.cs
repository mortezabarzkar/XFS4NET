using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.Command
{
    public class ExecuteEventBase :XfsCommand
    {
        public Datatype Datatype { get; set; }
        public int EventID { get; set; }
        public object EventParam { get; set; }
        public Type EventParamType { get; set; }
        public ExecuteEventBase()
        {
            Datatype = Datatype.Event;
        }
    }
}
