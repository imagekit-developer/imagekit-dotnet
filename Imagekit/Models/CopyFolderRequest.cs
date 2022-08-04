// <copyright file="CopyFolderRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class CopyFolderRequest
    {
        public string SourceFolderPath { get; set; }

        public string DestinationPath { get; set; }

        public bool IncludeFileVersions { get; set; }
    }
}