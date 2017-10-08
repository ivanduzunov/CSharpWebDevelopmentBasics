using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Enums;

namespace WebServer.Server.Routing.Contacts
{
    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestMethod,
            IDictionary<string, IRoutingContext>> Routes { get; }
    }
}
