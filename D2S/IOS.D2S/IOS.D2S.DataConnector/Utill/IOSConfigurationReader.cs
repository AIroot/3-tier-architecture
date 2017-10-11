using IOS.D2S.DataConnector.Core.DomainObjects;
using IOS.D2S.DataConnector.Core.IOSException;
using System;
using System.IO;
using System.Xml.Serialization;


namespace IOS.Common.DataConnector.Utill
{
   public static class IOSConfigurationReader
    {
        private static IOSConfigurations _configObj = null;

        public static IOSConfigurations GetIOSCongfiuration()
        {
            if (_configObj != null)
                return _configObj;

            try
            {
                string fileName =new  FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName + @"\IOSConfigurations.xml";

                // Following if find the file in read location when the .dll is called from a web application
                if (!File.Exists(fileName))
                {
                    fileName = System.Configuration.ConfigurationManager.AppSettings["IOS_Configuration_File_Path"];
                   
                }

                using (TextReader textReader = new StreamReader(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(IOSConfigurations));
                    object deserializedObject = serializer.Deserialize(textReader);
                    serializer = null;
                    _configObj = (IOSConfigurations)deserializedObject;
                    return _configObj;
                }
                
            }
            catch (Exception ex)
            {
                throw new IOSConfigurationReadException("Failed to read IOS Configurations from file [IOSConfigurations.xml]. " + ex.Message, ex);
            }
        }
    }
}
