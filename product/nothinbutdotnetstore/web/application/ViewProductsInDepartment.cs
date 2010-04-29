<<<<<<< HEAD
﻿using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
=======
﻿using System;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
>>>>>>> pass2
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
<<<<<<< HEAD
    public class ViewProductsInDepartment : ApplicationCommand
    {
        readonly CatalogTasks catalog_tasks;
        readonly ResponseEngine response_engine;

        public ViewProductsInDepartment()
            : this(new StubCatalogTasks(), new DefaultResponseEngine())
        {
        }

        public ViewProductsInDepartment(CatalogTasks catalog_tasks, ResponseEngine response_engine)
        {
            this.catalog_tasks = catalog_tasks;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(catalog_tasks.get_all_products_in(
                (request.map<Department>())));
        }
    }
}
=======
	public class ViewProductsInDepartment : ApplicationCommand
	{
		public CatalogTasks catalog_tasks { get; set; }
		public ResponseEngine response_engine { get; set; }

		public ViewProductsInDepartment(CatalogTasks catalog_tasks, ResponseEngine response_engine)
		{
			this.catalog_tasks = catalog_tasks;
			this.response_engine = response_engine;
		}

		public void process(Request request)
		{
			response_engine.display(catalog_tasks.get_all_products_in_department(request.map<Department>()));
		}
	}
}
>>>>>>> pass2
