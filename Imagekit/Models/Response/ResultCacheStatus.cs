// <copyright file="ResultCacheStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultCacheStatus : ResponseMetaData
{
    private string Help { get; set; }

    private string Status { get; set; }

    private string Raw { get; set; }
}