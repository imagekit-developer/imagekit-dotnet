// <copyright file="ResultCache.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
[ExcludeFromCodeCoverage]
public class ResultCache : ResponseMetaData
{
    private string help { get; set; }
    private string requestId { get; set; }

    private string raw { get; set; }

}