// <copyright file="ResultCacheStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
[ExcludeFromCodeCoverage]
public class ResultCacheStatus : ResponseMetaData
{
    private string help { get; set; }
    private string status { get; set; }

    private string raw { get; set; }
    
   
}