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
using System.Threading.Tasks;

namespace Imagekit.Util
{
    public static class Utils
    {
        private static HttpClient httpClient = new HttpClient();
        public const string UserAgent = "ImagekitDotNet/3.1.0";

        /// <summary>
        /// For testing
        /// </summary>
        /// <param name="client"></param>
        internal static void SetHttpClient(HttpClient client)
        {
            httpClient = client;
        }

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
            return GetAsync(uri, key, method).Result;
        }

        public static async Task<HttpResponseMessage> GetAsync(Uri uri, string key, string method="GET")
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
                    return await httpClient.DeleteAsync(uri).ConfigureAwait(false);
                }
                return await httpClient.GetAsync(uri).ConfigureAwait(false);
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
            return PostAsync(uri, data, contentType, key, method).Result;
        }

        public static async Task<HttpResponseMessage> PostAsync(
            Uri uri,
            Dictionary<string, object> data,
            string contentType,
            string key,
            string method = "POST"
        )
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
                    return await httpClient.SendAsync(request).ConfigureAwait(false);
                }
                return await httpClient.PostAsync(uri, content).ConfigureAwait(false);
            }
            catch (WebException ex)
            {
                Console.WriteLine("\nException!");
                Console.WriteLine("Message :{0} ", ex.Message);
                throw ex;
            }
        }


        private static async Task<HttpResponseMessage> PostUploadAsync(Uri uri, Dictionary<string, string> data, HttpContent content, string key = null)
        {
            try
            {
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                MultipartFormDataContent multiForm = new MultipartFormDataContent();
                multiForm.Add(content, "file");

                foreach (var pair in data)
                {
                    multiForm.Add(new StringContent(pair.Value), pair.Key);
                }

                if (string.IsNullOrEmpty(key))
                {
                    if (!data.ContainsKey("signature") || !data.ContainsKey("token") | !data.ContainsKey("expire"))
                    {
                        throw new ArgumentException("Client authentication is missing", nameof(data));
                    }
                }
                else
                {
                    string authInfo = key + ":" + "";
                    authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                    httpClient.DefaultRequestHeaders.Authorization
                            = new AuthenticationHeaderValue("Basic", authInfo);
                }
                httpClient.DefaultRequestHeaders.UserAgent.Clear();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
                return await httpClient.PostAsync(uri, multiForm).ConfigureAwait(false);

            }
            catch (WebException ex)
            {
                Console.WriteLine("\nException!");
                Console.WriteLine("Message :{0} ", ex.Message);
                throw ex;
            }
        }

        public static async Task<HttpResponseMessage> PostUploadAsync(Uri uri, Dictionary<string, string> data, byte[] file, string key = null)
        {
            HttpContent content = new StringContent(Convert.ToBase64String(file));
            return await PostUploadAsync(uri, data, content, key).ConfigureAwait(false);
        }

        public static HttpResponseMessage PostUpload(Uri uri, Dictionary<string, string> data, byte[] file, string key = null)
        {
            return PostUploadAsync(uri, data, file, key).Result;
        }

        public static async Task<HttpResponseMessage> PostUploadAsync(Uri uri, Dictionary<string, string> data, string filePath, string key = null)
        {
            HttpContent content = new StringContent(filePath);
            if (string.IsNullOrEmpty(filePath) || filePath.Length % 4 != 0
               || filePath.Contains(" ") || filePath.Contains("\t") || filePath.Contains("\r") || filePath.Contains("\n"))
            {
                if (IsLocalPath(filePath))
                {
                    var fileInfo = new FileInfo(filePath);
                    try
                    {
                        content = new StringContent(Convert.ToBase64String(File.ReadAllBytes(fileInfo.FullName)));
                    }
                    catch (Exception)
                    {
                        content = new StringContent(filePath);
                    }
                }
            }

            return await PostUploadAsync(uri, data, content, key).ConfigureAwait(false);
        }

        public static HttpResponseMessage PostUpload(Uri uri, Dictionary<string, string> data, string filePath, string key = null)
        {
            return PostUploadAsync(uri, data, filePath, key).Result;
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
