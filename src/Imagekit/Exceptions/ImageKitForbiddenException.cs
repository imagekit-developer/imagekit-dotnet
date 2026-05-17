using System.Net.Http;

namespace Imagekit.Exceptions;

public class ImageKitForbiddenException : ImageKit4xxException
{
    public ImageKitForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
