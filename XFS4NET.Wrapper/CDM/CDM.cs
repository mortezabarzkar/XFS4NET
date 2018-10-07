using XFS4NET.Wrapper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XFS4NET.Wrapper.CDM
{
    public unsafe class CDM : XFSDeviceBase<WFSCDMSTATUS, WFSCDMCAPS>
    {
        public event Action<int> DispenseError;
        public event Action DispenComplete;
        public event Action<int> PresentError;
        public event Action PresentComplete;
        public event Action ItemsTaken;
        public void Dispense(int amount, bool present = false, string currency = "CNY")
        {
            WFSCDMDENOMINATION denomination = new WFSCDMDENOMINATION();
            denomination.cCurrencyID = currency.ToArray();
            denomination.lpulValues = IntPtr.Zero;
            denomination.ulAmount = amount;
            denomination.usCount = 0;
            WFSCDMDISPENSE dispense = new WFSCDMDISPENSE();
            dispense.bPresent = present;
            dispense.fwPosition = OutputPosition.WFS_CDM_POSNULL;
            dispense.usMixNumber = 1;
            dispense.lpDenomination = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WFSCDMDENOMINATION)));
            Marshal.StructureToPtr(denomination, dispense.lpDenomination, false);
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WFSCDMDISPENSE)));
            Marshal.StructureToPtr(dispense, ptr, false);
            int hResult = XfsApi.WFSAsyncExecute(hService, CDMDefinition.WFS_CMD_CDM_DISPENSE, ptr, 0, Handle, ref requestID);
            Marshal.FreeHGlobal(dispense.lpDenomination);
            Marshal.FreeHGlobal(ptr);
            if (hResult != XFSDefinition.WFS_SUCCESS)
                OnDispenseError(hResult);
        }
        public void Present()
        {
            OutputPosition pos = OutputPosition.WFS_CDM_POSNULL;
            int hResult = XfsApi.WFSAsyncExecute(hService, CDMDefinition.WFS_CMD_CDM_PRESENT, new IntPtr(&pos), 0, Handle, ref requestID);
            if (hResult != XFSDefinition.WFS_SUCCESS)
                OnPresetError(hResult);
        }
        protected override void OnExecuteComplete(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case CDMDefinition.WFS_CMD_CDM_DISPENSE:
                    if (result.hResult == XFSDefinition.WFS_SUCCESS)
                        OnDispenComplete();
                    else
                        OnDispenseError(result.hResult);
                    break;
                case CDMDefinition.WFS_CMD_CDM_PRESENT:
                    if (result.hResult == XFSDefinition.WFS_SUCCESS)
                        OnPresentComplete();
                    else
                        OnPresetError(result.hResult);
                    break;
            }
        }
        protected override void OnServiceEvent(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case CDMDefinition.WFS_SRVE_CDM_ITEMSTAKEN:
                    OnItemsTaken();
                    break;
            }
        }
        protected virtual void OnDispenseError(int code)
        {
            if (DispenseError != null)
                DispenseError(code);
        }
        protected virtual void OnDispenComplete()
        {
            if (DispenComplete != null)
                DispenComplete();
        }
        protected virtual void OnPresetError(int code)
        {
            if (PresentError != null)
                PresentError(code);
        }
        protected virtual void OnPresentComplete()
        {
            if (PresentComplete != null)
                PresentComplete();
        }
        protected virtual void OnItemsTaken()
        {
            if (ItemsTaken != null)
                ItemsTaken();
        }
        #region Virtual
        protected override int StatusCommandCode
        {
            get
            {
                return CDMDefinition.WFS_INF_CDM_STATUS;
            }
        }
        protected override int CapabilityCommandCode
        {
            get
            {
                return CDMDefinition.WFS_INF_CDM_CAPABILITIES;
            }
        }
        #endregion
    }
}
