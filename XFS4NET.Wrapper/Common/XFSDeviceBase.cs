using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;
using XFS4NET.Model.Common;
using XFS4NET.Model;
using XFS4NET.Model.Command;
using System.Threading.Tasks;
using XFS4NET.Logger;

namespace XFS4NET.Wrapper.Common
{
    public class XFSDeviceBase : UserControl
    {

        public class GlobalEvent
        {
            public int EventId { get; set; }
            public object EventParam { get; set; }
            public Type EventParamType { get; set; }
        }

        public ServiceTypes serviceType;
        public XfsCommandBase<XfsCommand> CurrentCommand = null;


        #region Events
        public event Action<ServiceTypes> OpenComplete;
        public event Action<ServiceTypes,int> OpenError;
        public event Action<ServiceTypes> CloseComplete;
        public event Action<ServiceTypes> RegisterComplete;
        public event Action<ServiceTypes,int> RegisterError;
        public event Action<ServiceTypes,IntPtr, int> ExecuteComplete;
        public event Action<ServiceTypes,  int> ExecuteCompleteError;
        public event Action<ServiceTypes> CancelComplete;
        public event Action<ServiceTypes,int> CancelError;
        public event Action<ServiceTypes,int, IntPtr> ExecuteEvent;
        #endregion

        public ISTATUS StatusClass;
        public ICAPS CapabilityClass;
        public Type StatusType;
        public Type CapabilityType;
        #region Fields
        protected ushort hService;
        public int HService
        {
            get
            {
                return hService;
            }
        }
        protected string serviceName;
        public string ServiceName
        {
            get
            {
                return serviceName;
            }
        }
        protected bool autoRegister = false;
        protected int requestID = 0;
        protected bool isStartup = false;
        /// <summary>
        /// timeout of excution
        /// </summary>
        public int TimeOut { get; set; }
        /// <summary>
        /// dulication of handle for crossing thread
        /// </summary>
        protected IntPtr MessageHandle;
        public int StatusCommandCode { get; set; }
        public int CapabilityCommandCode { get; set; }
        public List<int> eventHandlers;
        public List<int> commandHandlers;

        public List<GlobalEvent> GlobalEvents;
        #endregion

        public XFSDeviceBase()
        {
            this.Width = this.Height = 0;
            this.Visible = false;
            MessageHandle = Handle;
            eventHandlers = new List<int>();
            commandHandlers = new List<int>();
            GlobalEvents = new List<GlobalEvent>();
        }

        public void ResetEvents()
        {
            OpenComplete = null;
            OpenError = null;
            RegisterComplete = null;
            RegisterError = null;
            CancelComplete = null;
            CancelError = null;
            ExecuteComplete = null;
            ExecuteCompleteError = null;
            ExecuteEvent = null;

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg >= XFSDefinition.WFS_OPEN_COMPLETE &&
                m.Msg <= XFSDefinition.WFS_SYSTEM_EVENT)
            {
                var msg = m.Msg;
                Task.Run(() => { L4Logger.Info(string.Format("Xfs WndProc ServiceName {0} msg {1} ", ServiceName, msg)); });
                WFSRESULT result = new WFSRESULT();
                if (m.LParam != IntPtr.Zero)
                    XFSUtil.PtrToStructure(m.LParam, ref result);
                switch (m.Msg)
                {
                    case XFSDefinition.WFS_OPEN_COMPLETE:
                        {
                            Task.Run(() => { L4Logger.Info("OpenCompleted =>  " + serviceType.ToString()); });
                            OnOpenComplete();
                        }
                        break;
                    case XFSDefinition.WFS_CLOSE_COMPLETE:
                        OnCloseComplete();
                        break;
                    case XFSDefinition.WFS_REGISTER_COMPLETE:
                        {
                            Task.Run(() => { L4Logger.Info("RegisterCompleted =>  " + serviceType.ToString()); });
                            OnRegisterComplete();
                        }
                        break;
                    case XFSDefinition.WFS_EXECUTE_COMPLETE:
                        Task.Run(() => { L4Logger.Info( string.Format("ExecuteCompleted  Service => {0} CommandCode => {1} " ,
                            serviceType.ToString(), result.dwCommandCodeOrEventID)); });

                        if (commandHandlers.Contains(result.dwCommandCodeOrEventID))
                            OnExecuteComplete(ref result, result.dwCommandCodeOrEventID);
                        break;
                    case XFSDefinition.WFS_EXECUTE_EVENT:
                    case XFSDefinition.WFS_SERVICE_EVENT:
                    case XFSDefinition.WFS_USER_EVENT:
                    case XFSDefinition.WFS_SYSTEM_EVENT:
                        Task.Run(() => { L4Logger.Info(string.Format("WFS_SYSTEM_EVENT servicename {0}  lpBuffer {1} EventId => ", 
                            serviceName, result.lpBuffer, result.dwCommandCodeOrEventID)); });
                        if (eventHandlers.Contains(result.dwCommandCodeOrEventID))
                            OnExecuteEvent(ref result);   
                        else
                        {
                            Task.Run(() =>
                            {
                                L4Logger.Info(string.Format("EventId = {0} AcceptsEvents = {1}",
                                    result.dwCommandCodeOrEventID,
                                    string.Join(",", eventHandlers.ToArray())));
                            });
                        }
                        break;
                }
                XfsApi.WFSFreeResult(ref result);
            }
            else
                base.WndProc(ref m);
        }

