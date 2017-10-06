using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.Enums;
using WebServer.Server.Exceptions;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.HTTP.Response
{
    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        public ViewResponse(HttpStatusCode responseCode, IView view)
        {
            this.ValidateStatusCode(responseCode);

            this.view = view;
            this.StatusCode = responseCode;
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int)statusCode;

            if (statusCodeNumber > 299 && statusCodeNumber < 400)
            {
                throw new InvalidResponseException("Invalid status code for view resourses!");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.view.View()}";
        }
    }
}
