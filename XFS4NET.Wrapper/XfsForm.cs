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
    public partial class XfsForm : Form
    {
        public XfsForm()
        {
            InitializeComponent();
        }

        public void Init()
        {
            this.AddControl(XFS_DevicesCollection.Instance.IDC);
            this.AddControl(XFS_DevicesCollection.Instance.PIN);
            this.AddControl(XFS_DevicesCollection.Instance.PTR);
            this.AddControl(XFS_DevicesCollection.Instance.SIU);
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
