using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class ResolverException :Exception
    {
        public Type type_that_could_not_be_resolved { get; private set; }
    }
}