using System;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure.containers
{
	public class RequestFactoryContainerResolver : ContainerResolver
	{
		MapperRegistry mapper_registry;

		public RequestFactoryContainerResolver(MapperRegistry mapper_registry)
		{
			this.mapper_registry = mapper_registry;
		}

		public object resolve()
		{
			return new DefaultRequestFactory(mapper_registry);
		}
	}
}