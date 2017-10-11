using System;

namespace IOS.D2S.DataConnector.Core.IOSException
{
    internal class IOSConfigurationReadException : Exception
    {
        public IOSConfigurationReadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
