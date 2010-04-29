using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure
{
    public class DefaultMapperRegistry : MapperRegistry
    {
        IDictionary<Type, object> all_mappers;

        public DefaultMapperRegistry(IDictionary<Type, object> all_mappers)
        {
            this.all_mappers = all_mappers;
        }

        public Mapper<Input, Output> get_mapper_for<Input, Output>()
        {
            var key = all_mappers.Keys.FirstOrDefault(x => typeof (Mapper<Input, Output>) == x);

            if (key == null)
                return new MissingMapper<Input, Output>();

            return (Mapper<Input, Output>) all_mappers[key];
        }
    }
}