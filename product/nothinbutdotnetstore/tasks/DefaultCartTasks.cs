﻿using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tasks
{
    public class DefaultCartTasks : CartTasks
    {
        Request request;

        public DefaultCartTasks(Request request, CartTasks cart_tasks)
        {
            this.request = request;
        }

        public List<CartItem> get_items()
        {
            throw new NotImplementedException();
        }

        public void add_item(CartItem cart_item)
        {
            throw new NotImplementedException();
        }
    }
}