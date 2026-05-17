using System.Net.Http;

namespace Imagekit.Exceptions;

public class ImageKit4xxException : ImageKitApiException
{
    public ImageKit4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
