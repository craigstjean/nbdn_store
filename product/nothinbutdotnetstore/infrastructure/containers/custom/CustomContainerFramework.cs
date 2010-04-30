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
            ensure_resolver_is_registered_for<Dependency>();
            try
            {
                return (Dependency) resolvers[typeof (Dependency)].resolve();
            }
            catch (Exception e)
            {
                throw new ResolverException(typeof (Dependency), e);
            }
        }

        void ensure_resolver_is_registered_for<Dependency>()
        {
            if (! this.resolvers.ContainsKey(typeof (Dependency)))
                throw new ResolverNotRegisteredException(typeof (Dependency));
        }
    }
}