// <copyright file="ResultFileDelete.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultFileDelete : ResponseMetaData
{
    public string Help { get; set; }

    public string Raw { get; set; }

    public List<string> SuccessfullyDeletedFileIds { get; set; }

    public List<string> MissingFileIds { get; set; }
}