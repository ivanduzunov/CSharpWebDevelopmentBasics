using System;
using System.Collections.Generic;
using System.Text;
using WebServer.Server.HTTP;

namespace WebServer.Server.HTTP.Contracts
{
    public interface IHttpHeaderCollection
    {
        void Add(HttpHeader header);

        bool ContainsKey(string key);

        HttpHeader GetHeader(string key);
    }
}
