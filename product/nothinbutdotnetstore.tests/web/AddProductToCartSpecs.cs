using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class AddProductToCartSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                            AddProductToCart>
        {
        }

        [Concern(typeof (AddProductToCart))]
        public class when_adding_product_to_cart : concern
        {
            context c = () =>
            {
                request = the_dependency<Request>();
                responseEngine = the_dependency<ResponseEngine>();
                cart_tasks = the_dependency<CartTasks>();

                cart_item = new CartItem(new Product(), 5);

                request.Stub(x => x.map<CartItem>()).Return(cart_item);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_ask_cartTask_to_add_item = () =>
            {
                cart_tasks.received(x => x.add_item(cart_item));
            };

            static IEnumerable<CartItem> results;
            static Request request;
            static ResponseEngine responseEngine;
            static CartTasks cart_tasks;
            static CartItem cart_item;
        }
    }
}