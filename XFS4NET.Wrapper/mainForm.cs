using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XFS4NET.Wrapper
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

            //var tmp = XFS_DevicesCollection.Instance;

            //L4Logger.Info("Adding control IDC");
            //this.AddControl(XFS_DevicesCollection.Instance.IDC);
            //L4Logger.Info("Adding control PIN");
            //this.AddControl(XFS_DevicesCollection.Instance.PIN);
            //L4Logger.Info("Adding control PTR");
            //this.AddControl(XFS_DevicesCollection.Instance.PTR);
            //L4Logger.Info("Adding control SIU");
            //this.AddControl(XFS_DevicesCollection.Instance.SIU);
        }
        public void AddControl(Control control)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.AddControl(control);
                }));
            }
            else
            {
                this.Controls.Add(control);
            }
        }
    }
}
