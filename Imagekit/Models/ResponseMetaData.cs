// <copyright file="ResponseMetaData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

public class ResponseMetaData
{
    private string raw;
    private int httpStatusCode;

    public string Raw { get => this.raw; set => this.raw = value; }

    public int HttpStatusCode { get => this.httpStatusCode; set => this.httpStatusCode = value; }
}