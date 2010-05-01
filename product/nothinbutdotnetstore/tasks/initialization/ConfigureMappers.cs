using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application.mappers;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.initialization
{
    public class ConfigureMappers : StartupCommand
    {
        IDictionary<Type, ContainerResolver> resolvers;

        public ConfigureMappers(IDictionary<Type, ContainerResolver> resolvers)
        {
            this.resolvers = resolvers;
        }

        public void run()
        {
            var all_mappers = new Dictionary<Type, object>
				{
					{typeof (Mapper<NameValueCollection, Department>), new DepartmentMapper()},
					{typeof (Mapper<NameValueCollection, Product>), new ProductMapper()}
				};

			resolvers.Add(typeof(MapperRegistry), new SimpleContainerResolver(() => new DefaultMapperRegistry(all_mappers)));
			resolvers.Add(typeof(RequestFactory), new SimpleContainerResolver(() => new DefaultRequestFactory(Container.resolve.a<MapperRegistry>())));
        }
    }
}