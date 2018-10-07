using XFS4NET.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFS4NET.Model.BCR
{
    public class BarcodeData : IXfsResultModel
    {       
        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public void Fill(object result)
        {
            var data = (WFSBCRREADOUTPUT)result;
            WFSBCRPHEXDATA tmp = new WFSBCRPHEXDATA();
            XFSUtil.PtrToStructure<WFSBCRPHEXDATA>(data.lpxBarcodeData, ref tmp);

            try
            {
                if (tmp.lpbData != null)
                    this.Value= XFSUtil.GetSeratedStringFromPointer(tmp.lpbData)[0];
            }
            catch { this.Value = string.Empty; }
            
        }
    }
}
