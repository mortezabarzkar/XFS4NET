using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Wrapper.Common
{
    public static class XfsApi
    {
        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSCancelAsyncRequest(ushort hService, int RequestID);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSCancelBlockingCall(int dwThreadID);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSCleanUp();

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSClose(ushort hService);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSAsyncClose(ushort hService, IntPtr hWnd, ref int lpRequestID);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSCreateAppHandle(ref IntPtr lphApp);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSDeregister(ushort hService, int dwEventClass, IntPtr hWndReg);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSAsyncDeregister(ushort hService, int dwEventClass, IntPtr hWndReg, IntPtr hWnd, ref int lpRequestID);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSDestroyAppHandle(IntPtr hApp);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSExecute(ushort hService, int dwCommand, IntPtr lpCmdData, int dwTimeOut, ref IntPtr lppResult);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSAsyncExecute(ushort hService, int dwCommand, IntPtr lpCmdData, int dwTimeOut, IntPtr hWnd,
            ref int lpRequestID);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSFreeResult(ref WFSRESULT lpResult);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSFreeResult(IntPtr ptr);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSGetInfo(ushort hService, int dwCategory, IntPtr lpQueryDetails, int dwTimeOut, ref IntPtr lppResult);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSAsyncGetInfo(ushort hService, int dwCategory, IntPtr lpQueryDetails, int dwTimeOut, IntPtr hWnd,
            ref int lpRequestID);
        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern bool WFSIsBlocking();

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSLock(ushort hService, int dwTimeOut, ref IntPtr lppResult);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSAsyncLock(ushort hService, int dwTimeOut, IntPtr hWnd, ref int lpRequestID);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSOpen(string lpszLogicalName, IntPtr hApp, string lpszAppID, int dwTraceLevel, int dwTimeOut,
            int dwSrvcVersionsRequired, ref WFSVERSION lpSrvcVersion, ref WFSVERSION lpSPIVersion, ref ushort lphService);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSAsyncOpen(string lpszLogicalName, IntPtr hApp, string lpszAppID, int dwTraceLevel, int dwTimeOut,
            ref ushort lphService, IntPtr hWnd, int dwSrvcVersionsRequired, ref WFSVERSION lpSrvcVersion, ref WFSVERSION lpSPIVersion,
            ref int lpRequestID);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSRegister(ushort hService, int dwEventClass, IntPtr hWndReg);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSAsyncRegister(ushort hService, int dwEventClass, IntPtr hWndReg, IntPtr hWnd, ref int lpRequestID);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSSetBlockingHook(Action<IntPtr> lpBlockFunc, Action<IntPtr> lppPrevFunc);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSStartUp(int dwVersionsRequired, ref WFSVERSION lpWFSVersion);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSUnhookBlockingHook();

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSUnlock(ushort hService);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFSAsyncUnlock(ushort hService, IntPtr hWnd, ref int lpRequestID);

        [DllImport(XFSConstants.LIBNAME, CharSet = XFSConstants.CHARSET, CallingConvention = XFSConstants.CALLINGCONVENTION)]
        public static extern int WFMSetTraceLevel(ushort hService, int dwTraceLevel);
    }
}
