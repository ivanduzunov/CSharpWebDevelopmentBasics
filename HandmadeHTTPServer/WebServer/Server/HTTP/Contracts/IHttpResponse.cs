
namespace WebServer.Server.HTTP.Contracts
{
    using System;
    using Enums;

    public interface IHttpResponse
    {
        HttpHeaderCollection Headers { get; }

        HttpStatusCode StatusCode { get; }
    }
}
