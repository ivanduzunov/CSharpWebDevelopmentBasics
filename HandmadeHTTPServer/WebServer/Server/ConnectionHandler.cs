using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Server.Common;
using WebServer.Server.Handlers;
using WebServer.Server.HTTP;
using WebServer.Server.HTTP.Contracts;
using WebServer.Server.Routing.Contacts;

namespace WebServer.Server
{
    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig routeConfig)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(routeConfig, nameof(routeConfig));

            this.client = client;
            this.serverRouteConfig = routeConfig;
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = this.ReadRequest();


            var httpContext = new HttpContext(httpRequest);

            var httpResponse = new HttpHandler(this.serverRouteConfig).Handle(httpContext);

            var responseBytes = Encoding.UTF8.GetBytes(httpResponse.ToString());

            var byteSegments = new ArraySegment<byte>(responseBytes);

            await this.client.SendAsync(byteSegments, SocketFlags.None);

            Console.WriteLine($"------------REQUEST ---------");
            Console.WriteLine(httpRequest);
            Console.WriteLine($"------------RESPONSE ---------");
            Console.WriteLine(httpResponse);

            this.client.Shutdown(SocketShutdown.Both);

        }

        private async Task<IHttpRequest> ReadRequest()
        {

            var result = new StringBuilder();

            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

                if (numberOfBytesRead < 1024)
                {
                    break;
                }
            }


            return new HttpRequest(result.ToString());

        }
    }
}
