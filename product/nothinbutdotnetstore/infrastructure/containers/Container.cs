
using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class Container
    {
        public static Func<ContainerFramework> container_resolver = delegate
        {
            throw new NotImplementedException("You have forgotten to configure a container framework resolver");
        };

        public static ContainerFramework resolve
        {
            get { return container_resolver(); }
        }
    }
}