using System;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public interface LoggingFrameworkFactory
    {
        LoggingFramework create_logger_bound_to(Type calling_type);
    }
}