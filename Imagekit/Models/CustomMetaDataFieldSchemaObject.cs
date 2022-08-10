// <copyright file="CustomMetaDataFieldSchemaObject.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class CustomMetaDataFieldSchemaObject
    {
        private CustomMetaDataTypeEnum type;
        private object selectOptions;
        private object defaultValue;
        private bool isValueRequired;
        private int minValue;
        private int maxValue;
        private int minLength;
        private int maxLength;

        public enum CustomMetaDataTypeEnum
        {
            Text,
            Textarea,
            Number,
            DateTime,
            SingleSelect,
            MultiSelect,
        }

        public CustomMetaDataTypeEnum Type { set => this.type = value; }

        public object SelectOptions { set => this.selectOptions = value; }

        public object DefaultValue { set => this.defaultValue = value; }

        public bool IsValueRequired { set => this.isValueRequired = value; }

        public int MinValue { get => this.minValue; set => this.minValue = value; }

        public int MaxValue { get => this.maxValue; set => this.maxValue = value; }

        public int MinLength { set => this.minLength = value; }

        public int MaxLength { set => this.maxLength = value; }
    }
}