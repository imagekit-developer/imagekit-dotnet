// <copyright file="DeleteFileVersionRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class DeleteFileVersionRequest
    {
        private string fileId;
        private string versionId;

        public string FileId { get => this.fileId; set => this.fileId = value; }

        public string VersionId { get => this.versionId; set => this.versionId = value; }
    }
}