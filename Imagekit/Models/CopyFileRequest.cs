// <copyright file="CopyFileRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class CopyFileRequest
    {
        public string sourceFilePath { get; set; }

        public string destinationPath { get; set; }

        public bool includeFileVersions { get; set; }
    }
}