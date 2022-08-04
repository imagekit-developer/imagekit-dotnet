namespace Imagekit.Helper
{
    using System;

    public class ImageKitException : Exception
    {
        public ImageKitException()
        {
        }

        public ImageKitException(string message)
            : base(message)
        {
            throw new Exception(message);
        }

        public ImageKitException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}