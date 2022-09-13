// <copyright file="DeleteFileVersionRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class DeleteFileVersionRequest
    {
        public string fileId { get; set; }
        public string versionId { get; set; }
    }
}