using System;

namespace Imagekit
{
    public class ServerImagekit : BaseImagekit
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
    }
}