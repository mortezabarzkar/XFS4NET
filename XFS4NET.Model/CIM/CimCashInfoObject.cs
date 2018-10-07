using XFS4NET.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.CIM
{
    public class CimCashInfoObject : ISTATUS, IXfsModel ,IXfsResultModel
    {
        public ushort usCount { get; set; }

        public CashIn[] CashIns { get; set; }

        public  ISTATUS UnMarshal(IntPtr pointer)
        {
            var cashinfoObj = new CimCashInfoObject();

            var cashunitInfo = new WFSCIMCASHINFO();
            XFSUtil.PtrToStructure<WFSCIMCASHINFO>(pointer, ref cashunitInfo);
            cashinfoObj.usCount = cashunitInfo.usCount;

            var cashUnits = XFSUtil.XFSPtrToArray<WFSCIMCASHIN>(cashunitInfo.lppCashIn, cashunitInfo.usCount);
            cashinfoObj.CashIns = new CashIn[cashUnits.Length];
            for (int i = 0; i < cashUnits.Length; i++)
            {
                cashinfoObj.CashIns[i] = CashIn.convertToCashIn(cashUnits[i]);
            }

            return cashinfoObj;
        }

        public IntPtr Marshal(CimCashInfoObject cashInfo)
        {
            WFSCIMCASHINFO dto = new WFSCIMCASHINFO();
            dto.usCount = cashInfo.usCount;
            WFSCIMCASHIN[] cashunitstructs = new WFSCIMCASHIN[cashInfo.CashIns.Length];
            for (int i = 0; i < cashInfo.CashIns.Length; i++)
            {
                cashunitstructs[i] = CashIn.convertToWFSCIMCASHIN(cashInfo.CashIns[i]);
            }

            dto.lppCashIn = XFSUtil.XFSArrayToPTR<WFSCIMCASHIN>(cashunitstructs);
            return XFSUtil.StructureToPtr<WFSCIMCASHINFO>(dto);
        }

        public IntPtr ToPopinter()
        {
            return Marshal(this);
        }

        public void Fill(object result)
        {
            var ptr = XFSUtil.StructureToPtr(result, typeof(WFSCIMCASHINFO));
            var data = (CimCashInfoObject) this.UnMarshal(ptr);
            this.TerminalCode = data.TerminalCode;
            this.CashIns = data.CashIns;
            this.Checksum = data.Checksum;
            this.TransactionCode = data.TransactionCode;
            this.usCount = data.usCount;
        }

        public long? TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the transaction code.
        /// </summary>
        /// <value>
        /// The transaction code.
        /// </value>
        public Guid TransactionCode { get; set; }

        /// <summary>
        /// Gets or sets the checksum.
        /// </summary>
        /// <value>
        /// The checksum.
        /// </value>
        public string Checksum { get; set; }

        /// <summary>
        /// Gets or sets the terminal identifier.
        /// </summary>
        /// <value>The terminal identifier.</value>
        public string TerminalCode { get; set; }
    }

    public class CashIn
    {
        public ushort usNumber { get; set; }
        public uint fwType { get; set; }
        public uint fwItemType { get; set; }
        public string cUnitID;
        public char[] cCurrencyID { get; set; }
        public uint ulValues { get; set; }
        public uint ulCashInCount { get; set; }
        public uint ulCount { get; set; }
        public uint ulMaximum { get; set; }
        public ushort usStatus { get; set; }
        public bool bAppLock { get; set; }
        public ushort usNumPhysicalCUs { get; set; }
        public WFSCIMPHCU[] lppPhysical { get; set; }
        public NoteNumberList lpNoteNumberList { get; set; }

        public string lpszExtra { get; set; }

        public static WFSCIMCASHIN convertToWFSCIMCASHIN(CashIn cashUnit)
        {
            WFSCIMCASHIN dtoCashUnit = new WFSCIMCASHIN();
            dtoCashUnit.usNumber = cashUnit.usNumber;
            dtoCashUnit.fwType = cashUnit.fwType;
            dtoCashUnit.fwItemType = cashUnit.fwItemType;
            dtoCashUnit.cUnitID = cashUnit.cUnitID;
            dtoCashUnit.cCurrencyID = cashUnit.cCurrencyID;
            dtoCashUnit.ulValues = cashUnit.ulValues;
            dtoCashUnit.ulCashInCount = cashUnit.ulCashInCount;
            dtoCashUnit.ulCount = cashUnit.ulCount;
            dtoCashUnit.ulMaximum = cashUnit.ulMaximum;
            dtoCashUnit.usStatus = cashUnit.usStatus;
            dtoCashUnit.bAppLock = cashUnit.bAppLock;
            dtoCashUnit.usNumPhysicalCUs = cashUnit.usNumPhysicalCUs;
            dtoCashUnit.lppPhysical = XFSUtil.XFSArrayToPTR<WFSCIMPHCU>(cashUnit.lppPhysical);
            return dtoCashUnit;
        }

        public static CashIn convertToCashIn(WFSCIMCASHIN item)
        {
            CashIn unit = new CashIn();
            unit.usNumber = item.usNumber;
            unit.fwType = item.fwType;
            unit.cUnitID = item.cUnitID;
            unit.cCurrencyID = item.cCurrencyID;
            unit.ulValues = item.ulValues;
            unit.ulCashInCount = item.ulCashInCount;
            unit.ulCount = item.ulCount;
            unit.ulMaximum = item.ulMaximum;
            unit.usStatus = item.usStatus;
            unit.bAppLock = item.bAppLock;
            unit.usNumPhysicalCUs = item.usNumPhysicalCUs;

            if (item.usNumPhysicalCUs > 0)
            {
                unit.lppPhysical = XFSUtil.XFSPtrToArray<WFSCIMPHCU>(item.lppPhysical, item.usNumPhysicalCUs);
            }
            else
            {
                unit.lppPhysical = new WFSCIMPHCU[0];
            }

            var notnumberList = new WFSCIMNOTENUMBERLIST();
            XFSUtil.PtrToStructure<WFSCIMNOTENUMBERLIST>(item.lpNoteNumberList, ref notnumberList);
            unit.lpNoteNumberList = convertToNoteNumberList(notnumberList);

            unit.lpszExtra = item.lpszExtra;

            return unit;
        }

        public static NoteNumberList convertToNoteNumberList(WFSCIMNOTENUMBERLIST item)
        {
            NoteNumberList noteNumberList = new NoteNumberList();
            noteNumberList.usNumOfNoteNumbers = item.usNumOfNoteNumbers;

            if (item.usNumOfNoteNumbers > 0)
            {
                noteNumberList.lppNoteNumber = XFSUtil.XFSPtrToArray<WFSCIMNOTENUMBER>(item.lppNoteNumber, item.usNumOfNoteNumbers);
            }
            else
            {
                noteNumberList.lppNoteNumber = new WFSCIMNOTENUMBER[0];
            }


            return noteNumberList;
        }
    }

    public class NoteNumberList
    {
        public ushort usNumOfNoteNumbers { get; set; }

        public WFSCIMNOTENUMBER[] lppNoteNumber { get; set; }
    }

    public struct NoteNumber
    {
        public ushort usNoteID { get; set; }

        public uint ulCount { get; set; }
    }
}
