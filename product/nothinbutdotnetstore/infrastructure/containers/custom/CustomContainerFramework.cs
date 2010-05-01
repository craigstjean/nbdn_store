using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class CustomContainerFramework : ContainerFramework
    {
        readonly IDictionary<Type, ContainerResolver> Resolvers;

        public CustomContainerFramework(IDictionary<Type, ContainerResolver> resolvers)
        {
            Resolvers = resolvers;
        }

        public TDependency an<TDependency>()
        {
            ContainerResolver resolver;

            if (!Resolvers.TryGetValue(typeof (TDependency), out resolver))
            {
                throw new ResolverNotRegisteredException(typeof(TDependency));
            }

            try
            {
                return (TDependency)resolver.resolve(); 
            }
            catch(Exception e)
            {
                throw new ResolverException(typeof(TDependency), e);
            }
               
        }
    }
}