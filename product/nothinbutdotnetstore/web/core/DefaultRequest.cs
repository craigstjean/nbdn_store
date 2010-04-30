using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        readonly MapperRegistry mapper_registry;
        readonly NameValueCollection request_data;
    	readonly string url;

        public DefaultRequest(MapperRegistry mapper_registry, NameValueCollection request_data, string url)
        {
            this.mapper_registry = mapper_registry;
            this.request_data = request_data;
        	this.url = url;
        }

        public InputModel map<InputModel>()
        {
            return mapper_registry.get_mapper_for<NameValueCollection, InputModel>().map(request_data);
        }

		public string command_name
		{
			get
			{
				int store_index = url.ToLower().IndexOf(".store");
				int command_index = url.LastIndexOf('/', store_index) + 1;

				return url.Substring(command_index, store_index - command_index);
			}
		}
    }
}