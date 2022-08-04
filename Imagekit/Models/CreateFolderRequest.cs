// <copyright file="CreateFolderRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class CreateFolderRequest
    {
        public string FolderName { get; set; }

        public string ParentFolderPath { get; set; }
    }
}