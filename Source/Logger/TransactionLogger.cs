using log4net;
using ServiceInterfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Logger
{
    public class TransactionLogger : ITransactionLogger
    {
        private static ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public TransactionLogger()
        {
            var resourceName = string.Empty;
#if DEBUG
            resourceName = (from resource in Assembly.GetExecutingAssembly().GetManifestResourceNames()
                            where resource.EndsWith("Local.config")
                            select resource).FirstOrDefault();
#else
            resourceName = (from resource in Assembly.GetExecutingAssembly().GetManifestResourceNames()
                            where resource.EndsWith("Release.config")
                            select resource).FirstOrDefault();
#endif
            var configFile = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        public void CreateErrorLog(string sourceClassName, string sourceMethodName, Exception error)
        {
            var errorSourceInfo = "ClassName Source:" + sourceClassName + ", Method Name:" + sourceMethodName;
            _log.Error(errorSourceInfo, error);
        }

        public void CreateInfoLog(string sourceClassName, string sourceMethodName, string messageInformationLog)
        {
            var logSourceInfo = "ClassName Source:" + sourceClassName + ", Method Name:" + sourceMethodName;
            _log.Info(logSourceInfo + "\r\n" + messageInformationLog);
        }

        public void CreateWarningLog(string sourceClassName, string sourceMethodName, string messageInformationLog)
        {
            var logSourceInfo = "ClassName Source:" + sourceClassName + ", Method Name:" + sourceMethodName;
            _log.Warn(logSourceInfo + "\r\n" + messageInformationLog);
        }
    }
}
