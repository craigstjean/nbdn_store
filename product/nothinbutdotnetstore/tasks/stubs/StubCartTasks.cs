using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
	public class StubCartTasks : CartTasks
	{
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