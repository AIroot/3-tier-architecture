using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IOS.D2S.Core.Utils
{
    public static class FileLogger
    {
        public static string EventPattern = AppSettingManager.GetAppSetting("LogPatternEvent");
        public static string ErrorPattern = AppSettingManager.GetAppSetting("LogPatternError");
        public static string LogPath = AppSettingManager.GetAppSetting("LogFilePath");
        public static string LogFileSyntax = AppSettingManager.GetAppSetting("LogFileName");

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string LogFileName = LogFileSyntax + DateTime.Today.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + ".log";

        //private static readonly string EventFileName = DateTime.Today.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + ".log";

        private static void EventLogger()
        {
            try
            {
                var hierarchy = (Hierarchy)LogManager.GetRepository();

                var patternLayout = new PatternLayout { ConversionPattern = EventPattern };
                patternLayout.ActivateOptions();

                var pathName = LogPath + LogFileName;

                var roller = new RollingFileAppender
                {
                    AppendToFile = true,
                    File = pathName,
                    Layout = patternLayout,
                    MaxSizeRollBackups = 5,
                    MaximumFileSize = "1GB",
                    RollingStyle = RollingFileAppender.RollingMode.Size,
                    StaticLogFileName = true
                };
                roller.ActivateOptions();
                hierarchy.Root.AddAppender(roller);

                var memory = new MemoryAppender();
                memory.ActivateOptions();
                hierarchy.Root.AddAppender(memory);

                hierarchy.Root.Level = log4net.Core.Level.Debug;
                hierarchy.Configured = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void ErrorLogger()
        {
            try
            {
                var hierarchy = (Hierarchy)LogManager.GetRepository();

                var patternLayout = new PatternLayout { ConversionPattern = EventPattern };
                patternLayout.ActivateOptions();

                var pathName = LogPath + LogFileName;

                var roller = new RollingFileAppender
                {
                    AppendToFile = true,
                    File = pathName,
                    Layout = patternLayout,
                    MaxSizeRollBackups = 5,
                    MaximumFileSize = "1GB",
                    RollingStyle = RollingFileAppender.RollingMode.Size,
                    StaticLogFileName = true
                };
                roller.ActivateOptions();
                hierarchy.Root.AddAppender(roller);

                var memory = new MemoryAppender();
                memory.ActivateOptions();
                hierarchy.Root.AddAppender(memory);

                hierarchy.Root.Level = log4net.Core.Level.Debug;
                hierarchy.Configured = true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        static FileLogger()
        {
            //XmlConfigurator.Configure();
            EventLogger();
            ErrorLogger();
        }


        //private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //static FileLogger()
        //{
        //    //XmlConfigurator.Configure();
        //}

        //public static void Error(string message, MethodBase method, Exception exception)
        //{
        //    log4net.GlobalContext.Properties["methodProperty"] = method.Name;
        //    if (method.ReflectedType != null)
        //        log4net.GlobalContext.Properties["classProperty"] = method.ReflectedType.Name;
        //    Logger.Error(message, exception);
        //}

        public static void Info(string message)
        {
            try
            {
                Log.Info(message);
            }
            catch (Exception)
            {

            }

        }

        public static void Debug(string message)
        {
            Log.Debug(message);
        }

        public static void Warn(string message)
        {
            Log.Warn(message);
        }

        public static void Error(string message, Exception exception)
        {
            try
            {
                Log.Error(message, exception);
            }
            catch (Exception)
            {

            }

        }

        public static void Fatal(string message, Exception exception)
        {
            Log.Fatal(message, exception);
        }
    }

    public static class AppSettingManager
    {
        public static string GetAppSetting(string key)
        {
            return new AppSettingsReader().GetValue(key, typeof(String)).ToString();
        }
    }
}
