using System;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
	public class ChainedDependencyResolver : ContainerResolver
	{
		Type type_to_resolve;
		ContainerFramework resolver;
		ConstructorSelector constructor_selector;

		public ChainedDependencyResolver(Type type_to_resolve, ContainerFramework container_framework, ConstructorSelector constructor_selector)
		{
			this.type_to_resolve = type_to_resolve;
			this.resolver = container_framework;
			this.constructor_selector = constructor_selector;
		}

		public object resolve()
    	{
    		ConstructorInfo constructor_info = constructor_selector.get_applicable_constructor_on(type_to_resolve);

			var dependencies = new object[constructor_info.GetParameters().Length];
			for (int i = 0; i < constructor_info.GetParameters().Length; i++)
    		{
				dependencies[i] = resolver.a(constructor_info.GetParameters()[i].ParameterType.GetType());
    		}

    		return constructor_info.Invoke(dependencies);
    	}
	}
}