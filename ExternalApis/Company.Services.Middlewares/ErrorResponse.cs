using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Services.Middlewares
{
    public class ErrorResponse
    {
        public string EventId { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
    }
}
