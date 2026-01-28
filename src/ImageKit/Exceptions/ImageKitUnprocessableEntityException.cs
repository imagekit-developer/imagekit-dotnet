using System.Net.Http;

namespace ImageKit.Exceptions;

public class ImageKitUnprocessableEntityException : ImageKit4xxException
{
    public ImageKitUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
