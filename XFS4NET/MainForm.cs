using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WebSocketSharp.Server;
using XFS4NET.Logger;
using XFS4NET.Model.Common;

namespace XFS4NET
{
    public partial class MainForm : Form
    {
        //XFSNet.IDC.IDC IDC = new XFSNet.IDC.IDC();

        //XFSNet.PIN.PIN PIN = new XFSNet.PIN.PIN();

        static WebSocketServer Server;

        public static string ServerIP
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerIP"];
            }
        }

        public static string ServerPort
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerPort"];
            }
        }
        public static string ServiceNameSIU
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerSIU"];
            }
        }

        public MainForm()
        {
            InitializeComponent();

            try
            {
                var tmp = XFS_DevicesCollection.Instance;
                L4Logger.Info(string.Format("Open socket for ws://{0}:{1}/XfsCommandBehavior", ServerIP, ServerPort));
                Server = new WebSocketServer(string.Format("ws://{0}:{1}", ServerIP, ServerPort));


                Server.AddWebSocketService<XfsCommandBehavior>("/XfsCommandBehavior");
                //Server.WaitTime = Timeout.InfiniteTimeSpan;

                Server.Start();

            }
            catch (Exception ex)
            {
                L4Logger.Info("Error in init WebSocketServer => " + ex.ToString());
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg >= XFSDefinition.WFS_OPEN_COMPLETE &&
                m.Msg <= XFSDefinition.WFS_SYSTEM_EVENT)
            {

            }
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
