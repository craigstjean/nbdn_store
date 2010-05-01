using nothinbutdotnetstore.tasks.initialization;

namespace nothinbutdotnetstore.tasks
{
    public class Start
    {
        public static StartupBuilder by<Command>() where Command : StartupCommand
        {
            return new StartupBuilder(typeof(Command));
        }
    }
}