// I've left this file with the name `Imagekit.cs` and the obsolete Imagekit in the same file to
// make the github differences easier to see for the PR. Any subsequent PR can rename this file
// and split out the obsolete Imagekit into its own file.

using System;
using System.Linq;
using Imagekit.Util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Imagekit
{
    public abstract partial class BaseImagekit
    {
        public Dictionary<string, object> options = new Dictionary<string, object>();

        public BaseImagekit(string urlEndpoint, string transformationPosition = "path")
        {
            if (string.IsNullOrEmpty(urlEndpoint))
            {
                throw new ArgumentNullException(nameof(urlEndpoint));
            }

            Regex rgx = new Regex(@"\b(path|query)\b");
            if(!rgx.IsMatch(transformationPosition))
            {
                throw new ArgumentException(errorMessages.INVALID_TRANSFORMATION_POSITION);
            }

            Add("urlEndpoint", urlEndpoint);
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
            return ListFilesAsync().Result;
        }

        public async Task<List<ListAPIResponse>> ListFilesAsync()
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
            var response = await Utils.GetAsync(apiEndpoint, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<ListAPIResponse>>(responseContent);
        }


        public ListAPIResponse GetFileDetails(string fileId)
        {
            return GetFileDetailsAsync(fileId).Result;
        }

        public async Task<ListAPIResponse> GetFileDetailsAsync(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                throw new ArgumentException(errorMessages.FILE_ID_MISSING);
            }
            Uri apiEndpoint = new Uri(Utils.GetFileApi() +"/" + fileId + "/details");
            var response = await Utils.GetAsync(apiEndpoint, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ListAPIResponse>(responseContent);
        }


        public MetadataResponse GetFileMetadata(string fileId)
        {
            return GetFileMetadataAsync(fileId).Result;
        }

        public async Task<MetadataResponse> GetFileMetadataAsync(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                throw new ArgumentException(errorMessages.FILE_ID_MISSING);
            }
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/" + fileId + "/metadata");
            HttpResponseMessage response = await Utils.GetAsync(apiEndpoint, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            MetadataResponse resp = JsonConvert.DeserializeObject<MetadataResponse>(responseContent);
            resp.StatusCode = response.StatusCode.ToString();
            return resp;
        }


        public string DeleteFile(string fileId)
        {
            return DeleteFileAsync(fileId).Result;
        }

        public async Task<string> DeleteFileAsync(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                throw new System.ArgumentException(errorMessages.FILE_ID_MISSING);
            }
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/" + fileId);
            var response = await Utils.GetAsync(apiEndpoint, (string)options["privateKey"], "DELETE").ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseContent;
        }

        public ListAPIResponse UpdateFileDetails(string fileId)
        {
            return UpdateFileDetailsAsync(fileId).Result;
        }

        public async Task<ListAPIResponse> UpdateFileDetailsAsync(string fileId)
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

            var response = await Utils.PostAsync(apiEndpoint, postData, contentType, (string)options["privateKey"], "PATCH").ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ListAPIResponse>(responseContent);
        }

        public PurgeAPIResponse PurgeCache(string url)
        {
            return PurgeCacheAsync(url).Result;
        }

        public async Task<PurgeAPIResponse> PurgeCacheAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException(errorMessages.CACHE_PURGE_URL_MISSING);
            }
            Dictionary<string, object> postData = new Dictionary<string, object>();
            postData.Add("url", url);
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/purge");
            string contentType = "application/json; charset=utf-8";
            var response = await Utils.PostAsync(apiEndpoint, postData, contentType, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PurgeAPIResponse>(responseContent);
        }


        public PurgeCacheStatusResponse GetPurgeCacheStatus(string requestId)
        {
            return GetPurgeCacheStatusAsync(requestId).Result;
        }

        public async Task<PurgeCacheStatusResponse> GetPurgeCacheStatusAsync(string requestId)
        {
            if (string.IsNullOrEmpty(requestId))
            {
                throw new ArgumentException(errorMessages.CACHE_PURGE_STATUS_ID_MISSING);
            }
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/purge/" + requestId);
            var response = await Utils.GetAsync(apiEndpoint, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PurgeCacheStatusResponse>(responseContent);
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
            return UploadAsync(file).Result;
        }

        public async Task<ImagekitResponse> UploadAsync(byte[] file)
        {
            Uri apiEndpoint = new Uri(Utils.GetUploadApi());

            var response = await Utils.PostUploadAsync(apiEndpoint, getUploadData(), file, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ImagekitResponse>(responseContent);
        }

        /// <summary>
        /// Upload the file at the path.
        /// </summary>
        /// <param name="filePath">The local file path or remote URL for the file.</param>
        /// <returns>The response body of the upload request.</returns>
        public ImagekitResponse Upload(string filePath)
        {
            return UploadAsync(filePath).Result;
        }

        /// <summary>
        /// Upload the file at the path.
        /// </summary>
        /// <param name="filePath">The local file path or remote URL for the file.</param>
        /// <returns>The response body of the upload request.</returns>
        public async Task<ImagekitResponse> UploadAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException(errorMessages.MISSING_UPLOAD_FILE_PARAMETER);
            }
            Uri apiEndpoint = new Uri(Utils.GetUploadApi());

            var response = await Utils.PostUploadAsync(apiEndpoint, getUploadData(), filePath, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ImagekitResponse>(responseContent);
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
            if (options.ContainsKey("isPrivateFile") && !string.IsNullOrEmpty((string)options["isPrivateFile"]))
            {
                postData.Add("isPrivateFile", (string)options["isPrivateFile"]);
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

    // Leaving this for backwards compatibility.
    // Renaming the class:
    // a) solves the issue where Imagekit must always be fully qualified since the name is the same as the assembly
    // b) allows for clarification between a server-side imagekit and a client-side imagekit
    [Obsolete("Use ServerImagekit")]
    public class Imagekit : ServerImagekit
    {
        public Imagekit(
            string publicKey,
            string privateKey,
            string urlEndpoint,
            string transformationPosition = "path"
        ) : base(publicKey, privateKey, urlEndpoint, transformationPosition)
        {
        }
    }
}
