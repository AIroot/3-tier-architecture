using IOS.D2S.DataConnector.Core.DomainObjects;
using IOS.D2S.DataConnector.Core.IOSException;
using System;
using System.Configuration;
using System.IO;

namespace IOS.Common.DataConnector.Utill
{
    public static class IOSRunTimeVariables
    { 
        public static string GetConnectionString()
        {
         
            try
            {
                return IOSConfigurationReader.GetIOSCongfiuration().ConnectionString;
            }
            catch (Exception ex)
            {
                throw new IOSConfigurationReadException("Failed to read default Database connection string. " + ex.Message, ex);
            }
        }

        public static string D2SConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["D2SdataContext"].ConnectionString;
        }

    }
}