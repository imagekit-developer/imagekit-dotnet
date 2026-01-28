using System.Net.Http;

namespace ImageKit.Exceptions;

public class ImageKit5xxException : ImageKitApiException
{
    public ImageKit5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
