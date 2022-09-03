// <copyright file="TagsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

public class TagsRequest
{
    private List<string> FileIds;
    private List<string> Tags;

    public List<string> fileIds { get => this.FileIds; set => this.FileIds = value; }

    public List<string> tags { get => this.Tags; set => this.Tags = value; }
}
