// <copyright file="ResultException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class ResultException : ResponseMetaData
{
    private string message { get; set; }
    private string help { get; set; }
  

}