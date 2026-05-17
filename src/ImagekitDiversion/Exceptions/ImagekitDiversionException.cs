using System;
using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversionException : Exception
{
    public ImagekitDiversionException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected ImagekitDiversionException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
