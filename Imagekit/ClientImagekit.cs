using System;
using System.Threading.Tasks;
using Imagekit.Util;
using Newtonsoft.Json;

namespace Imagekit
{
    public class ClientImagekit : BaseImagekit<ClientImagekit>
    {
        public ClientImagekit(
            string publicKey,
            string urlEndpoint,
            string transformationPosition = "path"
        ) : base(publicKey, urlEndpoint, transformationPosition)
        {
        }

        public ImagekitResponse Upload(byte[] file, AuthParamResponse clientAuth)
        {
            return UploadAsync(file, clientAuth).Result;
        }

        public async Task<ImagekitResponse> UploadAsync(byte[] file, AuthParamResponse clientAuth)
        {
            Uri apiEndpoint = new Uri(Utils.GetUploadApi());

            var response = await Utils.PostUploadAsync(apiEndpoint, getUploadData(clientAuth), file).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            ImagekitResponse resp = JsonConvert.DeserializeObject<ImagekitResponse>(responseContent);
            resp.StatusCode = (int)response.StatusCode;
            return resp;
        }

        /// <summary>
        /// Upload the file at the path.
        /// </summary>
        /// <param name="filePath">The local file path or remote URL for the file.</param>
        /// <returns>The response body of the upload request.</returns>
        public ImagekitResponse Upload(string filePath, AuthParamResponse clientAuth)
        {
            return UploadAsync(filePath, clientAuth).Result;
        }

        /// <summary>
        /// Upload the file at the path.
        /// </summary>
        /// <param name="filePath">The local file path or remote URL for the file.</param>
        /// <returns>The response body of the upload request.</returns>
        public async Task<ImagekitResponse> UploadAsync(string filePath, AuthParamResponse clientAuth)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException(errorMessages.MISSING_UPLOAD_FILE_PARAMETER);
            }
            Uri apiEndpoint = new Uri(Utils.GetUploadApi());

            var response = await Utils.PostUploadAsync(apiEndpoint, getUploadData(clientAuth), filePath).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            ImagekitResponse resp = JsonConvert.DeserializeObject<ImagekitResponse>(responseContent);
            resp.StatusCode = (int)response.StatusCode;
            return resp;
        }
    }
}