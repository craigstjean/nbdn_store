using System;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class ChainedDependencyResolver : ContainerResolver
    {
        Type type_to_resolve;
        ContainerFramework container;
        ConstructorSelector constructor_selector;

        public ChainedDependencyResolver(Type type_to_resolve, ContainerFramework container_framework, ConstructorSelector constructor_selector)
        {
            this.type_to_resolve = type_to_resolve;
            this.container = container_framework;
            this.constructor_selector = constructor_selector;
        }

        public object resolve()
        {
            var applicable_constructor = constructor_selector.get_applicable_constructor_on(type_to_resolve);

            var dependencies = applicable_constructor.GetParameters()
                .Select(info => info.ParameterType)
                .Select(parameter_type => container.a(parameter_type));


            return applicable_constructor.Invoke(dependencies.ToArray());
        }
    }
}