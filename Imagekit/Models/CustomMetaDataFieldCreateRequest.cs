// <copyright file="CustomMetaDataFieldCreateRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class CustomMetaDataFieldCreateRequest
    {
        public string Name { get; set; }

        public string Label { get; set; }

        public CustomMetaDataFieldSchemaObject Schema { get; set; }
    }
}