using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class ResolverNotRegisteredException
    {
        public Type type_that_has_no_resolver { get; private set; }
    }
}