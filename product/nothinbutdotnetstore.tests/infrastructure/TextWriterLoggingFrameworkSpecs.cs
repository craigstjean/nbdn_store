 using System.IO;
 using System.Text;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.logging;
 using nothinbutdotnetstore.infrastructure.logging.custom;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class TextWriterLoggingFrameworkSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<LoggingFramework,
                                             TextWriterLoggingFramework>
         {
        
         }

         [Concern(typeof(TextWriterLoggingFramework))]
         public class when_logging_an_informational_message : concern
         {
             context c = () =>
             {
                 builder = new StringBuilder();
                provide_a_basic_sut_constructor_argument<TextWriter>(new StringWriter(builder)); 
             };

             because b = () =>
             {
                sut.informational("hello world"); 
             };

        
             it should_output_the_message_to_the_text_writer_it_is_wrapping = () =>
             {
                 builder.ToString().should_be_equal_ignoring_case("hello world\r\n");
             };

             static StringBuilder builder;
         }
     }
 }
