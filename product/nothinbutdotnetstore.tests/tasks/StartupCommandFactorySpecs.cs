 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.tasks.initialization;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class StartupCommandFactorySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<StartupCommandFactory,
                                             DefaultStartupCommandFactory>
         {
        
         }

         [Concern(typeof(DefaultStartupCommandFactory))]
         public class when_creating_a_startup_command_from_a_type : concern
         {
             context c = () =>
             {
                all_resolvers = new Dictionary<Type, ContainerResolver>(); 
                 provide_a_basic_sut_constructor_argument(all_resolvers);
             };

             because b = () =>
             {
                 result = sut.create_command_for(typeof (OurCommand)); 
             };

        
             it should_return_an_instance_of_the_startup_command_with_its_necessary_dependencies_provided = () =>
             {
                result.should_be_an_instance_of<OurCommand>()
                    .resolvers.should_be_equal_to(all_resolvers);
             };

             static Command result;
             static IDictionary<Type, ContainerResolver> all_resolvers;
         }
     }

     class OurCommand : StartupCommand
     {
         public IDictionary<Type,ContainerResolver> resolvers;

         public OurCommand(IDictionary<Type, ContainerResolver> resolvers)
         {
             this.resolvers = resolvers;
         }

         public void run()
         {
             throw new NotImplementedException();
         }
     }
 }
