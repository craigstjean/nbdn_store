 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class DefaultMapperRegistrySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<MapperRegistry,
                                             DefaultMapperRegistry>
         {
        
         }

         [Concern(typeof(DefaultMapperRegistry))]
         public class when_getting_existing_mapper_from_input_output : concern
         {
             context c = () =>
             {
                 IDictionary<Type, object> mappers = new Dictionary<Type, object>();
                 mappers.Add(typeof(Mapper<string,DateTime>), an<Mapper<string, DateTime>>());

                 provide_a_basic_sut_constructor_argument(mappers);
             };

             because b = () =>
             {
                 result = sut.get_mapper_for<string, DateTime>();
             };

        
             it should_return_the_mapper = () =>
             {
                 result.should_be_an_instance_of<Mapper<string, DateTime>>();
             };

             static Mapper<string, DateTime> result;
         }

         [Concern(typeof(DefaultMapperRegistrySpecs))]
         public class when_getting_no_mapper_from_input_output : concern
         {
             context c = () =>
             {
                 IDictionary<MapperType, object> mappers = new Dictionary<MapperType, object>();
                 provide_a_basic_sut_constructor_argument(mappers);
             };

             because b = () =>
             {
                 result = sut.get_mapper_for<string, DateTime>();
             };

             it should_ = () =>
             {
                 result.should_be_an_instance_of<MissingMapper<string, DateTime>>();
             };

             static Mapper<string, DateTime> result;
         }
     }
 }
