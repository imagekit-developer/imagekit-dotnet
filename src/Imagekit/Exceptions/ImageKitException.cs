using System;
using System.Net.Http;

namespace Imagekit.Exceptions;

public class ImageKitException : Exception
{
    public ImageKitException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected ImageKitException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
