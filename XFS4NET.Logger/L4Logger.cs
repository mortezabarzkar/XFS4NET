[assembly: log4net.Config.XmlConfigurator(ConfigFile = "", Watch = true)]
namespace XFS4NET.Logger
{
    using System;
    using log4net;
    using log4net.Repository.Hierarchy;
    using log4net.Core;
    using log4net.Appender;
    using log4net.Layout;
    using log4net.Config;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using static log4net.Appender.FileAppender;

    public static class L4Logger
    {
        private static ILog logger = null;

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                {
                    var repository = LogManager.CreateRepository("XFS4NET");

                    logger = log4net.LogManager.GetLogger("XFS4NET", "XFS4NET");

                    RollingFileAppender fileAppender = new RollingFileAppender
                    {
                        Name = "LogFileAppenderDevice",
                        Layout = new PatternLayout("%d [%t] %logger {%property{method}}  [%property{NDC}]  ->  %m%n"),
                        File = @"C:\XFS4NET\logs\",
                        DatePattern = "yyyy_MM_dd'.log'",
                        AppendToFile = true,
                        RollingStyle = RollingFileAppender.RollingMode.Composite,
                        MaxSizeRollBackups = 5,
                        MaxFileSize = 200000000,
                        StaticLogFileName = false,
                        Encoding = System.Text.Encoding.UTF8,
                        LockingModel = new MinimalLock()
                    };
                    fileAppender.ActivateOptions();
                    //(logger.Logger as Logger).AddAppender(fileAppender);
                    BasicConfigurator.Configure(repository, fileAppender);
                }
                return logger;
                //return logger ?? (logger = log4net.LogManager.GetLogger("Dariche.Core.Devices"));
            }
        }

        public static void Debug(object message)
        {
            Logger.Debug(message);
        }

        public static void Debug(object message, Exception exception)
        {
            Logger.Debug(message, exception);
        }

        public static void Error(object message)
        {
            Logger.Error(message);
        }

        public static void Error(object message, Exception exception)
        {
            Logger.Error(message, exception);
        }

        //public static void Info(object message)
        //{
        //    Logger.Info(message);
        //}

        public static void Info(object message, Exception exception)
        {
            Logger.Info(message, exception);
        }

        public static void Warning(object message)
        {
            Logger.Warn(message);
        }

        public static void Warning(object message, Exception exception)
        {
            Logger.Warn(message, exception);
        }

        public static void Debug(object message, [CallerMemberName] string memberName = "",
              [CallerFilePath] string sourceFilePath = "",
              [CallerLineNumber] int sourceLineNumber = 0)
        {
            Logger.Debug(message);
        }

        public static void Debug(object message, Exception exception, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Logger.Debug(message, exception);
        }

        public static void Error(Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Logger.Error(string.Format(
                "Error Logged From method {0} in file {1} at line {2}",
                memberName, sourceFilePath, sourceLineNumber), ex);
        }

        public static void Error(object message ,[CallerMemberName] string memberName = "",
          [CallerFilePath] string sourceFilePath = "",
          [CallerLineNumber] int sourceLineNumber = 0)
        {
            Logger.Error(string.Format(
                 "Error Logged From method {0} in file {1} at line {2} -> {3}",
                 memberName, sourceFilePath, sourceLineNumber, message));
        }

        public static void Error(object message, Exception exception, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Logger.Error(message, exception);
        }

        public static void Info(object message, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            ThreadContext.Properties["method"] = string.Format("{0} ( {1} , {2} )",
                System.IO.Path.GetFileNameWithoutExtension(sourceFilePath), memberName, sourceLineNumber);

            Logger.Info(message);
        }

        public static void Info(object message, Exception exception, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Logger.Info(message, exception);
        }

        public static void Warning(object message, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Logger.Warn(message);
        }

        public static void Warning(object message, Exception exception, [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Logger.Warn(message, exception);
        }

    }
}
