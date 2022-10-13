// <copyright file="ResultNoContent.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultNoContent : ResponseMetaData
{
    private ResponseMetaData ResponseMetaData { get; set; } = new ResponseMetaData();
}