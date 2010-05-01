using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tasks
{
    public class DefaultStartupCommandFactory : StartupCommandFactory
    {
        IDictionary<Type, ContainerResolver> all_resolvers;

        public DefaultStartupCommandFactory(IDictionary<Type, ContainerResolver> all_resolvers)
        {
            this.all_resolvers = all_resolvers;
        }

        public Command create_command_for(Type command_type)
        {
            return (Command) command_type.GetConstructors()[0].Invoke(new object[] {all_resolvers});
        }
    }
}