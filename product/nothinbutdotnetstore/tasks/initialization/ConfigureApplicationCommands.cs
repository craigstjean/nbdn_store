using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks.initialization
{
    public class ConfigureApplicationCommands :StartupCommand
    {
        IDictionary<Type, ContainerResolver> resolvers;

        public ConfigureApplicationCommands(IDictionary<Type, ContainerResolver> resolvers)
        {
            this.resolvers = resolvers;
        }

        public void run()
        {
            new List<RequestCommand>
            {
//                new DefaultRequestCommand(x => x.command_name == typeof (ViewMainDepartments).Name,
//                                          new ViewMainDepartments(catalog_tasks, response_engine)),
//                new DefaultRequestCommand(x => x.command_name == typeof (ViewSubDepartments).Name,
//                                          new ViewSubDepartments(catalog_tasks, response_engine)),
//                new DefaultRequestCommand(x => x.command_name == typeof (ViewProductsInDepartment).Name,
//                                          new ViewProductsInDepartment(catalog_tasks, response_engine)),
//                new DefaultRequestCommand(x => x.command_name == typeof (AddProductToCart).Name,
//                                          new AddProductToCart(cart_tasks))
            };
        }
    }
}