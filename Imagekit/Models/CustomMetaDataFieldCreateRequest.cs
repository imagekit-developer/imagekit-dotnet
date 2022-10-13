// <copyright file="CustomMetaDataFieldCreateRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class CustomMetaDataFieldCreateRequest
    {
        public string name { get; set; }

        public string label { get; set; }

        public CustomMetaDataFieldSchemaObject schema { get; set; }
    }

    public class CustomMetaDataFieldUploadRequest
    {
        public string name { get; set; }

        public CustomMetaDataFieldSchemaObject schema { get; set; }
    }
}