// <copyright file="Result.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
 

public class Result : ResponseMetaData
{
    public string help { get; set; }

    public string raw { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public string fileId { get; set; }
    public object tags { get; set; }
    public object AITags { get; set; }
    public VersionInfo versionInfo { get; set; }
    public EmbeddedMetadata embeddedMetadata { get; set; }
    public object customCoordinates { get; set; }
    public CustomMetadata customMetadata { get; set; }
    public bool isPrivateFile { get; set; }
    public string url { get; set; }
    public string thumbnail { get; set; }
    public string fileType { get; set; }
    public string filePath { get; set; }
    public int height { get; set; }
    public int width { get; set; }
    public int size { get; set; }
    public bool hasAlpha { get; set; }
    public string mime { get; set; }


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
    public string id { get; set; }
    public string name { get; set; }
}