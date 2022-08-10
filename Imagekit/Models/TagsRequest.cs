// <copyright file="TagsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

public class TagsRequest
{
    private List<string> fileIds;
    private List<string> tags;

    public List<string> FileIds { get => this.fileIds; set => this.fileIds = value; }

    public List<string> Tags { get => this.tags; set => this.tags = value; }
}
