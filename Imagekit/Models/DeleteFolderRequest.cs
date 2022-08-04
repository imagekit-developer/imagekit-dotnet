// <copyright file="DeleteFolderRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class DeleteFolderRequest
    {
        private string folderPath;

        public string FolderPath { get => this.folderPath; set => this.folderPath = value; }
    }
}