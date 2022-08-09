// <copyright file="ResultCustomMetaDataField.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Imagekit.Models;

public class ResultCustomMetaDataField : ResponseMetaData
{
    private string Id { get; set; }

    private string Name { get; set; }

    private string Label { get; set; }

    private string Message { get; set; }

    private CustomMetaDataFieldSchemaObject Schema { get; set; }
   
}