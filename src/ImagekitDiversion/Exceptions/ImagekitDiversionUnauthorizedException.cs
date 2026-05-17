using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversionUnauthorizedException : ImagekitDiversion4xxException
{
    public ImagekitDiversionUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
