using System.Net.Http;

namespace Imagekit.Exceptions;

public class ImageKitUnexpectedStatusCodeException : ImageKitApiException
{
    public ImageKitUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
