using System;
using System.Net.Http;

namespace Imagekit.Exceptions;

public class ImageKitIOException : ImageKitException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public ImageKitIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
