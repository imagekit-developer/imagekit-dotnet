using System.Net.Http;

namespace ImageKit.Exceptions;

public class ImageKitRateLimitException : ImageKit4xxException
{
    public ImageKitRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
