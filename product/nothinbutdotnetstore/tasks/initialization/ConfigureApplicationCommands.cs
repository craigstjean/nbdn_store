using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.application;
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
        	var catalog_tasks = Container.resolve.a<CatalogTasks>();
        	var cart_tasks = Container.resolve.a<CartTasks>();
        	var response_engine = Container.resolve.a<ResponseEngine>();

            var all_commands = new List<RequestCommand>
				{
					new DefaultRequestCommand(x => x.command_name == typeof (ViewMainDepartments).Name,
                                          new ViewMainDepartments(catalog_tasks, response_engine)),
					new DefaultRequestCommand(x => x.command_name == typeof (ViewSubDepartments).Name,
                                          new ViewSubDepartments(catalog_tasks, response_engine)),
					new	DefaultRequestCommand(x => x.command_name == typeof (ViewProductsInDepartment).Name,
                                          new ViewProductsInDepartment(catalog_tasks, response_engine)),
					new DefaultRequestCommand(x => x.command_name == typeof (AddProductToCart).Name,
                                          new AddProductToCart(cart_tasks))
				};

			resolvers.Add(typeof(CommandRegistry), new SimpleContainerResolver(() => new DefaultCommandRegistry(all_commands)));
			resolvers.Add(typeof(FrontController), new SimpleContainerResolver(() => new DefaultFrontController(Container.resolve.a<CommandRegistry>())));
        }
    }
}