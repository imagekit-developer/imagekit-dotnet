using System;
using System.Threading.Tasks;
using Imagekit.Util;
using Newtonsoft.Json;

namespace Imagekit
{
    public class ServerImagekit : BaseImagekit<ServerImagekit>
    {
        public ServerImagekit(
            string publicKey,
            string privateKey,
            string urlEndpoint,
            string transformationPosition = "path"
        ) : base(urlEndpoint, transformationPosition)
        {
            if (string.IsNullOrEmpty(publicKey))
            {
                throw new ArgumentNullException(nameof(publicKey));
            }
            if (string.IsNullOrEmpty(privateKey))
            {
                throw new ArgumentNullException(nameof(privateKey));
            }

            Add("publicKey", publicKey);
            Add("privateKey", privateKey);
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
    }
}