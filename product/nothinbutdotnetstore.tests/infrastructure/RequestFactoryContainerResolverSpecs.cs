 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
 	public class RequestFactoryContainerResolverSpecs
 	{
 		public abstract class concern : observations_for_a_sut_with_a_contract<ContainerResolver,
 		                                	RequestFactoryContainerResolver>
 		{
        
 		}

 		[Concern(typeof(RequestFactoryContainerResolver))]
 		public class when_resolving_a_request_factory : concern
 		{
 			context c = () =>
 			{
 				the_dependency<MapperRegistry>();
 			};

 			because b = () =>
 			{
 				result = (RequestFactory)sut.resolve();
 			};

 			it should_return_a_default_request_factory = () =>
 			{
 				result.should_be_an_instance_of<DefaultRequestFactory>();
 			};

 			static RequestFactory result;
 		}
 	}
 }
