 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tasks;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.model;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class AddItemToShoppingCartSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             AddItemToShoppingCart>
         {
        
         }

         [Concern(typeof(AddItemToShoppingCart))]
         public class when_adding_an_item_to_the_cart : concern
         {
             context c = () =>
             {
                 request = an<Request>();
                 product = new Product();
                 catalog_tasks = the_dependency<CatalogTasks>();


                 request.Stub(x => x.map<Product>()).Return(product);
             };

             because b = () =>
             {
                sut.process(request);
             };

        
             it should_add_item_to_shopping_cart = () =>
             {
                 catalog_tasks.received(x => x.add_item_to_shopping_cart(product));
             };

             static Request request;
             static Product product;
             static CatalogTasks catalog_tasks;
         }
     }
 }
