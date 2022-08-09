// <copyright file="ResultCustomMetaDataFieldList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

public class ResultCustomMetaDataFieldList
{
    public List<ResultCustomMetaDataField> resultCustomMetaDataFieldList { get; set; }=new List<ResultCustomMetaDataField>();
    public ResponseMetaData responseMetaData { get; set; }=new ResponseMetaData();
}