using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Server.Exceptions
{
    public class InvalidResponseException : Exception
    {
        public InvalidResponseException(string message)
            : base(message)
        {

        }
    }
}
