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
    public abstract partial class BaseImagekit<T> where T : BaseImagekit<T>
    {
        public Dictionary<string, object> options = new Dictionary<string, object>();

        public BaseImagekit(string publicKey, string urlEndpoint, string transformationPosition = "path")
        {
            if (string.IsNullOrEmpty(publicKey))
            {
                throw new ArgumentNullException(nameof(publicKey));
            }
            if (string.IsNullOrEmpty(urlEndpoint))
            {
                throw new ArgumentNullException(nameof(urlEndpoint));
            }

            Regex rgx = new Regex("^(path|query)$");
            if (transformationPosition == null || !rgx.IsMatch(transformationPosition))
            {
                throw new ArgumentException(errorMessages.INVALID_TRANSFORMATION_POSITION, nameof(transformationPosition));
            }

            Add("publicKey", publicKey);
            Add("urlEndpoint", urlEndpoint);
            Add("transformationPosition", transformationPosition);
        }


        public string Generate()
        {
            Transformation transformation = (Transformation)options["transformation"];
            string tranformationString = transformation.Generate();
            return new Url(options).UrlBuilder(tranformationString);
        }


        public Dictionary<string, string> getUploadData(AuthParamResponse clientAuth = null)
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
            if (options.ContainsKey("isPrivateFile") && (bool)options["isPrivateFile"] == true)
            {
                postData.Add("isPrivateFile", "true");
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
            else if (options.ContainsKey("tagsList"))
            {
                var tags = (string[])options["tagsList"];
                if (tags.Any())
                {
                    postData.Add("tags", string.Join(",", tags));
                }
            }
            if (clientAuth != null)
            {
                postData.Add("signature", clientAuth.signature);
                postData.Add("expire", clientAuth.expire.ToString());
                postData.Add("token", clientAuth.token);
                postData.Add("publicKey", (string)options["publicKey"]);
            }
            return postData;
        }
    }

    public class ServerImagekit : BaseImagekit<ServerImagekit>
    {
        public ServerImagekit(
            string publicKey,
            string privateKey,
            string urlEndpoint,
            string transformationPosition = "path"
        ) : base(publicKey, urlEndpoint, transformationPosition)
        {
            if (string.IsNullOrEmpty(privateKey))
            {
                throw new ArgumentNullException(nameof(privateKey));
            }

            Add("privateKey", privateKey);
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
                    param.Add(item.Key + "=" + item.Value);

                }
            }
            options.Remove("tags");
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "?" + string.Join("&", param));
            var response = await Utils.GetAsync(apiEndpoint, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                return JsonConvert.DeserializeObject<List<ListAPIResponse>>(responseContent);
            } catch
            {
                ListAPIResponse resp = JsonConvert.DeserializeObject<ListAPIResponse>(responseContent);
                resp.StatusCode = (int)response.StatusCode;
                resp.XIkRequestId = response.Headers.FirstOrDefault(x => x.Key == "x-ik-requestid").Value?.First();
                List<ListAPIResponse> respList=new List<ListAPIResponse>();
                respList.Add(resp);
                return respList;
            }
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
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/" + fileId + "/details");
            var response = await Utils.GetAsync(apiEndpoint, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            ListAPIResponse resp = JsonConvert.DeserializeObject<ListAPIResponse>(responseContent);
            resp.StatusCode = (int)response.StatusCode;
            resp.XIkRequestId = response.Headers.FirstOrDefault(x => x.Key == "x-ik-requestid").Value?.First();
            return resp;
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
            resp.StatusCode = (int)response.StatusCode;
            resp.XIkRequestId = response.Headers.FirstOrDefault(x => x.Key == "x-ik-requestid").Value?.First();
            return resp;
        }

        public MetadataResponse GetFileMetadata(Uri url)
        {
            return GetFileMetadataAsync(url).Result;
        }

        public async Task<MetadataResponse> GetFileMetadataAsync(Uri uri)
        {
            if (!Utils.IsValidURI(uri.OriginalString))
            {
                throw new ArgumentException(errorMessages.INVALID_URI);
            }
            Uri apiEndpoint = new Uri(Utils.GetApiHost() + "/v1/metadata?url=" + uri.AbsoluteUri);
            HttpResponseMessage response = await Utils.GetAsync(apiEndpoint, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var requestId = response.Headers.GetValues("x-ik-requestid").FirstOrDefault();

            MetadataResponse resp = JsonConvert.DeserializeObject<MetadataResponse>(responseContent);
            resp.StatusCode = (int)response.StatusCode;
            resp.XIkRequestId = response.Headers.FirstOrDefault(x => x.Key == "x-ik-requestid").Value?.First();
            return resp;
        }

        public DeleteAPIResponse DeleteFile(string fileId)
        {
            return DeleteFileAsync(fileId).Result;
        }

        public async Task<DeleteAPIResponse> DeleteFileAsync(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                throw new ArgumentException(errorMessages.FILE_ID_MISSING);
            }
            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/" + fileId);
            HttpResponseMessage response = await Utils.GetAsync(apiEndpoint, (string)options["privateKey"], "DELETE").ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            DeleteAPIResponse resp = new DeleteAPIResponse();
            if (responseContent != "")
            {
                resp = JsonConvert.DeserializeObject<DeleteAPIResponse>(responseContent);
            }
            resp.StatusCode = (int)response.StatusCode;
            resp.XIkRequestId = response.Headers.FirstOrDefault(x => x.Key == "x-ik-requestid").Value?.First();
            return resp;
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
            // If one of these is not provided, this request does nothing
            if (!options.ContainsKey("tags") && !options.ContainsKey("tagsList") && !options.ContainsKey("customCoordinates"))
            {
                throw new ArgumentException(errorMessages.UPDATE_DATA_MISSING);
            }

            Dictionary<string, object> postData = new Dictionary<string, object>();

            if (options.ContainsKey("tags"))
            {
                var tags = (string)options["tags"];
                if (tags != null && tags != "null")
                {
                    var tagsArray = tags.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    postData.Add("tags", tagsArray);
                }
                options.Remove("tags");
            }
            else if (options.ContainsKey("tagsList"))
            {
                string[] tags = (string[])options["tagsList"];
                if (tags == null || !tags.Any())
                {
                    throw new ArgumentException(errorMessages.UPDATE_DATA_TAGS_INVALID);
                }
                postData.Add("tags", tags);
                options.Remove("tagsList");
            }

            if (options.ContainsKey("customCoordinates"))
            {
                if (string.IsNullOrEmpty((string)options["customCoordinates"]))
                {
                    throw new ArgumentException(errorMessages.UPDATE_DATA_COORDS_INVALID);
                }
                postData.Add("customCoordinates", (string)options["customCoordinates"]);
            }

            Uri apiEndpoint = new Uri(Utils.GetFileApi() + "/" + fileId + "/details");
            string contentType = "application/json; charset=utf-8";

            HttpResponseMessage response = await Utils.PostAsync(apiEndpoint, postData, contentType, (string)options["privateKey"], "PATCH").ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            ListAPIResponse resp = JsonConvert.DeserializeObject<ListAPIResponse>(responseContent);
            resp.StatusCode = (int)response.StatusCode;
            resp.XIkRequestId = response.Headers.FirstOrDefault(x => x.Key == "x-ik-requestid").Value?.First();
            return resp;
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
            HttpResponseMessage response = await Utils.PostAsync(apiEndpoint, postData, contentType, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            PurgeAPIResponse resp = JsonConvert.DeserializeObject<PurgeAPIResponse>(responseContent);
            resp.StatusCode = (int)response.StatusCode;
            resp.XIkRequestId = response.Headers.FirstOrDefault(x => x.Key == "x-ik-requestid").Value?.First();
            return resp;
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
            HttpResponseMessage response = await Utils.GetAsync(apiEndpoint, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            PurgeCacheStatusResponse resp = JsonConvert.DeserializeObject<PurgeCacheStatusResponse>(responseContent);
            resp.StatusCode = (int)response.StatusCode;
            resp.XIkRequestId = response.Headers.FirstOrDefault(x => x.Key == "x-ik-requestid").Value?.First();
            return resp;
        }

        /// <summary>
        /// Generate Auth params for client-side upload 
        /// </summary>
        /// <param name="token">Random Token String)</param>
        /// <param name="expire">Expire time for the token</param>
        /// <returns>Returns Authparams including token, expiry time & signature.</returns>
        public AuthParamResponse GetAuthenticationParameters(string token = null, string expire = null)
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

        /// <summary>
        /// Upload the file as byte[].
        /// </summary>
        /// <param name="file">File input as byte Array.</param>
        /// <returns>The response body of the upload request.</returns>
        public ImagekitResponse Upload(byte[] file)
        {
            return UploadAsync(file).Result;
        }

        /// <summary>
        /// Upload the file as byte[].
        /// </summary>
        /// <param name="file">File input as byte Array.</param>
        /// <returns>The response body of the upload request.</returns>
        public async Task<ImagekitResponse> UploadAsync(byte[] file)
        {
            Uri apiEndpoint = new Uri(Utils.GetUploadApi());

            HttpResponseMessage response = await Utils.PostUploadAsync(apiEndpoint, getUploadData(), file, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            ImagekitResponse resp = JsonConvert.DeserializeObject<ImagekitResponse>(responseContent); 
            resp.StatusCode = (int)response.StatusCode;
            resp.XIkRequestId = response.Headers.FirstOrDefault(x => x.Key == "x-ik-requestid").Value?.First();
            return resp;
        }

        /// <summary>
        /// The local file fullpath or remote URL for the file.
        /// </summary>
        /// <param name="file">The local file path or remote URL for the file.</param>
        /// <returns>The response body of the upload request.</returns>
        public ImagekitResponse Upload(string file)
        {
            return UploadAsync(file).Result;
        }

        /// <summary>
        /// The local file fullpath or remote URL for the file.
        /// </summary>
        /// <param name="file">The local file path or remote URL for the file.</param>
        /// <returns>The response body of the upload request.</returns>
        public async Task<ImagekitResponse> UploadAsync(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException(errorMessages.MISSING_UPLOAD_FILE_PARAMETER);
            }
            Uri apiEndpoint = new Uri(Utils.GetUploadApi());

            HttpResponseMessage response = await Utils.PostUploadAsync(apiEndpoint, getUploadData(), file, (string)options["privateKey"]).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            ImagekitResponse resp = JsonConvert.DeserializeObject<ImagekitResponse>(responseContent);
            resp.StatusCode = (int)response.StatusCode;
            resp.XIkRequestId = response.Headers.FirstOrDefault(x => x.Key == "x-ik-requestid").Value?.First();
            return resp;
        }
        


        /// <summary>
        /// Calculate pHash Distance(hamming-distance) of two pHash Strings.
        /// </summary>
        /// <param name="firstPhash">String pHash value of an image</param>
        /// <param name="secondPhash">String pHash value of second image</param>
        /// <returns></returns>
        public int PHashDistance(string firstPhash, string secondPhash)
        {
            return Utils.PHashDistance(firstPhash, secondPhash);
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
