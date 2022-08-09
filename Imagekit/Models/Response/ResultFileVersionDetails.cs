// <copyright file="ResultFileVersionDetails.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
[ExcludeFromCodeCoverage]
public class ResultFileVersionDetails : ResponseMetaData
{
    public string type { get; set; }
    public string name { get; set; }
    public string createdAt { get; set; }
    public string upDateTimedAt { get; set; }
    public string fileId { get; set; }
    public List<string> tags { get; set; }
    public JArray aiTags { get; set; }
    public JObject versionInfo { get; set; }
    public JObject embeddedMetadata { get; set; }
    public string customCoordinates { get; set; }
    public JObject customMetadata { get; set; }
    public bool ispublicFile { get; set; }
    public string url { get; set; }
    public string thumbnail { get; set; }
    public string fileType { get; set; }
    public string filePath { get; set; }
    public int height { get; set; }
    public int width { get; set; }
    public long size { get; set; }
    public bool hasAlpha { get; set; }
    public string mime { get; set; }
     
    
}