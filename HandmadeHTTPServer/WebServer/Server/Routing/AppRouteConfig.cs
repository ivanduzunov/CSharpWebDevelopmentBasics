using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WebServer.Server.Enums;
using WebServer.Server.Handlers;
using WebServer.Server.Routing.Contacts;

namespace WebServer.Server.Routing
{
    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpRequestMethod,
            IDictionary<string, RequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod,
                IDictionary<string, RequestHandler>>();

            var availableMethods = Enum.GetValues
                (typeof(HttpRequestMethod)).Cast<HttpRequestMethod>();

            foreach (var method in availableMethods)
            {
                this.routes[method] = new Dictionary<string, RequestHandler>();
            }
        }

        public IReadOnlyDictionary<HttpRequestMethod,
            IDictionary<string, RequestHandler>> Routes => this.routes;

        public void AddRoute(string route, RequestHandler handler)
        {
            var handlerName = handler.GetType().Name.ToLower();

            if (handlerName.Contains("get"))
            {
                routes[HttpRequestMethod.Get].Add(route, handler);
            }
            else
            {
                throw new InvalidOperationException("Invalid Handler!");
            }
        }
    }
}
