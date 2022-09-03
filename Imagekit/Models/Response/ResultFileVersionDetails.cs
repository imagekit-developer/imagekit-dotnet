// <copyright file="ResultFileVersionDetails.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;

[ExcludeFromCodeCoverage]
public class ResultFileVersionDetails : ResponseMetaData
{
    public string Type { get; set; }

    public string Name { get; set; }

    public string CreatedAt { get; set; }

    public string UpDateTimedAt { get; set; }

    public string FileId { get; set; }

    public List<string> Tags { get; set; }

    public JArray AITags { get; set; }

    public JObject VersionInfo { get; set; }

    public JObject EmbeddedMetadata { get; set; }

    public string CustomCoordinates { get; set; }

    public JObject CustomMetadata { get; set; }

    public bool IspublicFile { get; set; }

    public string Url { get; set; }

    public string Thumbnail { get; set; }

    public string FileType { get; set; }

    public string FilePath { get; set; }

    public int Height { get; set; }

    public int Width { get; set; }

    public long Size { get; set; }

    public bool HasAlpha { get; set; }

    public string Mime { get; set; }
}