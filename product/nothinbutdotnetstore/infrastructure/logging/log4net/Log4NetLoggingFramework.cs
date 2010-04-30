using log4net;

namespace nothinbutdotnetstore.infrastructure.logging.log4net
{
    public class Log4NetLoggingFramework : LoggingFramework
    {
        ILog underlying_log;

        public Log4NetLoggingFramework(ILog underlying_log)
        {
            this.underlying_log = underlying_log;
        }

        public void informational(string message)
        {
            underlying_log.Info(message);
        }
    }
}