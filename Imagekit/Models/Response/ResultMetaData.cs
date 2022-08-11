// <copyright file="ResultMetaData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models.Response
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class ResultMetaData : ResponseMetaData
    {
        public string Help { get; set; }

        public string Raw { get; set; }

        public MetaData Results { get; set; }
    }
}
