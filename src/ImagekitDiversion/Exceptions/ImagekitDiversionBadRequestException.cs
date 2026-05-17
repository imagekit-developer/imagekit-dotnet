using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversionBadRequestException : ImagekitDiversion4xxException
{
    public ImagekitDiversionBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
