using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.custom;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class CustomDependencyFrameworkSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ContainerFramework,
                                            CustomContainerFramework>
        {
        }

        [Concern(typeof (CustomContainerFramework))]
        public class when_getting_a_dependency_and_it_has_the_resolver_for_that_dependency : concern
        {
            context c = () =>
            {
                connection = new SqlConnection();
                connection_resolver = an<ContainerResolver>();
                connection_resolver.Stub(x => x.resolve()).Return(connection);

                resolvers = new Dictionary<Type, ContainerResolver>();
                resolvers.Add(typeof (IDbConnection), connection_resolver);

                provide_a_basic_sut_constructor_argument(resolvers);
            };

            because b = () =>
            {
                result = sut.an<IDbConnection>();
            };


            it should_return_the_dependency_created_by_the_resolver_for_that_item = () =>
            {
                result.should_be_equal_to(connection);
            };

            static IDbConnection result;
            static SqlConnection connection;
            static IDictionary<Type, ContainerResolver> resolvers;
            static ContainerResolver connection_resolver;
        }

        [Concern(typeof (CustomContainerFramework))]
        public class when_attempting_to_get_a_dependency_and_it_does_not_have_the_resolver_for_that_dependency : concern
        {
            context c = () =>
            {
                resolvers = new Dictionary<Type, ContainerResolver>();
                provide_a_basic_sut_constructor_argument(resolvers);
            };

            because b = () =>
            {
                doing(() => sut.an<IDbConnection>());
            };


            it should_throw_a_resolver_not_registered_exception = () =>
            {
                exception_thrown_by_the_sut.should_be_an_instance_of<ResolverNotRegisteredException>()
                    .type_that_has_no_resolver.should_be_equal_to(typeof(IDbConnection));
            };

            static IDictionary<Type, ContainerResolver> resolvers;
        }
    }
}