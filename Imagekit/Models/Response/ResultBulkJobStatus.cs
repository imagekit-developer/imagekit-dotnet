// <copyright file="ResultBulkJobStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultBulkJobStatus : ResponseMetaData
{
    public string JobId { get; set; }

    public string Type { get; set; }

    public string Status { get; set; }
}