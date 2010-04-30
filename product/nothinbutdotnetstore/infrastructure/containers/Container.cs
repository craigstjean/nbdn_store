using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class Container
    {
        public static Func<ContainerFramework> container_resolver = delegate
        {
            throw new NotImplementedException();
        };

        public static ContainerFramework resolve
        {
            get { throw new NotImplementedException(); }
        }
    }
}