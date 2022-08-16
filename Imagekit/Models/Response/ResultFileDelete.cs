// <copyright file="ResultFileDelete.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultFileDelete : ResponseMetaData
{
    public string Help { get; set; }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public string Raw { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    public List<string> SuccessfullyDeletedFileIds { get; set; }

    public List<string> MissingFileIds { get; set; }
}