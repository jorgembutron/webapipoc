using System;

namespace Company.Services.Exceptions
{
    public class NotFoundException : BusinessException
    {

        public NotFoundException(): this(string.Empty)
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
