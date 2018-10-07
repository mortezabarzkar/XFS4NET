using XFS4NET.Wrapper.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFS4NET.Logger;
using XFS4NET.Model;

namespace XFS4NET
{
    public class XFS_DevicesCollection
    {
        private ConcurrentDictionary<ServiceTypes, XFSDeviceBase> dictionary;

        public void Add(ServiceTypes key, XFSDeviceBase value )
        {
            XfsApplicationContext.Instance.mainForm.AddControl(value);
            dictionary.TryAdd(key, value);
        }

        public List<XFSDeviceBase> GetAll()
        {
            return dictionary.Select(c => c.Value).ToList();
        }

        public XFSDeviceBase GetValue(ServiceTypes key) 
        {
            return (XFSDeviceBase) dictionary[key];
        }

        public bool IsContainKey(ServiceTypes key)
        {
            return dictionary.ContainsKey(key);
        }
        public bool IsStartup
        {
            get
            {
                return _IsStartup;
            }
            set
            {
                _IsStartup = value;
            }
        }
        private bool _IsStartup = false;

        private static XFS_DevicesCollection _instance;
        public static XFS_DevicesCollection Instance
        {
            get
            {

                if (_instance == null)
                {
                    _instance = new XFS_DevicesCollection();
                }
                return _instance;
            }
        }

        public void Init()
        {
            //IDC.Startup();
        }
        public XFS_DevicesCollection()
        {
            dictionary = new ConcurrentDictionary<ServiceTypes, XFSDeviceBase>();
            L4Logger.Info("ctor XFS_DevicesCollection");
            //IDC = new IDC.IDC();
            //PIN = new PIN.PIN();
            //PTR = new PTR.PTR();
            //SIU = new SIU.SIU();
        }
    }
}
