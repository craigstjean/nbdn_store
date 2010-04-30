using System;
using log4net;

namespace nothinbutdotnetstore.infrastructure.logging.log4net
{
    public class Log4NetLoggingFactory : LoggingFrameworkFactory
    {
        public LoggingFramework create_logger_bound_to(Type calling_type)
        {
            return new Log4NetLoggingFramework(LogManager.GetLogger(calling_type));
        }
    }
}