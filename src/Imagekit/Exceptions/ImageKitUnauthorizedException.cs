using System.Net.Http;

namespace Imagekit.Exceptions;

public class ImageKitUnauthorizedException : ImageKit4xxException
{
    public ImageKitUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
