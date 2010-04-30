using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.infrastructure.containers
{
	public class FrontControllerContainerResolver : ContainerResolver
	{
		CommandRegistry command_registry;

		public FrontControllerContainerResolver(CommandRegistry command_registry)
		{
			this.command_registry = command_registry;
		}

		public object resolve()
		{
			return new DefaultFrontController(command_registry);
		}
	}
}