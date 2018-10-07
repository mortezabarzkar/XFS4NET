using XFS4NET.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.CIM
{
    public static class CIMDefinition
    {
        
        public const int WFS_SERVICE_CLASS_CIM = 13;
        public const int WFS_SERVICE_CLASS_VERSION_CIM = 0x0A03;
        public const string WFS_SERVICE_CLASS_NAME_CIM = "CIM";
        public const int CIM_SERVICE_OFFSET = (WFS_SERVICE_CLASS_CIM * 100);
        /* CIM Info Commands */
        #region CIM Info Commands
        public const int WFS_INF_CIM_STATUS = CIM_SERVICE_OFFSET + 1;
        public const int WFS_INF_CIM_CAPABILITIES = CIM_SERVICE_OFFSET + 2;
        public const int WFS_INF_CIM_CASH_UNIT_INFO = CIM_SERVICE_OFFSET + 3;
        public const int WFS_INF_CIM_TELLER_INFO = CIM_SERVICE_OFFSET + 4;
        public const int WFS_INF_CIM_CURRENCY_EXP = CIM_SERVICE_OFFSET + 5;
        public const int WFS_INF_CIM_BANKNOTE_TYPES = CIM_SERVICE_OFFSET + 6;
        public const int WFS_INF_CIM_CASH_IN_STATUS = CIM_SERVICE_OFFSET + 7;
        public const int WFS_INF_CIM_GET_P6_INFO = CIM_SERVICE_OFFSET + 8;
        public const int WFS_INF_CIM_GET_P6_SIGNATURE = CIM_SERVICE_OFFSET + 9;
        public const int WFS_INF_CIM_GET_ITEM_INFO = CIM_SERVICE_OFFSET + 10;
        public const int WFS_INF_CIM_POSITION_CAPABILITIES = CIM_SERVICE_OFFSET + 11;
        #endregion

        /* CIM Execute Commands */
        #region CIM Execute Commands
        public const int WFS_CMD_CIM_CASH_IN_START = CIM_SERVICE_OFFSET + 1;
        public const int WFS_CMD_CIM_CASH_IN = CIM_SERVICE_OFFSET + 2;
        public const int WFS_CMD_CIM_CASH_IN_END = CIM_SERVICE_OFFSET + 3;
        public const int WFS_CMD_CIM_CASH_IN_ROLLBACK = CIM_SERVICE_OFFSET + 4;
        public const int WFS_CMD_CIM_RETRACT = CIM_SERVICE_OFFSET + 5;
        public const int WFS_CMD_CIM_OPEN_SHUTTER = CIM_SERVICE_OFFSET + 6;
        public const int WFS_CMD_CIM_CLOSE_SHUTTER = CIM_SERVICE_OFFSET + 7;
        public const int WFS_CMD_CIM_SET_TELLER_INFO = CIM_SERVICE_OFFSET + 8;
        public const int WFS_CMD_CIM_SET_CASH_UNIT_INFO = CIM_SERVICE_OFFSET + 9;
        public const int WFS_CMD_CIM_START_EXCHANGE = CIM_SERVICE_OFFSET + 10;
        public const int WFS_CMD_CIM_END_EXCHANGE = CIM_SERVICE_OFFSET + 11;
        public const int WFS_CMD_CIM_OPEN_SAFE_DOOR = CIM_SERVICE_OFFSET + 12;
        public const int WFS_CMD_CIM_RESET = CIM_SERVICE_OFFSET + 13;
        public const int WFS_CMD_CIM_CONFIGURE_CASH_IN_UNITS = CIM_SERVICE_OFFSET + 14;
        public const int WFS_CMD_CIM_CONFIGURE_NOTETYPES = CIM_SERVICE_OFFSET + 15;
        public const int WFS_CMD_CIM_CREATE_P6_SIGNATURE = CIM_SERVICE_OFFSET + 16;
        public const int WFS_CMD_CIM_SET_GUIDANCE_LIGHT = CIM_SERVICE_OFFSET + 17;
        public const int WFS_CMD_CIM_CONFIGURE_NOTE_READER = CIM_SERVICE_OFFSET + 18;
        public const int WFS_CMD_CIM_COMPARE_P6_SIGNATURE = CIM_SERVICE_OFFSET + 19;
        public const int WFS_CMD_CIM_POWER_SAVE_CONTROL = CIM_SERVICE_OFFSET + 20;
        #endregion

        /* CIM Messages */
        #region CIM Messages
        public const int WFS_SRVE_CIM_SAFEDOOROPEN = CIM_SERVICE_OFFSET + 1;
        public const int WFS_SRVE_CIM_SAFEDOORCLOSED = CIM_SERVICE_OFFSET + 2;
        public const int WFS_USRE_CIM_CASHUNITTHRESHOLD = CIM_SERVICE_OFFSET + 3;
        public const int WFS_SRVE_CIM_CASHUNITINFOCHANGED = CIM_SERVICE_OFFSET + 4;
        public const int WFS_SRVE_CIM_TELLERINFOCHANGED = CIM_SERVICE_OFFSET + 5;
        public const int WFS_EXEE_CIM_CASHUNITERROR = CIM_SERVICE_OFFSET + 6;
        public const int WFS_SRVE_CIM_ITEMSTAKEN = CIM_SERVICE_OFFSET + 7;
        public const int WFS_SRVE_CIM_COUNTS_CHANGED = CIM_SERVICE_OFFSET + 8;
        public const int WFS_EXEE_CIM_INPUTREFUSE = CIM_SERVICE_OFFSET + 9;
        public const int WFS_SRVE_CIM_ITEMSPRESENTED = CIM_SERVICE_OFFSET + 10;
        public const int WFS_SRVE_CIM_ITEMSINSERTED = CIM_SERVICE_OFFSET + 11;
        public const int WFS_EXEE_CIM_NOTEERROR = CIM_SERVICE_OFFSET + 12;
        public const int WFS_EXEE_CIM_SUBCASHIN = CIM_SERVICE_OFFSET + 13;
        public const int WFS_SRVE_CIM_MEDIADETECTED = CIM_SERVICE_OFFSET + 14;
        public const int WFS_EXEE_CIM_INPUT_P6 = CIM_SERVICE_OFFSET + 15;
        public const int WFS_EXEE_CIM_INFO_AVAILABLE = CIM_SERVICE_OFFSET + 16;
        public const int WFS_EXEE_CIM_INSERTITEMS = CIM_SERVICE_OFFSET + 17;
        public const int WFS_SRVE_CIM_DEVICEPOSITION = CIM_SERVICE_OFFSET + 18;
        public const int WFS_SRVE_CIM_POWER_SAVE_CHANGE = CIM_SERVICE_OFFSET + 19;
        #endregion

        /* values of WFSCIMSTATUS.fwDevice */
        #region values of WFSCIMSTATUS.fwDevice
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

        public const int WFS_CDM_DEVONLINE = WFS_STAT_DEVONLINE;
        public const int WFS_CDM_DEVOFFLINE = WFS_STAT_DEVOFFLINE;
        public const int WFS_CDM_DEVPOWEROFF = WFS_STAT_DEVPOWEROFF;
        public const int WFS_CDM_DEVNODEVICE = WFS_STAT_DEVNODEVICE;
        public const int WFS_CDM_DEVHWERROR = WFS_STAT_DEVHWERROR;
        public const int WFS_CDM_DEVUSERERROR = WFS_STAT_DEVUSERERROR;
        public const int WFS_CDM_DEVBUSY = WFS_STAT_DEVBUSY;
        public const int WFS_CDM_DEVFRAUDATTEMPT = WFS_STAT_DEVFRAUDATTEMPT;
        #endregion

        /* values of WFSCIMSTATUS.fwSafeDoor */
        #region values of WFSCIMSTATUS.fwSafeDoor
        public const int WFS_CIM_DOORNOTSUPPORTED = 1;
        public const int WFS_CIM_DOOROPEN = 2;
        public const int WFS_CIM_DOORCLOSED = 3;
        public const int WFS_CIM_DOORUNKNOWN = 4;
        public const int WFS_CIM_ACCOK = 0;
        public const int WFS_CIM_ACCCUSTATE = 1;
        public const int WFS_CIM_ACCCUSTOP = 2;
        public const int WFS_CIM_ACCCUUNKNOWN = 3;
        public const int WFS_CIM_ISEMPTY = 0;
        public const int WFS_CIM_ISNOTEMPTY = 1;
        public const int WFS_CIM_ISFULL = 2;
        public const int WFS_CIM_ISUNKNOWN = 4;
        public const int WFS_CIM_ISNOTSUPPORTED = 5;
        public const int WFS_CIM_GUIDLIGHTS_SIZE = 32;
        public const int WFS_CIM_GUIDLIGHTS_MAX = WFS_CIM_GUIDLIGHTS_SIZE - 1;
        public const int WFS_CIM_GUIDANCE_POSINNULL = 0;
        public const int WFS_CIM_GUIDANCE_POSINLEFT = 1;
        public const int WFS_CIM_GUIDANCE_POSINRIGHT = 2;
        public const int WFS_CIM_GUIDANCE_POSINCENTER = 3;
        public const int WFS_CIM_GUIDANCE_POSINTOP = 4;
        public const int WFS_CIM_GUIDANCE_POSINBOTTOM = 5;
        public const int WFS_CIM_GUIDANCE_POSINFRONT = 6;
        public const int WFS_CIM_GUIDANCE_POSINREAR = 7;
        public const int WFS_CIM_GUIDANCE_POSOUTLEFT = 8;
        public const int WFS_CIM_GUIDANCE_POSOUTRIGHT = 9;
        public const int WFS_CIM_GUIDANCE_POSOUTCENTER = 10;
        public const int WFS_CIM_GUIDANCE_POSOUTTOP = 11;
        public const int WFS_CIM_GUIDANCE_POSOUTBOTTOM = 12;
        public const int WFS_CIM_GUIDANCE_POSOUTFRONT = 13;
        public const int WFS_CIM_GUIDANCE_POSOUTREAR = 14;
        public const int WFS_CIM_GUIDANCE_POSOUTNULL = 15;
        public const int WFS_CIM_GUIDANCE_NOT_AVAILABLE = 0x00000000;
        public const int WFS_CIM_GUIDANCE_OFF = 0x00000001;
        public const int WFS_CIM_GUIDANCE_SLOW_FLASH = 0x00000004;
        public const int WFS_CIM_GUIDANCE_MEDIUM_FLASH = 0x00000008;
        public const int WFS_CIM_GUIDANCE_QUICK_FLASH = 0x00000010;
        public const int WFS_CIM_GUIDANCE_CONTINUOUS = 0x00000080;
        public const int WFS_CIM_GUIDANCE_RED = 0x00000100;
        public const int WFS_CIM_GUIDANCE_GREEN = 0x00000200;
        public const int WFS_CIM_GUIDANCE_YELLOW = 0x00000400;
        public const int WFS_CIM_GUIDANCE_BLUE = 0x00000800;
        public const int WFS_CIM_GUIDANCE_CYAN = 0x00001000;
        public const int WFS_CIM_GUIDANCE_MAGENTA = 0x00002000;
        public const int WFS_CIM_GUIDANCE_WHITE = 0x00004000;
        public const int WFS_CIM_DEVICEINPOSITION = 0;
        public const int WFS_CIM_DEVICENOTINPOSITION = 1;
        public const int WFS_CIM_DEVICEPOSUNKNOWN = 2;
        public const int WFS_CIM_DEVICEPOSNOTSUPP = 3;
        public const int WFS_CIM_CUSTOMERACCESS = 0;
        public const int WFS_CIM_NOCUSTOMERACCESS = 1;
        public const int WFS_CIM_ACCESSUNKNOWN = 2;
        public const int WFS_CIM_NOITEMS = 4;
        public const int WFS_CIM_BNROK = 0;
        public const int WFS_CIM_BNRINOP = 1;
        public const int WFS_CIM_BNRUNKNOWN = 2;
        public const int WFS_CIM_BNRNOTSUPPORTED = 3;
        public const int WFS_CIM_SHTCLOSED = 0;
        public const int WFS_CIM_SHTOPEN = 1;
        public const int WFS_CIM_SHTJAMMED = 2;
        public const int WFS_CIM_SHTUNKNOWN = 3;
        public const int WFS_CIM_SHTNOTSUPPORTED = 4;
        public const int WFS_CIM_PSEMPTY = 0;
        public const int WFS_CIM_PSNOTEMPTY = 1;
        public const int WFS_CIM_PSUNKNOWN = 2;
        public const int WFS_CIM_PSNOTSUPPORTED = 3;
        public const int WFS_CIM_PSFOREIGNITEMS = 4;
        public const int WFS_CIM_TPOK = 0;
        public const int WFS_CIM_TPINOP = 1;
        public const int WFS_CIM_TPUNKNOWN = 2;
        public const int WFS_CIM_TPNOTSUPPORTED = 3;
        public const int WFS_CIM_TPSTATEMPTY = 0;
        public const int WFS_CIM_TPSTATNOTEMPTY = 1;
        public const int WFS_CIM_TPSTATNOTEMPTYCUST = 2;
        public const int WFS_CIM_TPSTATNOTEMPTY_UNK = 3;
        public const int WFS_CIM_TPSTATNOTSUPPORTED = 4;
        public const int WFS_CIM_TELLERBILL = 0;
        public const int WFS_CIM_SELFSERVICEBILL = 1;
        public const int WFS_CIM_TELLERCOIN = 2;
        public const int WFS_CIM_SELFSERVICECOIN = 3;
        public const int WFS_CIM_EXBYHAND = 0x0001;
        public const int WFS_CIM_EXTOCASSETTES = 0x0002;
        public const int WFS_CIM_CLEARRECYCLER = 0x0004;
        public const int WFS_CIM_DEPOSITINTO = 0x0008;
        public const int WFS_CIM_PRESENT = 0x0001;
        public const int WFS_CIM_RETRACT = 0x0002;
        public const int WFS_CIM_NOTSUPP = 0x0004;
        public const int WFS_CIM_REJECT = 0x0008;
        public const int WFS_CIM_TYPERECYCLING = 1;
        public const int WFS_CIM_TYPECASHIN = 2;
        public const int WFS_CIM_TYPEREPCONTAINER = 3;
        public const int WFS_CIM_TYPERETRACTCASSETTE = 4;
        public const int WFS_CIM_TYPEREJECT = 5;
        public const int WFS_CIM_TYPECDMSPECIFIC = 6;
        public const int WFS_CIM_CITYPALL = 0x0001;
        public const int WFS_CIM_CITYPUNFIT = 0x0002;
        public const int WFS_CIM_CITYPINDIVIDUAL = 0x0004;
        public const int WFS_CIM_CITYPLEVEL3 = 0x0008;
        public const int WFS_CIM_CITYPLEVEL2 = 0x0010;
        public const int WFS_CIM_STATCUOK = 0;
        public const int WFS_CIM_STATCUFULL = 1;
        public const int WFS_CIM_STATCUHIGH = 2;
        public const int WFS_CIM_STATCULOW = 3;
        public const int WFS_CIM_STATCUEMPTY = 4;
        public const int WFS_CIM_STATCUINOP = 5;
        public const int WFS_CIM_STATCUMISSING = 6;
        public const int WFS_CIM_STATCUNOVAL = 7;
        public const int WFS_CIM_STATCUNOREF = 8;
        public const int WFS_CIM_STATCUMANIP = 9;
        public const int WFS_CIM_POSNULL = 0x0000;
        public const int WFS_CIM_POSINLEFT = 0x0001;
        public const int WFS_CIM_POSINRIGHT = 0x0002;
        public const int WFS_CIM_POSINCENTER = 0x0004;
        public const int WFS_CIM_POSINTOP = 0x0008;
        public const int WFS_CIM_POSINBOTTOM = 0x0010;
        public const int WFS_CIM_POSINFRONT = 0x0020;
        public const int WFS_CIM_POSINREAR = 0x0040;
        public const int WFS_CIM_POSOUTLEFT = 0x0080;
        public const int WFS_CIM_POSOUTRIGHT = 0x0100;
        public const int WFS_CIM_POSOUTCENTER = 0x0200;
        public const int WFS_CIM_POSOUTTOP = 0x0400;
        public const int WFS_CIM_POSOUTBOTTOM = 0x0800;
        public const int WFS_CIM_POSOUTFRONT = 0x1000;
        public const int WFS_CIM_POSOUTREAR = 0x2000;
        public const int WFS_CIM_CIOK = 0;
        public const int WFS_CIM_CIROLLBACK = 1;
        public const int WFS_CIM_CIACTIVE = 2;
        public const int WFS_CIM_CIRETRACT = 3;
        public const int WFS_CIM_CIUNKNOWN = 4;
        public const int WFS_CIM_CIRESET = 5;
        public const int WFS_CIM_RA_RETRACT = 0x0001;
        public const int WFS_CIM_RA_TRANSPORT = 0x0002;
        public const int WFS_CIM_RA_STACKER = 0x0004;
        public const int WFS_CIM_RA_BILLCASSETTES = 0x0008;
        public const int WFS_CIM_RA_NOTSUPP = 0x0010;
        public const int WFS_CIM_RA_REJECT = 0x0020;
        public const int WFS_CIM_LEVEL_2 = 2;
        public const int WFS_CIM_LEVEL_3 = 3;
        public const int WFS_CIM_LEVEL_4 = 4;
        public const int WFS_CIM_CREATE_TELLER = 1;
        public const int WFS_CIM_MODIFY_TELLER = 2;
        public const int WFS_CIM_DELETE_TELLER = 3;
        public const int WFS_CIM_CASHUNITEMPTY = 1;
        public const int WFS_CIM_CASHUNITERROR = 2;
        public const int WFS_CIM_CASHUNITFULL = 3;
        public const int WFS_CIM_CASHUNITLOCKED = 4;
        public const int WFS_CIM_CASHUNITNOTCONF = 5;
        public const int WFS_CIM_CASHUNITINVALID = 6;
        public const int WFS_CIM_CASHUNITCONFIG = 7;
        public const int WFS_CIM_FEEDMODULEPROBLEM = 8;
        public const int WFS_CIM_ORFRONTTOP = 1;
        public const int WFS_CIM_ORFRONTBOTTOM = 2;
        public const int WFS_CIM_ORBACKTOP = 3;
        public const int WFS_CIM_ORBACKBOTTOM = 4;
        public const int WFS_CIM_ORUNKNOWN = 5;
        public const int WFS_CIM_ORNOTSUPPORTED = 6;
        public const int WFS_CIM_ITEM_SERIALNUMBER = 0x00000001;
        public const int WFS_CIM_ITEM_SIGNATURE = 0x00000002;
        public const int WFS_CIM_CASHINUNITFULL = 1;
        public const int WFS_CIM_INVALIDBILL = 2;
        public const int WFS_CIM_NOBILLSTODEPOSIT = 3;
        public const int WFS_CIM_DEPOSITFAILURE = 4;
        public const int WFS_CIM_COMMINPCOMPFAILURE = 5;
        public const int WFS_CIM_STACKERFULL = 6;
        public const int WFS_CIM_FOREIGN_ITEMS_DETECTED = 7;
        public const int WFS_CIM_INVALIDBUNCH = 8;
        public const int WFS_CIM_COUNTERFEIT = 9;
        public const int WFS_CIM_DOUBLENOTEDETECTED = 1;
        public const int WFS_CIM_LONGNOTEDETECTED = 2;
        public const int WFS_CIM_SKEWEDNOTE = 3;
        public const int WFS_CIM_INCORRECTCOUNT = 4;
        public const int WFS_CIM_NOTESTOOCLOSE = 5;
        public const int WFS_CIM_OTHERNOTEERROR = 6;
        public const int WFS_CIM_SHORTNOTEDETECTED = 7;
        public const int WFS_CIM_POSIN = 0x0001;
        public const int WFS_CIM_POSREFUSE = 0x0002;
        public const int WFS_CIM_POSROLLBACK = 0x0004;
        public const int WFS_CIM_ADDBUNCHNONE = 1;
        public const int WFS_CIM_ADDBUNCHONEMORE = 2;
        public const int WFS_CIM_ADDBUNCHUNKNOWN = 3;
        public const int WFS_CIM_NUMBERUNKNOWN = 255;
        #endregion

        /* WOSA/XFS CIM Errors */
        #region WOSA/XFS CIM Errors
        public const int WFS_ERR_CIM_INVALIDCURRENCY = (-(CIM_SERVICE_OFFSET + 0));
        public const int WFS_ERR_CIM_INVALIDTELLERID = (-(CIM_SERVICE_OFFSET + 1));
        public const int WFS_ERR_CIM_CASHUNITERROR = (-(CIM_SERVICE_OFFSET + 2));
        public const int WFS_ERR_CIM_TOOMANYITEMS = (-(CIM_SERVICE_OFFSET + 7));
        public const int WFS_ERR_CIM_UNSUPPOSITION = (-(CIM_SERVICE_OFFSET + 8));
        public const int WFS_ERR_CIM_SAFEDOOROPEN = (-(CIM_SERVICE_OFFSET + 10));
        public const int WFS_ERR_CIM_SHUTTERNOTOPEN = (-(CIM_SERVICE_OFFSET + 12));
        public const int WFS_ERR_CIM_SHUTTEROPEN = (-(CIM_SERVICE_OFFSET + 13));
        public const int WFS_ERR_CIM_SHUTTERCLOSED = (-(CIM_SERVICE_OFFSET + 14));
        public const int WFS_ERR_CIM_INVALIDCASHUNIT = (-(CIM_SERVICE_OFFSET + 15));
        public const int WFS_ERR_CIM_NOITEMS = (-(CIM_SERVICE_OFFSET + 16));
        public const int WFS_ERR_CIM_EXCHANGEACTIVE = (-(CIM_SERVICE_OFFSET + 17));
        public const int WFS_ERR_CIM_NOEXCHANGEACTIVE = (-(CIM_SERVICE_OFFSET + 18));
        public const int WFS_ERR_CIM_SHUTTERNOTCLOSED = (-(CIM_SERVICE_OFFSET + 19));
        public const int WFS_ERR_CIM_ITEMSTAKEN = (-(CIM_SERVICE_OFFSET + 23));
        public const int WFS_ERR_CIM_CASHINACTIVE = (-(CIM_SERVICE_OFFSET + 25));
        public const int WFS_ERR_CIM_NOCASHINACTIVE = (-(CIM_SERVICE_OFFSET + 26));
        public const int WFS_ERR_CIM_POSITION_NOT_EMPTY = (-(CIM_SERVICE_OFFSET + 28));
        public const int WFS_ERR_CIM_INVALIDRETRACTPOSITION = (-(CIM_SERVICE_OFFSET + 34));
        public const int WFS_ERR_CIM_NOTRETRACTAREA = (-(CIM_SERVICE_OFFSET + 35));
        public const int WFS_ERR_CIM_INVALID_PORT = (-(CIM_SERVICE_OFFSET + 36));
        public const int WFS_ERR_CIM_FOREIGN_ITEMS_DETECTED = (-(CIM_SERVICE_OFFSET + 37));
        public const int WFS_ERR_CIM_LOADFAILED = (-(CIM_SERVICE_OFFSET + 38));
        public const int WFS_ERR_CIM_CASHUNITNOTEMPTY = (-(CIM_SERVICE_OFFSET + 39));
        public const int WFS_ERR_CIM_INVALIDREFSIG = (-(CIM_SERVICE_OFFSET + 40));
        public const int WFS_ERR_CIM_INVALIDTRNSIG = (-(CIM_SERVICE_OFFSET + 41));
        public const int WFS_ERR_CIM_POWERSAVETOOSHORT = (-(CIM_SERVICE_OFFSET + 42));
        public const int WFS_ERR_CIM_POWERSAVEMEDIAPRESENT = (-(CIM_SERVICE_OFFSET + 43));
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

    /*=================================================================*/
    /* CIM Info Command Structures */
    /*=================================================================*/

    //typedef struct _wfs_cim_inpos
    //{
    //    WORD fwPosition;
    //    WORD fwShutter;
    //    WORD fwPositionStatus;
    //    WORD fwTransport;
    //    WORD fwTransportStatus;
    //}
    //WFSCIMINPOS, * LPWFSCIMINPOS;

    //typedef struct _wfs_cim_status
    //{
    //    WORD fwDevice;
    //    WORD fwSafeDoor;
    //    WORD fwAcceptor;
    //    WORD fwIntermediateStacker;
    //    WORD fwStackerItems;
    //    WORD fwBanknoteReader;
    //    BOOL bDropBox;
    //    LPWFSCIMINPOS* lppPositions;
    //    LPSTR lpszExtra;
    //}
    //WFSCIMSTATUS, * LPWFSCIMSTATUS;

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMSTATUS : ISTATUS
    {
        public ushort fwDevice;
        public ushort fwSafeDoor;
        public ushort fwAcceptor;
        public ushort fwIntermediateStacker;
        public ushort fwStackerItems;
        public ushort fwBanknoteReader;
        public Boolean bDropBox;
        public IntPtr lppPositions;
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpszExtra;

        public ISTATUS UnMarshal(IntPtr pointer)
        {
            WFSCIMSTATUS value = new WFSCIMSTATUS();
            Common.XFSUtil.PtrToStructure(pointer, ref value);
            return value;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct WFSCIMOUTPOS
    {
        public ushort fwPosition;
        public ushort fwShutter;
        public ushort fwPositionStatus;
        public ushort fwTransport;
        public ushort fwTransportStatus;
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

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMCAPS
    {
        public ushort wClass;
        public ushort fwType;
        public ushort wMaxCashInItems;
        public bool bCompound;
        public bool bShutter;
        public bool bShutterControl;
        public bool bSafeDoor;
        public bool bCashBox;
        public bool bRefill;
        public ushort fwIntermediateStacker;
        public bool bItemsTakenSensor;
        public bool bItemsInsertedSensor;
        public ushort fwPositions;
        public ushort fwExchangeType;
        public ushort fwRetractAreas;
        public ushort fwRetractTransportActions;
        public ushort fwRetractStackerActions;
        public string lpszExtra;
        public int dwItemInfoTypes;
        public bool bCompareSignatures;
        public bool bPowerSaveControl;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct WFSCIMP6INFO
    {
        public ushort usLevel;
        public IntPtr lpNoteNumberList;
        public ushort usNumOfSignatures;
    }

    /*=================================================================*/
    /* CIM Set Cash Info Command Structures */
    /*=================================================================*/

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMCASHINFO
    {
        public ushort usCount;
        public IntPtr lppCashIn;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct WFSCIMCASHIN
    {
        public ushort usNumber;
        public uint fwType;
        public uint fwItemType;

        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string cUnitID;

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] cCurrencyID;

        public uint ulValues;
        public uint ulCashInCount;
        public uint ulCount;
        public uint ulMaximum;
        public ushort usStatus;

        [MarshalAsAttribute(UnmanagedType.Bool)]
        public Boolean bAppLock;

        public IntPtr lpNoteNumberList;

        public ushort usNumPhysicalCUs;
        public IntPtr lppPhysical;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpszExtra;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMNOTENUMBERLIST
    {
        public ushort usNumOfNoteNumbers;

        public IntPtr lppNoteNumber;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct WFSCIMNOTENUMBER
    {
        public ushort usNoteID;
        public uint ulCount;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMPHCU
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpPhysicalPositionName;

        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string cUnitID;

        public uint ulCashInCount;
        public uint ulCount;
        public uint ulMaximum;
        public ushort usPStatus;

        [MarshalAsAttribute(UnmanagedType.Bool)]
        public Boolean bHardwareSensors;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpszExtra;
    }

    /*
    //============================Set Cash ============================
    //************cash in **********************************************************************************************************
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct WFSCIMCASHIN2
    {
        public ushort usNumber;

        public int fwType;

        public int fwItemType;

        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string cUnitID;

        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string cCurrencyID;

        public uint ulValues;
        public uint ulCashInCount;
        public uint ulCount;
        public uint ulMaximum;
        public ushort usStatus;
        public int bAppLock;
        public IntPtr lpNoteNumberList;
        public uint ulNumNoteNumberEx;
        public ushort usNumPhysicalCUs;
        public IntPtr lppPhysical;

        //public string lpszExtra;
        //public ushort lpusNoteIDs;
        //public ushort usCDMType;
        //public uint ulInitialCount;
        //public uint ulDispensedCount;
        //public uint ulPresentedCount;
        //public uint ulRetractedCount;
        //public uint ulRejectCount;
        //public uint ulMinimum;
        //[MarshalAsAttribute(UnmanagedType.LPStr)]
        //public string lpszCashUnitName;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct WFSCIMNOTENUMBER
    {
        public ushort usNoteID;

       // [MarshalAs(UnmanagedType.U4)]
        public uint ulCount;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMNOTENumber
    {
        public ushort usNumOfNoteNumbers;

        public IntPtr noteType;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMNOTETYPE
    {
        public ushort usNoteID;
        public ulong ulCount;

        //[MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 3)]
        //public string cCurrencyID;

        //public uint ulValues;
        //public ushort usRelease;
        //public int bConfigured;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct WFSCIMCASHINFO2
    {
        public ushort usCount;
        public IntPtr lppCashIn;
    }

    //************cash in **********************************************************************************************************
*/
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMTELLERINFO
    {
        public ushort usTellerID;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMTELLERTOTALS
    {
        public uint ulItemsReceived;
        public uint ulItemsDispensed;
        public uint ulCoinsReceived;
        public uint ulCoinsDispensed;
        public uint ulCashBoxReceived;
        public uint ulCashBoxDispensed;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMTELLERDETAILS
    {
        public ushort usTellerID;
        public ushort fwInputPosition;
        public ushort fwOutputPosition;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMCURRENCYEXP
    {
        public short sExponent;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMNOTETYPELIST
    {
        public ushort usNumOfNoteTypes;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMCASHINSTATUS
    {
        public ushort wStatus;
        public ushort usNumOfRefused;
        public IntPtr lpNoteNumberList;
        public string lpszExtra;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMGETP6SIGNATURE
    {
        public ushort usLevel;
        public ushort usIndex;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMP6SIGNATURE
    {
        public ushort usNoteId;
        public uint ulLength;
        public int dwOrientation;
        public IntPtr lpSignature;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMGETITEMINFO
    {
        public ushort usLevel;
        public ushort usIndex;
        public int dwItemInfoType;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMITEMINFO
    {
        public ushort usNoteID;
        public IntPtr lpszSerialNumber;
        public IntPtr lpP6Signature;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMITEMINFOSUMMARY
    {
        public ushort usLevel;
        public ushort usNumOfItems;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMPOSCAPS
    {
        public ushort fwPosition;
        public ushort fwUsage;
        public bool bShutterControl;
        public bool bItemsTakenSensor;
        public bool bItemsInsertedSensor;
        public ushort fwRetractAreas;
        public string lpszExtra;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMPOSCAPABILITIES
    {
    }


    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMCASHINSTART
    {
        public ushort usTellerID;
        public bool bUseRecycleUnits;
        public ushort fwOutputPosition;
        public ushort fwInputPosition;
    }


    //Retract ********************************************************************************************************************

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSCIMRETRACT
    {
        public ushort fwOutputPosition;
        public ushort usRetractArea;
        public ushort usIndex;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMTELLERUPDATE
    {
        public ushort usAction;
        public IntPtr lpTellerDetails;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMOUTPUT
    {
        public ushort usLogicalNumber;
        public ushort fwPosition;
        public ushort usNumber;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMSTARTEX
    {
        public ushort fwExchangeType;
        public ushort usTellerID;
        public ushort usCount;
        public ushort lpusCUNumList;
        public IntPtr lpOutput;
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMITEMPOSITION
    {
        public ushort usNumber;
        public IntPtr lpRetractArea;
        public ushort fwOutputPosition;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMCASHINTYPE
    {
        public ushort usNumber;
        public int dwType;
        public ushort lpusNoteIDs;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMSETGUIDLIGHT
    {
        public ushort wGuidLight;
        public int dwCommand;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMCONFIGURENOTEREADER
    {
        public bool bLoadAlways;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMCONFIGURENOTEREADEROUT
    {
        public bool bRebootNecessary;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMP6COMPARESIGNATURE
    {
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMP6SIGNATURESINDEX
    {
        public ushort usIndex;
        public ushort usConfidenceLevel;
        public uint ulLength;
        public IntPtr lpComparisonData;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMP6COMPARERESULT
    {
        public ushort usCount;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMPOWERSAVECONTROL
    {
        public ushort usMaxPowerSaveRecoveryTime;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMCUERROR
    {
        public ushort wFailure;
        public IntPtr lpCashUnit;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMCOUNTSCHANGED
    {
        public ushort usCount;
        public IntPtr lpusCUNumList;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMPOSITIONINFO
    {
        public ushort wPosition;
        public ushort wAdditionalBunches;
        public ushort usBunchesRemaining;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMDEVICEPOSITION
    {
        public ushort wPosition;
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet
     = XFSConstants.CHARSET)]
    public struct WFSCIMPOWERSAVECHANGE
    {
        public ushort usPowerSaveRecoveryTime;
    }

   
}


