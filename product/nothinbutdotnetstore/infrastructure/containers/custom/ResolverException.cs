using System;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public class ResolverException :Exception
    {
        public ResolverException(Type object_type, Exception inner) : base("This is my message.", inner)
        {
            type_that_could_not_be_resolved = object_type;
        }

        public Type type_that_could_not_be_resolved { get; private set; }
    }
}