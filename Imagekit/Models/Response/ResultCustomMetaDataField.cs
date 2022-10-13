// <copyright file="ResultCustomMetaDataField.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using Imagekit.Models;

[ExcludeFromCodeCoverage]
public class ResultCustomMetaDataField : ResponseMetaData
{
    public string id { get; set; }

    public string name { get; set; }

    public string label { get; set; }

    public CustomMetaDataFieldSchemaObject Schema { get; set; }
}