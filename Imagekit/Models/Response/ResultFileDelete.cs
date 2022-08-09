// <copyright file="ResultFileDelete.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Newtonsoft.Json;

public class ResultFileDelete : ResponseMetaData
{
    public string help { get; set; }

    public string raw { get; set; }
    public List<string> successfullyDeletedFileIds { get; set; }
    public List<string> missingFileIds { get; set; }
  
}