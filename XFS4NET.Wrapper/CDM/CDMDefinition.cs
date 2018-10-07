using XFS4NET.Wrapper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XFS4NET.Wrapper.CDM
{
    public static class CDMDefinition
    {
        public const int WFS_SERVICE_CLASS_CDM = 3;
        public const int WFS_SERVICE_CLASS_VERSION_CDM = 0x1403;
        public const string WFS_SERVICE_CLASS_NAME_CDM = "CDM";
        public const int CDM_SERVICE_OFFSET = WFS_SERVICE_CLASS_CDM * 100;
        #region CDM Info Commands
        public const int WFS_INF_CDM_STATUS = CDM_SERVICE_OFFSET + 1;
        public const int WFS_INF_CDM_CAPABILITIES = CDM_SERVICE_OFFSET + 2;
        public const int WFS_INF_CDM_CASH_UNIT_INFO = CDM_SERVICE_OFFSET + 3;
        public const int WFS_INF_CDM_TELLER_INFO = CDM_SERVICE_OFFSET + 4;
        public const int WFS_INF_CDM_CURRENCY_EXP = CDM_SERVICE_OFFSET + 6;
        public const int WFS_INF_CDM_MIX_TYPES = CDM_SERVICE_OFFSET + 7;
        public const int WFS_INF_CDM_MIX_TABLE = CDM_SERVICE_OFFSET + 8;
        public const int WFS_INF_CDM_PRESENT_STATUS = CDM_SERVICE_OFFSET + 9;
        #endregion
        #region CDM Execute Commands
        public const int WFS_CMD_CDM_DENOMINATE = CDM_SERVICE_OFFSET + 1;
        public const int WFS_CMD_CDM_DISPENSE = CDM_SERVICE_OFFSET + 2;
        public const int WFS_CMD_CDM_PRESENT = CDM_SERVICE_OFFSET + 3;
        public const int WFS_CMD_CDM_REJECT = CDM_SERVICE_OFFSET + 4;
        public const int WFS_CMD_CDM_RETRACT = CDM_SERVICE_OFFSET + 5;
        public const int WFS_CMD_CDM_OPEN_SHUTTER = CDM_SERVICE_OFFSET + 7;
        public const int WFS_CMD_CDM_CLOSE_SHUTTER = CDM_SERVICE_OFFSET + 8;
        public const int WFS_CMD_CDM_SET_TELLER_INFO = CDM_SERVICE_OFFSET + 9;
        public const int WFS_CMD_CDM_SET_CASH_UNIT_INFO = CDM_SERVICE_OFFSET + 10;
        public const int WFS_CMD_CDM_START_EXCHANGE = CDM_SERVICE_OFFSET + 11;
        public const int WFS_CMD_CDM_END_EXCHANGE = CDM_SERVICE_OFFSET + 12;
        public const int WFS_CMD_CDM_OPEN_SAFE_DOOR = CDM_SERVICE_OFFSET + 13;
        public const int WFS_CMD_CDM_CALIBRATE_CASH_UNIT = CDM_SERVICE_OFFSET + 15;
        public const int WFS_CMD_CDM_SET_MIX_TABLE = CDM_SERVICE_OFFSET + 20;
        public const int WFS_CMD_CDM_RESET = CDM_SERVICE_OFFSET + 21;
        public const int WFS_CMD_CDM_TEST_CASH_UNITS = CDM_SERVICE_OFFSET + 22;
        public const int WFS_CMD_CDM_COUNT = CDM_SERVICE_OFFSET + 23;
        public const int WFS_CMD_CDM_SET_GUIDANCE_LIGHT = CDM_SERVICE_OFFSET + 24;
        public const int WFS_CMD_CDM_POWER_SAVE_CONTROL = CDM_SERVICE_OFFSET + 25;
        public const int WFS_CMD_CDM_PREPARE_DISPENSE = CDM_SERVICE_OFFSET + 26;
        #endregion
        #region CDM Messages
        public const int WFS_SRVE_CDM_SAFEDOOROPEN = CDM_SERVICE_OFFSET + 1;
        public const int WFS_SRVE_CDM_SAFEDOORCLOSED = CDM_SERVICE_OFFSET + 2;
        public const int WFS_USRE_CDM_CASHUNITTHRESHOLD = CDM_SERVICE_OFFSET + 3;
        public const int WFS_SRVE_CDM_CASHUNITINFOCHANGED = CDM_SERVICE_OFFSET + 4;
        public const int WFS_SRVE_CDM_TELLERINFOCHANGED = CDM_SERVICE_OFFSET + 5;
        public const int WFS_EXEE_CDM_DELAYEDDISPENSE = CDM_SERVICE_OFFSET + 6;
        public const int WFS_EXEE_CDM_STARTDISPENSE = CDM_SERVICE_OFFSET + 7;
        public const int WFS_EXEE_CDM_CASHUNITERROR = CDM_SERVICE_OFFSET + 8;
        public const int WFS_SRVE_CDM_ITEMSTAKEN = CDM_SERVICE_OFFSET + 9;
        public const int WFS_EXEE_CDM_PARTIALDISPENSE = CDM_SERVICE_OFFSET + 10;
        public const int WFS_EXEE_CDM_SUBDISPENSEOK = CDM_SERVICE_OFFSET + 11;
        public const int WFS_SRVE_CDM_ITEMSPRESENTED = CDM_SERVICE_OFFSET + 13;
        public const int WFS_SRVE_CDM_COUNTS_CHANGED = CDM_SERVICE_OFFSET + 14;
        public const int WFS_EXEE_CDM_INCOMPLETEDISPENSE = CDM_SERVICE_OFFSET + 15;
        public const int WFS_EXEE_CDM_NOTEERROR = CDM_SERVICE_OFFSET + 16;
        public const int WFS_SRVE_CDM_MEDIADETECTED = CDM_SERVICE_OFFSET + 17;
        public const int WFS_EXEE_CDM_INPUT_P6 = CDM_SERVICE_OFFSET + 18;
        public const int WFS_SRVE_CDM_DEVICEPOSITION = CDM_SERVICE_OFFSET + 19;
        public const int WFS_SRVE_CDM_POWER_SAVE_CHANGE = CDM_SERVICE_OFFSET + 20;
        #endregion
        public const int WFS_CDM_INDIVIDUAL = 0;
        public const int WFS_CDM_MIX_MINIMUM_NUMBER_OF_BILLS = 1;
        public const int WFS_CDM_MIX_EQUAL_EMPTYING_OF_CASH_UNITS = 2;
        public const int WFS_CDM_MIX_MAXIMUM_NUMBER_OF_CASH_UNITS = 3;

    }
    [Flags]
    public enum OutputPosition : ushort
    {
        WFS_CDM_POSNULL = 0x0000,
        WFS_CDM_POSLEFT = 0x0001,
        WFS_CDM_POSRIGHT = 0x0002,
        WFS_CDM_POSCENTER = 0x0004,
        WFS_CDM_POSTOP = 0x0040,
        WFS_CDM_POSBOTTOM = 0x0080,
        WFS_CDM_POSFRONT = 0x0800,
        WFS_CDM_POSREAR = 0x1000
    }
    public enum CDMSafeDoor : ushort
    {
        WFS_CDM_DOORNOTSUPPORTED = (1),
        WFS_CDM_DOOROPEN = (2),
        WFS_CDM_DOORCLOSED = (3),
        WFS_CDM_DOORUNKNOWN = (5)
    }
    public enum CDMDispenser : ushort
    {
        WFS_CDM_DISPOK = (0),
        WFS_CDM_DISPCUSTATE = (1),
        WFS_CDM_DISPCUSTOP = (2),
        WFS_CDM_DISPCUUNKNOWN = (3)
    }
    public enum CDMIntermediateStacker : ushort
    {
        WFS_CDM_ISEMPTY = 0,
        WFS_CDM_ISNOTEMPTY = 1,
        WFS_CDM_ISNOTEMPTYCUST = 2,
        WFS_CDM_ISNOTEMPTYUNK = 3,
        WFS_CDM_ISUNKNOWN = 4,
        WFS_CDM_ISNOTSUPPORTED = 5
    }
    public enum CDMPositionStatus : ushort
    {
        WFS_CDM_DEVICEINPOSITION = 0,
        WFS_CDM_DEVICENOTINPOSITION = 1,
        WFS_CDM_DEVICEPOSUNKNOWN = 2,
        WFS_CDM_DEVICEPOSNOTSUPP = 3
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMDENOMINATION
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] cCurrencyID;
        public int ulAmount;
        public ushort usCount;
        public IntPtr lpulValues;
        public int ulCashBox;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMDISPENSE
    {
        public ushort usTellerID;
        public ushort usMixNumber;
        public OutputPosition fwPosition;
        public bool bPresent;
        public IntPtr lpDenomination;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMOUTPOS
    {
        public ushort fwPosition;
        public ushort fwShutter;
        public ushort fwPositionStatus;
        public ushort fwTransport;
        public ushort fwTransportStatus;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMSTATUS
    {
        public DEVSTATUS fwDevice;
        public CDMSafeDoor fwSafeDoor;
        public CDMDispenser fwDispenser;
        public CDMIntermediateStacker fwIntermediateStacker;
        public string lpszExtra;
        public CDMPositionStatus wDevicePosition;
        public ushort usPowerSaveRecoveryTime;
        public AntiFraudModule wAntiFraudModule;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMCAPS
    {
        public ushort wClass;
        public ushort fwType;
        public ushort wMaxDispenseItems;
        public bool bCompound;
        public bool bShutter;
        public bool bShutterControl;
        public ushort fwRetractAreas;
        public ushort fwRetractTransportActions;
        public ushort fwRetractStackerActions;
        public bool bSafeDoor;
        public bool bCashBox;
        public bool bIntermediateStacker;
        public bool bItemsTakenSensor;
        public ushort fwPositions;
        public ushort fwMoveItems;
        public ushort fwExchangeType;
        public string lpszExtra;
        public bool bPowerSaveControl;
        public bool bPrepareDispense;
        public bool bAntiFraudModule;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMPHCU
    {
        public string lpPhysicalPositionName;
        public uint ulInitialCount;
        public uint ulCount;
        public uint ulRejectCount;
        public uint ulMaximum;
        public ushort usPStatus;
        public bool bHardwareSensor;
        public uint ulDispensedCount;
        public uint ulPresentedCount;
        public uint ulRetractedCount;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMCASHUNIT
    {
        public ushort usNumber;
        public ushort usType;
        public string lpszCashUnitName;
        public uint ulValues;
        public uint ulInitialCount;
        public uint ulCount;
        public uint ulRejectCount;
        public uint ulMinimum;
        public uint ulMaximum;
        public bool bAppLock;
        public ushort usStatus;
        public ushort usNumPhysicalCUs;
        public uint ulDispensedCount;
        public uint ulPresentedCount;
        public uint ulRetractedCount;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMCUINFO
    {
        public ushort usTellerID;
        public ushort usCount;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMTELLERINFO
    {
        public ushort usTellerID;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMTELLERTOTALS
    {
        public uint ulItemsReceived;
        public uint ulItemsDispensed;
        public uint ulCoinsReceived;
        public uint ulCoinsDispensed;
        public uint ulCashBoxReceived;
        public uint ulCashBoxDispensed;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMTELLERDETAILS
    {
        public ushort usTellerID;
        public uint ulInputPosition;
        public ushort fwOutputPosition;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMCURRENCYEXP
    {
        public short sExponent;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMMIXTYPE
    {
        public ushort usMixNumber;
        public ushort usMixType;
        public ushort usSubType;
        public string lpszName;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public unsafe struct WFSCDMMIXROW
    {
        public uint ulAmount;
        public ushort* lpusMixture;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public unsafe struct WFSCDMMIXTABLE
    {
        public ushort usMixNumber;
        public string lpszName;
        public ushort usRows;
        public ushort usCols;
        public int* lpulMixHeader;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMPRESENTSTATUS
    {
        public IntPtr lpDenomination;
        public ushort wPresentState;
        public string lpszExtra;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMDENOMINATE
    {
        public ushort usTellerID;
        public ushort usMixNumber;
        public IntPtr lpDenomination;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMPHYSICALCU
    {
        public bool bEmptyAll;
        public ushort fwPosition;
        public string lpPhysicalPositionName;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMCOUNTEDPHYSCU
    {
        public string lpPhysicalPositionName;
        public uint ulDispensed;
        public uint ulCounted;
        public ushort usPStatus;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMCOUNT
    {
        public ushort usNumPhysicalCUs;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMRETRACT
    {
        public ushort fwOutputPosition;
        public ushort usRetractArea;
        public ushort usIndex;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMITEMNUMBER
    {
        public uint ulValues;
        public ushort usRelease;
        public uint ulCount;
        public ushort usNumber;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMITEMNUMBERLIST
    {
        public ushort usNumOfItemNumbers;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMTELLERUPDATE
    {
        public ushort usAction;
        public IntPtr lpTellerDetails;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public unsafe struct WFSCDMSTARTEX
    {
        public ushort fwExchangeType;
        public ushort usTellerID;
        public ushort usCount;
        public ushort* lpusCUNumList;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMITEMPOSITION
    {
        public ushort usNumber;
        public IntPtr lpRetractArea;
        public ushort fwOutputPosition;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMCALIBRATE
    {
        public ushort usNumber;
        public ushort usNumOfBills;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMSETGUIDLIGHT
    {
        public ushort wGuidLight;
        public int dwCommand;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMPOWERSAVECONTROL
    {
        public ushort usMaxPowerSaveRecoveryTime;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMPREPAREDISPENSE
    {
        public ushort wAction;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMCUERROR
    {
        public ushort wFailure;
        public IntPtr lpCashUnit;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public unsafe struct WFSCDMCOUNTSCHANGED
    {
        public ushort usCount;
        public ushort* lpusCUNumList;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMDEVICEPOSITION
    {
        public ushort wPosition;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMPOWERSAVECHANGE
    {
        public ushort usPowerSaveRecoveryTime;
    }

}
