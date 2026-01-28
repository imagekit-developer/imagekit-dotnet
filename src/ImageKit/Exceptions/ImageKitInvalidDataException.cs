using System;

namespace ImageKit.Exceptions;

public class ImageKitInvalidDataException : ImageKitException
{
    public ImageKitInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
