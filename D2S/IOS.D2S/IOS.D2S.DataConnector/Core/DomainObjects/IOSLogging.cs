using System;

namespace IOS.D2S.DataConnector.Core.DomainObjects
{
    [Serializable]
    public class IOSLogging
    {
        public string EventLogging { get; set; }
        public string ErrorLogging { get; set; } 
    }
}
