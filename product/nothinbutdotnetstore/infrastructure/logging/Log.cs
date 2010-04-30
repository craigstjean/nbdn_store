using System;
using System.Diagnostics;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class Log
    {
        public static LoggingFramework an
        {
            get
            {
                return Container.resolve.a<LoggingFrameworkFactory>().create_logger_bound_to(resolve_calling_type());
            }
        }

        static Type resolve_calling_type()
        {
            return new StackFrame(2).GetMethod().DeclaringType;
        }
    }
}