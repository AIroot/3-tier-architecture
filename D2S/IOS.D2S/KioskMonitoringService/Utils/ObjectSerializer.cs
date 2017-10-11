using System;
using System.Text;
using System.Web.Script.Serialization;

namespace KioskMonitoringService.Utils
{
    public static class ObjectSerializer
    {
        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

        public static byte[] Serialize(object obj)
        {
            try
            {
                return Encoding.UTF8.GetBytes(Serializer.Serialize(obj));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T Deserialize<T>(string response)
        {
            try
            {
                return Serializer.Deserialize<T>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
