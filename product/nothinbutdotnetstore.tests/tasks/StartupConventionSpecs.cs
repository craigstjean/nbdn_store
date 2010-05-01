 
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks.initialization;
using System.Linq;
using nothinbutdotnetstore.tests.utility;
using developwithpassion.bdd.core.extensions;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartupConventionSpecs
    {
        public abstract class concern : observations_for_a_static_sut
        {

        }

        [Concern(typeof (StartupCommand))]
        public class all_startup_commands_in_the_application : concern
        {

            it should_have_the_required_constructor_for_the_pipeline_process = () =>
            {
            	var startup_commands = typeof (StartupCommand).Assembly
            		.GetTypes()
            		.Where(is_a_startup_command);

            	var exceptions = startup_commands.exceptions_for(startup_convention);
				if (exceptions.Count() == 0)
				{
					return;
				}

				var exception_messages = new StringBuilder();
				foreach (var exception in exceptions)
				{
					exception_messages.AppendLine(exception.Message);
				}
				throw new ConventionNotFollowedException(exception_messages.ToString());
            };

            static void startup_convention(Type obj)
            {
            	var argument = obj.GetConstructors()[0].GetParameters().FirstOrDefault();
                if (argument == null || argument.ParameterType != typeof(IDictionary<Type,ContainerResolver>)) throw  new ConventionNotFollowedException(
                    "The type {0} does not follow the startup convention".format_using(obj.Name));
            }

            static bool is_a_startup_command(Type command_type)
            {
                return typeof (StartupCommand).IsAssignableFrom(command_type)
                       && ! command_type.IsAbstract
                       && command_type.IsClass;
            }
        }
    }
}
