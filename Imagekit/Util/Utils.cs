using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Imagekit.Util
{
    public class Utils
    {
        private static HttpClient httpClient = new HttpClient();
        public const string UserAgent = "ImagekitDotNet/3.0.4";

        public static long ToUnixTime(DateTime dateTime)
        {
            return (int)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static string GetSignatureTimestamp(int seconds)
        {
            if (seconds <= 0) { return Constants.DEFAULT_TIMESTAMP; }
            var TimeStamp = ToUnixTime(DateTime.UtcNow);
            return (TimeStamp + seconds).ToString();
        }

        public static string GetFileApi()
        {
            return Constants.HTTPS_PROTOCOL + Constants.API_HOST + Constants.FILE_API;
        }

        public static string GetUploadApi()
        {
            return Constants.HTTPS_PROTOCOL + Constants.API_HOST + Constants.UPLOAD_API;
        }

        public static string calculateSignature(string input, byte[] key)
        {
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }

        public static HttpResponseMessage Get(Uri uri, string key, string method="GET")
        {
            try
            {
                string authInfo = key + ":" + "";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Basic", authInfo);
                httpClient.DefaultRequestHeaders.UserAgent.Clear();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
                if (method == "DELETE")
                {
                    return httpClient.DeleteAsync(uri).Result;
                }
                return httpClient.GetAsync(uri).Result;
            }
            catch (WebException ex)
            {
                Console.WriteLine("\nException!");
                Console.WriteLine("Message :{0} ", ex.Message);
                throw ex;
            }
        }

        public static HttpResponseMessage Post(Uri uri, Dictionary<string, object> data, string contentType, string key, string method="POST")
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            var content = new StringContent(json);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);

            try
            {
                string authInfo = key + ":" + "";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Basic", authInfo);
                httpClient.DefaultRequestHeaders.UserAgent.Clear();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
                if (method == "PATCH")
                {
                    var httpMethod = new HttpMethod("PATCH");
                    var request = new HttpRequestMessage(httpMethod, uri)
                    {
                        Content = content
                    };
                    return httpClient.SendAsync(request).Result;
                }
                return httpClient.PostAsync(uri, content).Result;
            }
            catch (WebException ex)
            {
                Console.WriteLine("\nException!");
                Console.WriteLine("Message :{0} ", ex.Message);
                throw ex;
            }
        }


        public static HttpResponseMessage PostUpload(Uri uri, Dictionary<string, string> data, byte[] file, string key)
        {
            HttpContent content = new StringContent(Convert.ToBase64String(file));
            
            try
            {
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                MultipartFormDataContent multiForm = new MultipartFormDataContent();
                multiForm.Add(content, "file");

                foreach (var pair in data)
                {
                    multiForm.Add(new StringContent(pair.Value), pair.Key);
                }

                string authInfo = key + ":" + "";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Basic", authInfo);
                httpClient.DefaultRequestHeaders.UserAgent.Clear();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
                return httpClient.PostAsync(uri, multiForm).Result;

            }
            catch (WebException ex)
            {
                Console.WriteLine("\nException!");
                Console.WriteLine("Message :{0} ", ex.Message);
                throw ex;
            }
        }

        public static HttpResponseMessage PostUpload(Uri uri, Dictionary<string, string> data, string file, string key)
        {
            HttpContent content = new StringContent(file);
            if (string.IsNullOrEmpty(file) || file.Length % 4 != 0
               || file.Contains(" ") || file.Contains("\t") || file.Contains("\r") || file.Contains("\n"))
            {
                if (IsLocalPath(file))
                {
                    var fileInfo = new FileInfo(file);
                    try
                    {
                        content = new StringContent(Convert.ToBase64String(File.ReadAllBytes(fileInfo.FullName)));
                    }
                    catch (Exception)
                    {
                        content = new StringContent(file);
                    }
                }       
            }

            try
            {
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                MultipartFormDataContent multiForm = new MultipartFormDataContent();
                multiForm.Add(content, "file");

                foreach (var pair in data)
                {
                    multiForm.Add(new StringContent(pair.Value), pair.Key);
                }

                string authInfo = key + ":" + "";
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Basic", authInfo);
                httpClient.DefaultRequestHeaders.UserAgent.Clear();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
                
                return httpClient.PostAsync(uri, multiForm).Result;
            }
            catch (WebException ex)
            {
                Console.WriteLine("\nException!");
                Console.WriteLine("Message :{0} ", ex.Message);
                throw ex;
            }
        }

        private static bool IsLocalPath(string p)
        {
            if (p.StartsWith("http:\\", StringComparison.Ordinal))
            {
                return false;
            }
            if (p.StartsWith("https:\\", StringComparison.Ordinal))
            {
                return false;
            }

            return new Uri(p).IsFile;
        }
       
    }
}

