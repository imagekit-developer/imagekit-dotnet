// <copyright file="ImageKitException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Helper
{
    using System;

    public class ImagekitException : Exception
    {
        public ImagekitException()
        {
        }

        public ImagekitException(string message)
            : base(message)
        {
            throw new Exception(message);
        }

        public ImagekitException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}