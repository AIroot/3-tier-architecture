using System.Collections.Generic;

namespace IOS.D2S.DataConnector.Core.DomainObjects
{
        public class CustomConfigurations
        {
            private List<ConfigItem> _configurations = new List<ConfigItem>();

            public List<ConfigItem> Configurations
            {
                get { return _configurations; }
                set { _configurations = value; }
            }
        }
    
}
