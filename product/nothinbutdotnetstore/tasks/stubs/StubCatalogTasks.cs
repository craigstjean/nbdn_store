using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogTasks : CatalogTasks
    {
        public IEnumerable<Department> get_all_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_all_sub_departments_in_department(Department department)
        {
            return Enumerable.Range(100, 10).Select(x => new Department {name = x.ToString(department + ", SubDepartment 0 ")});
        }

        public IEnumerable<Product> get_all_products_in(Department department)
        {
            return Enumerable.Range(1, 10).Select(x => new Product());
        }

        public void add_item_to_shopping_cart(Product product)
        {
            // Do nothing
        }
    }
}