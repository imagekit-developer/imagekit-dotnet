using System.Net.Http;

namespace Imagekit.Exceptions;

public class ImageKitUnprocessableEntityException : ImageKit4xxException
{
    public ImageKitUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
