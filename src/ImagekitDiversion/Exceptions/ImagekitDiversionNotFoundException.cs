using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversionNotFoundException : ImagekitDiversion4xxException
{
    public ImagekitDiversionNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
