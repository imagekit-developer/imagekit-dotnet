using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversion4xxException : ImagekitDiversionApiException
{
    public ImagekitDiversion4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
