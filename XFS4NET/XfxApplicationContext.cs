using XFS4NET.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFS4NET.Logger;

namespace XFS4NET
{
    public class XfsApplicationContext : ApplicationContext
    {
        private static XfsApplicationContext _instance;
        public static XfsApplicationContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new XfsApplicationContext();
                return _instance ;
            }
        }

        public MainForm mainForm;

        public XfsApplicationContext()
        {
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            mainForm = new MainForm();
            mainForm.FormClosing += MainForm_FormClosing;
            mainForm.FormClosed += MainForm_FormClosed;

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            L4Logger.Info("MainForm_FormClosing =>" + e.CloseReason.ToString());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            L4Logger.Info("MainForm_FormClosing =>" + e.CloseReason.ToString());
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            L4Logger.Info("ApplicationExit");
        }

    }
}
