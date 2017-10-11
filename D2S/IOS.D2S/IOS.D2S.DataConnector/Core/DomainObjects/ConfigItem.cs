namespace IOS.D2S.DataConnector.Core.DomainObjects
{
    public class ConfigItem
    {
        private string _key = string.Empty;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private string _value = string.Empty;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
