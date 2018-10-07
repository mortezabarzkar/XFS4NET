using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;
using XFS4NET.Logger;
using XFS4NET.Model;

namespace XFS4NET
{
    static class Program
    {
        const int ERROR_FILE_NOT_FOUND = 2;
        const int ERROR_ACCESS_DENIED = 5;
        const int ERROR_NO_APP_ASSOCIATED = 1155;

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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            try
            {
                Microsoft.Win32.SystemEvents.SessionEnding += SystemEvents_SessionEnding;
                L4Logger.Info("*****************************************************Start Service****************************************************************");

                //var datattttt=  Daricheh.Core.Devices.Security.SecurityUtility.Instance.CalculateCDM(System.IO.File.ReadAllBytes("byte.txt"));
                //NativeMethods.FindAndLoadModule("msxfs.dll");
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.ThreadException += Application_ThreadException;
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);


                XFS_DevicesCollection.Instance.Add(ServiceTypes.IDC,
                    new Wrapper.Common.XFSDeviceBase
                    {
                        serviceType =ServiceTypes.IDC,
                    });

                XFS_DevicesCollection.Instance.Add( ServiceTypes.PIN,
                      new Wrapper.Common.XFSDeviceBase
                      {
                        serviceType =  ServiceTypes.PIN,
                    });

                XFS_DevicesCollection.Instance.Add( ServiceTypes.SIU,
                    new Wrapper.Common.XFSDeviceBase
                    {
                        serviceType =  ServiceTypes.SIU,
                    });

                XFS_DevicesCollection.Instance.Add( ServiceTypes.PTR,
                    new Wrapper.Common.XFSDeviceBase
                    {
                      serviceType =  ServiceTypes.PTR,
                  });

                XFS_DevicesCollection.Instance.Add( ServiceTypes.CDM,
                   new Wrapper.Common.XFSDeviceBase
                   {
                     serviceType =  ServiceTypes.CDM,
                 });

                XFS_DevicesCollection.Instance.Add( ServiceTypes.CIM,
                  new Wrapper.Common.XFSDeviceBase
                  {
                     serviceType =  ServiceTypes.CIM,
                 });

                XFS_DevicesCollection.Instance.Add( ServiceTypes.BCR,
                 new Wrapper.Common.XFSDeviceBase
                 {
                    serviceType =  ServiceTypes.BCR,
                });

                Form frm = XfsApplicationContext.Instance.mainForm;
                Application.Run(XfsApplicationContext.Instance);
                return;
            }

            catch (Win32Exception e)
            {
                L4Logger.Info("Win32 error => " + e.Message);
                Application.Exit();
            }
        }

        private static void SystemEvents_SessionEnding(object sender, Microsoft.Win32.SessionEndingEventArgs e)
        {
            L4Logger.Info("SystemEvents_SessionEnding");
            XFS_DevicesCollection.Instance.GetAll().ForEach(c => c.Close());
        }

        private static void Application_ThreadExit(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            L4Logger.Info("Application_ThreadException =>" + e.Exception.ToString());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            L4Logger.Info("CurrentDomain_UnhandledException =>" + e.ExceptionObject.ToString());
        }
    }
}
