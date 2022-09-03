// <copyright file="CustomMetaDataFieldSchemaObject.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class CustomMetaDataFieldSchemaObject
    {
        public string type { get; set; }
        public string[] selectOptions { get; set; }
        public object defaultValue { get; set; }
        public bool isValueRequired { get; set; }
        public object minValue { get; set; }
        public object maxValue { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }

        public enum CustomMetaDataTypeEnum
        {
            Text,
            Textarea,
            Number,
            DateTime,
            SingleSelect,
            MultiSelect,
        }

       
    }
}