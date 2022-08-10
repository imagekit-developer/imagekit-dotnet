// <copyright file="RenameFileRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

public class RenameFileRequest
{
    public string FilePath { get; set; }

    public string NewFileName { get; set; }

    public bool PurgeCache { get; set; }
}