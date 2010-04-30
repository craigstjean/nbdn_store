using System;
using System.Data;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class ContainerSpecs
    {
        public abstract class Concern : observations_for_a_static_sut
        {
        }

        [Concern(typeof (Container))]
        public class when_asked_to_resolve : Concern
        {
            context c = () =>
            {
                container_framework = an<ContainerFramework>();
                resolver = () => container_framework;
                change(() => Container.container_resolver).to(resolver);
            };

            because b = () =>
            {
                result = Container.resolve;
            };

            it should_provide_access_to_the_underlying_container_framework = () =>
            {
                result.should_be_equal_to(container_framework);
            };

            static ContainerFramework result;
            static ContainerFramework container_framework;
            static Func<ContainerFramework> resolver;
        }
    }
}