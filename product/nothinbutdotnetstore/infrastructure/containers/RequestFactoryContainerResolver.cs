using System;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure.containers
{
	public class RequestFactoryContainerResolver : ContainerResolver
	{
		MapperRegistry mapper_registry;
		RequestFactory request_factory;

		public RequestFactoryContainerResolver(MapperRegistry mapper_registry)
		{
			this.mapper_registry = mapper_registry;
			request_factory = new DefaultRequestFactory(mapper_registry);
		}

		public object resolve()
		{
			return request_factory;
		}
	}
}