using System;

namespace Wriststone.Common.Domain.Exceptions
{
    public class InternalException : Exception
    {
        public InternalException(string message, string developersError, Exception innerException): base(message, innerException)
        {

        }

        public InternalException(string message, Exception innerException): base(message, innerException)
        {

        }

        public InternalException(string message): base(message)
        {

        }

        public InternalException()
        {

        }

        public string DevelopersError { get; set; }
    }
}
