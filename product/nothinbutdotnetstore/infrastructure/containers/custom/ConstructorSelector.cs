using System;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers.custom
{
    public interface ConstructorSelector
    {
        ConstructorInfo get_applicable_constructor_on(Type type);

    }
}