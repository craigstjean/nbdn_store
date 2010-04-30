using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class CustomContainerFramework : ContainerFramework
    {
        IDictionary<Type, ContainerResolver> resolvers;

        public CustomContainerFramework(IDictionary<Type, ContainerResolver> resolvers)
        {
            this.resolvers = resolvers;
        }

        public Dependency a<Dependency>()
        {
            return (Dependency) a(typeof (Dependency));
        }

        public object a(Type dependency)
        {
            ensure_resolver_is_registered_for(dependency);
            try
            {
                return resolvers[dependency].resolve();
            }
            catch (Exception e)
            {
                throw new ResolverException(dependency, e);
            }
        }

        void ensure_resolver_is_registered_for(Type dependency)
        {
            if (! this.resolvers.ContainsKey(dependency))
                throw new ResolverNotRegisteredException(dependency);
        }
    }
}