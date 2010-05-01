using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.initialization;

namespace nothinbutdotnetstore.tests.tasks
{
	public class StartSpecs
	{
		public abstract class concern : observations_for_a_static_sut
		{

		}

		[Concern(typeof (Start))]
		public class when_starting_by_first_command : concern
		{
			context c = () =>
			{
				SimpleStartupCommand1.executed = false;
			};

			because b = () =>
			{
				result = Start.by<SimpleStartupCommand1>();
			};

			it should_not_execute_command = () =>
			{
				result.should_be_an_instance_of<Start>();
				SimpleStartupCommand1.executed.should_be_false();
			};

			static Start result;
		}

		[Concern(typeof(Start))]
		public class when_starting_by_following_command : concern
		{
			context c = () =>
			{
				SimpleStartupCommand1.executed = false;
				SimpleStartupCommand2.executed = false;
			};

			because b = () =>
			{
				result = Start.by<SimpleStartupCommand1>().followed_by<SimpleStartupCommand2>();
			};

			it should_not_execute_command = () =>
			{
				result.should_be_an_instance_of<Start>();
				SimpleStartupCommand1.executed.should_be_false();
				SimpleStartupCommand2.executed.should_be_false();
			};

			static Start result;
		}

		[Concern(typeof(Start))]
		public class when_starting_by_finishing_command : concern
		{
			context c = () =>
			{
				SimpleStartupCommand1.executed = false;
				SimpleStartupCommand2.executed = false;
				SimpleStartupCommand3.executed = false;
			};

			because b = () =>
			{
				Start.by<SimpleStartupCommand1>().followed_by<SimpleStartupCommand2>().finish_by<SimpleStartupCommand3>();
			};

			it should_execute_first_command = () =>
			{
				SimpleStartupCommand1.executed.should_be_true();
			};

			it should_execute_second_command = () =>
			{
				SimpleStartupCommand2.executed.should_be_true();
			};

			it should_execute_final_command = () =>
			{
				SimpleStartupCommand3.executed.should_be_true();
			};
		}

		[Concern(typeof(Start))]
		public class when_passing_control_to_next_command : concern
		{
			context c = () =>
			{
				SimpleStartupCommand1.resolvers = null;
				SimpleStartupCommand2.resolvers = null;
			};

			because b = () =>
			{
				Start.by<SimpleStartupCommand1>().finish_by<SimpleStartupCommand2>();
			};

			it should_provide_resulting_resolvers_from_previous_command = () =>
			{
				ReferenceEquals(SimpleStartupCommand1.resolvers, SimpleStartupCommand2.resolvers).should_be_true();
			};
		}

		[Concern(typeof(Start))]
		public class when_attempting_to_use_a_startup_command_without_our_convention : concern
		{
			because b = () =>
			{
				doing(() => Start.by<SimpleStartupCommand1>().finish_by<MissingConventionClass>());
			};

			it should_fail_miserably_with_a_pretty_exception = () =>
			{
				exception_thrown_by_the_sut.should_be_an_instance_of<StartupCommandMissingResolversConstructorException>();
			};
		}

		public class SimpleStartupCommand1 : StartupCommand
		{
			public static bool executed { get; set; }
			public static IDictionary<Type, ContainerResolver> resolvers { get; set; }

			public SimpleStartupCommand1(IDictionary<Type, ContainerResolver> resolvers)
			{
				SimpleStartupCommand1.resolvers = resolvers;
			}

			public void run()
			{
				executed = true;
			}
		}

		public class SimpleStartupCommand2 : StartupCommand
		{
			public static bool executed { get; set; }
			public static IDictionary<Type, ContainerResolver> resolvers { get; set; }

			public SimpleStartupCommand2(IDictionary<Type, ContainerResolver> resolvers)
			{
				SimpleStartupCommand2.resolvers = resolvers;
			}

			public void run()
			{
				executed = true;
			}
		}

		public class SimpleStartupCommand3 : StartupCommand
		{
			public static bool executed { get; set; }

			public SimpleStartupCommand3(IDictionary<Type, ContainerResolver> resolvers)
			{
				
			}

			public void run()
			{
				executed = true;
			}
		}
		
		public class MissingConventionClass : StartupCommand
		{
			public void run()
			{
			}
		}
	}
}
