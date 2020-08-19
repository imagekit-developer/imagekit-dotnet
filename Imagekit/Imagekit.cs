using System;
using System.Linq;
using Imagekit.Util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Text;

namespace Imagekit
{
    public partial class Imagekit
    {
       
        public Dictionary<string, object> options = new Dictionary<string, object>();

        public Imagekit(string publicKey, string privateKey, string urlEndpoint, string transformationPosition = "path")
        {
            if (string.IsNullOrEmpty(urlEndpoint) || string.IsNullOrEmpty(publicKey) || string.IsNullOrEmpty(privateKey))
            {
                throw new ArgumentException(errorMessages.MANDATORY_INITIALIZATION_MISSING);
            }

            Regex rgx = new Regex(@"\b(path|query)\b");
            if(!rgx.IsMatch(transformationPosition))
            {
                throw new ArgumentException(errorMessages.INVALID_TRANSFORMATION_POSITION);
            }

            Add("urlEndpoint", urlEndpoint);
            Add("publicKey", publicKey);
            Add("privateKey", privateKey);
            Add("transformationPosition", transformationPosition);
        }

        
        public string Generate()
        {
            Transformation transformation = (Transformation)options["transformation"];
            string tranformationString = transformation.Generate();
            return new Url(options).UrlBuilder(tranformationString);
        }

        
        public List<ListAPIResponse> ListFiles()
        {
            
            string[] arr = { "limit", "skip", "name", "includeFolder", "tags", "fileType", "path" };
            var param = new List<string>();
            foreach (var item in options)
            {
                if (arr.Any(item.Key.Contains))
                {
                    param.Add(item.Key + "=" +  item.Value);

                }
            }
            options.Remove("tags");
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "?" + string.Join("&", param));
            var response = Utils.Get(apiEndpoint, (string)options["privateKey"]);
            var responseContent = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ListAPIResponse>>(responseContent.Result);
        }

        
        public ListAPIResponse GetFileDetails(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                throw new ArgumentException(errorMessages.FILE_ID_MISSING);
            }
            Uri apiEndpoint = new Uri(Utils.GetFileApi() +"/" + fileId + "/details");
            var response = Utils.Get(apiEndpoint, (string)options["privateKey"]);
            var responseContent = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ListAPIResponse>(responseContent.Result);
        }

        
        public MetadataResponse GetFileMetadata(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                throw new ArgumentException(errorMessages.FILE_ID_MISSING);
            }
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/" + fileId + "/metadata");
            HttpResponseMessage response = Utils.Get(apiEndpoint, (string)options["privateKey"]);
            using (var responseContent = response.Content.ReadAsStringAsync())
            {
                MetadataResponse resp = JsonConvert.DeserializeObject<MetadataResponse>(responseContent.Result);
                resp.StatusCode = response.StatusCode.ToString();
                return resp;
            }
        }

       
        public string DeleteFile(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                throw new System.ArgumentException(errorMessages.FILE_ID_MISSING);
            }
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/" + fileId);
            var response = Utils.Get(apiEndpoint, (string)options["privateKey"], "DELETE");
            var responseContent = response.Content.ReadAsStringAsync();
            return responseContent.Result;
        }

        public ListAPIResponse UpdateFileDetails(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                throw new ArgumentException(errorMessages.FILE_ID_MISSING);
            }
            if (!options.ContainsKey("tagsList") && !options.ContainsKey("customCoordinates"))
            {
                throw new ArgumentException(errorMessages.UPDATE_DATA_MISSING);
            }
            Dictionary<string, object> postData = new Dictionary<string, object>();
            if (options.ContainsKey("tags")) {
                if ((string)options["tags"] == "null"){
                    postData.Add("tags", "null");
                    options.Remove("tags");
                } else
                {
                    throw new ArgumentException(errorMessages.UPDATE_DATA_TAGS_INVALID);
                }
                
            } else if (options.ContainsKey("tagsList"))
            {
                string[] tags = (string[])options["tagsList"];
                if (!tags.Any())
                {
                    throw new ArgumentException(errorMessages.UPDATE_DATA_TAGS_INVALID);
                }
                postData.Add("tags", tags);
                options.Remove("tagsList");
            }
            if (options.ContainsKey("customCoordinates")) {
                if(string.IsNullOrEmpty((string)options["customCoordinates"]))
                {
                    throw new ArgumentException(errorMessages.UPDATE_DATA_COORDS_INVALID);
                }
                postData.Add("customCoordinates", (string)options["customCoordinates"]);
            }

            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/" + fileId + "/details");
            string contentType = "application/json; charset=utf-8";

            var response = Utils.Post(apiEndpoint, postData, contentType, (string)options["privateKey"], "PATCH");
            var responseContent = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ListAPIResponse>(responseContent.Result);
        }

        public PurgeAPIResponse PurgeCache(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException(errorMessages.CACHE_PURGE_URL_MISSING);
            }
            Dictionary<string, object> postData = new Dictionary<string, object>();
            postData.Add("url", url);
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/purge"); 
            string contentType = "application/json; charset=utf-8";
            var response = Utils.Post(apiEndpoint, postData, contentType, (string)options["privateKey"]);
            var responseContent = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PurgeAPIResponse>(responseContent.Result);
        }

        
        public PurgeCacheStatusResponse GetPurgeCacheStatus(string requestId)
        {
            if (string.IsNullOrEmpty(requestId))
            {
                throw new ArgumentException(errorMessages.CACHE_PURGE_STATUS_ID_MISSING);
            }
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/purge/" + requestId);
            var response = Utils.Get(apiEndpoint, (string)options["privateKey"]);
            var responseContent = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PurgeCacheStatusResponse>(responseContent.Result);
        }

        public AuthParamResponse GetAuthenticationParameters (string token = null, string expire = null)
        {
            var DEFAULT_TIME_DIFF = 60 * 30;

            AuthParamResponse authParameters = new AuthParamResponse();
            authParameters.token = token;
            authParameters.expire = expire;
            authParameters.signature = "";

            if (!options.ContainsKey("privateKey") || string.IsNullOrEmpty((string)options["privateKey"]))
            {
                return authParameters;
            }

            string defaultExpire = Utils.GetSignatureTimestamp(DEFAULT_TIME_DIFF);

            if (string.IsNullOrEmpty(expire))
            {
                expire = defaultExpire;
            }
            if (string.IsNullOrEmpty(token))
            {
                token = Guid.NewGuid().ToString();
            }
            string signature = Utils.calculateSignature(token + expire, Encoding.ASCII.GetBytes((string)options["privateKey"]));
            authParameters.token = token;
            authParameters.expire = expire;
            authParameters.signature = signature;

            return authParameters;
        }


        public ImagekitResponse Upload(byte[] file)
        {
            Uri apiEndpoint = new Uri(Utils.GetUploadApi());

            var response = Utils.PostUpload(apiEndpoint, getUploadData(), file, (string)options["privateKey"]);
            //response.EnsureSuccessStatusCode();
            var responseContent = response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ImagekitResponse>(responseContent.Result);
        }

        public ImagekitResponse Upload(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException(errorMessages.MISSING_UPLOAD_FILE_PARAMETER);
            }
            Uri apiEndpoint = new Uri(Utils.GetUploadApi());

            var response = Utils.PostUpload(apiEndpoint, getUploadData(), file, (string)options["privateKey"]);
            var responseContent = response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ImagekitResponse>(responseContent.Result);
        }

        public Dictionary<string, string> getUploadData()
        {
            if (!options.ContainsKey("fileName") || string.IsNullOrEmpty((string)options["fileName"]))
            {
                throw new ArgumentException(errorMessages.MISSING_UPLOAD_FILENAME_PARAMETER);
            }

            Dictionary<string, string> postData = new Dictionary<string, string>();
            postData.Add("fileName", (string)options["fileName"]);
            if (options.ContainsKey("folder") && !string.IsNullOrEmpty((string)options["folder"]))
            {
                postData.Add("folder", (string)options["folder"]);
            }
            if (options.ContainsKey("isPrivate") && !string.IsNullOrEmpty((string)options["isPrivate"]))
            {
                postData.Add("isPrivate", (string)options["isPrivate"]);
            }
            if (options.ContainsKey("useUniqueFileName") && (bool)options["useUniqueFileName"] == false)
            {
                postData.Add("useUniqueFileName", "false");
            }
            if (options.ContainsKey("customCoordinates") && !string.IsNullOrEmpty((string)options["customCoordinates"]))
            {
                postData.Add("customCoordinates", (string)options["customCoordinates"]);
            }
            if (options.ContainsKey("responseFields") && !string.IsNullOrEmpty((string)options["responseFields"]))
            {
                postData.Add("responseFields", (string)options["responseFields"]);
            }
            if (options.ContainsKey("tags") && !string.IsNullOrEmpty((string)options["tags"]))
            {
                postData.Add("tags", (string)options["tags"]);
            }
            return postData;
        }
    }
}
