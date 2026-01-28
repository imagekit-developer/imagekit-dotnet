using System.Net.Http;

namespace ImageKit.Exceptions;

public class ImageKitNotFoundException : ImageKit4xxException
{
    public ImageKitNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
