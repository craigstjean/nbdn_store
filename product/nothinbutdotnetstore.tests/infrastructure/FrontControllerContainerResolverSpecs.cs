 using System.Data.SqlClient;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
 	public class FrontControllerContainerResolverSpecs
 	{
 		public abstract class concern : observations_for_a_sut_with_a_contract<ContainerResolver,
 		                                	FrontControllerContainerResolver>
 		{
        
 		}

 		[Concern(typeof(FrontControllerContainerResolver))]
 		public class when_asking_container_resolver_to_resolve_a_front_controller : concern
 		{
 			context c = () =>
 			{
 				the_dependency<CommandRegistry>();
 			};

 			because b = () =>
 			{
 				result = sut.resolve();
 			};

        
 			it should_return_a_front_controller = () =>
 			{
 				result.should_be_an_instance_of<FrontController>();
 			};

 			static object result;
 		}
 	}
 }
