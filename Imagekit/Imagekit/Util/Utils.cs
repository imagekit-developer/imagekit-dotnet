using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.ExceptionServices;

namespace Imagekit.Util
{
    public class Utils
    {
        private static readonly Encoding encoding = Encoding.UTF8;
        public const string UserAgent = "Imagekit .Net SDK";


        public static long ToUnixTime(DateTime dateTime)
        {
            return (int)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        internal static string getImageUploadAPI()
        {
            throw new NotImplementedException();
        }

        public static string calculateSignature(string input, byte[] key)
        {
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }

        public static string GetHost(string imagekitId, string subDomain)
        {
            if (string.IsNullOrEmpty(subDomain))
            {
                return Constants.COMMON_GET_SUBDOMAIN + Constants.BASE_GET;
            }
            else
            {
                return imagekitId + Constants.BASE_GET;
            }
        }

        public static string GetProtocol(bool useSecure)
        {
            return (useSecure ? Constants.HTTPS_PROTOCOL : Constants.HTTP_PROTOCOL);
        }

        public static string getImageUploadAPI(string imagekitId)
        {
            return Constants.BASE_UPLOAD + "/" + Constants.UPLOAD_API + "/" + imagekitId;
        }

        public static string getImageUploadURLAPI(string imagekitId)
        {
            return Constants.BASE_UPLOAD + "/" + Constants.UPLOAD_URL_API + "/" + imagekitId;
        }

        public static string getMetadataAPI(string imagekitId)
        {
            return Constants.BASE_UPLOAD + "/" + Constants.METADATA_API + "/" + imagekitId;
        }

        public static string getDeleteAPI()
        {
            return Constants.BASE_DASHBOARD + "/" + Constants.DELETE_API;
        }

        public static string getImagePurgeAPI()
        {
            return Constants.BASE_DASHBOARD + "/" + Constants.PURGE_API;
        }

        public static string getListMediaAPI()
        {
            return Constants.BASE_DASHBOARD + "/" + Constants.LIST_MEDIA_API;
        }

        public static long getInifiniteExpiry()
        {
            return Constants.INFINITE_EXPIRY_TIME;
        }

        public enum HttpMethod
        {
            DELETE,
            GET,
            POST,
            PUT
        }

        public static string Get(string uri)
        {
            var details = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                details = GetServerErrorMessage(ex);
            }
            return details;
        }

        public static string Post(string uri, string data, string contentType, string method = "POST")
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            var details = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = method;

            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    details = reader.ReadToEnd();
                    response.Close();
                }
            }
            catch(WebException ex)
            {
                details = GetServerErrorMessage(ex);
            }
            return details;

        }

        private static string GetServerErrorMessage(WebException wex)
        {
            string error;
            if (wex.Response == null) return null;
            var errorResponse = (HttpWebResponse)wex.Response;
            var respnseStream = errorResponse.GetResponseStream();
            if (respnseStream == null) return null;
            using (var reader = new StreamReader(respnseStream))
            {
                error = reader.ReadToEnd();
                reader.Close();
            }
            Console.WriteLine(error);
            throw new Exception(wex.Message);
        }
    }
}

