using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.initialization;
using Rhino.Mocks;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdd.core.extensions;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartupBuilderSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<StartupBuilder>
        {
            context c = () =>
            {
                all_commands = new List<Command>();
                startup_command_factory = the_dependency<StartupCommandFactory>();


                provide_a_basic_sut_constructor_argument(all_commands);
                provide_a_basic_sut_constructor_argument(typeof (FirstCommand));

                first_command = an<Command>();

                startup_command_factory.Stub(factory => factory.create_command_for(typeof (FirstCommand)))
                    .Return(first_command);
            };

            protected static IList<Command> all_commands;
            protected static StartupCommandFactory startup_command_factory;
            protected static Command first_command;
        }

        [Concern(typeof (StartupBuilder))]
        public class when_constructed_with_its_initial_command_to_run : concern
        {
            it should_store_the_command_on_the_list_of_all_commands_to_run = () =>
            {
                all_commands.should_contain(first_command);
            };
        }

        [Concern(typeof (StartupBuilder))]
        public class when_following_with_another_command : concern
        {
            context c = () =>
            {
                second_command = an<Command>();

                startup_command_factory.Stub(factory => factory.create_command_for(typeof (SecondCommand)))
                    .Return(second_command);
            };

            because b = () =>
            {
                result = sut.followed_by<SecondCommand>();
            };


            it should_return_a_reference_to_itself_to_continue_building_the_chain = () =>
            {
                result.should_be_equal_to(sut);
            };

            it should_store_the_second_command_in_the_list_of_all_commands = () =>
            {
                all_commands.should_only_contain(first_command, second_command);
            };

            static Command second_command;
            static StartupBuilder result;
        }

        [Concern(typeof (StartupBuilder))]
        public class when_told_to_finish : concern
        {
            context c = () =>
            {
                second_command = an<Command>();
                last_command = an<Command>();

                startup_command_factory.Stub(factory => factory.create_command_for(typeof (ThirdCommand)))
                    .Return(last_command);

                all_commands.Add(second_command);
            };

            because b = () =>
            {
                sut.finish_by<ThirdCommand>();
            };


            it should_run_all_of_its_commands = () =>
            {
                all_commands.Count.should_be_equal_to(3);
                all_commands.each(x => x.received(y => y.run()));
            };


            static Command second_command;
            static StartupBuilder result;
            static Command last_command;
        }
    }

    class ThirdCommand : StartupCommand
    {
        public void run()
        {
            throw new NotImplementedException();
        }
    }

    class SecondCommand : StartupCommand
    {
        public void run()
        {
            throw new NotImplementedException();
        }
    }

    class FirstCommand : StartupCommand
    {
        public void run()
        {
            throw new NotImplementedException();
        }
    }
}