        protected virtual void OnOpenComplete()
        {
            if (OpenComplete != null)
                OpenComplete(serviceType);
            if (autoRegister)
            {
                InnerRegister(GetEventClass());
            }
        }

        protected virtual bool InnerGetInfo<T>(int category, IntPtr inParam, Type type, out T value )
        {
            IntPtr pOutParam = IntPtr.Zero;

            value = (T)Activator.CreateInstance(type);           
            int hResult = XfsApi.WFSGetInfo(hService, category, inParam, TimeOut, ref pOutParam);
            if (hResult == XFSDefinition.WFS_SUCCESS)
            {
                WFSRESULT wfsResult = (WFSRESULT)Marshal.PtrToStructure(pOutParam, typeof(WFSRESULT));
                if (wfsResult.hResult == XFSDefinition.WFS_SUCCESS)
                {
                    value = (T)((ISTATUS)value).UnMarshal(wfsResult.lpBuffer);
                    XfsApi.WFSFreeResult(pOutParam);
                    return true;                   
                }
            }
            XfsApi.WFSFreeResult(pOutParam);
            return false;
        }
        protected void InnerRegister(int eventClasses)
        {
            Task.Run(() => { L4Logger.Info(string.Format("Register service {0} EventClass {1} MessageHandle {2} , class {3}", hService, eventClasses, MessageHandle, this.GetType().Name)); });
            int hResult = XfsApi.WFSAsyncRegister(hService, eventClasses, MessageHandle
                , MessageHandle, ref requestID);
            if (hResult != XFSDefinition.WFS_SUCCESS)
            {
                OnRegisterError(hResult);
            }
        }
        protected virtual int GetEventClass()
        {
            return XFSDefinition.EXECUTE_EVENTS | XFSDefinition.SERVICE_EVENTS
                | XFSDefinition.SYSTEM_EVENTS | XFSDefinition.USER_EVENTS;
        }
        protected virtual void OnOpenError(int code)
        {
            if (OpenError != null)
                OpenError(serviceType, code);
        }
        protected virtual void OnCloseComplete()
        {
            if (CloseComplete != null)
                CloseComplete(serviceType);
        }
        protected virtual void OnRegisterComplete()
        {
            if (RegisterComplete != null)
                RegisterComplete(serviceType);
        }
        protected virtual void OnRegisterError(int code)
        {
            if (RegisterError != null)
                RegisterError(serviceType, code);
        }
        protected virtual void OnExecuteComplete(ref WFSRESULT result, int EventID)
        {
            //Task.Run(() => { L4Logger.Info("OnExecuteComplete  ServiceName => " + serviceName); });
            if (result.hResult == 0)
            {
                if (ExecuteComplete != null)
                    ExecuteComplete?.Invoke(serviceType, result.lpBuffer, EventID);
            }
            else
            {
                if (ExecuteCompleteError != null)
                    ExecuteCompleteError?.Invoke(serviceType, result.hResult);
            }
        }
        protected virtual void OnExecuteEvent(ref WFSRESULT result)
        {
            //Task.Run(() => { L4Logger.Info("OnExecuteEvent  ServiceName => " + serviceName); });
            if (ExecuteEvent != null)
                ExecuteEvent.Invoke(serviceType, result.dwCommandCodeOrEventID, result.lpBuffer);
        }
        protected virtual void OnServiceEvent(ref WFSRESULT result)
        { }
        protected virtual void OnUserEvent(ref WFSRESULT result)
        { }
        protected virtual void OnSystemEvent(ref WFSRESULT result)
        { }
        public void Open(string logicName, bool paramAutoRegister = true,
            string appID = "CitydiXFS", string lowVersion = "3.0",
            string highVersion = "3.0")
        {

            try
            {
                Task.Run(() => { L4Logger.Info("xfs to open service => " + logicName); });
                serviceName = logicName;
                autoRegister = paramAutoRegister;
                int requestVersion = XFSUtil.ParseVersionString(lowVersion,
                    highVersion);
                WFSVERSION srvcVersion = new WFSVERSION();
                WFSVERSION spVersion = new WFSVERSION();
                int hResult = 0;
                if (!isStartup)
                {
                    hResult = XfsApi.WFSStartUp(requestVersion, ref spVersion);
                    Task.Run(() => { L4Logger.Info("xfs start result =>" + hResult); });
                    if (hResult != XFSDefinition.WFS_SUCCESS &&
                        hResult != XFSDefinition.WFS_ERR_ALREADY_STARTED)
                    {
                        OnOpenError(hResult);
                        return;
                    }
                }
                appID = "Citydi";
                Task.Run(() =>
                {
                    L4Logger.Info(string.Format(
                    "logicName {0} appID {1} hService {2} MessageHandle {3} requestVersion {4} srvcVersion {5} spVersion {6} requestID {7}",
                    logicName, appID, hService, MessageHandle, requestVersion, srvcVersion, spVersion, requestID));
                });

                //hResult= XfsApi.WFSOpen(logicName, IntPtr.Zero, appID, XFSDefinition.WFS_TRACE_API, XFSConstants.WFS_INDEFINITE_WAIT, requestVersion, ref srvcVersion, ref spVersion, ref hService);
                //L4Logger.Info(string.Format(" service {0} WFSOpen resule {1}", logicName, hResult));
                hResult = XfsApi.WFSAsyncOpen(logicName, IntPtr.Zero, appID, XFSDefinition.WFS_TRACE_ALL_API,
                    XFSConstants.WFS_INDEFINITE_WAIT, ref hService,
                MessageHandle, requestVersion, ref srvcVersion, ref spVersion,
                ref requestID);
                Task.Run(() => { L4Logger.Info(string.Format(" service {0} WFSAsyncOpen resule {1}", logicName, hResult)); });
                if (hResult != XFSDefinition.WFS_SUCCESS)
                {
                    OnOpenError(hResult);
                }
            }
            catch (Win32Exception ex)
            {
                L4Logger.Info(ex);
            }
            catch (Exception ex)
            {
                L4Logger.Error(ex);
                OnOpenError(-10000);
            }

        }
        public void Register(int eventClasses = XFSDefinition.EXECUTE_EVENTS |
            XFSDefinition.SERVICE_EVENTS | XFSDefinition.SYSTEM_EVENTS |
            XFSDefinition.USER_EVENTS)
        {
            InnerRegister(eventClasses);
        }
        public bool GetStatus(out ISTATUS value, int CustomStatusCommandCode, Type StatusType)
        {
            return InnerGetInfo(CustomStatusCommandCode, IntPtr.Zero, StatusType, out value);
        }
       
