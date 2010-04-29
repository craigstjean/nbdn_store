using System.Collections.Generic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogTasks
    {
        IEnumerable<Department> get_all_main_departments();
        IEnumerable<Department> get_all_sub_departments_in_department(Department department_name);
        IEnumerable<Product> get_all_products_in(Department department);
        void add_item_to_shopping_cart(Product product);
    }
}