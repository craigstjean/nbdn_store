using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.initialization
{
    public class ConfigureServiceLayer : StartupCommand
    {
        IDictionary<Type, ContainerResolver> resolvers;

        public ConfigureServiceLayer(IDictionary<Type, ContainerResolver> resolvers)
        {
            this.resolvers = resolvers;
        }

        public void run()
        {
			resolvers.Add(typeof(CatalogTasks), new SimpleContainerResolver(() => new StubCatalogTasks()));
			resolvers.Add(typeof(CartTasks), new SimpleContainerResolver(() => new StubCartTasks()));
			resolvers.Add(typeof(ResponseEngine), new SimpleContainerResolver(() => new StubResponseEngine()));
        }
    }
}