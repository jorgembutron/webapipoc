using System;

namespace Company.Services.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : this(message, (Exception)null)
        {
        }

        public BusinessException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
    }
}
