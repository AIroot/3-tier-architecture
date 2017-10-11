namespace IOS.D2S.DataConnector.Core.DomainObjects
{
    public class IOSConfigurations
    {
        public string ConnectionString { get; set; }
        
        private CustomConfigurations _extendedConfiguratiions = new CustomConfigurations();
        public CustomConfigurations ExtendedConfiguratiions
        {
            get { return _extendedConfiguratiions; }
            set { _extendedConfiguratiions = value; }
        }
    }
}
