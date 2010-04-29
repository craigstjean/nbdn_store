using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.web.application
{
    public class AddItemToShoppingCart : ApplicationCommand
    {
        CatalogTasks catalog_tasks;

        public AddItemToShoppingCart(CatalogTasks catalog_tasks)
        {
            this.catalog_tasks = catalog_tasks;
        }

        public void process(Request request)
        {
            catalog_tasks.add_item_to_shopping_cart(request.map<Product>());
        }
    }
}