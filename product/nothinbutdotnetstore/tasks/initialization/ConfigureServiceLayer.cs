using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.stubs;

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
            CatalogTasks catalog_tasks = new StubCatalogTasks();
            CartTasks cart_tasks = new StubCartTasks();
        }
    }
}