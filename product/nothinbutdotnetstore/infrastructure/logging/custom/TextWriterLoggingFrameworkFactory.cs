using System;

namespace nothinbutdotnetstore.infrastructure.logging.custom
{
    public class TextWriterLoggingFrameworkFactory : LoggingFrameworkFactory
    {
        public LoggingFramework create_logger_bound_to(Type calling_type)
        {
            return new TextWriterLoggingFramework(Console.Out);
        }
    }
}