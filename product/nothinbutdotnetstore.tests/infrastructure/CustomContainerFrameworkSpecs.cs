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
            context c = () =>
            {
                resolvers = new Dictionary<Type, ContainerResolver>();
                provide_a_basic_sut_constructor_argument(resolvers);
            };

            protected static IDictionary<Type, ContainerResolver> resolvers;
        }

        [Concern(typeof (CustomContainerFramework))]
        public class when_getting_a_dependency_and_it_has_the_resolver_for_that_dependency : concern
        {
            context c = () =>
            {
                connection = new SqlConnection();
                connection_resolver = an<ContainerResolver>();
                connection_resolver.Stub(x => x.resolve()).Return(connection);

                resolvers.Add(typeof (IDbConnection), connection_resolver);

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
            static ContainerResolver connection_resolver;
        }

        [Concern(typeof (CustomContainerFramework))]
        public class when_attempting_to_get_a_dependency_and_it_does_not_have_the_resolver_for_that_dependency : concern
        {
            because b = () =>
            {
                doing(() => sut.an<IDbConnection>());
            };


            it should_throw_a_resolver_not_registered_exception = () =>
            {
                exception_thrown_by_the_sut.should_be_an_instance_of<ResolverNotRegisteredException>()
                    .type_that_has_no_resolver.should_be_equal_to(typeof (IDbConnection));
            };

        }

        [Concern(typeof (CustomContainerFramework))]
        public class when_the_resolver_for_a_type_throws_an_exception_during_resolution : concern
        {
            context c = () =>
            {
                inner_exception = new Exception();
                connection_resolver = an<ContainerResolver>();
                resolvers.Add(typeof (IDbConnection), connection_resolver);

                connection_resolver.Stub(x => x.resolve()).Throw(inner_exception);
            };

            because b = () =>
            {
                doing(() => sut.an<IDbConnection>());
            };


            it should_throw_a_resolver_exception_that_provides_access_to_the_actual_exception_that_was_thrown = () =>
            {
                var exception = exception_thrown_by_the_sut.should_be_an_instance_of<ResolverException>();
                exception.type_that_could_not_be_resolved.should_be_equal_to(typeof (IDbConnection));
                exception.InnerException.should_be_equal_to(inner_exception);
            };

            static Exception inner_exception;
            static ContainerResolver connection_resolver;
        }
    }
}