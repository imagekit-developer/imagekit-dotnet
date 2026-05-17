using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversion5xxException : ImagekitDiversionApiException
{
    public ImagekitDiversion5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
