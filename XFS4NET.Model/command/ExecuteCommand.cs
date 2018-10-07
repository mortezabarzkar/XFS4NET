using XFS4NET.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.Command
{
    public class ExecuteCommand : XfsCommand
    {
        public int CommandCode { get; set; }

        public Type ParamModelType { get; set; }
        public object ParamModel { get; set; }

        public Type PramType { get; set; }
        public object Param { get; set; }
        
        public object ResultModel { get; set; }
        public Type ResultModelType { get; set; }

        public object ResultXfs { get; set; }
        public Type ResultXfsType { get; set; }

        public List<XfSEventBase> Events { get; set; }
        public object EventParam { get; set; }
        public Type EventParamType { get; set; }
        public bool NeedGlobalEvents { get; set; } = false;

        public bool CancelLastCommand { get; set; } = false;

        public List<int> AcceptEvents { get; set; }

        public LightControlCommand LightControlCommand { get; set; }
       
    }
}
