// <copyright file="Result.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]

public class Result : ResponseMetaData
{
    public string Help { get; set; }

    public string Type { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string FileId { get; set; }

    public object Tags { get; set; }

    public object AITags { get; set; }

    public VersionInfo VersionInfo { get; set; }

    public EmbeddedMetadata EmbeddedMetadata { get; set; }

    public object CustomCoordinates { get; set; }

    public CustomMetadata CustomMetadata { get; set; }

    public bool IsPrivateFile { get; set; }

    public string Url { get; set; }

    public string Thumbnail { get; set; }

    public string FileType { get; set; }

    public string FilePath { get; set; }

    public int Height { get; set; }

    public int Width { get; set; }

    public int Size { get; set; }

    public bool HasAlpha { get; set; }

    public string Mime { get; set; }
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

public class VersionInfo
{
    public string Id { get; set; }

    public string Name { get; set; }
}