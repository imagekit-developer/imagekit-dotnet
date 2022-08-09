// <copyright file="ResultBulkJobStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultBulkJobStatus :ResponseMetaData
{
    public string jobId { get; set; }
    public string type { get; set; }
    public string status { get; set; }



}