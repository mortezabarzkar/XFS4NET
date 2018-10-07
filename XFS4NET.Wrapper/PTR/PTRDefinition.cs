using XFS4NET.Wrapper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Wrapper.PTR
{
    public static class PTRDefinition
    {
        public const int WFS_SERVICE_CLASS_PTR = 1;
        public const int PTR_SERVICE_OFFSET = WFS_SERVICE_CLASS_PTR * 100;
        public const int WFS_SERVICE_CLASS_VERSION_PTR = 0x0003;
        public const string WFS_SERVICE_CLASS_NAME_PTR = "PTR";


        /* PTR Info Commands */

        public const int WFS_INF_PTR_STATUS = (PTR_SERVICE_OFFSET + 1);
        public const int WFS_INF_PTR_CAPABILITIES = (PTR_SERVICE_OFFSET + 2);
        public const int WFS_INF_PTR_FORM_LIST = (PTR_SERVICE_OFFSET + 3);
        public const int WFS_INF_PTR_MEDIA_LIST = (PTR_SERVICE_OFFSET + 4);
        public const int WFS_INF_PTR_QUERY_FORM = (PTR_SERVICE_OFFSET + 5);
        public const int WFS_INF_PTR_QUERY_MEDIA = (PTR_SERVICE_OFFSET + 6);
        public const int WFS_INF_PTR_QUERY_FIELD = (PTR_SERVICE_OFFSET + 7);


        /* PTR Execute Commands */

        public const int WFS_CMD_PTR_CONTROL_MEDIA = (PTR_SERVICE_OFFSET + 1);
        public const int WFS_CMD_PTR_PRINT_FORM = (PTR_SERVICE_OFFSET + 2);
        public const int WFS_CMD_PTR_READ_FORM = (PTR_SERVICE_OFFSET + 3);
        public const int WFS_CMD_PTR_RAW_DATA = (PTR_SERVICE_OFFSET + 4);
        public const int WFS_CMD_PTR_MEDIA_EXTENTS = (PTR_SERVICE_OFFSET + 5);
        public const int WFS_CMD_PTR_RESET_COUNT = (PTR_SERVICE_OFFSET + 6);
        public const int WFS_CMD_PTR_READ_IMAGE = (PTR_SERVICE_OFFSET + 7);
        public const int WFS_CMD_PTR_RESET = (PTR_SERVICE_OFFSET + 8);
        public const int WFS_CMD_PTR_RETRACT_MEDIA = (PTR_SERVICE_OFFSET + 9);
        public const int WFS_CMD_PTR_DISPENSE_PAPER = (PTR_SERVICE_OFFSET + 10);


        /* PTR Messages */

        public const int WFS_EXEE_PTR_NOMEDIA = (PTR_SERVICE_OFFSET + 1);
        public const int WFS_EXEE_PTR_MEDIAINSERTED = (PTR_SERVICE_OFFSET + 2);
        public const int WFS_EXEE_PTR_FIELDERROR = (PTR_SERVICE_OFFSET + 3);
        public const int WFS_EXEE_PTR_FIELDWARNING = (PTR_SERVICE_OFFSET + 4);
        public const int WFS_USRE_PTR_RETRACTBINTHRESHOLD = (PTR_SERVICE_OFFSET + 5);
        public const int WFS_SRVE_PTR_MEDIATAKEN = (PTR_SERVICE_OFFSET + 6);
        public const int WFS_USRE_PTR_PAPERTHRESHOLD = (PTR_SERVICE_OFFSET + 7);
        public const int WFS_USRE_PTR_TONERTHRESHOLD = (PTR_SERVICE_OFFSET + 8);
        public const int WFS_SRVE_PTR_MEDIAINSERTED = (PTR_SERVICE_OFFSET + 9);
        public const int WFS_USRE_PTR_LAMPTHRESHOLD = (PTR_SERVICE_OFFSET + 10);
        public const int WFS_USRE_PTR_INKTHRESHOLD = (PTR_SERVICE_OFFSET + 11);
        public const int WFS_SRVE_PTR_MEDIADETECTED = (PTR_SERVICE_OFFSET + 12);



        /* values of WFSPTRSTATUS.fwMedia and
                     WFSPTRMEDIADETECTED.wPosition */




        /* Size and max index of fwPaper array */

        public const int WFS_PTR_SUPPLYSIZE = (16);
        public const int WFS_PTR_SUPPLYMAX = (WFS_PTR_SUPPLYSIZE - 1);

        /* values of WFSPTRPRINTFORM.wOffsetX and WFSPTRPRINTFORM.wOffsetY */

        public const int WFS_PTR_OFFSETUSEFORMDEFN = 0xffff;


        /* XFS PTR Errors */

        public const int WFS_ERR_PTR_FORMNOTFOUND = (-(PTR_SERVICE_OFFSET + 0));
        public const int WFS_ERR_PTR_FIELDNOTFOUND = (-(PTR_SERVICE_OFFSET + 1));
        public const int WFS_ERR_PTR_NOMEDIAPRESENT = (-(PTR_SERVICE_OFFSET + 2));
        public const int WFS_ERR_PTR_READNOTSUPPORTED = (-(PTR_SERVICE_OFFSET + 3));
        public const int WFS_ERR_PTR_FLUSHFAIL = (-(PTR_SERVICE_OFFSET + 4));
        public const int WFS_ERR_PTR_MEDIAOVERFLOW = (-(PTR_SERVICE_OFFSET + 5));
        public const int WFS_ERR_PTR_FIELDSPECFAILURE = (-(PTR_SERVICE_OFFSET + 6));
        public const int WFS_ERR_PTR_FIELDERROR = (-(PTR_SERVICE_OFFSET + 7));
        public const int WFS_ERR_PTR_MEDIANOTFOUND = (-(PTR_SERVICE_OFFSET + 8));
        public const int WFS_ERR_PTR_EXTENTNOTSUPPORTED = (-(PTR_SERVICE_OFFSET + 9));
        public const int WFS_ERR_PTR_MEDIAINVALID = (-(PTR_SERVICE_OFFSET + 10));
        public const int WFS_ERR_PTR_FORMINVALID = (-(PTR_SERVICE_OFFSET + 11));
        public const int WFS_ERR_PTR_FIELDINVALID = (-(PTR_SERVICE_OFFSET + 12));
        public const int WFS_ERR_PTR_MEDIASKEWED = (-(PTR_SERVICE_OFFSET + 13));
        public const int WFS_ERR_PTR_RETRACTBINFULL = (-(PTR_SERVICE_OFFSET + 14));
        public const int WFS_ERR_PTR_STACKERFULL = (-(PTR_SERVICE_OFFSET + 15));
        public const int WFS_ERR_PTR_PAGETURNFAIL = (-(PTR_SERVICE_OFFSET + 16));
        public const int WFS_ERR_PTR_MEDIATURNFAIL = (-(PTR_SERVICE_OFFSET + 17));
        public const int WFS_ERR_PTR_SHUTTERFAIL = (-(PTR_SERVICE_OFFSET + 18));
        public const int WFS_ERR_PTR_MEDIAJAMMED = (-(PTR_SERVICE_OFFSET + 19));
        public const int WFS_ERR_PTR_FILE_IO_ERROR = (-(PTR_SERVICE_OFFSET + 20));
        public const int WFS_ERR_PTR_CHARSETDATA = (-(PTR_SERVICE_OFFSET + 21));
        public const int WFS_ERR_PTR_PAPERJAMMED = (-(PTR_SERVICE_OFFSET + 22));
        public const int WFS_ERR_PTR_PAPEROUT = (-(PTR_SERVICE_OFFSET + 23));
        public const int WFS_ERR_PTR_INKOUT = (-(PTR_SERVICE_OFFSET + 24));
        public const int WFS_ERR_PTR_TONEROUT = (-(PTR_SERVICE_OFFSET + 25));
        public const int WFS_ERR_PTR_LAMPINOP = (-(PTR_SERVICE_OFFSET + 26));
        public const int WFS_ERR_PTR_SOURCEINVALID = (-(PTR_SERVICE_OFFSET + 27));
        public const int WFS_ERR_PTR_SEQUENCEINVALID = (-(PTR_SERVICE_OFFSET + 28));
        public const int WFS_ERR_PTR_MEDIASIZE = (-(PTR_SERVICE_OFFSET + 29));

    }



    /* Indices of WFSPTRSTATUS.fwPaper [...] */

    public enum PTRPaperStatus
    {
        WFS_PTR_SUPPLYUPPER = (0),
        WFS_PTR_SUPPLYLOWER = (1),
        WFS_PTR_SUPPLYEXTERNAL = (2),
        WFS_PTR_SUPPLYAUX = (3),
        WFS_PTR_SUPPLYAUX2 = (4),
        WFS_PTR_SUPPLYPARK = (5)
    }


    /* values of WFSPTRSTATUS.fwPaper and
                 WFSPTRPAPERTHRESHOLD.wPaperThreshold */
    public enum PTRStatusPaperTheshold
    {
        WFS_PTR_PAPERFULL = (0),
        WFS_PTR_PAPERLOW = (1),
        WFS_PTR_PAPEROUT = (2),
        WFS_PTR_PAPERNOTSUPP = (3),
        WFS_PTR_PAPERUNKNOWN = (4),
        WFS_PTR_PAPERJAMMED = (5)
    }

    /* values of WFSPTRSTATUS.fwToner */
    public enum PTRStatusToner
    {
        WFS_PTR_TONERFULL = (0),
        WFS_PTR_TONERLOW = (1),
        WFS_PTR_TONEROUT = (2),
        WFS_PTR_TONERNOTSUPP = (3),
        WFS_PTR_TONERUNKNOWN = (4)
    }

    /* values of WFSPTRSTATUS.fwInk */
    public enum PTRStatusFwInk
    {
        WFS_PTR_INKFULL = (0),
        WFS_PTR_INKLOW = (1),
        WFS_PTR_INKOUT = (2),
        WFS_PTR_INKNOTSUPP = (3),
        WFS_PTR_INKUNKNOWN = (4)
    }

    /* values of WFSPTRSTATUS.fwLamp */
    public enum PTRStatusFwLamp
    {
        WFS_PTR_LAMPOK = (0),
        WFS_PTR_LAMPFADING = (1),
        WFS_PTR_LAMPINOP = (2),
        WFS_PTR_LAMPNOTSUPP = (3),
        WFS_PTR_LAMPUNKNOWN = (4)
    }

    /* values of WFSPTRSTATUS.fwRetractBin and
                 WFSPTRBINTHRESHOLD.wRetractBin */
    public enum PTRStatusRetractionBin
    {
        WFS_PTR_RETRACTBINOK = (0),
        WFS_PTR_RETRACTBINFULL = (1),
        WFS_PTR_RETRACTNOTSUPP = (2),
        WFS_PTR_RETRACTUNKNOWN = (3),
        WFS_PTR_RETRACTBINHIGH = (4)
    }

    /* values of WFSPTRCAPS.fwType */
    public enum PTRCapsType
    {
        WFS_PTR_TYPERECEIPT = 0x0001,
        WFS_PTR_TYPEPASSBOOK = 0x0002,
        WFS_PTR_TYPEJOURNAL = 0x0004,
        WFS_PTR_TYPEDOCUMENT = 0x0008,
        WFS_PTR_TYPESCANNER = 0x0010
    }


    /* values of WFSPTRCAPS.wResolution, WFSPTRPRINTFORM.wResolution */
    public enum PTRCapsResoulotion
    {
        WFS_PTR_RESLOW = 0x0001,
        WFS_PTR_RESMED = 0x0002,
        WFS_PTR_RESHIGH = 0x0004,
        WFS_PTR_RESVERYHIGH = 0x0008,
    }


    /* values of WFSPTRCAPS.fwReadForm */
    public enum PTRCapsReadForm
    {
        WFS_PTR_READOCR = 0x0001,
        WFS_PTR_READMICR = 0x0002,
        WFS_PTR_READMSF = 0x0004,
        WFS_PTR_READBARCODE = 0x0008,
        WFS_PTR_READPAGEMARK = 0x0010,
        WFS_PTR_READIMAGE = 0x0020,
        WFS_PTR_READEMPTYLINE = 0x0040
    }

    /* values of WFSPTRCAPS.fwWriteForm */
    public enum PTRCapsWriteForm
    {
        WFS_PTR_WRITETEXT = 0x0001,
        WFS_PTR_WRITEGRAPHICS = 0x0002,
        WFS_PTR_WRITEOCR = 0x0004,
        WFS_PTR_WRITEMICR = 0x0008,
        WFS_PTR_WRITEMSF = 0x0010,
        WFS_PTR_WRITEBARCODE = 0x0020,
        WFS_PTR_WRITESTAMP = 0x0040
    }

    /* values of WFSPTRCAPS.fwExtents */
    public enum PTRCapsEvent
    {
        WFS_PTR_EXTHORIZONTAL = 0x0001,
        WFS_PTR_EXTVERTICAL = 0x0002
    }


    /* values of WFSPTRCAPS.fwControl, dwMediaControl */
    public enum PTRCapsFwControl
    {
        WFS_PTR_CTRLEJECT = 0x0001,
        WFS_PTR_CTRLPERFORATE = 0x0002,
        WFS_PTR_CTRLCUT = 0x0004,
        WFS_PTR_CTRLSKIP = 0x0008,
        WFS_PTR_CTRLFLUSH = 0x0010,
        WFS_PTR_CTRLRETRACT = 0x0020,
        WFS_PTR_CTRLSTACK = 0x0040,
        WFS_PTR_CTRLPARTIALCUT = 0x0080,
        WFS_PTR_CTRLALARM = 0x0100,
        WFS_PTR_CTRLATPFORWARD = 0x0200,
        WFS_PTR_CTRLATPBACKWARD = 0x0400,
        WFS_PTR_CTRLTURNMEDIA = 0x0800,
        WFS_PTR_CTRLSTAMP = 0x1000,
        WFS_PTR_CTRLPARK = 0x2000
    }

    /* values of WFSPTRCAPS.fwPaperSources,
                 WFSFRMMEDIA.wPaperSources,
                 WFSPTRPRINTFORM.wPaperSource and
                 WFSPTRPAPERTHRESHOLD.wPaperSource   */
    public enum PTRCapsPaperSource
    {
        WFS_PTR_PAPERANY = 0x0001,
        WFS_PTR_PAPERUPPER = 0x0002,
        WFS_PTR_PAPERLOWER = 0x0004,
        WFS_PTR_PAPEREXTERNAL = 0x0008,
        WFS_PTR_PAPERAUX = 0x0010,
        WFS_PTR_PAPERAUX2 = 0x0020,
        WFS_PTR_PAPERPARK = 0x0040
    }

    /* values of WFSPTRCAPS.fwImageType,
                 WFSPTRIMAGEREQUEST.wFrontImageFormat and
                 WFSPTRIMAGEREQUEST.wBackImageFormat */
    public enum PTRCapsFwImageType
    {
        WFS_PTR_IMAGETIF = 0x0001,
        WFS_PTR_IMAGEWMF = 0x0002,
        WFS_PTR_IMAGEBMP = 0x0004
    }

    /* values of WFSPTRCAPS.fwFrontImageColorFormat,
                 WFSPTRCAPS.fwBackImageColorFormat,
                 WFSPTRIMAGEREQUEST.wFrontImageColorFormat and
                 WFSPTRIMAGEREQUEST.wBackImageColorFormat */
    public enum PTRCapsFwFrontImageColorFormat
    {
        WFS_PTR_IMAGECOLORBINARY = 0x0001,
        WFS_PTR_IMAGECOLORGRAYSCALE = 0x0002,
        WFS_PTR_IMAGECOLORFULL = 0x0004
    }

    /* values of WFSPTRCAPS.fwCodelineFormat and
                 WFSPTRIMAGEREQUEST.wCodelineFormat */
    public enum PTRCapsFwCodeLineFormat
    {
        WFS_PTR_CODELINECMC7 = 0x0001,
        WFS_PTR_CODELINEE13B = 0x0002,
        WFS_PTR_CODELINEOCR = 0x0004
    }

    /* values of WFSPTRCAPS.fwImageSource,
                 WFSPTRIMAGEREQUEST.fwImageSource and
                 WFSPTRIMAGE.wImageSource */
    public enum PTRCapsFwImageSource
    {
        WFS_PTR_IMAGEFRONT = 0x0001,
        WFS_PTR_IMAGEBACK = 0x0002,
        WFS_PTR_CODELINE = 0x0004
    }

    /* values of WFSPTRCAPS.fwCharSupport, WFSFRMHEADER.fwCharSupport  */
    public enum PTRCapsCharSupport
    {
        WFS_PTR_ASCII = 0x0001,
        WFS_PTR_UNICODE = 0x0002
    }


    /* values of WFSFRMHEADER.wBase, WFSFRMMEDIA.wBase, WFSPTRMEDIAUNIT.wBase */
    public enum PTRFrmHeaderBase
    {
        WFS_FRM_INCH = (0),
        WFS_FRM_MM = (1),
        WFS_FRM_ROWCOLUMN = (2)
    }


    /* values of WFSFRMHEADER.wAlignment */
    public enum PTRFrmHeaderAlignment
    {
        WFS_FRM_TOPLEFT = (0),
        WFS_FRM_TOPRIGHT = (1),
        WFS_FRM_BOTTOMLEFT = (2),
        WFS_FRM_BOTTOMRIGHT = (3)
    }

    /* values of WFSFRMHEADER.wOrientation */
    public enum PTRFrmHeaderOrientation
    {
        WFS_FRM_PORTRAIT = (0),
        WFS_FRM_LANDSCAPE = (1),
    }


    /* values of WFSFRMMEDIA.fwMediaType */
    public enum PTRMFrmMediaType
    {
        WFS_FRM_MEDIAGENERIC = (0),
        WFS_FRM_MEDIAPASSBOOK = (1),
        WFS_FRM_MEDIAMULTIPART = (2)
    }

    /* values of WFSFRMMEDIA.fwFoldType */
    public enum PTRMediaFoldType
    {
        WFS_FRM_FOLDNONE = (0),
        WFS_FRM_FOLDHORIZONTAL = (1),
        WFS_FRM_FOLDVERTICAL = (2)
    }

    /* values of WFSFRMFIELD.fwType */
    public enum PTRFrmFieldType
    {
        WFS_FRM_FIELDTEXT = (0),
        WFS_FRM_FIELDMICR = (1),
        WFS_FRM_FIELDOCR = (2),
        WFS_FRM_FIELDMSF = (3),
        WFS_FRM_FIELDBARCODE = (4),
        WFS_FRM_FIELDGRAPHIC = (5),
        WFS_FRM_FIELDPAGEMARK = (6)
    }


    /* values of WFSFRMFIELD.fwClass */
    public enum PTRFrmFieldClass
    {
        WFS_FRM_CLASSSTATIC = (0),
        WFS_FRM_CLASSOPTIONAL = (1),
        WFS_FRM_CLASSREQUIRED = (2)
    }

    /* values of WFSFRMFIELD.fwAccess */
    public enum PTRFrmFieldAccess
    {
        WFS_FRM_ACCESSREAD = 0x0001,
        WFS_FRM_ACCESSWRITE = 0x0002
    }

    /* values of WFSFRMFIELD.fwOverflow */
    public enum PTRFrmFieldOverFlow
    {
        WFS_FRM_OVFTERMINATE = (0),
        WFS_FRM_OVFTRUNCATE = (1),
        WFS_FRM_OVFBESTFIT = (2),
        WFS_FRM_OVFOVERWRITE = (3),
        WFS_FRM_OVFWORDWRAP = (4)
    }

    /* values of WFSPTRFIELDFAIL.wFailure */
    public enum PTRFieldFailFailure
    {
        WFS_PTR_FIELDREQUIRED = (0),
        WFS_PTR_FIELDSTATICOVWR = (1),
        WFS_PTR_FIELDOVERFLOW = (2),
        WFS_PTR_FIELDNOTFOUND = (3),
        WFS_PTR_FIELDNOTREAD = (4),
        WFS_PTR_FIELDNOTWRITE = (5),
        WFS_PTR_FIELDHWERROR = (6),
        WFS_PTR_FIELDTYPENOTSUPPORTED = (7),
        WFS_PTR_FIELDGRAPHIC = (8),
        WFS_PTR_CHARSETFORM = (9)
    }

    /* values of WFSPTRPRINTFORM.wAlignment */
    public enum PTRPrintingFormAlignment
    {
        WFS_PTR_ALNUSEFORMDEFN = (0),
        WFS_PTR_ALNTOPLEFT = (1),
        WFS_PTR_ALNTOPRIGHT = (2),
        WFS_PTR_ALNBOTTOMLEFT = (3),
        WFS_PTR_ALNBOTTOMRIGHT = (4)
    }



    /* values of WFSPTRRAWDATA.wInputData */
    public enum PTRRawDataInput
    {
        WFS_PTR_NOINPUTDATA = (0),
        WFS_PTR_INPUTDATA = (1)
    }

    /* values of WFSPTRIMAGE.wStatus */
    public enum PTRStatusImage
    {
        WFS_PTR_DATAOK = (0),
        WFS_PTR_DATASRCNOTSUPP = (1),
        WFS_PTR_DATASRCMISSING = (2)
    }


    public enum PTRMediaStatus : ushort
    {
        WFS_PTR_MEDIAPRESENT = (0),
        WFS_PTR_MEDIANOTPRESENT = (1),
        WFS_PTR_MEDIAJAMMED = (2),
        WFS_PTR_MEDIANOTSUPP = (3),
        WFS_PTR_MEDIAUNKNOWN = (4),
        WFS_PTR_MEDIAENTERING = (5),
        WFS_PTR_MEDIARETRACTED = (6)
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRRETRACTBINS
    {
        public ushort wRetractBin { get; set; }
        public ushort usRetractCount { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRSTATUS
    {
        public DEVSTATUS fwDevice { get; set; }
        public PTRMediaStatus fwMedia { get; set; }
        public PTRStatusToner fwToner { get; set; }
        public PTRStatusFwInk fwInk { get; set; }
        public PTRStatusFwLamp fwLamp { get; set; }
        public ushort usMediaOnStacker { get; set; }
        public string lpszExtra { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRCAPS
    {
        public ushort wClass { get; set; }
        public PTRCapsType fwType { get; set; }
        public bool bCompound { get; set; }
        public PTRCapsResoulotion wResolution { get; set; }
        public PTRCapsReadForm fwReadForm { get; set; }
        public PTRCapsWriteForm fwWriteForm { get; set; }
        public ushort fwExtents { get; set; }
        public PTRCapsFwControl fwControl { get; set; }
        public ushort usMaxMediaOnStacker { get; set; }
        public PTRMFrmMediaType bAcceptMedia { get; set; }
        public bool bMultiPage { get; set; }
        public ushort fwPaperSources { get; set; }
        public bool bMediaTaken { get; set; }
        public ushort usRetractBins { get; set; }
        public String lpusMaxRetract { get; set; }
        public PTRCapsFwImageType fwImageType { get; set; }
        public PTRCapsFwFrontImageColorFormat fwFrontImageColorFormat { get; set; }
        public ushort fwBackImageColorFormat { get; set; }
        public ushort fwCodelineFormat { get; set; }
        public PTRCapsFwImageSource fwImageSource { get; set; }
        public PTRCapsCharSupport fwCharSupport { get; set; }
        public bool bDispensePaper { get; set; }
        public string lpszExtra { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSFRMHEADER
    {
        public string lpszFormName { get; set; }
        public ushort wBase { get; set; }
        public ushort wUnitX { get; set; }
        public ushort wUnitY { get; set; }
        public ushort wWidth { get; set; }
        public ushort wHeight { get; set; }
        public ushort wAlignment { get; set; }
        public ushort wOrientation { get; set; }
        public ushort wOffsetX { get; set; }
        public ushort wOffsetY { get; set; }
        public ushort wVersionMajor { get; set; }
        public ushort wVersionMinor { get; set; }
        public string lpszUserPrompt { get; set; }
        public ushort fwCharSupport { get; set; }
        public string lpszFields { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSFRMMEDIA
    {
        public ushort fwMediaType { get; set; }
        public ushort wBase { get; set; }
        public ushort wUnitX { get; set; }
        public ushort wUnitY { get; set; }
        public ushort wSizeWidth { get; set; }
        public ushort wSizeHeight { get; set; }
        public ushort wPageCount { get; set; }
        public ushort wLineCount { get; set; }
        public ushort wPrintAreaX { get; set; }
        public ushort wPrintAreaY { get; set; }
        public ushort wPrintAreaWidth { get; set; }
        public ushort wPrintAreaHeight { get; set; }
        public ushort wRestrictedAreaX { get; set; }
        public ushort wRestrictedAreaY { get; set; }
        public ushort wRestrictedAreaWidth { get; set; }
        public ushort wRestrictedAreaHeight { get; set; }
        public ushort wStagger { get; set; }
        public ushort wFoldType { get; set; }
        public ushort wPaperSources { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRQUERYFIELD
    {
        public string lpszFormName { get; set; }
        public string lpszFieldName { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSFRMFIELD
    {
        public string lpszFieldName { get; set; }
        public ushort wIndexCount { get; set; }
        public ushort fwType { get; set; }
        public ushort fwClass { get; set; }
        public ushort fwAccess { get; set; }
        public ushort fwOverflow { get; set; }
        public string lpszInitialValue { get; set; }
        public String lpszUNICODEInitialValue { get; set; }
        public string lpszFormat { get; set; }
        public String lpszUNICODEFormat { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRPRINTFORM
    {
        public string lpszFormName { get; set; }
        public string lpszMediaName { get; set; }
        public ushort wAlignment { get; set; }
        public ushort wOffsetX { get; set; }
        public ushort wOffsetY { get; set; }
        public ushort wResolution { get; set; }
        public int dwMediaControl { get; set; }
        public string lpszFields { get; set; }
        public String lpszUNICODEFields { get; set; }
        public ushort wPaperSource { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRREADFORM
    {
        public string lpszFormName { get; set; }
        public string lpszFieldNames { get; set; }
        public string lpszMediaName { get; set; }
        public int dwMediaControl { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRREADFORMOUT
    {
        public string lpszFields { get; set; }
        public String lpszUNICODEFields { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRRAWDATA
    {
        public ushort wInputData { get; set; }
        public uint ulSize { get; set; }
        public IntPtr lpbData { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRRAWDATAIN
    {
        public uint ulSize { get; set; }
        public IntPtr lpbData { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRMEDIAUNIT
    {
        public ushort wBase { get; set; }
        public ushort wUnitX { get; set; }
        public ushort wUnitY { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRMEDIAEXT
    {
        public uint ulSizeX { get; set; }
        public uint ulSizeY { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRIMAGEREQUEST
    {
        public ushort wFrontImageType { get; set; }
        public ushort wBackImageType { get; set; }
        public ushort wFrontImageColorFormat { get; set; }
        public ushort wBackImageColorFormat { get; set; }
        public ushort wCodelineFormat { get; set; }
        public ushort fwImageSource { get; set; }
        public string lpszFrontImageFile { get; set; }
        public string lpszBackImageFile { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRIMAGE
    {
        public ushort wImageSource { get; set; }
        public ushort wStatus { get; set; }
        public uint ulDataLength { get; set; }
        public IntPtr lpbData { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRRESET
    {
        public int dwMediaControl { get; set; }
        public ushort usRetractBinNumber { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRFIELDFAIL
    {
        public string lpszFormName { get; set; }
        public string lpszFieldName { get; set; }
        public ushort wFailure { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRBINTHRESHOLD
    {
        public ushort usBinNumber { get; set; }
        public ushort wRetractBin { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRPAPERTHRESHOLD
    {
        public ushort wPaperSource { get; set; }
        public ushort wPaperThreshold { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRMEDIADETECTED
    {
        public ushort wPosition { get; set; }
        public ushort usRetractBinNumber { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]
    public struct WFSPTRCONTROLMEDIA
    {
        public int dwMediaControl;
    }
}
