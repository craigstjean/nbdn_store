using nothinbutdotnetstore.tasks.initialization;

namespace nothinbutdotnetstore.tasks
{
    public class Startup
    {
        public static void run()
        {
            Start.by<ConfigureCoreServices>()
                .followed_by<ConfigureServiceLayer>()
                .followed_by<ConfigureMappers>()
                .finish_by<ConfigureApplicationCommands>();
        }
    }
}