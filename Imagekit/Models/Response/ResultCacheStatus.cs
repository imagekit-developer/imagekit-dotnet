// <copyright file="ResultCacheStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultCacheStatus : ResponseMetaData
{
    public string Help { get; set; }

    public string Status { get; set; }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public string Raw { get; set; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
}