using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversionRateLimitException : ImagekitDiversion4xxException
{
    public ImagekitDiversionRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
