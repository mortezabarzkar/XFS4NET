using XFS4NET.Wrapper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Wrapper
{
    public class XFSCommandHandler : XFSEventHandler
    {
        public Action<string, int, string> ErrorHandler { get; protected set; }
        public XFSCommandHandler(Action<string, int, string> errorEventHandler, Action completeHandler,
            Action<IntPtr> subRoutine = null, Type paramType = null) : base(completeHandler, subRoutine, paramType)
        {
            ErrorHandler = errorEventHandler;
        }
    }
}
