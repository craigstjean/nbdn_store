using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
	public class StubResponseEngine : ResponseEngine
	{
		public void display<ViewModel>(ViewModel view_model)
		{
			HttpContext.Current.Items.Add("view_model",view_model);
			HttpContext.Current.Server.Transfer("DepartmentBrowser.aspx", true);
		}
	}
}