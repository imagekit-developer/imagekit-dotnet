// <copyright file="FileCreateRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Imagekit.Models;
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
    private List<Extension> extensions;
    private string webhookUrl;
    private bool overwriteFile;
    private bool overwriteAiTags;
    private bool overwriteTags;
    private bool overwriteCustomMetadata;
    private Hashtable customMetadata;

    public bool UseUniqueFileName { get => this.useUniqueFileName; set => this.useUniqueFileName = value; }

    public Uri Url { get => this.url; set => this.url = value; }

    public string Base64 { get => this.base64; set => this.base64 = value; }

    public byte[] Bytes { get => this.bytes; set => this.bytes = value; }

    public string FileName { get => this.fileName; set => this.fileName = value; }

    public List<string> Tags
    {
        get => this.tags; set => this.tags = value;
    }

    public string Folder { get => this.folder; set => this.folder = value; }

    public bool IsPrivateFileValue { get => this.isPrivateFileValue; set => this.isPrivateFileValue = value; }

    public string CustomCoordinates
    {
        get => this.customCoordinates; set => this.customCoordinates = value;
    }

    public List<string> ResponseFields
    {
        get => this.responseFields; set => this.responseFields = value;
    }

    public List<Extension> Extensions
    {
        get => this.extensions; set => this.extensions = value;
    }

    public string WebhookUrl { get => this.webhookUrl; set => this.webhookUrl = value; }

    public bool OverwriteFile { get => this.overwriteFile; set => this.overwriteFile = value; }

    public bool OverwriteAiTags { get => this.overwriteAiTags; set => this.overwriteAiTags = value; }

    public bool OverwriteTags { get => this.overwriteTags; set => this.overwriteTags = value; }

    public bool OverwriteCustomMetadata { get => this.overwriteCustomMetadata; set => this.overwriteCustomMetadata = value; }

    public Hashtable CustomMetadata { get => this.customMetadata; set => this.customMetadata = value; }
}