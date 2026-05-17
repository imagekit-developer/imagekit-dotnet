using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversionUnprocessableEntityException : ImagekitDiversion4xxException
{
    public ImagekitDiversionUnprocessableEntityException(
        HttpRequestException? innerException = null
    )
        : base(innerException) { }
}
