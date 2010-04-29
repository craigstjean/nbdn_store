 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ResponseEngineSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ResponseEngine,
                                             DefaultResponseEngine>
         {
        
         }

         [Concern(typeof(DefaultResponseEngine))]
         public class when_calling_display_on_response_engine : concern
         {
             context c = () =>
             {
                
             };

             because b = () =>
             {
                sut.display(view_model);
             };

             it should_setup_page_with_view_model = () =>
             {
                
             };

             it should_transfer_control_to_view_page = () =>
             {

             };

             static object view_model;
             static object result;
         }
     }
 }
