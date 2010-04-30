using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure.containers
{
	public class FrontControllerContainerResolver : ContainerResolver
	{
		CommandRegistry command_registry;
		FrontController front_controller;

		public FrontControllerContainerResolver(CommandRegistry command_registry)
		{
			this.command_registry = command_registry;
			front_controller = new DefaultFrontController(command_registry);
		}

		public object resolve()
		{
			return front_controller;
		}
	}
}