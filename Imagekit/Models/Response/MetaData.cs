// <copyright file="MetaData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models.Response
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class MetaData
    {
        public float Height { get; set; }

        public float Width { get; set; }

        public float Size { get; set; }

        public string Format { get; set; }

        public bool HasColorProfile { get; set; }

        public float Quality { get; set; }

        public float Density { get; set; }

        public bool HasTransparency { get; set; }

        public string PHash { get; set; }
    }
}
