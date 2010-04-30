 using System.Data.SqlClient;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
 	public class ContainerResolverSpecs
 	{
 		public abstract class concern : observations_for_a_sut_with_a_contract<ContainerResolver,
 		                                	SqlConnectionContainerResolver>
 		{
        
 		}

 		[Concern(typeof(SqlConnectionContainerResolver))]
 		public class when_asking_container_resolver_to_resolve_a_sql_connection : concern
 		{
 			context c = () =>
 			{
 				provide_a_basic_sut_constructor_argument("Data Source=MSSQL1;Database=AdventureWorks;Integrated Security=true;");
 			};

 			because b = () =>
 			{
 				result = sut.resolve();
 			};

        
 			it should_return_a_new_sql_connection = () =>
 			{
 				result.should_be_an_instance_of<SqlConnection>();
 			};

 			static object result;
 		}
 	}
 }
