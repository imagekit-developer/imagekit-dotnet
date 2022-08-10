// <copyright file="ResultFileVersions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultFileVersions : ResponseMetaData
{
    public List<ResultFileVersionDetails> resultFileVersionDetailsList { get; set; } = new List<ResultFileVersionDetails>();
    
 
}