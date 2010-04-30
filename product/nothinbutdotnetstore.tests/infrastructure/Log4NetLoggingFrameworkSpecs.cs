using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using log4net;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.log4net;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class Log4NetLoggingFrameworkSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<LoggingFramework,
                                            Log4NetLoggingFramework>
        {
        }

        [Concern(typeof (Log4NetLoggingFramework))]
        public class when_logging_an_informational_message : concern
        {
            context c = () =>
            {
                message = "blah";
                log_4_net_log = the_dependency<ILog>();
            };

            because b = () =>
            {
                sut.informational(message);
            };


            it should_marshal_the_call_to_the_correct_log_4_net_method = () =>
            {
                log_4_net_log.received(x => x.Info(message));
            };

            static ILog log_4_net_log;
            static string message;
        }
    }
}