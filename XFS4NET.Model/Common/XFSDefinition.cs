using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.Common
{
    public static class XFSDefinition
    {
        #region Error codes
        public const int WFS_SUCCESS = 0;
        public const int WFS_ERR_ALREADY_STARTED = -1;
        public const int WFS_ERR_API_VER_TOO_HIGH = -2;
        public const int WFS_ERR_API_VER_TOO_LOW = -3;
        public const int WFS_ERR_CANCELED = -4;
        public const int WFS_ERR_CFG_INVALID_HKEY = -5;
        public const int WFS_ERR_CFG_INVALID_NAME = -6;
        public const int WFS_ERR_CFG_INVALID_SUBKEY = -7;
        public const int WFS_ERR_CFG_INVALID_VALUE = -8;
        public const int WFS_ERR_CFG_KEY_NOT_EMPTY = -9;
        public const int WFS_ERR_CFG_NAME_TOO_LONG = -10;
        public const int WFS_ERR_CFG_NO_MORE_ITEMS = -11;
        public const int WFS_ERR_CFG_VALUE_TOO_LONG = -12;
        public const int WFS_ERR_DEV_NOT_READY = -13;
        public const int WFS_ERR_HARDWARE_ERROR = -14;
        public const int WFS_ERR_INTERNAL_ERROR = -15;
        public const int WFS_ERR_INVALID_ADDRESS = -16;
        public const int WFS_ERR_INVALID_APP_HANDLE = -17;
        public const int WFS_ERR_INVALID_BUFFER = -18;
        public const int WFS_ERR_INVALID_CATEGORY = -19;
        public const int WFS_ERR_INVALID_COMMAND = -20;
        public const int WFS_ERR_INVALID_EVENT_CLASS = -21;
        public const int WFS_ERR_INVALID_HSERVICE = -22;
        public const int WFS_ERR_INVALID_HPROVIDER = -23;
        public const int WFS_ERR_INVALID_HWND = -24;
        public const int WFS_ERR_INVALID_HWNDREG = -25;
        public const int WFS_ERR_INVALID_POINTER = -26;
        public const int WFS_ERR_INVALID_REQ_ID = -27;
        public const int WFS_ERR_INVALID_RESULT = -28;
        public const int WFS_ERR_INVALID_SERVPROV = -29;
        public const int WFS_ERR_INVALID_TIMER = -30;
        public const int WFS_ERR_INVALID_TRACELEVEL = -31;
        public const int WFS_ERR_LOCKED = -32;
        public const int WFS_ERR_NO_BLOCKING_CALL = -33;
        public const int WFS_ERR_NO_SERVPROV = -34;
        public const int WFS_ERR_NO_SUCH_THREAD = -35;
        public const int WFS_ERR_NO_TIMER = -36;
        public const int WFS_ERR_NOT_LOCKED = -37;
        public const int WFS_ERR_NOT_OK_TO_UNLOAD = -38;
        public const int WFS_ERR_NOT_STARTED = -39;
        public const int WFS_ERR_NOT_REGISTERED = -40;
        public const int WFS_ERR_OP_IN_PROGRESS = -41;
        public const int WFS_ERR_OUT_OF_MEMORY = -42;
        public const int WFS_ERR_SERVICE_NOT_FOUND = -43;
        public const int WFS_ERR_SPI_VER_TOO_HIGH = -44;
        public const int WFS_ERR_SPI_VER_TOO_LOW = -45;
        public const int WFS_ERR_SRVC_VER_TOO_HIGH = -46;
        public const int WFS_ERR_SRVC_VER_TOO_LOW = -47;
        public const int WFS_ERR_TIMEOUT = -48;
        public const int WFS_ERR_UNSUPP_CATEGORY = -49;
        public const int WFS_ERR_UNSUPP_COMMAND = -50;
        public const int WFS_ERR_VERSION_ERROR_IN_SRVC = -51;
        public const int WFS_ERR_INVALID_DATA = -52;
        public const int WFS_ERR_SOFTWARE_ERROR = -53;
        public const int WFS_ERR_CONNECTION_LOST = -54;
        public const int WFS_ERR_USER_ERROR = -55;
        public const int WFS_ERR_UNSUPP_DATA = -56;
        public const int WFS_ERR_FRAUD_ATTEMPT = -57;
        public const int WFS_ERR_SEQUENCE_ERROR = -58;
        #endregion
        public const int WFS_INDEFINITE_WAIT = 0;
        #region Message-No
        public const int WFS_OPEN_COMPLETE = XFSConstants.WM_USER + 1;
        public const int WFS_CLOSE_COMPLETE = XFSConstants.WM_USER + 2;
        public const int WFS_LOCK_COMPLETE = XFSConstants.WM_USER + 3;
        public const int WFS_UNLOCK_COMPLETE = XFSConstants.WM_USER + 4;
        public const int WFS_REGISTER_COMPLETE = XFSConstants.WM_USER + 5;
        public const int WFS_DEREGISTER_COMPLETE = XFSConstants.WM_USER + 6;
        public const int WFS_GETINFO_COMPLETE = XFSConstants.WM_USER + 7;
        public const int WFS_EXECUTE_COMPLETE = XFSConstants.WM_USER + 8;
        public const int WFS_EXECUTE_EVENT = XFSConstants.WM_USER + 20;
        public const int WFS_SERVICE_EVENT = XFSConstants.WM_USER + 21;
        public const int WFS_USER_EVENT = XFSConstants.WM_USER + 22;
        public const int WFS_SYSTEM_EVENT = XFSConstants.WM_USER + 23;
        public const int WFS_TIMER_EVENT = XFSConstants.WM_USER + 100;
        #endregion
        #region Event Classes
        public const int SERVICE_EVENTS = 1;
        public const int USER_EVENTS = 2;
        public const int SYSTEM_EVENTS = 4;
        public const int EXECUTE_EVENTS = 8;
        #endregion
        #region System Event IDs
        public const int WFS_SYSE_UNDELIVERABLE_MSG = 1;
        public const int WFS_SYSE_HARDWARE_ERROR = 2;
        public const int WFS_SYSE_VERSION_ERROR = 3;
        public const int WFS_SYSE_DEVICE_STATUS = 4;
        public const int WFS_SYSE_APP_DISCONNECT = 5;
        public const int WFS_SYSE_SOFTWARE_ERROR = 6;
        public const int WFS_SYSE_USER_ERROR = 7;
        public const int WFS_SYSE_LOCK_REQUESTED = 8;
        public const int WFS_SYSE_FRAUD_ATTEMPT = 9;
        #endregion
        #region XFS Trace Level 
        public const int WFS_TRACE_API = 0x00000001;
        public const int WFS_TRACE_ALL_API = 0x00000002;
        public const int WFS_TRACE_SPI = 0x00000004;
        public const int WFS_TRACE_ALL_SPI = 0x00000008;
        public const int WFS_TRACE_MGR = 0x00000010;
        #endregion
        #region XFS Error Actions 
        public const int WFS_ERR_ACT_NOACTION = 0x0000;
        public const int WFS_ERR_ACT_RESET = 0x0001;
        public const int WFS_ERR_ACT_SWERROR = 0x0002;
        public const int WFS_ERR_ACT_CONFIG = 0x0004;
        public const int WFS_ERR_ACT_HWCLEAR = 0x0008;
        public const int WFS_ERR_ACT_HWMAINT = 0x0010;
        public const int WFS_ERR_ACT_SUSPEND = 0x0020;
        #endregion

    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct SYSTEMTIME
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSRESULT
    {
        public int RequestID;
        public ushort hService;
        public SYSTEMTIME tsTimestamp;
        public int hResult;
        public int dwCommandCodeOrEventID;
        public IntPtr lpBuffer;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public unsafe struct WFSVERSION
    {
        public ushort wVersion;
        public ushort wLowVersion;
        public ushort wHighVersion;
        public fixed char szDescription[XFSConstants.WFSDDESCRIPTION_LEN + 1];
        public fixed char szSystemStatus[XFSConstants.WFSDSYSSTATUS_LEN + 1];

    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSDEVSTATUS
    {
        public string lpszPhysicalName;
        public string lpszWorkstationName;
        public uint dwState;

    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSUNDEVMSG
    {
        public string lpszLogicalName;
        public string lpszWorkstationName;
        public string lpszAppID;
        public uint dwSize;
        public IntPtr lpbDescription;
        public uint dwMsg;
        public IntPtr lpWFSResult;

    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSAPPDISC
    {
        public string lpszLogicalName;
        public string lpszWorkstationName;
        public string lpszAppID;

    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSHWERROR
    {
        public string lpszLogicalName;
        public string lpszPhysicalName;
        public string lpszWorkstationName;
        public string lpszAppID;
        public uint dwAction;
        public uint dwSize;
        public IntPtr lpbDescription;

    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSVRSNERROR
    {
        public string lpszLogicalName;
        public string lpszWorkstationName;
        public string lpszAppID;
        public uint dwSize;
        public IntPtr lpbDescription;
        public IntPtr lpWFSVersion;

    }
}
