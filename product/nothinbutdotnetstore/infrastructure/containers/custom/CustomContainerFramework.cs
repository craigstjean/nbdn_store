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

        public TDependency an<TDependency>()
        {
            ensure_resolver_is_registered_for<TDependency>();
            try
            {
                return (TDependency) resolvers[typeof (TDependency)].resolve();
            }
            catch (Exception e)
            {
                throw new ResolverException(typeof (TDependency), e);
            }
        }

        void ensure_resolver_is_registered_for<TDependency>()
        {
            if (! this.resolvers.ContainsKey(typeof (TDependency)))
                throw new ResolverNotRegisteredException(typeof (TDependency));
        }
    }
}