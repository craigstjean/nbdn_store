 using System.IO;
 using System.Web;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class RequestFactorySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<RequestFactory,
                                             DefaultRequestFactory>
         {
        
         }

         [Concern(typeof(DefaultRequestFactory))]
         public class when_creating_a_request_from_http_context : concern
         {
             context c = () =>
             {
                 var http_request = new HttpRequest("index.html", "http://thefactthaticannotmockhttpcontextsucks.com", "/");
                 var http_response = new HttpResponse(new StringWriter());
                 http_context = new HttpContext(http_request, http_response);
                 mapper_registry = the_dependency<MapperRegistry>();
             };

             because b = () =>
             {
                 result = sut.create_a_request_from(http_context);
             };

        
             it should_return_valid_request = () =>
             {
                 result.should_be_an_instance_of<DefaultRequest>();
             };

             static Request result;
             static HttpContext http_context;
             static MapperRegistry mapper_registry;
         }
     }
 }
