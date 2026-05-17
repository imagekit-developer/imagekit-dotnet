using System.Net.Http;

namespace Imagekit.Exceptions;

public class ImageKitBadRequestException : ImageKit4xxException
{
    public ImageKitBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
