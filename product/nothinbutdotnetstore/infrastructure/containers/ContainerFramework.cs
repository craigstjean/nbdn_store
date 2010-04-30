using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface ContainerFramework
    {
        Dependency a<Dependency>();
        object a(Type dependency);
    }
}