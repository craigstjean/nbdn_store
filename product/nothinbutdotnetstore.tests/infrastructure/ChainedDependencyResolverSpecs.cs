using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.custom;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class ChainedDependencyResolverSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ContainerResolver,
                                            ChainedDependencyResolver>
        {
        }

        [Concern(typeof (ChainedDependencyResolver))]
        public class when_resolving_an_object_with_multiple_dependencies : concern
        {
            context c = () =>
            {
                sql_connection = new SqlConnection();
                sql_command = new SqlCommand();
                connection_settings = new ConnectionStringSettings();
                container_framework = the_dependency<ContainerFramework>();
                constructor_selector = the_dependency<ConstructorSelector>();

                constructor_selector.Stub(x => x.get_applicable_constructor_on(typeof (SomeItemWithDependencies))).Return(
                    SomeItemWithDependencies.applicable_constructor());
                container_framework.Stub(x => x.a(typeof(IDbConnection))).Return(sql_connection);
                container_framework.Stub(x => x.a(typeof(IDbCommand))).Return(sql_command);
                container_framework.Stub(x => x.a(typeof(ConnectionStringSettings))).Return(connection_settings);

                provide_a_basic_sut_constructor_argument(typeof (SomeItemWithDependencies));
            };

            because b = () =>
            {
                result = sut.resolve();
            };


            it should_return_the_instance_with_all_of_its_dependencies_satisfied = () =>
            {
                var actual_dependency = (SomeItemWithDependencies) result;
                actual_dependency.connection.should_be_equal_to(sql_connection);
                actual_dependency.command.should_be_equal_to(sql_command);
                actual_dependency.connection_settings.should_be_equal_to(connection_settings);
            };

            static object result;
            static SqlConnection sql_connection;
            static SqlCommand sql_command;
            static ConnectionStringSettings connection_settings;
            static ContainerFramework container_framework;
            static ConstructorSelector constructor_selector;
        }
    }

    public class SomeItemWithDependencies
    {
        public IDbConnection connection;
        public IDbCommand command;
        public ConnectionStringSettings connection_settings;

        public SomeItemWithDependencies(IDbConnection connection, IDbCommand command, ConnectionStringSettings connection_settings)
        {
            this.connection = connection;
            this.command = command;
            this.connection_settings = connection_settings;
        }

        public SomeItemWithDependencies(IDbConnection connection, IDbCommand command)
        {
        }

        public static ConstructorInfo applicable_constructor()
        {
            return typeof (SomeItemWithDependencies)
                .GetConstructors()
                .OrderByDescending(x => x.GetParameters().Count()).First();
        }
    }
}