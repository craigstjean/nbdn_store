using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.initialization;

namespace nothinbutdotnetstore.tasks
{
	public class Start
	{
		IList<Type> startup_commands = new List<Type>();

		public Start(Type first_startup_command_type)
		{
			startup_commands.Add(first_startup_command_type);
		}

		public static Start by<StartupCommandType>() where StartupCommandType : StartupCommand
		{
			 return new Start(typeof(StartupCommandType));
		}

		public Start followed_by<StartupCommandType>() where StartupCommandType : StartupCommand
		{
			startup_commands.Add(typeof(StartupCommandType));
			return this;
		}

		public void finish_by<StartupCommandType>() where StartupCommandType : StartupCommand
		{
			startup_commands.Add(typeof(StartupCommandType));

			var invalid_command = startup_commands.FirstOrDefault(x => x.GetConstructor(new[] {typeof (IDictionary<Type, ContainerResolver>)}) == null);
			if (invalid_command != null)
			{
				throw new StartupCommandMissingResolversConstructorException(invalid_command.Name + " is missing ctor of IDictionary<Type, ContainerResolver>");
			}

			var resolvers = new Dictionary<Type, ContainerResolver>();
			foreach (var startup_command_type in startup_commands)
			{
				var startup_command = (StartupCommand)Activator.CreateInstance(startup_command_type, new object[] {resolvers});
				startup_command.run();
			}
		}
	}
}