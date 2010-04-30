using System.Web;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestFactory : RequestFactory
    {
        readonly MapperRegistry mapper_registry;

        public DefaultRequestFactory(MapperRegistry mapper_registry)
        {
            this.mapper_registry = mapper_registry;
        }

        public Request create_a_request_from(HttpContext http_context)
        {
            return new DefaultRequest(mapper_registry, http_context.Request.Params, http_context.Request.Url.AbsolutePath);
        }
    }
}