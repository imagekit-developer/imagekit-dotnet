using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversionUnexpectedStatusCodeException : ImagekitDiversionApiException
{
    public ImagekitDiversionUnexpectedStatusCodeException(
        HttpRequestException? innerException = null
    )
        : base(innerException) { }
}
