using XFS4NET.Logger;
using XFS4NET.Model.Utility;
using XFS4NET.Model.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XFS4NET.Model.Common;
using WebSocketSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XFS4NET.Model.BCR
{
    public class BCR
    {
        BlockingQueue<TaskModel> blockingQueue = new BlockingQueue<TaskModel>();
        //List<CoreSocketeModel<string, string>> CommandHistory = new List<CoreSocketeModel<string, string>>();
        public WorkingMode workingMode = WorkingMode.None;
        WebSocketSharp.WebSocket _WebSocket;

        private string ServerIP;
        private string ServerPort;

        private static BCR _instance;

        #region Events
        public event Action<WFSBCRSTATUS, WFSBCRCAPS> GetInfoResponse;
        public event Action<string> ReadDataCompleted;
        public event Action<string, int, string> ReadDataError;

        public event Action OpenCompleted;
        public event Action RegisterCompleted;
        public event Action<int> OpenError;
        public event Action<int> RegisterError;

        #endregion

        #region Public Params
        public string ServiceName = "";
        public bool IsOpenned = false;
        #endregion

        public static BCR Instance
        {
            get
            {
                return _instance ?? (_instance = new BCR());
            }
        }

        public BCR()
        {
            blockingQueue.ObjectTimeout += BlockingQueue_ObjectTimeout;
        }

        private void BlockingQueue_ObjectTimeout(TaskModel obj)
        {
            L4Logger.Info(MethodBase.GetCurrentMethod().Name + "  Start");
            //L4Logger.Info("IDC working mode => " + workingMode.ToString());
            //if (workingMode == WorkingMode.EjectCard)
            //{
            //    workingMode = WorkingMode.None;
            //    CaptureCard();
            //}
        }

        public void InitServerInfo(string serverIp, string serverPort)
        {
            IsOpenned = false;
            L4Logger.Info("BCR InitServerInfo");
            if (_WebSocket != null)
            {
                _WebSocket.Close();
                _WebSocket.OnMessage -= _WebSocket_OnMessage;
            }
            this.ServerIP = serverIp;
            this.ServerPort = serverPort;

            _WebSocket = new WebSocketSharp.WebSocket(string.Format("ws://{0}:{1}/XfsCommandBehavior", ServerIP, ServerPort));
            _WebSocket.OnMessage += _WebSocket_OnMessage;
            _WebSocket.OnClose += _WebSocket_OnClose;
            _WebSocket.OnError += _WebSocket_OnError;
            _WebSocket.Connect();

            ReadDataCompleted = null;
            ReadDataError = null;
            OpenCompleted = null;
            RegisterCompleted = null;
            OpenError = null;
            RegisterError = null;
        }

        private void _WebSocket_OnError(object sender, ErrorEventArgs e)
        {
            IsOpenned = false;
            L4Logger.Error(string.Format(" BCR Connection Error => Message {0}  , Exception {1}", e.Message, e.Exception));
            return;
            try
            {
                _WebSocket.Close();
            }
            catch (Exception ex) { L4Logger.Error(ex); }
            try
            {
                _WebSocket.Connect();
            }
            catch (Exception ex) { L4Logger.Error(ex); }
        }

        private void _WebSocket_OnClose(object sender, CloseEventArgs e)
        {
            IsOpenned = false;
            L4Logger.Error(string.Format(" BCR Connection Error => Code {0}  , Reason {1}", e.Code, e.Reason));
            return;
            try
            {
                _WebSocket.Close();
            }
            catch (Exception ex) { L4Logger.Error(ex); }
            try
            {
                _WebSocket.Connect();
            }
            catch (Exception ex) { L4Logger.Error(ex); }
        }

        private void _WebSocket_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                L4Logger.Info("Barcode Reader _WebSocket_OnMessage => " + e.Data);
                JObject Parametrs = JObject.Parse(e.Data);
                var Datatype = (Datatype)Enum.ToObject(typeof(Datatype), int.Parse((string)Parametrs["Datatype"]));
                switch (Datatype)
                {
                    case Datatype.Command:
                        {
                            try
                            {
                                var obj = JsonConvert.DeserializeObject<XfsCommandBase<object>>(e.Data);
                                ParsCommand(obj);
                                L4Logger.Info("XfsCommandBase<IXfsCommand> data recived ");
                            }
                            catch (Exception ex)
                            {
                                L4Logger.Error(ex);
                            }
                            break;
                        }
                    case Datatype.Event:
                        {
                            try
                            {
                                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ExecuteEventBase>(e.Data);
                                ParsEvent(obj);
                                L4Logger.Info("ExecuteEventBase data recived ");
                            }
                            catch (Exception ex)
                            {
                                L4Logger.Error(ex);
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                L4Logger.Error(ex);
            }
        }
        private void ParsCommand(XfsCommandBase<object> commandBase)
        {
            switch (commandBase.CommandType)
            {
                case CommandType.Execute:
                    {
                        blockingQueue.Clear();
                        var cmnd = JsonConvert.DeserializeObject<ExecuteCommand>(JsonConvert.SerializeObject(commandBase.XfsCommand));
                        if (commandBase.IsExecuteSuccessfully)
                        {
                            if (cmnd.CommandCode == BCRDefinition.WFS_CMD_BCR_READ)
                            {
                                blockingQueue.Clear();
                                try
                                {
                                    var data = XFSUtil.Cast<BarcodeData[]>(cmnd.ResultModel)[0].Value;
                                    ReadDataCompleted?.Invoke(data);
                                }
                                catch (Exception ex)
                                {
                                    L4Logger.Error(ex);
                                    //MediaError.Invoke();
                                }
                            }
                        }
                        else
                        {
                            if (commandBase.ErrorCode == XFSDefinition.WFS_ERR_CANCELED)
                            {
                                return;
                            }
                            if (cmnd.CommandCode == BCRDefinition.WFS_CMD_BCR_READ)
                            {
                                ReadDataError?.Invoke("BCR", commandBase.ErrorCode, commandBase.ErrorCode.ToString());
                                //if (workingMode == WorkingMode.None || workingMode == WorkingMode.EjectCard)
                                //    return;
                                //else
                                //    ReadRawDataError?.Invoke("IDC", commandBase.ErrorCode, commandBase.ErrorCode.ToString());

                                //workingMode = WorkingMode.None;
                            }
                        }
                        break;
                    }
                case CommandType.Open:
                    {
                        var cmnd = JsonConvert.DeserializeObject<OpenCommand>(JsonConvert.SerializeObject(commandBase.XfsCommand));
                        if (commandBase.IsExecuteSuccessfully)
                        {
                            if (commandBase.Detail.Equals("XFSDevice_OpenComplete"))
                            {
                                IsOpenned = true;
                                OpenCompleted?.Invoke();
                            }
                            if (commandBase.Detail.Equals("XFSDevice_RegisterComplete"))
                                RegisterCompleted?.Invoke();
                        }
                        else
                        {
                            if (commandBase.Detail.Equals("XFSDevice_OpenError"))
                            {
                                IsOpenned = false;
                                OpenError?.Invoke(commandBase.ErrorCode);
                            }
                            if (commandBase.Detail.Equals("XFSDevice_RegisterError"))
                                RegisterError?.Invoke(commandBase.ErrorCode);
                        }
                        break;
                    }
                case CommandType.Getinfo:
                    {
                        var cmnd = JsonConvert.DeserializeObject<GetInfoCommand>(JsonConvert.SerializeObject(commandBase.XfsCommand));
                        GetInfoResponse?.Invoke(XFSUtil.Cast<WFSBCRSTATUS>(cmnd.Status), null);
                        break;
                    }
            }
        }

        private void ParsEvent(ExecuteEventBase eventBase)
        {
            switch (eventBase.EventID)
            {

            }
        }


        public List<string> GetServiceNames
        {
            get
            {
                return XfsUtility.Instance.GetServiceNames("BCR");
            }
        }

        #region Commands    
        public void OpenAndRegister(string serviceName)
        {
            if (!_WebSocket.IsAlive)
                _WebSocket.Connect();
            L4Logger.Info("Open BCR connection");
            XfsCommandBase<XfsCommand> xfsCommand = new XfsCommandBase<XfsCommand>
            {
                CommandType = CommandType.Open,
                ServiceType = ServiceTypes.BCR,
                XfsCommand = new OpenCommand
                {
                    ServiceName = serviceName
                }
            };

            _WebSocket.Send(Newtonsoft.Json.JsonConvert.SerializeObject(xfsCommand, Formatting.Indented));
            ServiceName = serviceName;
        }

        public void ReadData()
        {
            L4Logger.Info(MethodBase.GetCurrentMethod().Name + "  Start");
            if (!blockingQueue.Enqueue(
                    new TaskModel
                    {
                        MethodName = "ReadData",
                        WaitForResponse = true
                    }
                ))
            {
                L4Logger.Info("another operation in progress");
                return;
            }
            L4Logger.Info(MethodBase.GetCurrentMethod().Name + "  Start for sending xfs command");
            try
            {
                if (!_WebSocket.IsAlive)
                    _WebSocket.Connect();
                WFSBCRREADINPUT source = new WFSBCRREADINPUT
                {
                    lpwSymbologies = (ushort)BarcodeType.WFS_BCR_SYM_UNKNOWN
                };
                XfsCommandBase<XfsCommand> xfsCommand = new XfsCommandBase<XfsCommand>
                {
                    CommandType = CommandType.Execute,
                    ServiceType = ServiceTypes.BCR,
                    XfsCommand = new ExecuteCommand
                    {
                        CommandCode = BCRDefinition.WFS_CMD_BCR_READ,
                        Param = source,
                        ResultModel = new BarcodeData[1],
                        PramType = typeof(WFSBCRREADINPUT),
                        ResultModelType = typeof(BarcodeData),
                        ResultXfs = new WFSBCRREADOUTPUT[1],
                        ResultXfsType = typeof(WFSBCRREADOUTPUT),
                        CancelLastCommand = false,
                        LightControlCommand = new LightControlCommand
                        {

                        },
                        AcceptEvents = new List<int>
                        {

                        }
                    }
                };
                _WebSocket.Send(Newtonsoft.Json.JsonConvert.SerializeObject(xfsCommand, Formatting.Indented));
            }
            catch (Exception ex)
            {
                L4Logger.Error(ex);
            }
        }

        public void Cancel()
        {
            L4Logger.Info(MethodBase.GetCurrentMethod().Name + "  Start for sending xfs command");
            try
            {
                if (!_WebSocket.IsAlive)
                    _WebSocket.Connect();
                XfsCommandBase<XfsCommand> xfsCommand = new XfsCommandBase<XfsCommand>
                {
                    CommandType = CommandType.Cancel,
                    ServiceType = ServiceTypes.BCR,
                    XfsCommand = new ExecuteCommand
                    {

                    }
                };
                _WebSocket.Send(Newtonsoft.Json.JsonConvert.SerializeObject(xfsCommand, Formatting.Indented));
            }
            catch (Exception ex)
            {
                L4Logger.Error(ex);
            }
        }

        public void GetStatus()
        {
            try
            {
                if (!_WebSocket.IsAlive)
                    _WebSocket.Connect();

                XfsCommandBase<GetInfoCommand> xfsCommand = new XfsCommandBase<GetInfoCommand>
                {
                    CommandType = CommandType.Getinfo,
                    ServiceType = ServiceTypes.BCR,
                    XfsCommand = new GetInfoCommand
                    {
                        CommandCode = BCRDefinition.WFS_INF_BCR_STATUS,
                        StatusType = typeof(WFSBCRSTATUS),
                        Status = new WFSBCRSTATUS(),
                        Result = IntPtr.Zero,
                    }
                };
                workingMode = WorkingMode.GettingStatus;
                _WebSocket.Send(Newtonsoft.Json.JsonConvert.SerializeObject(xfsCommand, Formatting.Indented));
            }
            catch (Exception ex)
            {
                L4Logger.Error(ex);
            }
        }
        #endregion
    }
}
