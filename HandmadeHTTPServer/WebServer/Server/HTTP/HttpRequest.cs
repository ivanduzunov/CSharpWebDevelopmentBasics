using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using WebServer.Server.Common;
using WebServer.Server.Enums;
using WebServer.Server.Exceptions;
using WebServer.Server.HTTP.Contracts;

namespace WebServer.Server.HTTP
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public IDictionary<string, string> FormData { get; private set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public string Path { get; private set; }

        public IDictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public IDictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameter(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            var requestLines = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (!requestLines.Any())
            {
                throw new BadRequestException("Request Empty.");
            }

            var firstLine = requestLines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (firstLine.Length != 3 || firstLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException("Invalid first line of the request.");
            }

            this.Method = this.ParseMethod(firstLine[0]);
            this.Url = firstLine[1];
            this.Path = this.ParsePath(this.Url);
            this.ParseHeaders(requestLines);
            this.ParseParameters();
            this.ParseFormData(requestLines.Last());

        }



        private HttpRequestMethod ParseMethod(string method)
        {
            try
            {
                return Enum.Parse<HttpRequestMethod>(method, true);
            }
            catch (Exception)
            {
                throw new BadRequestException("Invalid request method.");
            }

        }

        private string ParsePath(string url)
        {
            return url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private void ParseHeaders(string[] requestLines)
        {
            var emptyLineAfterHeadersIndex = Array.IndexOf(requestLines, string.Empty);

            for (int i = 1; i < emptyLineAfterHeadersIndex; i++)
            {
                var currentLine = requestLines[i];
                var headerParts = currentLine.Split(new[] { ':', }, StringSplitOptions.RemoveEmptyEntries);

                if (headerParts.Length != 2)
                {
                    throw new BadRequestException("Invalid headers.");
                }

                var headerKey = headerParts[0];
                var headerValue = headerParts[1].Trim();

                var header = new HttpHeader(headerKey, headerValue);

                this.Headers.Add(header);
            }

            if (!this.Headers.ContainsKey("Host"))
            {
                throw new BadRequestException("Missing Host header in the request.");
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }

            this.ParseQuery(this.Url, this.UrlParameters);
        }

        private void ParseQuery(string queryString, IDictionary<string, string> dict)
        {
            var query = queryString.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries).Last();

            if (!query.Contains('='))
            {
                return;
            }

            var queryPairs = query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var queryPair in queryPairs)
            {
                var queryKvp = queryPair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                if (queryKvp.Length != 2)
                {
                    return;
                }

                var queryKey = WebUtility.UrlDecode(queryKvp[0]);
                var queryValue = WebUtility.UrlDecode(queryKvp[1]);

                dict.Add(queryKey, queryValue);
            }
        }

        private void ParseFormData(string formDataLine)
        {
            if (this.Method == HttpRequestMethod.Get)
            {
                return; 
            }

            this.ParseQuery(formDataLine, this.QueryParameters);
        }
    }
}
