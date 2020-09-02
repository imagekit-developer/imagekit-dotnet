using System;

namespace Imagekit
{
    public class ClientImagekit : BaseImagekit<ClientImagekit>
    {
        public ClientImagekit(
            string urlEndpoint,
            string transformationPosition = "path"
        ) : base(urlEndpoint, transformationPosition)
        {
        }
    }
}