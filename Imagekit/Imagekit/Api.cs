using System;
using System.IO;
using System.Text;
using Imagekit.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Imagekit
{
    public class Api
    {
        JObject options;
        public const string UserAgent =
              "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393";


        public Api(Client client)
        {
            if (string.IsNullOrEmpty(client.ImageKitId) || string.IsNullOrEmpty(client.ApiKey) || string.IsNullOrEmpty(client.ApiSecret))
            {
                throw new System.ArgumentException("ImageKit Id, API Key and API secret are necessary for initialization.");
            }
            options = new JObject(
                new JProperty[]
                {
                    new JProperty("imagekitId", client.ImageKitId),
                    new JProperty("apiKey", client.ApiKey),
                    new JProperty("apiSecret", client.ApiSecret),
                    new JProperty("pattern", ""),
                    new JProperty("useSubdomain", false),
                    new JProperty("useSecure", false)
                });
        }

        /// <summary>
        /// Generating image URLs
        /// </summary>
        /// <param name="key"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public string Url(string key, object[] options, bool signedUrl=false, long expirySeconds=0)
        {
            Image img = new Image(key, options);
            if (signedUrl)
            {
                var res = img.getSignedUrl(expirySeconds);
                return res;
            }
            else
            {
                var res = img.getUrl();
                return res;
            }
        }

        /// <summary>
        /// List Media Libtrary Uploaded files
        /// </summary>
        /// <param name="skip">Number of records to skip (default 0).</param>
        /// <param name="limit">Number of recrods to fetch (default 1000).</param>
        /// <returns></returns>
        public List<ListAPIResponse> ListUploadedMediaFiles(int skip = 0, int limit = 100)
        {
            string apiUrl = Utils.GetProtocol(false) + "//" + Utils.getListMediaAPI();
            string str = string.Format("imagekitId={0}&limit={1}&skip={2}", (string)options["imagekitId"], limit, skip);
            string signature = Utils.calculateSignature(str, Encoding.ASCII.GetBytes((string)options["apiSecret"]));
            apiUrl = apiUrl + "?skip=" + skip + "&limit=" + limit + "&imagekitId=" + (string)options["imagekitId"] + "&signature=" + signature;
            string resp = Utils.Get(apiUrl);
            List<ListAPIResponse> resp1 = JsonConvert.DeserializeObject<List<ListAPIResponse>>(resp);
            return resp1;
        }

        public PurgeAPIResponse PurgeFile(string url)
        {
            string apiUrl = Utils.GetProtocol(true) + "//" + Utils.getImagePurgeAPI();
            string str = string.Format("imagekitId={0}&url={1}", (string)options["imagekitId"], url);
            string signature = Utils.calculateSignature(str, Encoding.ASCII.GetBytes((string)options["apiSecret"]));
            string contentType = "application/x-www-form-urlencoded";
            string postData = "url=" + url;
            postData += "&imagekitId=" + (string)options["imagekitId"];
            postData += "&signature=" + signature;
            string resp = Utils.Post(apiUrl, postData, contentType);
            PurgeAPIResponse resp1 = JsonConvert.DeserializeObject<PurgeAPIResponse>(resp);
            return resp1;
        }

        public DeleteAPIResponse DeleteFile(string path)
        {
            string apiUrl = Utils.GetProtocol(true) + "//" + Utils.getDeleteAPI();
            string str = string.Format("imagekitId={0}&path={1}", (string)options["imagekitId"], path);
            string signature = Utils.calculateSignature(str, Encoding.ASCII.GetBytes((string)options["apiSecret"]));
            string contentType = "application/x-www-form-urlencoded";
            string postData = "path=" + path;
            postData += "&imagekitId=" + (string)options["imagekitId"];
            postData += "&signature=" + signature;
            string resp = Utils.Post(apiUrl, postData, contentType);
            DeleteAPIResponse resp1 = JsonConvert.DeserializeObject<DeleteAPIResponse>(resp);
            return resp1;
        }

        public MetadataRespone GetMetadata(string url)
        {
            string apiUrl = Utils.GetProtocol(true) + "//" + Utils.getMetadataAPI((string)options["imagekitId"]);
            var TimeStamp = Utils.ToUnixTime(DateTime.UtcNow);
            string str = string.Format("apiKey={0}&timestamp={1}&url={2}", (string)options["apiKey"], TimeStamp, url);
            string signature = Utils.calculateSignature(str, Encoding.ASCII.GetBytes((string)options["apiSecret"]));
            string contentType = "application/x-www-form-urlencoded";
            string postData = "url=" + url;
            postData += "&apiKey=" + (string)options["apiKey"];
            postData += "&timestamp=" + TimeStamp;
            postData += "&signature=" + signature;
            string resp = Utils.Post(apiUrl, postData, contentType);
            return JsonConvert.DeserializeObject<MetadataRespone>(resp);
        }

        public ImagekitResponse Upload(string imagePath, string folder, string filename, bool useUniqueFileName = true)
        {
            if (string.IsNullOrEmpty(folder))
            {
                folder = "/";
            }
            Uri uploadUrl = new Uri(Utils.GetProtocol(false) + "//" + Utils.getImageUploadAPI((string)options["imagekitId"]));
            var TimeStamp = Utils.ToUnixTime(DateTime.UtcNow);
            string str = string.Format("apiKey={0}&filename={1}&timestamp={2}", (string)options["apiKey"], filename, TimeStamp);
            var signature = Utils.calculateSignature(str, Encoding.ASCII.GetBytes((string)options["apiSecret"]));
            var postParameters = new Dictionary<string, object>
            {
                {"apiKey", (string)options["apiKey"]},
                {"filename",filename },
                {"folder", folder},
                {"signature", signature},
                {"timestamp",TimeStamp },
                {"useUniqueFilename", useUniqueFileName }
            };

            var fi = new FileInfo(imagePath);

            string responseText = FormUpload.ExecutePostRequest(uploadUrl, postParameters, fi, "image/jpeg", "file");
            return JsonConvert.DeserializeObject<ImagekitResponse>(responseText);

        }

        public ImagekitResponse UploadViaURL(string url, string folder, string filename, bool useUniqueFileName = true)
        {
            string apiUrl = Utils.GetProtocol(true) + "//" + Utils.getImageUploadURLAPI((string)options["imagekitId"]);
            var TimeStamp = Utils.ToUnixTime(DateTime.UtcNow);
            string str = string.Format("apiKey={0}&filename={1}&timestamp={2}", (string)options["apiKey"], filename, TimeStamp);
            string signature = Utils.calculateSignature(str, Encoding.ASCII.GetBytes((string)options["apiSecret"]));
            string contentType = "application/x-www-form-urlencoded";
            string postData = "url=" + url;
            postData += "&apiKey=" + (string)options["apiKey"];
            postData += "&signature=" + signature;
            postData += "&folder=" + folder;
            postData += "&timestamp=" + TimeStamp;
            postData += "&filename=" + filename;
            postData += "&useUniqueFilename=" + useUniqueFileName;
            string responseText = Utils.Post(apiUrl, postData, contentType);
            return JsonConvert.DeserializeObject<ImagekitResponse>(responseText);

        }

        
    }
}
