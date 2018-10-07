using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace XFS4NET.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        const string ProcessName = "XFS4NET.exe";
        public App()
        {
            try
            {
                if(IsProcessRunning(ProcessName))
                KillProcess(ProcessName);
                string ServiceApp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Service\"+ProcessName;

                System.Threading.Thread.Sleep(200);
                var p = Process.Start(ServiceApp);
                p.WaitForInputIdle(4000);
                if (IsProcessRunning(ProcessName))
                {
                    new MainWindow().Show();
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
            catch (TypeLoadException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private bool IsProcessRunning(string name)
        {
            return Process.GetProcesses().Where(c => 
            c.ProcessName.ToLower().Contains(Path.GetFileNameWithoutExtension(name.ToLower()))
            && c.ProcessName.ToLower() != Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName).ToLower()
            ).ToList().Count > 0 ? true : false;
        }

        private void KillProcess(string name)
        {
            try
            {
                Process.GetProcesses().Where(c =>
             c.ProcessName.ToLower().Contains(Path.GetFileNameWithoutExtension(name.ToLower()))
             && c.ProcessName.ToLower() != Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName).ToLower()
             ).ToList().ForEach(c => c.Kill());
            }
            catch
            { }
        }
        ~App()
        {
            KillProcess(ProcessName);
        }
    }
}
