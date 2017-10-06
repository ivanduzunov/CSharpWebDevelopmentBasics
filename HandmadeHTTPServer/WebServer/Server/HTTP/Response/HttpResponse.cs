using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Common;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.HTTP.Response
{
    using Enums;

    public abstract class HttpResponse : IHttpResponse
    {
        protected HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
        }
       

        public HttpHeaderCollection Headers { get; }

        public HttpStatusCode StatusCode { get; protected set; }

        private string StatusCodeMessage => this.StatusCode.ToString();

        public override string ToString()
        {
            var response = new StringBuilder();

            int statusCodeNumber = (int)this.StatusCode;

            response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.StatusCodeMessage}");

            response.AppendLine(this.Headers.ToString());
            response.AppendLine();

            return response.ToString();
        }
    }
}
