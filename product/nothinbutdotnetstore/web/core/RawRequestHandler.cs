using System.Web;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.web.core
{
    public class RawRequestHandler : IHttpHandler
    {
        readonly FrontController front_controller;
        readonly RequestFactory request_factory;

        public RawRequestHandler() : this(Container.resolve.a<FrontController>(),
                                          Container.resolve.a<RequestFactory>())
        {
        }

        public RawRequestHandler(FrontController front_controller, RequestFactory request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_a_request_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}