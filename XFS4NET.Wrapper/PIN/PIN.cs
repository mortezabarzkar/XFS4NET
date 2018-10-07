using XFS4NET.Wrapper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace XFS4NET.Wrapper.PIN
{
    public unsafe class PIN : XFSDeviceBase<WFSPINSTATUS, WFSPINCAPS>
    {

        public PIN()
        {
            commandHandlers = new Dictionary<int, XFSCommandHandler>();
            eventHandlers = new Dictionary<int, XFSEventHandler>();

            //eventHandlers.Add(PINDefinition.WFS_EXEE_PIN_KEY, new XFSEventHandler(null,OnPINKey));
        }
        public event Action<int> GetDataError;
        public event Action<string> PINKey;
        public event Action GetDataCompleted;
        public void GetData(ushort maxLen, bool autoEnd, XFSPINKey activeKeys, XFSPINKey terminateKeys, XFSPINKey activeFDKs = XFSPINKey.WFS_PIN_FK_UNUSED,
            XFSPINKey terminateFDKs = XFSPINKey.WFS_PIN_FK_UNUSED)
        {
            WFSPINGETDATA inputData = new WFSPINGETDATA();
            inputData.usMaxLen = maxLen;
            inputData.bAutoEnd = autoEnd;
            inputData.ulActiveFDKs = activeFDKs;
            inputData.ulActiveKeys = activeKeys;
            inputData.ulTerminateFDKs = terminateFDKs;
            inputData.ulTerminateKeys = terminateKeys;
            int len = Marshal.SizeOf(typeof(WFSPINGETDATA));
            IntPtr ptr = Marshal.AllocHGlobal(len);
            Marshal.StructureToPtr(inputData, ptr, false);
            int hResult = XfsApi.WFSAsyncExecute(hService, PINDefinition.WFS_CMD_PIN_GET_DATA, ptr, 0, Handle, ref requestID);
            Marshal.FreeHGlobal(ptr);
            if (hResult != XFSDefinition.WFS_SUCCESS)
                OnGetDataError(hResult);
        }
        protected override void OnExecuteComplete(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case PINDefinition.WFS_CMD_PIN_GET_DATA:
                    if (result.hResult != XFSDefinition.WFS_SUCCESS)
                        OnGetDataError(result.hResult);
                    else
                        if (GetDataCompleted != null)
                        GetDataCompleted.Invoke();
                    break;
            }
        }
        protected override void OnExecuteEvent(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case PINDefinition.WFS_EXEE_PIN_KEY:
                    WFSPINKEY key = new WFSPINKEY();
                    XFSUtil.PtrToStructure(result.lpBuffer, ref key);
                    L4Logger.Info("WFS_EXEE_PIN_KEY => " + key.ulDigit);
                    OnPINKey(ref key);
                    break;
            }
        }
        protected virtual void OnGetDataError(int code)
        {
            if (GetDataError != null)
                GetDataError(code);
        }
        protected virtual void OnPINKey(ref WFSPINKEY key)
        {
            if (PINKey != null)
                PINKey(key.ulDigit.ToString().Substring(11));
        }
        #region Virtual
        protected override int StatusCommandCode
        {
            get
            {
                return PINDefinition.WFS_INF_PIN_STATUS;
            }
        }
        protected override int CapabilityCommandCode
        {
            get
            {
                return PINDefinition.WFS_INF_PIN_CAPABILITIES;
            }
        }
        #endregion
    }
}
