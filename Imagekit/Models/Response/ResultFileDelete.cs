// <copyright file="ResultFileDelete.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultFileDelete : ResponseMetaData
{
    public string Help { get; set; }

    public List<string> SuccessfullyDeletedfileIds { get; set; }

    public List<string> MissingfileIds { get; set; }
}