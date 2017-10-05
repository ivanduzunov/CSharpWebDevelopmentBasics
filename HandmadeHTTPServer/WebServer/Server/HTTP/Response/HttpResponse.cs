using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.HTTP.Response
{
    public abstract class HttpResponse : IHttpResponse
    {
        private readonly IView view;

        protected HttpResponse(string redirectUrl)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader("Location", redirectUrl);
        }

        protected HttpResponse(HttpStatusCode responseCode, IView view)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            //todo
            //todo
        }

        private HttpHeaderCollection HeaderCollection { get; set; }

        private HttpStatusCode StatusCode { get; set; }

        private string StatusMessage => this.StatusCode.ToString();

        private void AddHeader(string location, string redirectUrl)
        {
            //todo
        }
    }
}
