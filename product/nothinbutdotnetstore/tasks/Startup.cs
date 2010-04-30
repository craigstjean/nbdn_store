using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.custom;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.custom;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks.initialization;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.mappers;
using nothinbutdotnetstore.web.core;

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

            Start.by_running_pipeline_in(pipeline.txt);
        }


    }
}