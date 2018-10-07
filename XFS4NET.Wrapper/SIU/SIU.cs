using XFS4NET.Wrapper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace XFS4NET.Wrapper.SIU
{
    public unsafe class SIU : XFSDeviceBase<WFSSIUSTATUS, WFSSIUCAPS>
    {

        public SIU()
        {
            commandHandlers = new Dictionary<int, XFSCommandHandler>();
            eventHandlers = new Dictionary<int, XFSEventHandler>();
        }
        public void SetGuidLight(GuidLights pos, LightControl con)
        {
            SetGuidLight((int)pos, con);
        }
        public void SetGuidLight(int pos, LightControl con)
        {
            WFSSIUSETGUIDLIGHT guidLight = new WFSSIUSETGUIDLIGHT();
            guidLight.fwCommand = con;
            guidLight.wGuidLight = (ushort)pos;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WFSSIUSETGUIDLIGHT)));
            Marshal.StructureToPtr(guidLight, ptr, false);
            int hResult = XfsApi.WFSAsyncExecute(hService, SIUDefinition.WFS_CMD_SIU_SET_GUIDLIGHT, ptr, 0, Handle, ref requestID);
        }
        protected override int GetEventClass()
        {
            return base.GetEventClass() & (~XFSDefinition.USER_EVENTS);
        }
        #region Virtual
        protected override int StatusCommandCode
        {
            get
            {
                return SIUDefinition.WFS_INF_SIU_STATUS;
            }
        }
        protected override int CapabilityCommandCode
        {
            get
            {
                return SIUDefinition.WFS_INF_SIU_CAPABILITIES;
            }
        }
        #endregion
    }
}
