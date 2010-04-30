 
using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.custom;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class LogSpecs
    {
        public abstract class concern : observations_for_a_static_sut
        {

        }

        [Concern(typeof (Log))]
        public class when_accessing_the_logging_infrastructure : concern
        {
            context c = () =>
            {
                logging_framework = an<LoggingFramework>();
                logging_framework_factory = an<LoggingFrameworkFactory>();
                container_framework = an<ContainerFramework>();
                resolver = () => container_framework;
                container_framework.Stub(x => x.a<LoggingFrameworkFactory>()).Return(logging_framework_factory);

                change(() => Container.container_resolver).to(resolver);

                logging_framework_factory.Stub(x => x.create_logger_bound_to(typeof (when_accessing_the_logging_infrastructure)))
                    .Return(logging_framework);
            };

            because b = () =>
            {
                result = Log.an;
            };


            it should_return_the_logging_framework_registered_in_the_container_bound_to_the_calling_type = () =>
            {
               result .should_be_equal_to(logging_framework);
            };

            static LoggingFramework result;
            static LoggingFramework logging_framework;
            static ContainerFramework container_framework;
            static Func<ContainerFramework> resolver;
            static LoggingFrameworkFactory logging_framework_factory;
        }

        [Concern(typeof (Log))]
        public class when_logging_with_the_running_application : concern
        {
            context c = () =>
            {
                logging_framework = new TextWriterLoggingFramework(Console.Out);
                container_framework = an<ContainerFramework>();
                resolver = () => container_framework;
                container_framework.Stub(x => x.a<LoggingFramework>()).Return(logging_framework);

                change(() => Container.container_resolver).to(resolver);
            };

            because b = () =>
            {
                new SomeClassThatWantsToUseLogging().run_a_method();
            };


            it should_output_to_the_console = () =>
            {

            };

            static LoggingFramework logging_framework;
            static ContainerFramework container_framework;
            static Func<ContainerFramework> resolver;
        }
    }

    public class SomeClassThatWantsToUseLogging
    {
        public void run_a_method()
        {
            Log.an.informational("I am about to do something really complicated");
        }
    }
}
