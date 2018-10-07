using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFS4NET.Wrapper.Common;
using System.Runtime.InteropServices;
using System.Reflection;
using static XFS4NET.Wrapper.PTR.PTRDefinition;

namespace XFS4NET.Wrapper.PTR
{
    public unsafe class PTR : XFSDeviceBase<WFSPTRSTATUS, WFSPTRCAPS>
    {
        public event Action<int> PrintErrorError;

        public event Action PrintCompleted;
        public PTR()
        {
            commandHandlers = new Dictionary<int, XFSCommandHandler>();
            eventHandlers = new Dictionary<int, XFSEventHandler>();

            eventHandlers.Add(PTRDefinition.WFS_SRVE_PTR_MEDIATAKEN, new XFSEventHandler(PTR_MEDIATAKEN));
        }

        public void RejectAndCut()
        {
            try
            {
                L4Logger.Info(MethodBase.GetCurrentMethod().Name + "  Start");
                this.Invoke(new Action(() =>
                {
                    //L4Logger.Info("PTR Execute => WFS_CMD_PTR_CONTROL_MEDIA");
                    WFSPTRCONTROLMEDIA ptrmedia = new WFSPTRCONTROLMEDIA();
                    ptrmedia.dwMediaControl = (int) PTRCapsFwControl.WFS_PTR_CTRLEJECT | (int)PTRCapsFwControl.WFS_PTR_CTRLCUT;

                    IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WFSPTRCONTROLMEDIA)));
                    Marshal.StructureToPtr(ptrmedia, ptr, false);

                    int hResult = XfsApi.WFSAsyncExecute(hService, PTRDefinition.WFS_CMD_PTR_CONTROL_MEDIA, ptr, 0, Handle, ref requestID);
                    //L4Logger.Info(string.Format("PTR RejectAndCut requestID {0}  Result = {1}", requestID, hResult));
                    if (hResult != XFSDefinition.WFS_SUCCESS)
                        OnPrintErrorError(hResult);
                    else
                        OnPrintCompleted();
                }));
            }
            catch (Exception ex)
            {
                L4Logger.Info(ex.ToString());
            }
        }

        private void OnPrintCompleted()
        {
            if (PrintCompleted != null)
                PrintCompleted.Invoke();
        }

        private void OnPrintErrorError(int hResult)
        {
            if (PrintErrorError != null)
                PrintErrorError.Invoke(hResult);
        }
        protected override void OnExecuteComplete(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {

            }
        }
        protected override void OnExecuteEvent(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case PTRDefinition.WFS_SRVE_PTR_MEDIATAKEN:
                    {

                        break;
                    }
            }
        }
        private void PTR_MEDIATAKEN()
        {

        }

        protected virtual void OnGetDataError(int code)
        {

        }

        #region Virtual
        protected override int StatusCommandCode
        {
            get
            {
                return PTRDefinition.WFS_INF_PTR_STATUS;
            }
        }
        protected override int CapabilityCommandCode
        {
            get
            {
                return PTRDefinition.WFS_INF_PTR_CAPABILITIES;
            }
        }
        #endregion
    }
}
