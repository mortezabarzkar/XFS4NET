using XFS4NET.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.CDM
{
    public class CashInfoObject : ISTATUS , IXfsModel
    {
        public ushort TellerID
        {
            get;
            set;
        }

        public ushort usCount
        {
            get;
            set;
        }

        public CashUnit[] CashUnits
        {
            get;
            set;
        }

        public ISTATUS UnMarshal(IntPtr pointer)
        {
            var cashinfoObj = new CashInfoObject();

            var cashunitInfo = new WFS_CDM_CashUnit_INFO();
            XFSUtil.PtrToStructure<WFS_CDM_CashUnit_INFO>(pointer, ref cashunitInfo);

            cashinfoObj.TellerID = cashunitInfo.usTellerID;
            cashinfoObj.usCount = cashunitInfo.usCount;

            var cashUnits = XFSUtil.XFSPtrToArray<WFSCDMCASHUNIT>(cashunitInfo.lppList, cashunitInfo.usCount);
            cashinfoObj.CashUnits = new CashUnit[cashUnits.Length];

            for (int i = 0; i < cashUnits.Length; i++)
            {
                cashinfoObj.CashUnits[i] = CashUnit.convertToCashUnit(cashUnits[i]);
            }

            return cashinfoObj;
        }

        public  IntPtr Marshal(CashInfoObject cashInfo)
        {
            WFS_CDM_CashUnit_INFO dto = new WFS_CDM_CashUnit_INFO();
            dto.usCount = cashInfo.usCount;
            dto.usTellerID = cashInfo.TellerID;
            WFSCDMCASHUNIT[] cashunitstructs = new WFSCDMCASHUNIT[cashInfo.CashUnits.Length];
            for (int i = 0; i < cashInfo.CashUnits.Length; i++)
            {
                cashunitstructs[i] = CashUnit.convertToWFSCDMCASHUNIT(cashInfo.CashUnits[i]);
            }

            dto.lppList = XFSUtil.XFSArrayToPTR<WFSCDMCASHUNIT>(cashunitstructs);
            return XFSUtil.StructureToPtr<WFS_CDM_CashUnit_INFO>(dto);
        }

        public IntPtr ToPopinter()
        {
            return Marshal(this);
        }
    }

    public class CashUnit
    {
        public ushort usNumber;
        public ushort usType;
        public string szCashUnitName;
        public string cUnitID;
        public char[] cCurrencyID;
        public uint ulValues;
        public uint ulInitialCount;
        public uint ulCount;
        public uint ulRejectCount;
        public uint ulMinimum;
        public uint ulMaximum;
        public bool bAppLock;
        public ushort usStatus;
        public ushort usNumPhysicalCUs;
        public WFSCDMPHCU[] PhysicalCashUnits
        {
            get;
            set;
        }

        public static WFSCDMCASHUNIT convertToWFSCDMCASHUNIT(CashUnit cashUnit)
        {
            WFSCDMCASHUNIT dtoCashUnit = new WFSCDMCASHUNIT();
            dtoCashUnit.bAppLock = cashUnit.bAppLock;
            dtoCashUnit.cCurrencyID = cashUnit.cCurrencyID;
            dtoCashUnit.cUnitID = cashUnit.cUnitID;
            dtoCashUnit.szCashUnitName = cashUnit.szCashUnitName;
            dtoCashUnit.ulCount = cashUnit.ulCount;
            dtoCashUnit.ulInitialCount = cashUnit.ulInitialCount;
            dtoCashUnit.ulMaximum = cashUnit.ulMaximum;
            dtoCashUnit.ulMinimum = cashUnit.ulMinimum;
            dtoCashUnit.ulRejectCount = cashUnit.ulRejectCount;
            dtoCashUnit.ulValues = cashUnit.ulValues;
            dtoCashUnit.usNumber = cashUnit.usNumber;
            dtoCashUnit.usNumPhysicalCUs = cashUnit.usNumPhysicalCUs;
            dtoCashUnit.usStatus = cashUnit.usStatus;
            dtoCashUnit.usType = cashUnit.usType;
            dtoCashUnit.lppPhysical = XFSUtil.XFSArrayToPTR<WFSCDMPHCU>(cashUnit.PhysicalCashUnits);
            return dtoCashUnit;
        }

        public static CashUnit convertToCashUnit(WFSCDMCASHUNIT item)
        {
            CashUnit unit = new CashUnit();
            unit.bAppLock = item.bAppLock;
            unit.cCurrencyID = item.cCurrencyID;
            unit.cUnitID = item.cUnitID;
            unit.szCashUnitName = item.szCashUnitName;
            unit.ulCount = item.ulCount;
            unit.ulInitialCount = item.ulInitialCount;
            unit.ulMaximum = item.ulMaximum;
            unit.ulMinimum = item.ulMinimum;
            unit.ulRejectCount = item.ulRejectCount;
            unit.ulValues = item.ulValues;
            unit.usNumber = item.usNumber;
            unit.usNumPhysicalCUs = item.usNumPhysicalCUs;
            unit.usStatus = item.usStatus;
            unit.usType = item.usType;

            if (item.usNumPhysicalCUs > 0)
            {
                unit.PhysicalCashUnits = XFSUtil.XFSPtrToArray<WFSCDMPHCU>(item.lppPhysical, item.usNumPhysicalCUs);
            }
            else
            {
                unit.PhysicalCashUnits = new WFSCDMPHCU[0];
            }

            return unit;
        }
    }
}
