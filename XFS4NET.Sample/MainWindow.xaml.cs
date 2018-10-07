using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XFS4NET.Model.IDC;
using XFS4NET.Model.PIN;

namespace XFS4NET.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string ServerIp = "127.0.0.1";
        const string ServerPort = "8090";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region IDC
            if (!IDC.Instance.IsOpenned)
            {
                IDC.Instance.InitServerInfo(ServerIp, ServerPort);
                IdcServices.ItemsSource = IDC.Instance.GetServiceNames;
                idcGetstatus.IsEnabled = false;
                idcReadCard.IsEnabled = false;
                idcEjectCard.IsEnabled = false;
                idcCaptureCard.IsEnabled = false;
            }
            else
            {
                IDC_OpenCompleted();
                IdcServices.ItemsSource = IDC.Instance.GetServiceNames;
                IdcServices.Text = IDC.Instance.ServiceName;
            }

            IDC.Instance.EjectCardCompleted += IDC_EjectCardCompleted;
            IDC.Instance.EjectCardError += IDC_EjectCardError;
            IDC.Instance.MediaRemoved += IDC_MediaRemoved;
            IDC.Instance.ReadRawDataCompleted += IDC_ReadRawDataCompleted;
            IDC.Instance.ReadRawDataError += IDC_ReadRawDataError;
            IDC.Instance.OpenCompleted += IDC_OpenCompleted;
            IDC.Instance.RegisterCompleted += IDC_RegisterCompleted;
            IDC.Instance.GetInfoResponse += IDC_GetInfoResponse;


            #endregion

            #region PIN
            if (!PIN.Instance.IsOpenned)
            {
                PIN.Instance.InitServerInfo(ServerIp, ServerPort);
                PinServices.ItemsSource = PIN.Instance.GetServiceNames;
                PinGetEntery.IsEnabled = false;
                PinGetPin.IsEnabled = false;
                PinGetstatus.IsEnabled = false;
            }
            else
            {
                PIN_OpenCompleted();
                PinServices.ItemsSource = PIN.Instance.GetServiceNames;
                PinServices.Text = PIN.Instance.ServiceName;
            }
            PIN.Instance.GetInfoResponse += PIN_GetInfoResponse;
            PIN.Instance.OpenCompleted += PIN_OpenCompleted;
            PIN.Instance.OpenError += PIN_OpenError;
            PIN.Instance.PinFormatted += PIN_PinFormatted;
            PIN.Instance.PINKeyPressed += PIN_PINKeyPressed;
            PIN.Instance.PinPadCancelled += PIN_PinPadCancelled;
            PIN.Instance.PinPadError += PIN_PinPadError;
            PIN.Instance.RegisterCompleted += PIN_RegisterCompleted;
            PIN.Instance.RegisterError += PIN_RegisterError;

            #endregion
        }


        #region PIN       
        private void PIN_RegisterError(int obj)
        {
            Dispatcher.Invoke(() =>
            {
                PinResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void PIN_RegisterCompleted()
        {
            Dispatcher.Invoke(() =>
            {
                PinResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void PIN_PinPadError(string obj)
        {
            Dispatcher.Invoke(() =>
            {
                PinResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void PIN_PinPadCancelled()
        {
            Dispatcher.Invoke(() =>
            {
                PinResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void PIN_PINKeyPressed(string obj)
        {
            Dispatcher.Invoke(() =>
            {
                PinResponse.Text += MethodBase.GetCurrentMethod().Name + " Key => " + obj + Environment.NewLine;
            });
        }

        private void PIN_PinFormatted(string obj)
        {
            Dispatcher.Invoke(() =>
            {
                PinResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void PIN_OpenError(int obj)
        {
            Dispatcher.Invoke(() =>
            {
                PinResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void PIN_OpenCompleted()
        {
            Dispatcher.Invoke(() =>
            {
                PinResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
                PinGetEntery.IsEnabled = true;
                PinGetPin.IsEnabled = true;
                PinGetstatus.IsEnabled = true;
            });
        }

        private void PinOpenAndRegister_Click(object sender, RoutedEventArgs e)
        {
            if (PinServices.SelectedIndex > -1)
            {
                PIN.Instance.OpenAndRegister(PinServices.Text);
            }
        }

        private void PinGetstatus_Click(object sender, RoutedEventArgs e)
        {
            PIN.Instance.GetStatus();
        }

        private void PinGetEntery_Click(object sender, RoutedEventArgs e)
        {
            PIN.Instance.ReadEntery();
        }

        private void PinGetPin_Click(object sender, RoutedEventArgs e)
        {
            PIN.Instance.ReadPin("5047061024337671");
        }
        private void PIN_GetInfoResponse(WFSPINSTATUS arg1, WFSPINCAPS arg2)
        {
            Dispatcher.Invoke(() =>
            {
                PinResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }
        #endregion

        #region IDC        
        private void IDC_GetInfoResponse(WFSIDCSTATUS arg1, WFSIDCCAPS arg2)
        {
            Dispatcher.Invoke(() =>
            {
                idcResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void IDC_RegisterCompleted()
        {
            Dispatcher.Invoke(() =>
            {
                idcResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void IDC_OpenCompleted()
        {
            Dispatcher.Invoke(() =>
            {
                idcResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
                idcGetstatus.IsEnabled = true;
                idcReadCard.IsEnabled = true;
                idcEjectCard.IsEnabled = true;
                idcCaptureCard.IsEnabled = true;
            });
        }

        private void IDC_ReadRawDataError(string arg1, int arg2, string arg3)
        {
            Dispatcher.Invoke(() =>
            {
                idcResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void IDC_ReadRawDataCompleted(IDCCardData[] obj)
        {
            Dispatcher.Invoke(() =>
            {
                idcResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine + JsonConvert.SerializeObject(obj, Formatting.Indented) + Environment.NewLine;
            });
        }

        private void IDC_MediaRemoved()
        {
            Dispatcher.Invoke(() =>
            {
                idcResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void IDC_EjectCardError()
        {
            Dispatcher.Invoke(() =>
            {
                idcResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void IDC_EjectCardCompleted()
        {
            Dispatcher.Invoke(() =>
            {
                idcResponse.Text += MethodBase.GetCurrentMethod().Name + Environment.NewLine;
            });
        }

        private void idcOpenAndRegister_Click(object sender, RoutedEventArgs e)
        {
            if (IdcServices.SelectedIndex > -1)
            {
                IDC.Instance.OpenAndRegister(IdcServices.Text);
            }
        }

        private void idcGetstatus_Click(object sender, RoutedEventArgs e)
        {
            IDC.Instance.GetStatus();
        }

        private void idcReadCard_Click(object sender, RoutedEventArgs e)
        {
            IDC.Instance.ReadCard();
        }

        private void idcEjectCard_Click(object sender, RoutedEventArgs e)
        {
            IDC.Instance.EjectCard();
        }
        #endregion

        private void Response_TextChanged(object sender, TextChangedEventArgs e)
        {
            (sender as TextBox).ScrollToEnd();
        }

        private void btnSaveIdcConfig_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
