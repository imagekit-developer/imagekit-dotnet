// <copyright file="Result.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

[ExcludeFromCodeCoverage]

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Exif
{
}

public class ExtensionStatus
{
    [JsonProperty("remove-bg")]
    public string RemoveBg { get; set; }

    [JsonProperty("google-auto-tagging")]
    public string GoogleAutoTagging { get; set; }
}

public class Metadata
{
    public int height { get; set; }

    public int width { get; set; }

    public int size { get; set; }

    public string format { get; set; }

    public bool hasColorProfile { get; set; }

    public int quality { get; set; }

    public int density { get; set; }

    public bool hasTransparency { get; set; }

    public Exif exif { get; set; }

    public string pHash { get; set; }
}

public class Result : ResponseMetaData
{
    public string fileId { get; set; }

    public string name { get; set; }

    public int size { get; set; }

    public VersionInfo versionInfo { get; set; }

    public string filePath { get; set; }

    public string url { get; set; }

    public string fileType { get; set; }

    public int height { get; set; }

    public int width { get; set; }

    public string thumbnailUrl { get; set; }

    public List<string> tags { get; set; }

    public object AITags { get; set; }

    public bool isPrivateFile { get; set; }

    public string customCoordinates { get; set; }

    public Metadata metadata { get; set; }

    public ExtensionStatus extensionStatus { get; set; }
}

public class VersionInfo
{
    public string id { get; set; }

    public string name { get; set; }
}

public class CustomMetadata
{
}

public class EmbeddedMetadata
{
    public int XResolution { get; set; }

    public int YResolution { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateTimeCreated { get; set; }
}

public class ResultDelete : ResponseMetaData
{
    public string FileId { get; set; }
}