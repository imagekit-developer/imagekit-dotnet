// <copyright file="RenameFileRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel;

public class RenameFileRequest
{
    public string filePath { get; set; }

    public string newFileName { get; set; }

    private bool IspurgeCache;

    [DefaultValue(false)]
    public bool purgeCache
    {
        get
        {
            return this.IspurgeCache;
        }

        set
        {
            this.IspurgeCache = value;
        }
    }
}