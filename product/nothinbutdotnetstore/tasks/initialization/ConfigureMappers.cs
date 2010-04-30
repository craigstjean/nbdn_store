using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application.mappers;

namespace nothinbutdotnetstore.tasks.initialization
{
    public class ConfigureMappers : StartupCommand
    {
        public void run()
        {
            IDictionary<Type, object> all_mappers = new Dictionary<Type, object>();
            all_mappers.Add(typeof (Mapper<NameValueCollection, Department>), new DepartmentMapper());
            all_mappers.Add(typeof (Mapper<NameValueCollection, Product>), new ProductMapper());
        }
    }
}