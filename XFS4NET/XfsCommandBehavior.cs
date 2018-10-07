using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using XFS4NET.Logger;
using XFS4NET.Model;
using XFS4NET.Model.Command;
using XFS4NET.Model.Common;
using XFS4NET.Model.IDC;
using XFS4NET.Model.SIU;

namespace XFS4NET
{
    public class XfsCommandBehavior : WebSocketBehavior
    {
        object syncObject = new object();
        //static XfsCommandBase<XfsCommand> CurrentCommand;

        public XfsCommandBehavior()
        {
            var obj = XFS_DevicesCollection.Instance;
        }

        [STAThread]
        protected override void OnClose(CloseEventArgs e)
        {
            L4Logger.Info("Event OnClose => " + this.ToString());
            XFS_DevicesCollection.Instance.GetAll().ForEach(item =>
            {
                item.Close();
            });
        }


        [STAThread]
        protected override void OnMessage(MessageEventArgs e)
        {
            lock (syncObject)
            {
                try
                {
                    L4Logger.Info("XfsCommandBehavior WebSocket_OnMessage => " + e.Data);
                    JObject Parametrs = JObject.Parse(e.Data);
                    var CommandType = (CommandType)Enum.ToObject(typeof(CommandType), int.Parse((string)Parametrs["CommandType"]));
                    switch (CommandType)
                    {
                        case CommandType.Init:
                            {
                                //var Command = JsonConvert.DeserializeObject<XfsCommandBase<i>>(e.Data);
                                //CurrentCommand = new XfsCommandBase<IXfsCommand>
                                //{
                                //    CommandType = Command.CommandType,
                                //    XfsCommand = Command.XfsCommand,
                                //    IsExecuteSuccessfully = Command.IsExecuteSuccessfully,
                                //    ServiceType = Command.ServiceType
                                //};

                                //var XFSDevice = AddOrGetServiceBase(Command);

                                //XFSDevice.OpenComplete += XFSDevice_OpenComplete;
                                //XFSDevice.OpenError += XFSDevice_OpenError;
                                //XFSDevice.RegisterComplete += XFSDevice_RegisterComplete;
                                //XFSDevice.RegisterError += XFSDevice_RegisterError;

                                break;
                            }
                        case CommandType.Open:
                            {
                                var Command = JsonConvert.DeserializeObject<XfsCommandBase<OpenCommand>>(e.Data);

                                var XFSDevice = XFS_DevicesCollection.Instance.GetValue(Command.ServiceType);

                                XFSDevice.ResetEvents();

                                XFSDevice.CurrentCommand = new XfsCommandBase<XfsCommand>
                                {
                                    CommandType = CommandType.Open,
                                    XfsCommand = Command.XfsCommand,
                                    IsExecuteSuccessfully = Command.IsExecuteSuccessfully,
                                    ServiceType = Command.ServiceType
                                };


                                XFSDevice.OpenComplete -= XFSDevice_OpenComplete;
                                XFSDevice.OpenError -= XFSDevice_OpenError; XFSDevice.RegisterComplete -= XFSDevice_RegisterComplete;
                                XFSDevice.RegisterError -= XFSDevice_RegisterError;
                                XFSDevice.CancelComplete -= XFSDevice_CancelComplete;
                                XFSDevice.CancelError -= XFSDevice_CancelError;
                                XFSDevice.ExecuteComplete -= XFSDevice_ExecuteComplete;
                                XFSDevice.ExecuteCompleteError -= XFSDevice_ExecuteCompleteError;
                                XFSDevice.ExecuteEvent -= XFSDevice_ExecuteEvent;


                                XFSDevice.OpenComplete += XFSDevice_OpenComplete;
                                XFSDevice.OpenError += XFSDevice_OpenError;
                                XFSDevice.RegisterComplete += XFSDevice_RegisterComplete;
                                XFSDevice.RegisterError += XFSDevice_RegisterError;
                                XFSDevice.CancelComplete += XFSDevice_CancelComplete;
                                XFSDevice.CancelError += XFSDevice_CancelError;
                                XFSDevice.ExecuteComplete += XFSDevice_ExecuteComplete;
                                XFSDevice.ExecuteCompleteError += XFSDevice_ExecuteCompleteError;
                                XFSDevice.ExecuteEvent += XFSDevice_ExecuteEvent;
                                if (Command.XfsCommand.AcceptEvents != null)
                                {
                                    XFSDevice.eventHandlers.Clear();
                                    XFSDevice.eventHandlers.AddRange(Command.XfsCommand.AcceptEvents);
                                }
                                XFSDevice.Open(Command.XfsCommand.ServiceName);

                                break;
                            }
                        case CommandType.Cancel:
                            {
                                XfsCommandBase<CancellCommand> Command = JsonConvert.DeserializeObject<XfsCommandBase<CancellCommand>>(e.Data);
                                var XFSDevice = XFS_DevicesCollection.Instance.GetValue(Command.ServiceType);
                                XFSDevice.CurrentCommand = new XfsCommandBase<XfsCommand>
                                {
                                    CommandType = CommandType.Cancel,
                                    XfsCommand = Command.XfsCommand,
                                    IsExecuteSuccessfully = Command.IsExecuteSuccessfully,
                                    ServiceType = Command.ServiceType
                                };
                                XFSDevice.Cancel();
                                break;
                            }
                        case CommandType.Getinfo:
                            {
                                try
                                {

                                    XfsCommandBase<GetInfoCommand> Command = JsonConvert.DeserializeObject<XfsCommandBase<GetInfoCommand>>(e.Data);
                                    var XFSDevice = XFS_DevicesCollection.Instance.GetValue(Command.ServiceType);
                                    L4Logger.Info("Start get info for " + Command.ServiceType);
                                    XFSDevice.CurrentCommand = new XfsCommandBase<XfsCommand>
                                    {
                                        CommandType = CommandType.Getinfo,
                                        XfsCommand = Command.XfsCommand,
                                        IsExecuteSuccessfully = Command.IsExecuteSuccessfully,
                                        ServiceType = Command.ServiceType
                                    };
                                    L4Logger.Info("call GetStatus");
                                    var obj = (ISTATUS)Activator.CreateInstance(Command.XfsCommand.StatusType);

                                    XFSDevice.GetStatus(out obj, Command.XfsCommand.CommandCode, Command.XfsCommand.StatusType);

                                    L4Logger.Info(" Fill info data");
                                    Command.XfsCommand.Status = obj;
                                    if (Command.XfsCommand.StatusTypeModel != null)
                                    {
                                        var model = (IXfsResultModel)Activator.CreateInstance(Command.XfsCommand.StatusTypeModel);
                                        model.Fill(obj);
                                        Command.XfsCommand.StatusModel = model;
                                    }

                                    L4Logger.Info("Call to send");
                                    Command.IsExecuteSuccessfully = true;
                                    SendResponse(Command);
                                }
                                catch (Exception ex)
                                {
                                    L4Logger.Error(ex);
                                }
                                break;
                            }
                        case CommandType.Execute:

                            {
                                XfsCommandBase<ExecuteCommand> Command = JsonConvert.DeserializeObject<XfsCommandBase<ExecuteCommand>>(e.Data);

                                var XFSDevice = XFS_DevicesCollection.Instance.GetValue(Command.ServiceType);

                                XFSDevice.CurrentCommand = new XfsCommandBase<XfsCommand>
                                {
                                    CommandType = CommandType.Execute,
                                    XfsCommand = Command.XfsCommand,
                                    IsExecuteSuccessfully = Command.IsExecuteSuccessfully,
                                    ServiceType = Command.ServiceType
                                };

                                if (Command.XfsCommand.CancelLastCommand)
                                {
                                    XFSDevice.Cancel(false);
                                }

                                //unsafe
                                {
                                    List<int> AcceptEvents = new List<int>();
                                    if (Command.XfsCommand.AcceptEvents != null)
                                    {
                                        AcceptEvents.AddRange(Command.XfsCommand.AcceptEvents);
                                    }


                                    if (Command.XfsCommand.Events != null)
                                    {
                                        XFSDevice.eventHandlers.Clear();
                                        XFSDevice.GlobalEvents.Clear();
                                        XFSDevice.eventHandlers.AddRange(AcceptEvents);
                                        Command.XfsCommand.Events.ForEach(Event =>
                                        {

                                            XFSDevice.eventHandlers.Add(Event.EventId);
                                            if (Event.IsGlobalEvent)
                                            {
                                                XFSDevice.GlobalEvents.Add(new Wrapper.Common.XFSDeviceBase.GlobalEvent
                                                {
                                                    EventId = Event.EventId,
                                                    EventParam = Event.EventParam,
                                                    EventParamType = Event.EventParamType
                                                });
                                            }
                                        });

                                    }
                                    else
                                    {
                                        XFSDevice.eventHandlers.Clear();
                                        XFSDevice.GlobalEvents.Clear();
                                        XFSDevice.eventHandlers.AddRange(AcceptEvents);
                                    }
                                    XFSDevice.commandHandlers.Add(Command.XfsCommand.CommandCode);
                                    IntPtr cmdPtr = IntPtr.Zero;

                                    if (Command.XfsCommand.ParamModel != null)
                                    {
                                        //var objModel = Activator.CreateInstance(Command.XfsCommand.ParamModelType);
                                        var param = XFSUtil.Cast(Command.XfsCommand.ParamModel, Command.XfsCommand.ParamModelType);
                                        cmdPtr = (param as IXfsModel).ToPopinter();
                                    }
                                    else
                                    {
                                        cmdPtr = XFSUtil.StructureToPtr(Command.XfsCommand.Param, Command.XfsCommand.PramType);

                                    }
                                    int hResult = XFSDevice.ExecuteCommand(
                                            Command.XfsCommand.CommandCode,
                                            cmdPtr,
                                            XFSDevice_ExecuteError);
                                    Marshal.FreeHGlobal(cmdPtr);
                                    if (hResult == XFS4NET.Model.Common.XFSDefinition.WFS_SUCCESS)
                                        if (Command.XfsCommand.LightControlCommand != null)
                                        {
                                            ExcuteSiuCommand(Command.XfsCommand.LightControlCommand.ExecuteSIU, Command.ServiceType);
                                        }
                                        else
                                        {

                                        }
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
        }

        private void XFSDevice_ExecuteCompleteError(ServiceTypes serviceType, int Code)
        {
            lock (syncObject)
            {
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.IsExecuteSuccessfully = false;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.Detail = "XFSDevice_ExecuteError => " + Code;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.ErrorCode = Code;
                SendResponse(XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand);
            }
        }

        public void ExcuteSiuCommand(int cmd, ServiceTypes serviceType)
        {
            WFSSIUSETGUIDLIGHT guidLight = new WFSSIUSETGUIDLIGHT();
            var XFSDevice = XFS_DevicesCollection.Instance.GetValue(ServiceTypes.SIU);
            var GuidLightCtrl = GetGuidLights(serviceType);
            if (GuidLightCtrl != null)
            {
                guidLight.fwCommand = (LightControl)(ushort)cmd;
                guidLight.wGuidLight = (ushort)GetGuidLights(serviceType).Value;
                IntPtr ptr = XFSUtil.StructureToPtr(guidLight, typeof(WFSSIUSETGUIDLIGHT));
                XFSDevice.ExecuteCommand(SIUDefinition.WFS_CMD_SIU_SET_GUIDLIGHT, ptr);
                Marshal.FreeHGlobal(ptr);
            }
        }

        GuidLights? GetGuidLights(ServiceTypes serviceType)
        {

            switch (XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.ServiceType)
            {
                case ServiceTypes.IDC: return GuidLights.WFS_SIU_CARDUNIT; break;
                case ServiceTypes.PIN: return GuidLights.WFS_SIU_PINPAD; break;
                case ServiceTypes.PTR: return GuidLights.WFS_SIU_RECEIPTPRINTER; break;
                default: return null;
            }
        }

        [STAThread]
        private void XFSDevice_ExecuteEvent(ServiceTypes serviceType, int EventID, IntPtr obj)
        {
            L4Logger.Info("XFSDevice_ExecuteEvent");
            lock (syncObject)
            {
                try
                {
                    var math = XFS_DevicesCollection.Instance.GetValue(serviceType).GlobalEvents.FirstOrDefault(c => c.EventId == EventID);
                    if (math != null)
                    {
                        L4Logger.Info("Global Event Reaised");
                        object res = null;
                        res = Activator.CreateInstance(math.EventParamType);
                        XFSUtil.PtrToStructure(obj, math.EventParamType, ref res);
                        ExecuteEventBase eventBase = new ExecuteEventBase
                        {
                            EventID = EventID,
                            EventParam = res,
                            EventParamType = math.EventParamType
                        };
                        SendResponse(eventBase);
                    }
                    else if (XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.XfsCommand is ExecuteCommand)
                    {
                        L4Logger.Info("Command Event Reaised");
                        var cmnd = (XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.XfsCommand as ExecuteCommand);
                        object res = null;
                        if (cmnd != null && cmnd.EventParamType != null)
                        {
                            L4Logger.Info("Event hass response model");
                            res = Activator.CreateInstance(cmnd.EventParamType);
                            XFSUtil.PtrToStructure(obj, cmnd.EventParamType, ref res);

                            ExecuteEventBase eventBase = new ExecuteEventBase
                            {
                                EventID = EventID,
                                EventParam = res,
                                EventParamType = cmnd.EventParamType
                            };
                            SendResponse(eventBase);
                        }
                        else if (cmnd.EventParamType == null)
                        {
                            L4Logger.Info("Event not model");
                            ExecuteEventBase eventBase = new ExecuteEventBase
                            {
                                EventID = EventID,
                                EventParam = null,
                                EventParamType = null
                            };
                            SendResponse(eventBase);
                        }
                    }
                    else
                    {
                        L4Logger.Info("Un categoriezd Event");
                        ExecuteEventBase eventBase = new ExecuteEventBase
                        {
                            EventID = EventID,
                            EventParam = null,
                            EventParamType = null
                        };
                        SendResponse(eventBase);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        [STAThread]
        private void XFSDevice_CancelError(ServiceTypes serviceType, int obj)
        {
            lock (syncObject)
            {
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.IsExecuteSuccessfully = false;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.ErrorCode = obj;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.Detail = "XFSDevice_CancelError";
                SendResponse(XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand);
                var XfsCommand = (XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.XfsCommand as ExecuteCommand);
                if (XfsCommand != null && XfsCommand.LightControlCommand != null)
                {
                    ExcuteSiuCommand(XfsCommand.LightControlCommand.ExecuteSIU, serviceType);
                }
            }
        }

        [STAThread]
        private void XFSDevice_CancelComplete(ServiceTypes serviceType)
        {
            lock (syncObject)
            {
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.IsExecuteSuccessfully = true;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.Detail = "XFSDevice_CancelComplete";
                SendResponse(XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand);
            }
        }

        [STAThread]
        private void XFSDevice_ExecuteError(ServiceTypes serviceType, string ServiceName, int Code, string CodeStr)
        {
            lock (syncObject)
            {
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.IsExecuteSuccessfully = false;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.Detail = "XFSDevice_ExecuteError => " + CodeStr;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.ErrorCode = Code;
                SendResponse(XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand);
            }
        }

        [STAThread]
        private void XFSDevice_ExecuteComplete(ServiceTypes serviceType, IntPtr obj, int EventID)
        {
            try
            {
                lock (syncObject)
                {
                    if (obj == IntPtr.Zero)
                    {
                        XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.IsExecuteSuccessfully = true;
                        XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.Detail = "XFSDevice_ExecuteComplete";

                        var XfsCommand = (XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.XfsCommand as ExecuteCommand);
                        if (XfsCommand != null && XfsCommand.LightControlCommand != null)
                        {
                            ExcuteSiuCommand(XfsCommand.LightControlCommand.CompleteSIU, serviceType);
                        }
                        SendResponse(XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand);
                        return;
                    }
                    else
                    {
                        XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.IsExecuteSuccessfully = true;
                        #region old
                        //switch (EventID)
                        //{
                        //    case IDCDefinition.WFS_CMD_IDC_READ_RAW_DATA:
                        //        {
                        //            //(CurrentCommand.XfsCommand as ExecuteCommand).Result = Activator.CreateInstance((CurrentCommand.XfsCommand as ExecuteCommand).ResultType);
                        //            var resobj = OnReadRawDataComplete(obj);
                        //            if(resobj.Length==0)
                        //            {
                        //                XFSDevice_ExecuteError(serviceType, "", -500, "-500");
                        //                return;
                        //            }
                        //            (XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.XfsCommand as ExecuteCommand).ResultModel = resobj;
                        //            break;
                        //        }
                        //    default:
                        //        {

                        //            break;
                        //        }
                        //}
                        #endregion

                        XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.Detail = "XFSDevice_ExecuteComplete";

                        var XfsCommand = (XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.XfsCommand as ExecuteCommand);

                        if ((XfsCommand.ResultXfs.GetType().Name.Equals("JArray")))
                        {
                            int len = 0;
                            var data = XFSUtil.XFSPtrToArray(obj, XfsCommand.ResultXfsType, ref len);
                            var model = Array.CreateInstance(XfsCommand.ResultModelType, len);
                            for (int i = 0; i < len; ++i)
                            {
                                var tmp = (IXfsResultModel)Activator.CreateInstance(XfsCommand.ResultModelType);
                                tmp.Fill(data.GetValue(i));
                                model.SetValue(tmp, i);
                            }
                            XfsCommand.ResultModel = model;
                        }
                        else
                        {
                            object data = null;
                            XFSUtil.PtrToStructure(obj, XfsCommand.ResultXfsType, ref data);
                            var model = (IXfsResultModel)Activator.CreateInstance(XfsCommand.ResultModelType);
                            model.Fill(data);
                            XfsCommand.ResultModel = model;
                        }

                        if (XfsCommand != null && XfsCommand.LightControlCommand != null)
                        {
                            ExcuteSiuCommand(XfsCommand.LightControlCommand.CompleteSIU, serviceType);
                        }

                        SendResponse(XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand);
                    }
                }
            }
            catch (Exception ex)
            {
                L4Logger.Error(ex);
            }
        }

        private void SendResponse(object obj)
        {
            L4Logger.Info("Sending Response  => " + JsonConvert.SerializeObject(obj, Formatting.Indented));
            try
            {
                Send(JsonConvert.SerializeObject(obj, Formatting.Indented));
            }
            catch (Exception ex)
            {
                L4Logger.Error(ex);
            }
        }

        [STAThread]
        private void XFSDevice_RegisterError(ServiceTypes serviceType, int obj)
        {
            lock (syncObject)
            {
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.IsExecuteSuccessfully = false;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.ErrorCode = obj;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.Detail = "XFSDevice_RegisterError";
                SendResponse(XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand);
            }
        }

        [STAThread]
        private void XFSDevice_RegisterComplete(ServiceTypes serviceType)
        {
            lock (syncObject)
            {
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.IsExecuteSuccessfully = true;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.Detail = "XFSDevice_RegisterComplete";
                SendResponse(XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand);
            }
        }

        [STAThread]
        private void XFSDevice_OpenError(ServiceTypes serviceType, int obj)
        {
            lock (syncObject)
            {
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.IsExecuteSuccessfully = false;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.ErrorCode = obj;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.Detail = "XFSDevice_OpenError";
                SendResponse(XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand);
            }
        }

        [STAThread]
        private void XFSDevice_OpenComplete(ServiceTypes serviceType)
        {
            L4Logger.Info("OpenComplete => " + serviceType.ToString());
            lock (syncObject)
            {
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.IsExecuteSuccessfully = true;
                XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand.Detail = "XFSDevice_OpenComplete";
                SendResponse(XFS_DevicesCollection.Instance.GetValue(serviceType).CurrentCommand);
            }
        }

        protected IDCCardData[] OnReadRawDataComplete(IntPtr ptr)
        {
            WFSIDCCardData[] data = XFSUtil.XFSPtrToArray<WFSIDCCardData>(ptr);
            IDCCardData[] outerData = new IDCCardData[data.Length];
            for (int i = 0; i < data.Length; ++i)
            {
                outerData[i] = new IDCCardData();
                outerData[i].DataSource = data[i].wDataSource;
                outerData[i].WriteMethod = data[i].fwWriteMethod;
                outerData[i].Status = data[i].wStatus;
                if (data[i].ulDataLength > 0)
                {
                    outerData[i].Data = new byte[data[i].ulDataLength];
                    for (int j = 0; j < data[i].ulDataLength; ++j)
                        outerData[i].Data[j] = Marshal.ReadByte(data[i].lpbData, j);
                }
            }
            return outerData;
        }
        private Wrapper.Common.XFSDeviceBase AddOrGetServiceBase(XfsCommandBase<OpenCommand> Command)
        {
            if (!XFS_DevicesCollection.Instance.IsContainKey(Command.ServiceType))
            {
                ISTATUS TStatusType;
                ICAPS TCapabilityType;
                Wrapper.Common.XFSDeviceBase XFSDevice = null;

                switch (Command.ServiceType)
                {
                    case ServiceTypes.IDC:
                        {
                            TStatusType = new WFSIDCSTATUS();
                            TCapabilityType = new WFSIDCCAPS();
                            XFSDevice = new Wrapper.Common.XFSDeviceBase
                            {
                                StatusClass = TStatusType,
                                CapabilityClass = TCapabilityType
                            };

                            break;
                        }
                    case ServiceTypes.PIN:
                        {
                            TStatusType = new WFSIDCSTATUS();
                            TCapabilityType = new WFSIDCCAPS();
                            //XFSDevice = new XFSDeviceBase<pinst\\\, WFSIDCCAPS>();
                            break;
                        }
                }



                XFS_DevicesCollection.Instance.Add(ServiceTypes.IDC, XFSDevice);

                return XFSDevice;
            }
            else
            {
                var XFSDevice = XFS_DevicesCollection.Instance.GetValue(Command.ServiceType);

                return XFSDevice;
            }
        }
    }
}
