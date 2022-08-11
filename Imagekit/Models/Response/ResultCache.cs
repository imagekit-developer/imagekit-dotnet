// <copyright file="ResultCache.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultCache : ResponseMetaData
{
    private string Help { get; set; }

    private string RequestId { get; set; }

    private string Raw { get; set; }
}