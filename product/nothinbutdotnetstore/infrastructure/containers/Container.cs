#region

using System;

#endregion

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class Container
    {
        public static Func<IContainerFramework> container_resolver = delegate
        {
            throw new NotImplementedException();
        };

        public static IContainerFramework resolve
        {
            get { return container_resolver(); }
        }
    }
}