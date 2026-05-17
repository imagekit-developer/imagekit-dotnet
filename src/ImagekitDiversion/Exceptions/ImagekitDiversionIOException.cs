using System;
using System.Net.Http;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversionIOException : ImagekitDiversionException
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

    public ImagekitDiversionIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
