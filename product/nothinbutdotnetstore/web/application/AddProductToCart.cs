using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class AddProductToCart : ApplicationCommand
    {
        public AddProductToCart(CartTasks cart_tasks)
        {
            this.cart_tasks = cart_tasks;
        }

        CartTasks cart_tasks;

        public void process(Request request)
        {
            cart_tasks.add_item(request.map<CartItem>());
        }
    }
}