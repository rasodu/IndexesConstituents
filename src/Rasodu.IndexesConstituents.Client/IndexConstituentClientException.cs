using System;

namespace Rasodu.IndexesConstituents.Client
{
    public class IndexConstituentClientException : Exception
    {
        internal IndexConstituentClientException(string message) : base(message)
        {
        }
        internal IndexConstituentClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}