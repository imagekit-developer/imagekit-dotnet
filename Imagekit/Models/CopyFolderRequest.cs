// <copyright file="CopyFolderRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class CopyFolderRequest
    {
        public string sourceFolderPath { get; set; }

        public string destinationPath { get; set; }

        public bool includeFileVersions { get; set; }
    }
}