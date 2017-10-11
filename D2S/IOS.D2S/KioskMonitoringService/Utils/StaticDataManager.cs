using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KioskMonitoringService.Utils
{
    public class StaticDataManager
    {
        public static string ServiceUrl;
        public static string SmsUrl;
        public static string UserName;
        public static string Password;
        public static string KioskAppProcessName;
        public static string KioskAppProcessPath;
        public static string KIOSKUploadedFilePath = "C:\\KIOSKUploadedFiles";
        public static DateTime CurrentDate = DateTime.Now;

     
        public static string MachineId;
        public static int MachineDetailId;
       


        public static WebRequest GetWebRequest<T>(List<string> parameters, string methodType, T t = default(T))
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                string url = parameters.Aggregate(ServiceUrl, (current, item) => current + "/" + item);
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Method = methodType;
                webRequest.ContentType = "application/json";
                string cred = Convert.ToBase64String(Encoding.ASCII.GetBytes(UserName + ":" + Password));
                webRequest.Headers.Add("Authorization", "Basic " + cred);

                if (t != null)
                {
                    var postData = ObjectSerializer.Serialize(t);

                    webRequest.ContentLength = postData.Length;
                    using (var reqStream = webRequest.GetRequestStream())
                    {
                        reqStream.Write(postData, 0, postData.Length);
                    }
                }
                return webRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T GetWebResponse<T>(WebRequest webRequest)
        {
            try
            {
                HttpWebResponse httpWebResponse = webRequest.GetResponse() as HttpWebResponse;
                if (httpWebResponse != null)
                {
                    using (StreamReader responseStream = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        return ObjectSerializer.Deserialize<T>(responseStream.ReadToEnd());
                    }
                }
                return default(T);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static T GetWebResponse<T>(WebRequest webRequest, string methodName)
        {
            try
            {
                HttpWebResponse httpWebResponse = webRequest.GetResponse() as HttpWebResponse;
                if (httpWebResponse != null)
                {
                    using (StreamReader responseStream = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        string Respons = responseStream.ReadToEnd().FormatJsonListString(methodName);
                        return ObjectSerializer.Deserialize<T>(Respons);
                    }
                }
                return default(T);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
