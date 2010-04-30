using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class SimpleContainerResolver : ContainerResolver
    {
        Func<object> factory;

        public SimpleContainerResolver(Func<object> factory)
        {
            this.factory = factory;
        }

        public object resolve()
        {
            return factory();
        }
    }
}