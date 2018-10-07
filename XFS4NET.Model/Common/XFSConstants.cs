using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.Common
{
    public static class XFSConstants
    {
        public const int STRUCTPACKSIZE = 1;

        /// <summary>
        /// xfs dll name
        /// </summary>
        public const string LIBNAME = "msxfs.dll";

        /// <summary>
        /// charset of xfs function 
        /// </summary>
        public const CharSet CHARSET = CharSet.Ansi;
        /// <summary>
        /// CallingConvention of xfs function
        /// </summary>
        public const CallingConvention CALLINGCONVENTION = CallingConvention.Winapi;
        public const int WFSDDESCRIPTION_LEN = 256;
        public const int WFSDSYSSTATUS_LEN = 256;
        public const int WFS_DEFAULT_HAPP = 0;
        public const int WM_USER = 0x0400;
        public const int WFS_INDEFINITE_WAIT = 0;
    }
}
