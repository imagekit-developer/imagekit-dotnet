// <copyright file="CustomMetaDataFieldSchemaObject.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Imagekit.Models
{
    public class CustomMetaDataFieldSchemaObject
    {
        public string type { get; set; }
        public string[] selectOptions { get; set; }
        public object defaultValue { get; set; }
        private bool _isValueRequired;
        [DefaultValue(false)]
        public bool isValueRequired
        {
            get
            {
                return _isValueRequired;
            }
            set
            {
                _isValueRequired = value;
            }
        }
        
        public object minValue { get; set; }
        public object maxValue { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }

        public enum CustomMetaDataTypeEnum
        {
            Text,
            Textarea,
            Number,
            Date,
            SingleSelect,
            MultiSelect,
        }

       
    }
}