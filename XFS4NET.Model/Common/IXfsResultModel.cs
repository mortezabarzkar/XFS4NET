using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.Common
{
    public interface IXfsResultModel
    {
        void Fill(object result);
        //void Fill(IntPtr result);
    }
}
