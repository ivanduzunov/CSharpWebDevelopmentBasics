using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Handlers;

namespace WebServer.Server.Routing.Contacts
{
    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler Handler { get; }
    }
}