        public bool GetCapability(out ICAPS value)
        {
            return InnerGetInfo(CapabilityCommandCode, IntPtr.Zero, CapabilityType, out value);
        }
        public void Close()
        {
            //
        }

        public void Reset()
        {
            //
        }
        public void Cancel(bool NeedNotify = true)
        {
            int hResult = XfsApi.WFSCancelAsyncRequest(hService, requestID);
            if (hResult != XFSDefinition.WFS_SUCCESS && CancelError != null && NeedNotify)
                CancelError.Invoke(serviceType, hResult);
            else
            {
                if (CancelComplete != null && NeedNotify)
                    CancelComplete.Invoke(serviceType);
            }
        }
        protected void HandleExecutionResult(int hResult, Action completeHandler, Action<string, int, string> errorHandler)
        {
            if (hResult == XFSDefinition.WFS_SUCCESS)
                completeHandler();
            else
                errorHandler(serviceName, hResult, hResult.ToString());
        }
        protected void HandleAysncExcutionResult(int hResult, Action<string, int, string> errorHandler)
        {
            if (hResult != XFSDefinition.WFS_SUCCESS)
                OnExecuteError(errorHandler, hResult);
        }
        public int ExecuteCommand(int commandCode, IntPtr ptrParam, Action<ServiceTypes, string, int, string> errorHandler = null)
        {
            Task.Run(() => { L4Logger.Info(string.Format("ExecuteCommand service {0}  {1} MessageHandle {2} , class {3}", hService, "", MessageHandle, this.GetType().Name)); });

            int hResult = XfsApi.WFSAsyncExecute(hService, commandCode, ptrParam, TimeOut, MessageHandle, ref requestID);
            Task.Run(() => { L4Logger.Info(string.Format("WFSAsyncExecute  serviceName {0}  Result {1} ", serviceName, hResult)); });
            if (hResult != XFSDefinition.WFS_SUCCESS && errorHandler != null)
                errorHandler(serviceType, serviceName, hResult, string.Empty);
            return hResult;
        }
        protected virtual void OnExecuteError(Action<string, int, string> errorHandler, int code)
        {
            if (errorHandler != null)
                errorHandler(ServiceName, code, code.ToString());
        }

    }
}
