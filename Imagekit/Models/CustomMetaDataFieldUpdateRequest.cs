// <copyright file="CustomMetaDataFieldUpdateRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class CustomMetaDataFieldUpdateRequest
    {
        public string Id { get; set; }

        public CustomMetaDataFieldSchemaObject Schema { get; set; }
    }
}