// <copyright file="ResultCustomMetaDataFieldList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultCustomMetaDataFieldList : ResponseMetaData
{
    public List<ResultCustomMetaDataField> resultCustomMetaDataFieldList { get; set; }=new List<ResultCustomMetaDataField>();
   
}