using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartments : ApplicationCommand
    {
        readonly CatalogTasks catalog_tasks;
        readonly ResponseEngine response_engine;

        public ViewMainDepartments() : this(new StubCatalogTasks(), new DefaultResponseEngine())
        {
        }

        public ViewMainDepartments(CatalogTasks catalog_tasks, ResponseEngine response_engine)
        {
            this.catalog_tasks = catalog_tasks;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(catalog_tasks.get_all_main_departments());
        }
    }
}