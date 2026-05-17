using System;

namespace ImagekitDiversion.Exceptions;

public class ImagekitDiversionInvalidDataException : ImagekitDiversionException
{
    public ImagekitDiversionInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
