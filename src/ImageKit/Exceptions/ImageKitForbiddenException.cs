using System.Net.Http;

namespace ImageKit.Exceptions;

public class ImageKitForbiddenException : ImageKit4xxException
{
    public ImageKitForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
