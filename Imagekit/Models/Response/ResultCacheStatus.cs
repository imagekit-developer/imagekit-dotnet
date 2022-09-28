// <copyright file="ResultCacheStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultCacheStatus : ResponseMetaData
{
    public string Help { get; set; }

    public string Status { get; set; }
}