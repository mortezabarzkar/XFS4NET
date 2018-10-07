using XFS4NET.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.BCR
{
    public static class BCRDefinition
    {
        public const int WFS_SERVICE_CLASS_BCR = 15;
        public const int BCR_SERVICE_OFFSET = WFS_SERVICE_CLASS_BCR * 100;
        public const string WFS_SERVICE_CLASS_NAME_IDC = "BCR";
        public const int WFS_SERVICE_CLASS_VERSION_BCR = 0x0A03;

        public const int WFS_INF_BCR_STATUS = BCR_SERVICE_OFFSET + 1;
        public const int WFS_INF_BCR_CAPABILITIES = BCR_SERVICE_OFFSET + 2;
        public const int WFS_CMD_BCR_READ = BCR_SERVICE_OFFSET + 1;
        public const int WFS_CMD_BCR_RESET = BCR_SERVICE_OFFSET + 2;
        public const int WFS_CMD_BCR_SET_GUIDANCE_LIGHT = BCR_SERVICE_OFFSET + 3;
        public const int WFS_CMD_BCR_POWER_SAVE_CONTROL = BCR_SERVICE_OFFSET + 4;
        public const int WFS_SRVE_BCR_DEVICEPOSITION = BCR_SERVICE_OFFSET + 1;
        public const int WFS_SRVE_BCR_POWER_SAVE_CHANGE = BCR_SERVICE_OFFSET + 2;
        public const int WFS_BCR_SCANNERON = 0;
        public const int WFS_BCR_SCANNEROFF = 1;
        public const int WFS_BCR_SCANNERINOP = 2;
        public const int WFS_BCR_SCANNERUNKNOWN = 3;
        public const int WFS_BCR_DEVICEINPOSITION = 0;
        public const int WFS_BCR_DEVICENOTINPOSITION = 1;
        public const int WFS_BCR_DEVICEPOSUNKNOWN = 2;
        public const int WFS_BCR_DEVICEPOSNOTSUPP = 3;



        public const int WFS_BCR_GUIDLIGHTS_SIZE = 32;
        public const int WFS_BCR_GUIDLIGHTS_MAX = WFS_BCR_GUIDLIGHTS_SIZE - 1;
        public const int WFS_BCR_GUIDANCE_BCR = 0;
        public const int WFS_BCR_GUIDANCE_NOT_AVAILABLE = 0x00000000;
        public const int WFS_BCR_GUIDANCE_OFF = 0x00000001;
        public const int WFS_BCR_GUIDANCE_ON = 0x00000002;
        public const int WFS_BCR_GUIDANCE_SLOW_FLASH = 0x00000004;
        public const int WFS_BCR_GUIDANCE_MEDIUM_FLASH = 0x00000008;
        public const int WFS_BCR_GUIDANCE_QUICK_FLASH = 0x00000010;
        public const int WFS_BCR_GUIDANCE_CONTINUOUS = 0x00000080;
        public const int WFS_BCR_GUIDANCE_RED = 0x00000100;
        public const int WFS_BCR_GUIDANCE_GREEN = 0x00000200;
        public const int WFS_BCR_GUIDANCE_YELLOW = 0x00000400;
        public const int WFS_BCR_GUIDANCE_BLUE = 0x00000800;
        public const int WFS_BCR_GUIDANCE_CYAN = 0x00001000;
        public const int WFS_BCR_GUIDANCE_MAGENTA = 0x00002000;
        public const int WFS_BCR_GUIDANCE_WHITE = 0x00004000;
    }

    public enum WorkingMode
    {
        None,
        ReadData,
        GettingStatus
    }
    [Flags]
        public enum BarcodeType : ushort
        {
            WFS_BCR_SYM_UNKNOWN = 0,
            WFS_BCR_SYM_EAN128 = 1,
            WFS_BCR_SYM_EAN8 = 2,
            WFS_BCR_SYM_EAN8_2 = 3,
            WFS_BCR_SYM_EAN8_5 = 4,
            WFS_BCR_SYM_EAN13 = 5,
            WFS_BCR_SYM_EAN13_2 = 6,
            WFS_BCR_SYM_EAN13_5 = 7,
            WFS_BCR_SYM_JAN13 = 8,
            WFS_BCR_SYM_UPCA = 9,
            WFS_BCR_SYM_UPCE0 = 10,
            WFS_BCR_SYM_UPCE0_2 = 11,
            WFS_BCR_SYM_UPCE0_5 = 12,
            WFS_BCR_SYM_UPCE1 = 13,
            WFS_BCR_SYM_UPCE1_2 = 14,
            WFS_BCR_SYM_UPCE1_5 = 15,
            WFS_BCR_SYM_UPCA_2 = 16,
            WFS_BCR_SYM_UPCA_5 = 17,
            WFS_BCR_SYM_CODABAR = 18,
            WFS_BCR_SYM_ITF = 19,
            WFS_BCR_SYM_11 = 20,
            WFS_BCR_SYM_39 = 21,
            WFS_BCR_SYM_49 = 22,
            WFS_BCR_SYM_93 = 23,
            WFS_BCR_SYM_128 = 24,
            WFS_BCR_SYM_MSI = 25,
            WFS_BCR_SYM_PLESSEY = 26,
            WFS_BCR_SYM_STD2OF5 = 27,
            WFS_BCR_SYM_STD2OF5_IATA = 28,
            WFS_BCR_SYM_PDF_417 = 29,
            WFS_BCR_SYM_MICROPDF_417 = 30,
            WFS_BCR_SYM_DATAMATRIX = 31,
            WFS_BCR_SYM_MAXICODE = 32,
            WFS_BCR_SYM_CODEONE = 33,
            WFS_BCR_SYM_CHANNELCODE = 34,
            WFS_BCR_SYM_TELEPEN_ORIGINAL = 35,
            WFS_BCR_SYM_TELEPEN_AIM = 36,
            WFS_BCR_SYM_RSS = 37,
            WFS_BCR_SYM_RSS_EXPANDED = 38,
            WFS_BCR_SYM_RSS_RESTRICTED = 39,
            WFS_BCR_SYM_COMPOSITE_CODE_A = 40,
            WFS_BCR_SYM_COMPOSITE_CODE_B = 41,
            WFS_BCR_SYM_COMPOSITE_CODE_C = 42,
            WFS_BCR_SYM_POSICODE_A = 43,
            WFS_BCR_SYM_POSICODE_B = 44,
            WFS_BCR_SYM_TRIOPTIC_CODE_39 = 45,
            WFS_BCR_SYM_CODABLOCK_F = 46,
            WFS_BCR_SYM_CODE_16K = 47,
            WFS_BCR_SYM_QRCODE = 48,
            WFS_BCR_SYM_AZTEC = 49,
            WFS_BCR_SYM_UKPOST = 50,
            WFS_BCR_SYM_PLANET = 51,
            WFS_BCR_SYM_POSTNET = 52,
            WFS_BCR_SYM_CANADIANPOST = 53,
            WFS_BCR_SYM_NETHERLANDSPOST = 54,
            WFS_BCR_SYM_AUSTRALIANPOST = 55,
            WFS_BCR_SYM_JAPANESEPOST = 56,
            WFS_BCR_SYM_CHINESEPOST = 57,
            WFS_BCR_SYM_KOREANPOST = 58,
        }

        [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
        public unsafe class WFSBCRSTATUS :ISTATUS
        {
            public DEVSTATUS fwDevice;
            public ushort fwBCRScanner;
            public string lpszExtra;
            public ushort wDevicePosition;
            public ushort usPowerSaveRecoveryTime;

        public ISTATUS UnMarshal(IntPtr pointer)
        {
            WFSBCRSTATUS value = new WFSBCRSTATUS();
            Common.XFSUtil.PtrToStructure(pointer, ref value);
            return value;
        }
    }
        [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
        public unsafe class WFSBCRCAPS :ICAPS
        {
            public ushort wClass;
            public bool bCompound;
            public bool bCanFilterSymbologies;
            public UIntPtr lpwSymbologies;
            public string lpszExtra;
            public bool bPowerSaveControl;
        }
        [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
        public struct WFSBCRXDATA
        {
            public ushort usLength;
            public IntPtr lpbData;
        }
        [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
        public struct WFSBCRREADINPUT
        {
            public ushort lpwSymbologies;
        }
        [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
        public struct WFSBCRREADOUTPUT
        {
            public ushort wSymbology;
            public IntPtr lpxBarcodeData;
            public string lpszSymbologyName;
        }
        [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
        public struct WFSBCRSETGUIDLIGHT
        {
            public ushort wGuidLight;
            public int dwCommand;
        }
        [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
        public struct WFSBCRPOWERSAVECONTROL
        {
            public ushort usMaxPowerSaveRecoveryTime;
        }
        [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
        public struct WFSBCRDEVICEPOSITION
        {
            public ushort wPosition;
        }
        [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
        public struct WFSBCRPOWERSAVECHANGE
        {
            public ushort usPowerSaveRecoveryTime;
        }


        [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
        public struct WFSBCRPHEXDATA
        {
            public ushort usLength;
            public IntPtr lpbData;
        }
    
}