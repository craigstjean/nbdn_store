using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.custom;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.custom;

namespace nothinbutdotnetstore.tasks.initialization
{
    public class ConfigureCoreServices
    {
        void run()
        {
            IDictionary<Type, ContainerResolver> resolvers = new Dictionary<Type, ContainerResolver>();
            resolvers.Add(typeof (LoggingFrameworkFactory), new SimpleContainerResolver(() => new TextWriterLoggingFrameworkFactory()));
            Container.container_resolver = () => new CustomContainerFramework(resolvers);
        }
    }
}