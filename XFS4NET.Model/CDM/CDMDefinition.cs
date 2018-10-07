namespace XFS4NET.Model.CDM
{
    using XFS4NET.Model.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

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

        #region Others
        public const int WFS_CDM_GUIDLIGHTS_SIZE = 32;
        public const int WFS_CDM_INDIVIDUAL = 0;
        public const int WFS_CDM_MIX_MINIMUM_NUMBER_OF_BILLS = 1;
        public const int WFS_CDM_MIX_EQUAL_EMPTYING_OF_CASH_UNITS = 2;
        public const int WFS_CDM_MIX_MAXIMUM_NUMBER_OF_CASH_UNITS = 3;

        public const int WFS_STAT_DEVONLINE = 0;
        public const int WFS_STAT_DEVOFFLINE = 1;
        public const int WFS_STAT_DEVPOWEROFF = 2;
        public const int WFS_STAT_DEVNODEVICE = 3;
        public const int WFS_STAT_DEVHWERROR = 4;
        public const int WFS_STAT_DEVUSERERROR = 5;
        public const int WFS_STAT_DEVBUSY = 6;
        public const int WFS_STAT_DEVFRAUDATTEMPT = 7;

        /* values of WFSCDMSTATUS.fwDevice */
        public const int WFS_CDM_DEVONLINE = WFS_STAT_DEVONLINE;
        public const int WFS_CDM_DEVOFFLINE = WFS_STAT_DEVOFFLINE;
        public const int WFS_CDM_DEVPOWEROFF = WFS_STAT_DEVPOWEROFF;
        public const int WFS_CDM_DEVNODEVICE = WFS_STAT_DEVNODEVICE;
        public const int WFS_CDM_DEVHWERROR = WFS_STAT_DEVHWERROR;
        public const int WFS_CDM_DEVUSERERROR = WFS_STAT_DEVUSERERROR;
        public const int WFS_CDM_DEVBUSY = WFS_STAT_DEVBUSY;
        public const int WFS_CDM_DEVFRAUDATTEMPT = WFS_STAT_DEVFRAUDATTEMPT;

        /* values of WFSCDMSTATUS.fwSafeDoor */

        public const int WFS_CDM_DOORNOTSUPPORTED = 1;
        public const int WFS_CDM_DOOROPEN = 2;
        public const int WFS_CDM_DOORCLOSED = 3;
        public const int WFS_CDM_DOORUNKNOWN = 5;

        /* values of WFSCDMSTATUS.fwDispenser */

        public const int WFS_CDM_DISPOK = 0;
        public const int WFS_CDM_DISPCUSTATE = 1;
        public const int WFS_CDM_DISPCUSTOP = 2;
        public const int WFS_CDM_DISPCUUNKNOWN = 3;

        /* values of WFSCDMSTATUS.fwIntermediateStacker */

        public const int WFS_CDM_ISEMPTY = 0;
        public const int WFS_CDM_ISNOTEMPTY = 1;
        public const int WFS_CDM_ISNOTEMPTYCUST = 2;
        public const int WFS_CDM_ISNOTEMPTYUNK = 3;
        public const int WFS_CDM_ISUNKNOWN = 4;
        public const int WFS_CDM_ISNOTSUPPORTED = 5;

        /* Size and max index of dwGuidLights array */

        //public const int WFS_CDM_GUIDLIGHTS_SIZE = 32;
        public const int WFS_CDM_GUIDLIGHTS_MAX = WFS_CDM_GUIDLIGHTS_SIZE - 1;

        /* Indices of WFSCDMSTATUS.dwGuidLights [...]
                      WFSCDMCAPS.dwGuidLights [...]
        */

        public const int WFS_CDM_GUIDANCE_POSOUTNULL = 0;
        public const int WFS_CDM_GUIDANCE_POSOUTLEFT = 1;
        public const int WFS_CDM_GUIDANCE_POSOUTRIGHT = 2;
        public const int WFS_CDM_GUIDANCE_POSOUTCENTER = 3;
        public const int WFS_CDM_GUIDANCE_POSOUTTOP = 4;
        public const int WFS_CDM_GUIDANCE_POSOUTBOTTOM = 5;
        public const int WFS_CDM_GUIDANCE_POSOUTFRONT = 6;
        public const int WFS_CDM_GUIDANCE_POSOUTREAR = 7;

        /* Values of WFSCDMSTATUS.dwGuidLights [...]
                     WFSCDMCAPS.dwGuidLights [...]
        */
        public const int WFS_CDM_GUIDANCE_OFF = 0x00000001;
        public const int WFS_CDM_GUIDANCE_SLOW_FLASH = 0x00000004;
        public const int WFS_CDM_GUIDANCE_MEDIUM_FLASH = 0x00000008;
        public const int WFS_CDM_GUIDANCE_QUICK_FLASH = 0x00000010;
        public const int WFS_CDM_GUIDANCE_CONTINUOUS = 0x00000080;
        public const int WFS_CDM_GUIDANCE_RED = 0x00000100;
        public const int WFS_CDM_GUIDANCE_GREEN = 0x00000200;
        public const int WFS_CDM_GUIDANCE_YELLOW = 0x00000400;
        public const int WFS_CDM_GUIDANCE_BLUE = 0x00000800;
        public const int WFS_CDM_GUIDANCE_CYAN = 0x00001000;
        public const int WFS_CDM_GUIDANCE_MAGENTA = 0x00002000;
        public const int WFS_CDM_GUIDANCE_WHITE = 0x00004000;

        /* Values of WFSCDMSTATUS.dwGuidLights [...]
                     WFSCDMCAPS.dwGuidLights [...]
        */
        public const int WFS_CDM_GUIDANCE_NOT_AVAILABLE = 0x0000;

        /* values of WFSCDMSTATUS.fwDevicePosition
                     WFSCDMDEVICEPOSITION.wPosition */

        public const int WFS_CDM_DEVICEINPOSITION = 0;
        public const int WFS_CDM_DEVICENOTINPOSITION = 1;
        public const int WFS_CDM_DEVICEPOSUNKNOWN = 2;
        public const int WFS_CDM_DEVICEPOSNOTSUPP = 3;


        /* values of WFSCDMOUTPOS.fwShutter */

        public const int WFS_CDM_SHTCLOSED = 0;
        public const int WFS_CDM_SHTOPEN = 1;
        public const int WFS_CDM_SHTJAMMED = 2;
        public const int WFS_CDM_SHTUNKNOWN = 3;
        public const int WFS_CDM_SHTNOTSUPPORTED = 4;

        /* values of WFSCDMOUTPOS.fwPositionStatus */

        public const int WFS_CDM_PSEMPTY = 0;
        public const int WFS_CDM_PSNOTEMPTY = 1;
        public const int WFS_CDM_PSUNKNOWN = 2;
        public const int WFS_CDM_PSNOTSUPPORTED = 3;

        /* values of WFSCDMOUTPOS.fwTransport */

        public const int WFS_CDM_TPOK = 0;
        public const int WFS_CDM_TPINOP = 1;
        public const int WFS_CDM_TPUNKNOWN = 2;
        public const int WFS_CDM_TPNOTSUPPORTED = 3;

        /* values of WFSCDMOUTPOS.fwTransportStatus */

        public const int WFS_CDM_TPSTATEMPTY = 0;
        public const int WFS_CDM_TPSTATNOTEMPTY = 1;
        public const int WFS_CDM_TPSTATNOTEMPTYCUST = 2;
        public const int WFS_CDM_TPSTATNOTEMPTY_UNK = 3;
        public const int WFS_CDM_TPSTATNOTSUPPORTED = 4;


        /* values of WFSCDMCAPS.fwType */

        public const int WFS_CDM_TELLERBILL = 0;
        public const int WFS_CDM_SELFSERVICEBILL = 1;
        public const int WFS_CDM_TELLERCOIN = 2;
        public const int WFS_CDM_SELFSERVICECOIN = 3;

        /* values of WFSCDMCAPS.fwRetractAreas */
        /* values of WFSCDMRETRACT.usRetractArea */

        public const int WFS_CDM_RA_RETRACT = 0x0001;
        public const int WFS_CDM_RA_TRANSPORT = 0x0002;
        public const int WFS_CDM_RA_STACKER = 0x0004;
        public const int WFS_CDM_RA_REJECT = 0x0008;
        public const int WFS_CDM_RA_NOTSUPP = 0x0010;
        public const int WFS_CDM_RA_ITEMCASSETTE = 0x0020;

        /* values of WFSCDMCAPS.fwRetractTransportActions */
        /* values of WFSCDMCAPS.fwRetractStackerActions */

        public const int WFS_CDM_PRESENT = 0x0001;
        public const int WFS_CDM_RETRACT = 0x0002;
        public const int WFS_CDM_REJECT = 0x0004;
        public const int WFS_CDM_NOTSUPP = 0x0008;
        public const int WFS_CDM_ITEMCASSETTE = 0x0010;

        /* values of WFSCDMCAPS.fwMoveItems */

        public const int WFS_CDM_FROMCU = 0x0001;
        public const int WFS_CDM_TOCU = 0x0002;
        public const int WFS_CDM_TOTRANSPORT = 0x0004;

        /* values of WFSCDMCASHUNIT.usType */

        public const int WFS_CDM_TYPENA = 1;
        public const int WFS_CDM_TYPEREJECTCASSETTE = 2;
        public const int WFS_CDM_TYPEBILLCASSETTE = 3;
        public const int WFS_CDM_TYPECOINCYLINDER = 4;
        public const int WFS_CDM_TYPECOINDISPENSER = 5;
        public const int WFS_CDM_TYPERETRACTCASSETTE = 6;
        public const int WFS_CDM_TYPECOUPON = 7;
        public const int WFS_CDM_TYPEDOCUMENT = 8;
        public const int WFS_CDM_TYPEREPCONTAINER = 11;
        public const int WFS_CDM_TYPERECYCLING = 12;

        /* values of WFSCDMCASHUNIT.usStatus */

        public const int WFS_CDM_STATCUOK = 0;
        public const int WFS_CDM_STATCUFULL = 1;
        public const int WFS_CDM_STATCUHIGH = 2;
        public const int WFS_CDM_STATCULOW = 3;
        public const int WFS_CDM_STATCUEMPTY = 4;
        public const int WFS_CDM_STATCUINOP = 5;
        public const int WFS_CDM_STATCUMISSING = 6;
        public const int WFS_CDM_STATCUNOVAL = 7;
        public const int WFS_CDM_STATCUNOREF = 8;
        public const int WFS_CDM_STATCUMANIP = 9;

        /* values of WFSCDMMIXTYPE.usMixType */

        public const int WFS_CDM_MIXALGORITHM = 1;
        public const int WFS_CDM_MIXTABLE = 2;

        /* values of WFSCDMMIXTYPE.usMixNumber */

        //public const int WFS_CDM_INDIVIDUAL = 0;

        /* values of WFSCDMMIXTYPE.usSubType (predefined mix algorithms) */

        //public const int WFS_CDM_MIX_MINIMUM_NUMBER_OF_BILLS = 1;
        //public const int WFS_CDM_MIX_EQUAL_EMPTYING_OF_CASH_UNITS = 2;
        //public const int WFS_CDM_MIX_MAXIMUM_NUMBER_OF_CASH_UNITS = 3;

        /* values of WFSCDMPRESENTSTATUS.wPresentState */

        public const int WFS_CDM_PRESENTED = 1;
        public const int WFS_CDM_NOTPRESENTED = 2;
        public const int WFS_CDM_UNKNOWN = 3;

        /* values of WFSCDMDISPENSE.fwPosition */
        /* values of WFSCDMCAPS.fwPositions */
        /* values of WFSCDMOUTPOS.fwPosition */
        /* values of WFSCDMTELLERPOS.fwPosition */
        /* values of WFSCDMTELLERDETAILS.fwOutputPosition */
        /* values of WFSCDMPHYSICALCU.fwPosition */

        public const int WFS_CDM_POSNULL = 0x0000;
        public const int WFS_CDM_POSLEFT = 0x0001;
        public const int WFS_CDM_POSRIGHT = 0x0002;
        public const int WFS_CDM_POSCENTER = 0x0004;
        public const int WFS_CDM_POSTOP = 0x0040;
        public const int WFS_CDM_POSBOTTOM = 0x0080;
        public const int WFS_CDM_POSFRONT = 0x0800;
        public const int WFS_CDM_POSREAR = 0x1000;

        /* additional values of WFSCDMPHYSICALCU.fwPosition */
        public const int WFS_CDM_POSREJECT = 0x0100;

        /* values of WFSCDMTELLERDETAILS.ulInputPosition */

        public const int WFS_CDM_POSINLEFT = 0x0001;
        public const int WFS_CDM_POSINRIGHT = 0x0002;
        public const int WFS_CDM_POSINCENTER = 0x0004;
        public const int WFS_CDM_POSINTOP = 0x0008;
        public const int WFS_CDM_POSINBOTTOM = 0x0010;
        public const int WFS_CDM_POSINFRONT = 0x0020;
        public const int WFS_CDM_POSINREAR = 0x0040;

        /* values of fwExchangeType */

        public const int WFS_CDM_EXBYHAND = 0x0001;
        public const int WFS_CDM_EXTOCASSETTES = 0x0002;

        /* values of WFSCDMTELLERUPDATE.usAction */

        public const int WFS_CDM_CREATE_TELLER = 1;
        public const int WFS_CDM_MODIFY_TELLER = 2;
        public const int WFS_CDM_DELETE_TELLER = 3;


        /* values of WFSCDMCUERROR.wFailure */

        public const int WFS_CDM_CASHUNITEMPTY = 1;
        public const int WFS_CDM_CASHUNITERROR = 2;
        public const int WFS_CDM_CASHUNITFULL = 4;
        public const int WFS_CDM_CASHUNITLOCKED = 5;
        public const int WFS_CDM_CASHUNITINVALID = 6;
        public const int WFS_CDM_CASHUNITCONFIG = 7;
        public const int WFS_CDM_CASHUNITNOTCONF = 8;


        /* values of lpusReason in WFS_EXEE_CDM_NOTESERROR */

        public const int WFS_CDM_DOUBLENOTEDETECTED = 1;
        public const int WFS_CDM_LONGNOTEDETECTED = 2;
        public const int WFS_CDM_SKEWEDNOTE = 3;
        public const int WFS_CDM_INCORRECTCOUNT = 4;
        public const int WFS_CDM_NOTESTOOCLOSE = 5;
        public const int WFS_CDM_OTHERNOTEERROR = 6;
        public const int WFS_CDM_SHORTNOTEDETECTED = 7;

        /* values of WFSCDMPREPAREDISPENSE.wAction */
        public const int WFS_CDM_START = 1;
        public const int WFS_CDM_STOP = 2;


        /* WOSA/XFS CDM Errors */

        public const int WFS_ERR_CDM_INVALIDCURRENCY = -(CDM_SERVICE_OFFSET + 0);
        public const int WFS_ERR_CDM_INVALIDTELLERID = -(CDM_SERVICE_OFFSET + 1);
        public const int WFS_ERR_CDM_CASHUNITERROR = -(CDM_SERVICE_OFFSET + 2);
        public const int WFS_ERR_CDM_INVALIDDENOMINATION = -(CDM_SERVICE_OFFSET + 3);
        public const int WFS_ERR_CDM_INVALIDMIXNUMBER = -(CDM_SERVICE_OFFSET + 4);
        public const int WFS_ERR_CDM_NOCURRENCYMIX = -(CDM_SERVICE_OFFSET + 5);
        public const int WFS_ERR_CDM_NOTDISPENSABLE = -(CDM_SERVICE_OFFSET + 6);
        public const int WFS_ERR_CDM_TOOMANYITEMS = -(CDM_SERVICE_OFFSET + 7);
        public const int WFS_ERR_CDM_UNSUPPOSITION = -(CDM_SERVICE_OFFSET + 8);
        public const int WFS_ERR_CDM_SAFEDOOROPEN = -(CDM_SERVICE_OFFSET + 10);
        public const int WFS_ERR_CDM_SHUTTERNOTOPEN = -(CDM_SERVICE_OFFSET + 12);
        public const int WFS_ERR_CDM_SHUTTEROPEN = -(CDM_SERVICE_OFFSET + 13);
        public const int WFS_ERR_CDM_SHUTTERCLOSED = -(CDM_SERVICE_OFFSET + 14);
        public const int WFS_ERR_CDM_INVALIDCASHUNIT = -(CDM_SERVICE_OFFSET + 15);
        public const int WFS_ERR_CDM_NOITEMS = -(CDM_SERVICE_OFFSET + 16);
        public const int WFS_ERR_CDM_EXCHANGEACTIVE = -(CDM_SERVICE_OFFSET + 17);
        public const int WFS_ERR_CDM_NOEXCHANGEACTIVE = -(CDM_SERVICE_OFFSET + 18);
        public const int WFS_ERR_CDM_SHUTTERNOTCLOSED = -(CDM_SERVICE_OFFSET + 19);
        public const int WFS_ERR_CDM_PRERRORNOITEMS = -(CDM_SERVICE_OFFSET + 20);
        public const int WFS_ERR_CDM_PRERRORITEMS = -(CDM_SERVICE_OFFSET + 21);
        public const int WFS_ERR_CDM_PRERRORUNKNOWN = -(CDM_SERVICE_OFFSET + 22);
        public const int WFS_ERR_CDM_ITEMSTAKEN = -(CDM_SERVICE_OFFSET + 23);
        public const int WFS_ERR_CDM_INVALIDMIXTABLE = -(CDM_SERVICE_OFFSET + 27);
        public const int WFS_ERR_CDM_OUTPUTPOS_NOT_EMPTY = -(CDM_SERVICE_OFFSET + 28);
        public const int WFS_ERR_CDM_INVALIDRETRACTPOSITION = -(CDM_SERVICE_OFFSET + 29);
        public const int WFS_ERR_CDM_NOTRETRACTAREA = -(CDM_SERVICE_OFFSET + 30);
        public const int WFS_ERR_CDM_NOCASHBOXPRESENT = -(CDM_SERVICE_OFFSET + 33);
        public const int WFS_ERR_CDM_AMOUNTNOTINMIXTABLE = -(CDM_SERVICE_OFFSET + 34);
        public const int WFS_ERR_CDM_ITEMSNOTTAKEN = -(CDM_SERVICE_OFFSET + 35);
        public const int WFS_ERR_CDM_ITEMSLEFT = -(CDM_SERVICE_OFFSET + 36);
        public const int WFS_ERR_CDM_INVALID_PORT = -(CDM_SERVICE_OFFSET + 37);
        public const int WFS_ERR_CDM_POWERSAVETOOSHORT = -(CDM_SERVICE_OFFSET + 38);
        public const int WFS_ERR_CDM_POWERSAVEMEDIAPRESENT = -(CDM_SERVICE_OFFSET + 39);
        #endregion
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

    [Flags]
    public enum RetractArea : ushort
    {
        WFS_CDM_RA_RETRACT = (0x0001),
        WFS_CDM_RA_TRANSPORT = (0x0002),
        WFS_CDM_RA_STACKER = (0x0004),
        WFS_CDM_RA_REJECT = (0x0008),
        WFS_CDM_RA_NOTSUPP = (0x0010),
        WFS_CDM_RA_ITEMCASSETTE = (0x0020)
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFS_CDM_CashUnit_INFO
    {
        public ushort usTellerID;
        public ushort usCount;
        public System.IntPtr lppList;
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

    //*****************************************************************************
    //typedef struct _wfs_cdm_status
    //{
    //    WORD fwDevice;
    //    WORD fwSafeDoor;
    //    WORD fwDispenser;
    //    WORD fwIntermediateStacker;
    //    LPWFSCDMOUTPOS* lppPositions;
    //    LPSTR lpszExtra;
    //    DWORD dwGuidLights[WFS_CDM_GUIDLIGHTS_SIZE];
    //    WORD wDevicePosition;
    //    USHORT usPowerSaveRecoveryTime;
    //}
    //WFSCDMSTATUS, * LPWFSCDMSTATUS;

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public unsafe class WFSCDMSTATUS
    {
        public UInt16 fwDevice;
        public UInt16 fwSafeDoor;
        public UInt16 fwDispenser;
        public UInt16 fwIntermediateStacker;
        public string lpszExtra;
        public UInt16 wDevicePosition;
        public UInt16 usPowerSaveRecoveryTime;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct _wfs_result
    {
        public System.UInt32 RequestID;
        public System.UInt16 hService;
        //            [MarshalAs(UnmanagedType.Struct)]
        //            public SystemTime      tsTimeStamp;
        public System.UInt16 wYear;
        public System.UInt16 wMonth;
        public System.UInt16 wDayOfWeek;
        public System.UInt16 wDay;
        public System.UInt16 wHour;
        public System.UInt16 wMinute;
        public System.UInt16 wSecond;
        public System.UInt16 wMilliseconds;
        public System.UInt32 hResult;
        public CommandEvent_struct CommandEvent;
        public IntPtr lpBuffer;
    }

    [StructLayout(LayoutKind.Explicit, Size = 4, Pack = 1, CharSet = CharSet.Ansi)]
    public struct CommandEvent_struct
    {
        [FieldOffset(0)]
        public System.UInt32 CommandCode;

        [FieldOffset(0)]
        public System.UInt32 EventID;
    }

    //Status ************************************************************************************

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public unsafe class WFS_CDM_STATUS : ISTATUS
    {
        public UInt16 fwDevice;

        public UInt16 fwSafeDoor;

        public UInt16 fwDispenser;

        public UInt16 fwIntermediateStacker;

        public IntPtr lppPositions;

        public string lpszExtra;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CDMDefinition.WFS_CDM_GUIDLIGHTS_SIZE)]
        public uint[] dwGuidLights;//[CDMDefinition.WFS_CDM_GUIDLIGHTS_SIZE];

        public UInt16 wDevicePosition;

        public UInt16 usPowerSaveRecoveryTime;
        public ISTATUS UnMarshal(IntPtr pointer)
        {
            WFS_CDM_STATUS value = new WFS_CDM_STATUS();
            Common.XFSUtil.PtrToStructure(pointer, ref value);
            return value;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public unsafe class WFSCDMCAPS : ICAPS
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
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = CDMDefinition.WFS_CDM_GUIDLIGHTS_SIZE)]
        public uint[] dwGuidLights;
        public bool bPowerSaveControl;
        public bool bPrepareDispense;
    }

    //GetCapabilities************************************************************************************
    public struct WFS_CDM_OUTPOS
    {
        public ushort fwPosition; 
        public ushort fwShutter;
        public ushort fwPositionStatus;
        public ushort fwTransport;
        public ushort fwTransportStatus;
    }

    //Cash unit ************************************************************************************
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMPHCU
    {
        //LPSTR     lpPhysicalPositionName;
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string szCashUnitName;

        //CHAR      cUnitID[5];
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string cUnitID;

        //ULONG     ulInitialCount;
        public uint ulInitialCount;

        //ULONG     ulCount;
        public uint ulCount;

        //ULONG ulRejectCount;
        public uint ulRejectCount;

        //ULONG ulMaximum;
        public uint ulMaximum;


        //USHORT    usPStatus;
        public ushort usPStatus;

        //BOOL      bHardwareSensor;
        [MarshalAsAttribute(UnmanagedType.Bool)]
        public Boolean bHardwareSensor;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct WFSCDMCASHUNIT
    {
        public ushort usNumber;
        public ushort usType;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string szCashUnitName;

        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string cUnitID;

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] cCurrencyID;

        public uint ulValues;
        public uint ulInitialCount;
        public uint ulCount;
        public uint ulRejectCount;
        public uint ulMinimum;
        public uint ulMaximum;

        [MarshalAsAttribute(UnmanagedType.Bool)]
        public Boolean bAppLock;

        public ushort usStatus;
        public ushort usNumPhysicalCUs;


        public System.IntPtr lppPhysical;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack =1)]   
    public struct WFSCDMCUINFO :ISTATUS
    {
        public ushort usTellerID;
        public ushort usCount;

        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public System.IntPtr lppList;
        public ISTATUS UnMarshal(IntPtr pointer)
        {
            WFSCDMCUINFO value = new WFSCDMCUINFO();
            Common.XFSUtil.PtrToStructure(pointer, ref value);
            return value;
        }
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct WFSCDMCUINFO2
    {
        public ushort usTellerID;
        public ushort usCount;

        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public System.IntPtr[] lppList;
    }

    //Teller unit ************************************************************************************
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct WFSCDMTellerINFO
    {
        public ushort usTellerID;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] cCurrencyID;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMTELLERDETAILS
    {
        public ushort usTellerID;
        public uint ulInputPosition;
        public ushort fwOutputPosition;
        public System.IntPtr lppTellerTotals;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMTELLERTOTALS
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] cCurrencyID;

        public uint ulItemsReceived;
        public uint ulItemsDispensed;
        public uint ulCoinsReceived;
        public uint ulCoinsDispensed;
        public uint ulCashBoxReceived;
        public uint ulCashBoxDispensed;
    }

    //currencyExp****************************************************************************************
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMCURRENCYEXP
    {
        /// CHAR[3]
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string cCurrencyID;
        public short sExponent;
    }

    //mix type****************************************************************************************
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMMIXTYPE
    {
        public ushort usMixNumber;
        public ushort usMixType;
        public ushort usSubType;
        public string lpszName;
    }

    //mix table****************************************************************************************
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMMIXROW
    {
        public uint ulAmount;
        public IntPtr lpusMixture;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMMIXTABLE
    {
        public ushort usMixNumber;

        public string lpszName;

        public ushort usRows;

        public ushort usCols;

        public IntPtr lpulMixHeader;

        public IntPtr lppMixRows;
    }

    //present status table****************************************************************************************
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMPRESENTSTATUS
    {
        public IntPtr lpDenomination;
        public ushort wPresentState;
        public string lpszExtra;
    }

    // **************************************************************************************************** execute command ********************************************************************************************************************

    //denominate ****************************************************************************************
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMDENOMINATE
    {
        public ushort usTellerID;
        public ushort usMixNumber;
        public IntPtr lpDenomination;
    }

    //Count ****************************************************************************************
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMPHYSICALCU
    {
        public bool bEmptyAll;
        public ushort fwPosition;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpPhysicalPositionName;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct _wfs_cdm_count
    {
        public ushort usNumPhysicalCUs;
        public IntPtr lppCountedPhysCUs;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMCOUNTEDPHYSCU
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpPhysicalPositionName;

        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string cUnitId;

        public uint ulDispensed;
        public uint ulCounted;
        public ushort usPStatus;
    }

    //Retract ********************************************************************************************************************
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMRETRACT
    {
        public ushort fwOutputPosition;
        public ushort usRetractArea;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct WFSCDMITEMNUMBERLIST
    {
        public ushort usNumOfItemNumbers;
        public IntPtr lppItemNumber;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMITEMNUMBER
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string cCurrencyID;

        public uint ulValues;

        public ushort usRelease;

        public uint ulCount;

        public ushort usNumber;
    }

    //TellerUpdate****************************************************************************************************************
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMTELLERUPDATE
    {
        public ushort usAction;

        //it is WFSCDMTELLERDETAILS
        public UIntPtr lpTellerDetails;
    }

    //WFSCDMSTARTEX
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCDMSTARTEX
    {
        public ushort fwExchangeType;
        public ushort usTellerID;
        public ushort usCount;
        public ushort[] lpusCUNumList;
    }
}

