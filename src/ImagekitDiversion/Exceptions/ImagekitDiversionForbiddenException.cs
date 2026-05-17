using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversionForbiddenException : ImagekitDiversion4xxException
{
    public ImagekitDiversionForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
