using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface CartTasks
    {
        List<CartItem> get_items();
        void add_item(CartItem cart_item);
    }
}