// <copyright file="ResultException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

public class ResultException
{
    private string message { get; set; }
    private string help { get; set; }
    private ResponseMetaData responseMetaData { get; set; } = new ResponseMetaData();

}