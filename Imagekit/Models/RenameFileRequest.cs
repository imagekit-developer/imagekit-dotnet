// <copyright file="RenameFileRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

public class RenameFileRequest
{
    public string filePath { get; set; }

    public string newFileName { get; set; }

    public bool purgeCache { get; set; }
}