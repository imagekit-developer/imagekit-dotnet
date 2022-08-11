// <copyright file="ResultCustomMetaDataFieldList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultCustomMetaDataFieldList : ResponseMetaData
{
    public List<ResultCustomMetaDataField> ResultCustomMetaDataFieldList1 { get; set; } = new List<ResultCustomMetaDataField>();
}