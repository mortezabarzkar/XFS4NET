using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XFS4NET.Wrapper
{
    public class XfsApplicationContext : ApplicationContext
    {

        private static XfsApplicationContext _instance;
        public static XfsApplicationContext Instance
        {
            get
            {
                return _instance ?? (_instance = new XfsApplicationContext());
            }
        }
        public XfsApplicationContext()
        {
            L4Logger.Info("create XfsApplicationContext");
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            mainForm mainForm = new mainForm();
            mainForm.FormClosing += MainForm_FormClosing;
            mainForm.FormClosed += MainForm_FormClosed;
            mainForm.Load += new EventHandler(mainForm_Load);
        }

        void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void OnApplicationExit(object sender, EventArgs e)
        {

        }

    }
}
