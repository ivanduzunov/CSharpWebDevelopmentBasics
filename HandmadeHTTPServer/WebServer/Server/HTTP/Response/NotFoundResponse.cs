using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Enums;

namespace WebServer.Server.HTTP.Response
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}
