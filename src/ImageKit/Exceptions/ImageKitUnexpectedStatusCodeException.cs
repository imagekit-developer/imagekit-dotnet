using System.Net.Http;

namespace ImageKit.Exceptions;

public class ImageKitUnexpectedStatusCodeException : ImageKitApiException
{
    public ImageKitUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
