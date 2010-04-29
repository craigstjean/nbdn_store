using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.infrastructure
{
    public class DefaultMapperRegistry : MapperRegistry
    {
        readonly Dictionary<MapperType, object> all_mappers;

        public DefaultMapperRegistry(Dictionary<MapperType, object> all_mappers)
        {
            this.all_mappers = all_mappers;
        }

        public Mapper<Input, Output> get_mapper_for<Input, Output>()
        {
            var key = all_mappers.Keys.FirstOrDefault(x => x.Input.Equals(typeof (Input)) && x.Output.Equals(typeof (Output)));

            if (key == null)
                return new MissingMapper<Input, Output>();

            return (Mapper<Input, Output>) all_mappers[key];
        }
    }
}