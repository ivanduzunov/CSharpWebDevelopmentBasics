﻿using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Common;
using WebServer.Server.Handlers;
using WebServer.Server.Routing.Contacts;

namespace WebServer.Server.Routing
{
    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(RequestHandler handler, IEnumerable<string> parameters)
        {
            CoreValidator.ThrowIfNull(handler, nameof(handler));
            CoreValidator.ThrowIfNull(parameters, nameof(parameters));

            this.Handler = handler;
            this.Parameters = parameters;
        }

        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler Handler { get; private set}
    }
}
