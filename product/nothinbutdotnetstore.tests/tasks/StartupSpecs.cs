using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartupSpecs
    {
        public abstract class concern : observations_for_a_static_sut
        {

        }

        [Concern(typeof (Startup))]
        public class when_the_application_has_completed_its_startup : concern
        {

            because b = () =>
            {
                Startup.run();
            };


            it should_be_able_to_access_key_application_services = () =>
            {
                Container.resolve.an<FrontController>().should_be_an_instance_of<DefaultFrontController>();
            };
        }
    }
}
