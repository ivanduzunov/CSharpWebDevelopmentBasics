using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServer.Server.Enums;
using WebServer.Server.Routing.Contacts;

namespace WebServer.Server.Routing
{
    public class ServerRouteConfig : IServerRouteConfig
    {
        private readonly IDictionary<HttpRequestMethod,
            IDictionary<string, IRoutingContext>> routes;

        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.routes = new Dictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>>();

            var availableMethods = Enum.GetValues(typeof(HttpRequestMethod)).Cast<HttpRequestMethod>();

            foreach (var method in availableMethods)
            {
                routes[method] = new Dictionary<string, IRoutingContext>();
            }

            this.InitializeRouteConfig(appRouteConfig);
        }


        public IDictionary<HttpRequestMethod,
            IDictionary<string, IRoutingContext>> Routes
        { get; }

        private void InitializeRouteConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (var registeredRoute in appRouteConfig.Routes)
            {
                foreach (var requestHandler in registeredRoute.Value)
                {
                    var route = requestHandler.Key;

                    var handler = requestHandler.Value;

                    var parameters = new List<string>();

                    var parsedRouteRegex = this.ParseRoute(route, parameters);

                    var routingContext = new RoutingContext(handler, parameters);

                    this.routes[registeredRoute.Key].Add(parsedRouteRegex, routingContext);
                }
            }
        }

        //private object ParseRoute(string route, List<string> parameters)
        //{
        //    // todo: (1:40:50)
        //}
    }
}
