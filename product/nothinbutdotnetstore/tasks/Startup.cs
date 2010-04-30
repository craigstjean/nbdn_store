using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.custom;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.mappers;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks
{
    public class Startup
    {
    	public static void run()
    	{
    		IDictionary<Type, ContainerResolver> resolvers = new Dictionary<Type, ContainerResolver>();

    		CatalogTasks catalog_tasks = new StubCatalogTasks();
    		ResponseEngine response_engine = new StubResponseEngine();
    		CartTasks cart_tasks = new StubCartTasks();

    		IList<RequestCommand> all_commands = new List<RequestCommand>
                     {
                     	new DefaultRequestCommand(x => x.command_name == typeof (ViewMainDepartments).Name, new ViewMainDepartments(catalog_tasks, response_engine)),
                     	new DefaultRequestCommand(x => x.command_name == typeof (ViewSubDepartments).Name, new ViewSubDepartments(catalog_tasks, response_engine)),
                     	new DefaultRequestCommand(x => x.command_name == typeof (ViewProductsInDepartment).Name, new ViewProductsInDepartment(catalog_tasks, response_engine)),
                     	new DefaultRequestCommand(x => x.command_name == typeof (AddProductToCart).Name, new AddProductToCart(cart_tasks))
                     };

    		CommandRegistry command_registry = new DefaultCommandRegistry(all_commands);
			resolvers.Add(typeof(FrontController), new FrontControllerContainerResolver(command_registry));

			IDictionary<Type, object> all_mappers = new Dictionary<Type, object>();
    		all_mappers.Add(typeof (Mapper<NameValueCollection, Department>), new DepartmentMapper());
    		all_mappers.Add(typeof (Mapper<NameValueCollection, Product>), new ProductMapper());

    		MapperRegistry mapper_registry = new DefaultMapperRegistry(all_mappers);
			resolvers.Add(typeof(RequestFactory), new RequestFactoryContainerResolver(mapper_registry));

    		Container.container_resolver = () => new CustomContainerFramework(resolvers);
    	}
    }
}