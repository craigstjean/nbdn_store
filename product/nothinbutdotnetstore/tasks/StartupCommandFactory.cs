using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks
{
    public interface StartupCommandFactory
    {
        Command create_command_for(Type command_type);
    }
}