using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.HTTP
{
    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;

        public HttpContext(string requestString)
        {
            this.request = new HttpRequest(requestString);
        }

        public IHttpRequest Request => this.request;
    }
}
