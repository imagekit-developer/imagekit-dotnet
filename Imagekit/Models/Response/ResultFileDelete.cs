// <copyright file="ResultFileDelete.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Newtonsoft.Json;

public class ResultFileDelete
{
    private string help { get; set; }

    private string raw { get; set; }
    private List<string> successfullyDeletedFileIds { get; set; }
    private List<string> missingFileIds { get; set; }
    private ResponseMetaData responseMetaData { get; set; } = new ResponseMetaData();
}