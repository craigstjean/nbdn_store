using System;
using System.Web;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core
{
    public class RawRequestHandler : IHttpHandler
    {
        readonly FrontController front_controller;
        readonly RequestFactory request_factory;

        [Obsolete]
        public RawRequestHandler() : this(new DefaultFrontController(),
                                          new DefaultRequestFactory(new DefaultMapperRegistry(null)))
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