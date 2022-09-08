// <copyright file="GetJsonBody.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using global::Imagekit.Models;

    [ExcludeFromCodeCoverage]
    public static class GetJsonBody
    {
        public static string CreateCustomMetaDataBody(CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest)
        {
            string body = string.Empty;
            if (customMetaDataFieldCreateRequest.schema.isValueRequired)
            {
                if (customMetaDataFieldCreateRequest.schema.type == "Text")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""minLength"": " +
                           customMetaDataFieldCreateRequest.schema.minLength.ToString() + "," + "\n" +
                           @"        ""maxLength"": " +
                           customMetaDataFieldCreateRequest.schema.maxLength.ToString() + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "," + "\n" +
                           @"        ""defaultValue"": " +
                           AddDoubleQuotesObject(customMetaDataFieldCreateRequest.schema.defaultValue) + "\n" +
                           @"    }" + "\n" +
                           @"}";
                }

                if (customMetaDataFieldCreateRequest.schema.type == "Textarea")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""minLength"": " +
                           customMetaDataFieldCreateRequest.schema.minLength.ToString() + "," + "\n" +
                           @"        ""maxLength"": " +
                           customMetaDataFieldCreateRequest.schema.maxLength.ToString() + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "," + "\n" +
                           @"        ""defaultValue"": " +
                           AddDoubleQuotesObject(customMetaDataFieldCreateRequest.schema.defaultValue) + "\n" +
                           @"    }" + "\n" +
                           @"}";
                }

                if (customMetaDataFieldCreateRequest.schema.type == "Number")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""minValue"": " +
                           customMetaDataFieldCreateRequest.schema.minValue.ToString() + "," + "\n" +
                           @"        ""maxValue"": " +
                           customMetaDataFieldCreateRequest.schema.maxValue.ToString() + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "," + "\n" +
                           @"        ""defaultValue"": " +
                           customMetaDataFieldCreateRequest.schema.defaultValue + "\n" +

                           @"    }" + "\n" +
                           @"}";
                }

                if (customMetaDataFieldCreateRequest.schema.type == "Date")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""minValue"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.minValue.ToString()) + "," + "\n" +
                           @"        ""maxValue"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.maxValue.ToString()) + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "," + "\n" +
                           @"        ""defaultValue"": " +
                           AddDoubleQuotesObject(customMetaDataFieldCreateRequest.schema.defaultValue) + "\n" +
                           @"    }" + "\n" +
                           @"}";
                }

                if (customMetaDataFieldCreateRequest.schema.type == "SingleSelect")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""selectOptions"": " +
                           AddBigQuotes(customMetaDataFieldCreateRequest.schema.selectOptions) + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "," + "\n" +
                           @"        ""defaultValue"": " +
                           AddDoubleQuotesObject(customMetaDataFieldCreateRequest.schema.defaultValue) + "\n" +

                           @"    }" + "\n" +
                           @"}";
                }

                if (customMetaDataFieldCreateRequest.schema.type == "MultiSelect")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""selectOptions"": " +
                           AddBigQuotes(customMetaDataFieldCreateRequest.schema.selectOptions) + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "," + "\n" +
                           @"        ""defaultValue"": " +
                           customMetaDataFieldCreateRequest.schema.defaultValue + "\n" +

                           @"    }" + "\n" +
                           @"}";
                }
            }
            else
            {
                if (customMetaDataFieldCreateRequest.schema.type == "Text")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""minLength"": " +
                           customMetaDataFieldCreateRequest.schema.minLength.ToString() + "," + "\n" +
                           @"        ""maxLength"": " +
                           customMetaDataFieldCreateRequest.schema.maxLength.ToString() + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "\n" +
                           @"    }" + "\n" +
                           @"}";
                }

                if (customMetaDataFieldCreateRequest.schema.type == "Textarea")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""minLength"": " +
                           customMetaDataFieldCreateRequest.schema.minLength.ToString() + "," + "\n" +
                           @"        ""maxLength"": " +
                           customMetaDataFieldCreateRequest.schema.maxLength.ToString() + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "\n" +

                           @"    }" + "\n" +
                           @"}";
                }

                if (customMetaDataFieldCreateRequest.schema.type == "Number")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""minValue"": " +
                           customMetaDataFieldCreateRequest.schema.minValue.ToString() + "," + "\n" +
                           @"        ""maxValue"": " +
                           customMetaDataFieldCreateRequest.schema.maxValue.ToString() + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "\n" +
                           @"    }" + "\n" +
                           @"}";
                }

                if (customMetaDataFieldCreateRequest.schema.type == "Date")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""minValue"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.minValue.ToString()) + "," + "\n" +
                           @"        ""maxValue"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.maxValue.ToString()) + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "\n" +
                           @"    }" + "\n" +
                           @"}";
                }

                if (customMetaDataFieldCreateRequest.schema.type == "SingleSelect" ||
                    customMetaDataFieldCreateRequest.schema.type == "MultiSelect")
                {
                    body = @"{" + "\n" +
                           @"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.name) + "," + "\n" +
                           @"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.label) + "," + "\n" +
                           @"    ""schema"": {" + "\n" +
                           @"        ""type"": " +
                           AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                           @"        ""selectOptions"": " +
                           AddBigQuotes(customMetaDataFieldCreateRequest.schema.selectOptions) + "," + "\n" +
                           @"        ""isValueRequired"": " +
                           customMetaDataFieldCreateRequest.schema.isValueRequired.ToString().ToLower() + "\n" +
                           @"    }" + "\n" +
                           @"}";
                }
            }

            return body;
        }

        public static string UpdateCustomMetaDataBody(CustomMetaDataFieldUpdateRequest customMetaDataFieldCreateRequest)
        {
            string body = string.Empty;
            if (customMetaDataFieldCreateRequest.schema.type == "Text")
            {
                body = @"{" + "\n" +
                        @"    ""schema"": {" + "\n" +
                       @"        ""type"": " +
                       AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                       @"        ""minLength"": " +
                       customMetaDataFieldCreateRequest.schema.minLength.ToString() + "," + "\n" +
                       @"        ""maxLength"": " +
                       customMetaDataFieldCreateRequest.schema.maxLength.ToString() + "\n" +
                       @"    }" + "\n" +
                       @"}";
            }

            if (customMetaDataFieldCreateRequest.schema.type == "Textarea")
            {
                body = @"{" + "\n" +
                         @"    ""schema"": {" + "\n" +
                       @"        ""type"": " +
                       AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                       @"        ""minLength"": " +
                       customMetaDataFieldCreateRequest.schema.minLength.ToString() + "," + "\n" +
                       @"        ""maxLength"": " +
                       customMetaDataFieldCreateRequest.schema.maxLength.ToString() + "\n" +
                       @"    }" + "\n" +
                       @"}";
            }

            if (customMetaDataFieldCreateRequest.schema.type == "Number")
            {
                body = @"{" + "\n" +
                         @"    ""schema"": {" + "\n" +
                       @"        ""type"": " +
                       AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                       @"        ""minValue"": " +
                       customMetaDataFieldCreateRequest.schema.minValue.ToString() + "," + "\n" +
                       @"        ""maxValue"": " +
                       customMetaDataFieldCreateRequest.schema.maxValue.ToString() + "\n" +
                       @"    }" + "\n" +
                       @"}";
            }

            if (customMetaDataFieldCreateRequest.schema.type == "Date")
            {
                body = @"{" + "\n" +
                         @"    ""schema"": {" + "\n" +
                       @"        ""type"": " +
                       AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                       @"        ""minValue"": " +
                       customMetaDataFieldCreateRequest.schema.minValue.ToString() + "," + "\n" +
                       @"        ""maxValue"": " +
                       customMetaDataFieldCreateRequest.schema.maxValue.ToString() + "\n" +
                       @"    }" + "\n" +
                       @"}";
            }

            if (customMetaDataFieldCreateRequest.schema.type == "SingleSelect")
            {
                body = @"{" + "\n" +
                       @"    ""schema"": {" + "\n" +
                       @"        ""type"": " +
                       AddDoubleQuotes(customMetaDataFieldCreateRequest.schema.type.ToString()) + "," + "\n" +
                       @"        ""selectOptions"": " + AddBigQuotes(customMetaDataFieldCreateRequest.schema.selectOptions) + "\n" +

                             @"    }" + "\n" +
                       @"}";
            }

            return body;
        }

        public static string DeleteFolderBody(DeleteFolderRequest deleteFolderRequest)
        {
            var body = @"{" + "\n" +
 @"	""folderPath"" : " + AddDoubleQuotes(deleteFolderRequest.folderPath) + "\n" +
 @"}";

            return body;
        }

        private static string AddDoubleQuotes(this string value)
        {
            return "\"" + value + "\"";
        }

        private static string AddDoubleQuotesObject(this object value)
        {
            return "\"" + value + "\"";
        }

        private static string AddBigQuotes(this string[] value)
        {
            var joinedNames = "\"" + string.Join("\", \"", value) + "\"";

            return "[" + joinedNames + "]";
        }

        public static string GetBase64(object imageArray)
        {
            string base64ImageRepresentation = Convert.ToBase64String((byte[])imageArray);
            return base64ImageRepresentation;
        }

        public static string GetBase64Uri(string imagePath)
        {
            var uri = new System.Uri(imagePath);
            byte[] imageArray = System.IO.File.ReadAllBytes(uri.AbsolutePath);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }

        public static string GetFileRequestBody(GetFileListRequest getFileListRequest)
        {
            QueryMaker queryMaker = new QueryMaker();
            Dictionary<string, string> options = new Dictionary<string, string>();
            if (getFileListRequest.Type != null)
            {
                options.Add("type", getFileListRequest.Type);
            }

            if (getFileListRequest.Sort != null)
            {
                options.Add("sort", getFileListRequest.Sort);
            }

            if (getFileListRequest.Path != null)
            {
                options.Add("path", getFileListRequest.Path);
            }

            if (getFileListRequest.SearchQuery != null)
            {
                options.Add("searchQuery", getFileListRequest.SearchQuery);
            }

            if (getFileListRequest.FileType != null)
            {
                options.Add("fileType", getFileListRequest.FileType);
            }

            if (getFileListRequest.Limit > 0)
            {
                options.Add("limit", getFileListRequest.Limit.ToString());
            }

            if (getFileListRequest.Skip > 0)
            {
                options.Add("skip", getFileListRequest.Skip.ToString());
            }

            if (getFileListRequest.Tags != null)
            {
                options.Add("tags", string.Join(",", getFileListRequest.Tags));
            }

            foreach (KeyValuePair<string, string> entry in options)
            {
                queryMaker.Add(string.Format("{0}={1}", entry.Key, entry.Value));
            }

            return queryMaker.Get();
        }
    }

    public class QueryMaker
    {
        private string query;

        public void Add(string q)
        {
            if (this.query != null)
            {
                this.query += "&";
            }
            else
            {
                this.query = string.Empty;
            }

            this.query += q;
        }

        public string Get()
        {
            return this.query;
        }
    }
}
