using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.custom;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.custom;

namespace nothinbutdotnetstore.tasks.initialization
{
    public class ConfigureCoreServices : StartupCommand
    {
        IDictionary<Type, ContainerResolver> resolvers;

        public ConfigureCoreServices(IDictionary<Type, ContainerResolver> resolvers)
        {
            this.resolvers = resolvers;
        }

        public void run()
        {
            resolvers.Add(typeof (LoggingFrameworkFactory), new SimpleContainerResolver(() => new TextWriterLoggingFrameworkFactory()));
            Container.container_resolver = () => new CustomContainerFramework(resolvers);
        }
    }
}