using XFS4NET.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using XFS4NET.Logger;

namespace XFS4NET.Model.CDM
{

    public class WFSCDMDENOMINATIONModel : IXfsModel, IXfsResultModel
    {
        public char[] cCurrencyID;
        public int ulAmount;
        public ushort usCount;
        public IntPtr lpulValues;
        public int ulCashBox;

        public void Fill(object result)
        {
            var data = (WFSCDMDENOMINATION)result;
            this.cCurrencyID = data.cCurrencyID;
            this.lpulValues = IntPtr.Zero;
            this.ulAmount = data.ulAmount;
            this.ulCashBox = data.ulCashBox;
            this.usCount = data.usCount;
        }

        public IntPtr ToPopinter()
        {
            WFSCDMDENOMINATION param = new WFSCDMDENOMINATION
            {
                cCurrencyID = this.cCurrencyID,
                lpulValues = IntPtr.Zero,
                ulAmount = ulAmount,
                ulCashBox = this.ulCashBox,
                usCount = this.usCount
            };
            return XFSUtil.StructureToPtr(param, typeof(WFSCDMDENOMINATION));
        }
    }

    public class WFSCDMDISPENSEModel : IXfsModel
    {
        public ushort usTellerID;
        public ushort usMixNumber;
        public OutputPosition fwPosition;
        public bool bPresent;
        public WFSCDMDENOMINATIONModel lpDenomination;

        public IntPtr ToPopinter()
        {
            WFSCDMDISPENSE param = new WFSCDMDISPENSE
            {
                bPresent = this.bPresent,
                fwPosition = this.fwPosition,
                lpDenomination =  this.lpDenomination.ToPopinter(),
                usMixNumber = this.usMixNumber,
                usTellerID = this.usTellerID
            };
            return XFSUtil.StructureToPtr(param, typeof(WFSCDMDISPENSE));
        }
    }

    public class WFS_CDM_STATUS_Model : IXfsResultModel
    {
        public UInt16 fwDevice;

        public UInt16 fwSafeDoor;

        public UInt16 fwDispenser;

        public UInt16 fwIntermediateStacker;

        public WFS_CDM_OUTPOS lppPositions;

        public string lpszExtra;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CDMDefinition.WFS_CDM_GUIDLIGHTS_SIZE)]
        public uint[] dwGuidLights;//[CDMDefinition.WFS_CDM_GUIDLIGHTS_SIZE];

        public UInt16 wDevicePosition;

        public UInt16 usPowerSaveRecoveryTime;

        public void Fill(object result)
        {
            var data = (WFS_CDM_STATUS)result;
            this.dwGuidLights = data.dwGuidLights;
            this.fwDevice = data.fwDevice;
            this.fwDispenser = data.fwDispenser;
            this.fwIntermediateStacker = data.fwIntermediateStacker;
            this.fwSafeDoor = data.fwSafeDoor;
            this.lpszExtra = data.lpszExtra;
            this.usPowerSaveRecoveryTime = data.usPowerSaveRecoveryTime;
            this.wDevicePosition = data.wDevicePosition;
            var tmp = Activator.CreateInstance(typeof(WFS_CDM_OUTPOS));
            XFSUtil.PtrToStructure(data.lppPositions, typeof(WFS_CDM_OUTPOS), ref tmp);

            try
            {
                this.lppPositions = new WFS_CDM_OUTPOS
                {
                    fwPosition = ((WFS_CDM_OUTPOS)tmp).fwPosition,
                    fwPositionStatus = ((WFS_CDM_OUTPOS)tmp).fwPositionStatus,
                    fwShutter = ((WFS_CDM_OUTPOS)tmp).fwShutter,
                    fwTransport = ((WFS_CDM_OUTPOS)tmp).fwTransport,
                    fwTransportStatus = ((WFS_CDM_OUTPOS)tmp).fwTransportStatus
                };
            }
            catch(Exception ex)
            {
                L4Logger.Error(ex);
                L4Logger.Info(string.Format("Device Result => {0}  And PositionXfs {1} )", Newtonsoft.Json.JsonConvert.SerializeObject(tmp), data.lppPositions));
                this.lppPositions = new WFS_CDM_OUTPOS();
            }
        }
    }


}
