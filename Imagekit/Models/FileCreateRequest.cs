// <copyright file="FileCreateRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using Imagekit.Models;

public class FileCreateRequest
{
    public string fileName { get; set; }

    public bool useUniqueFileName { get; set; }

    public List<string> tags { get; set; }

    public string folder { get; set; }

    public string customCoordinates { get; set; }

    public List<string> responseFields { get; set; }

    public List<Extension> extensions { get; set; }

    public string webhookUrl { get; set; }

    public bool overwriteFile { get; set; }

    public bool overwriteAITags { get; set; }

    public bool overwriteTags { get; set; }

    public bool overwriteCustomMetadata { get; set; }

    public Hashtable customMetadata { get; set; }

    public object file { get; set; }

    public bool isPrivateFile { get; set; }
}