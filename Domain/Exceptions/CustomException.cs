using System;
using System.Net;

namespace Domain.Domain.Core.Exceptions
{
    public class CustomException : Exception
    {
        public string Msg { get; private set; }
        public dynamic Info { get; private set; }
        public HttpStatusCode Status { get; private set; }

        public CustomException(HttpStatusCode status, string msg, dynamic info = null) 
        {
            Status = status;
            Msg = msg;
            Info = info;
        }
    }
}
