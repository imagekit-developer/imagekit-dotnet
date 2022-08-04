// <copyright file="CopyFileRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class CopyFileRequest
    {
        public string SourceFilePath { get; set; }

        public string DestinationPath { get; set; }

        public bool IncludeFileVersions { get; set; }
    }
}