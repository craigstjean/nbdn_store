using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class ResolverNotRegisteredException : Exception
    {
        public Type type_that_has_no_resolver { get; private set; }

        public ResolverNotRegisteredException(Type object_type)
        {
            type_that_has_no_resolver = object_type;
        }
    }
}