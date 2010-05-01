using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.initialization;

namespace nothinbutdotnetstore.tasks
{
    public class StartupBuilder
    {
        IList<Command> all_commands;
        StartupCommandFactory startup_command_factory;

        public StartupBuilder(Type initial_command):this(new List<Command>(),
            new DefaultStartupCommandFactory(new Dictionary<Type, ContainerResolver>()),initial_command)
        {
        }

        public StartupBuilder(IList<Command> all_commands, StartupCommandFactory startup_command_factory,Type initial_command)
        {
            this.all_commands = all_commands;
            this.startup_command_factory = startup_command_factory;

            follow_with(initial_command);
        }

        public StartupBuilder followed_by<T>() where T : StartupCommand
        {
            follow_with(typeof (T));
            return this;
        }

        void follow_with(Type command_type)
        {
            all_commands.Add(startup_command_factory.create_command_for(command_type));
        }

        public void finish_by<T>() where T : StartupCommand
        {
            follow_with(typeof(T));
            foreach (var command in all_commands) command.run();
        }
    }
}