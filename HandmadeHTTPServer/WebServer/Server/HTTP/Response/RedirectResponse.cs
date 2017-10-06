using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Common;
using WebServer.Server.Enums;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.HTTP.Response
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;
            this.Headers.Add(new HttpHeader("Location", redirectUrl));
        }
    }
}
