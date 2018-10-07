using XFS4NET.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using XFS4NET.Logger;

namespace XFS4NET.Model.CIM
{

    public class WFSCIMNOTENUMBERLIST_Model : IXfsResultModel
    {
        public ushort usNumOfNoteNumbers;

        public WFSCIMNOTENUMBER[] lppNoteNumber;
        public void Fill(object result)
        {
            var data = (WFSCIMNOTENUMBERLIST)result;
            this.usNumOfNoteNumbers = data.usNumOfNoteNumbers;
            this.lppNoteNumber = new WFSCIMNOTENUMBER[this.usNumOfNoteNumbers];

            for (int j = 0; j < this.usNumOfNoteNumbers; j++)
            {
                IntPtr noteNumber = Marshal.ReadIntPtr(data.lppNoteNumber, j * IntPtr.Size);
                lppNoteNumber[j] = (WFSCIMNOTENUMBER)Marshal.PtrToStructure(noteNumber, typeof(WFSCIMNOTENUMBER));
            }
        }
    }

    public class WFS_CIM_STATUS_Model : IXfsResultModel
    {
        public ushort fwDevice;
        public ushort fwSafeDoor;
        public ushort fwAcceptor;
        public ushort fwIntermediateStacker;
        public ushort fwStackerItems;
        public ushort fwBanknoteReader;
        public Boolean bDropBox;
        public WFSCIMOUTPOS lppPositions;
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string lpszExtra;

        public void Fill(object result)
        {
            var data = (WFSCIMSTATUS)result;
            this.fwDevice = data.fwDevice;
            this.fwIntermediateStacker = data.fwIntermediateStacker;
            this.fwSafeDoor = data.fwSafeDoor;
            this.lpszExtra = data.lpszExtra;
            this.fwAcceptor = data.fwAcceptor;
            this.fwStackerItems = data.fwStackerItems;
            this.fwBanknoteReader = data.fwBanknoteReader;
            this.bDropBox = data.bDropBox;

            var tmp = Activator.CreateInstance(typeof(WFSCIMOUTPOS));
            XFSUtil.PtrToStructure(data.lppPositions, typeof(WFSCIMOUTPOS), ref tmp);

            try
            {
                this.lppPositions = new WFSCIMOUTPOS
                {
                    fwPosition = ((WFSCIMOUTPOS)tmp).fwPosition,
                    fwPositionStatus = ((WFSCIMOUTPOS)tmp).fwPositionStatus,
                    fwShutter = ((WFSCIMOUTPOS)tmp).fwShutter,
                    fwTransport = ((WFSCIMOUTPOS)tmp).fwTransport,
                    fwTransportStatus = ((WFSCIMOUTPOS)tmp).fwTransportStatus
                };
            }
            catch (Exception ex)
            {
                L4Logger.Error(ex);
                L4Logger.Info(string.Format("Device Result => {0}  And PositionXfs {1} )", Newtonsoft.Json.JsonConvert.SerializeObject(tmp), data.lppPositions));
                this.lppPositions = new WFSCIMOUTPOS();
            }
        }
    }
}
