using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.tasks.initialization
{
    public class ConfigureServiceLayer : StartupCommand
    {
        public void run()
        {
            CatalogTasks catalog_tasks = new StubCatalogTasks();
            CartTasks cart_tasks = new StubCartTasks();
        }
    }
}