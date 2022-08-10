// <copyright file="FileCreateRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class FileCreateRequest
{
    private Uri url;
    private string base64;
    private byte[] bytes;
    private string fileName;
    private bool useUniqueFileName;
    private List<string> tags;
    private string folder;
    private bool isPrivateFileValue;
    private string customCoordinates;
    private List<string> responseFields;
    private JArray extensions;
    private string webhookUrl;
    private bool overwriteFile;
    private bool overwriteAiTags;
    private bool overwriteTags;
    private bool overwriteCustomMetadata;
    private JObject customMetadata;

    public bool UseUniqueFileName { set => this.useUniqueFileName = value; }

    public Uri Url { get => this.url; set => this.url = value; }

    public string Base64 { get => this.base64; set => this.base64 = value; }

    public byte[] Bytes { get => this.bytes; set => this.bytes = value; }

    public string FileName { get => this.fileName; set => this.fileName = value; }

    public List<string> Tags { set => this.tags = value; }

    public string Folder { set => this.folder = value; }

    public bool IsPrivateFileValue { set => this.isPrivateFileValue = value; }

    public string CustomCoordinates { set => this.customCoordinates = value; }

    public List<string> ResponseFields { set => this.responseFields = value; }

    public JArray Extensions { set => this.extensions = value; }

    public string WebhookUrl { set => this.webhookUrl = value; }

    public bool OverwriteFile { set => this.overwriteFile = value; }

    public bool OverwriteAiTags { set => this.overwriteAiTags = value; }

    public bool OverwriteTags { set => this.overwriteTags = value; }

    public bool OverwriteCustomMetadata { set => this.overwriteCustomMetadata = value; }

    public JObject CustomMetadata { set => this.customMetadata = value; }
}