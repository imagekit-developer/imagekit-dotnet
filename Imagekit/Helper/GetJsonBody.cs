// <copyright file="GetJsonBody.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Imagekit.Helper
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using global::Imagekit.Models;

    [ExcludeFromCodeCoverage]
    public static class GetJsonBody
    {
        public static string CreateCustomMetaDataBody(CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest)
        {
            var body = @"{" + "\n" +
@"    ""name"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.Name) + "," + "\n" +
@"    ""label"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.Label) + "," + "\n" +
@"    ""schema"": {" + "\n" +
@"        ""type"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.Schema.GetType().ToString()) + "," + "\n" +
@"        ""minValue"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.Schema.MinValue.ToString()) + "," + "\n" +
@"        ""maxValue"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.Schema.MaxValue.ToString()) + "\n" +
@"    }" + "\n" +
@"}";

            return body;
        }

        public static string UpdateCustomMetaDataBody(CustomMetaDataFieldUpdateRequest customMetaDataFieldCreateRequest)
        {
            var body = @"{" + "\n" +
@"    ""schema"": {" + "\n" +
@"        ""type"": " + AddDoubleQuotes(customMetaDataFieldCreateRequest.Schema.GetType().ToString()) + "," + "\n" +
@"        ""minValue"": " + customMetaDataFieldCreateRequest.Schema.MinValue + "," + "\n" +
@"        ""maxValue"": " + customMetaDataFieldCreateRequest.Schema.MaxValue + "\n" +
@"    }" + "\n" +
@"}";

            return body;
        }

        public static string DeleteFolderBody(DeleteFolderRequest deleteFolderRequest)
        {
            var body = @"{" + "\n" +
 @"	""folderPath"" : " + AddDoubleQuotes(deleteFolderRequest.FolderPath) + "\n" +
 @"}";

            return body;
        }

        private static string AddDoubleQuotes(this string value)
        {
            return "\"" + value + "\"";
        }

        public static string GetBase64(byte[] imageArray)
        {
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
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
            if (getFileListRequest.type != null)
            {
                options.Add("type", getFileListRequest.type);
            }
            if (getFileListRequest.sort != null)
            {
                options.Add("sort", getFileListRequest.sort);
            }
            if (getFileListRequest.path != null)
            {
                options.Add("path", getFileListRequest.path);
            }
            if (getFileListRequest.searchQuery != null)
            {
                options.Add("searchQuery", getFileListRequest.searchQuery);
            }
            if (getFileListRequest.fileType != null)
            {
                options.Add("fileType", getFileListRequest.fileType);
            }
            if (getFileListRequest.limit > 0)
            {
                options.Add("limit", getFileListRequest.limit.ToString());
            }
            if (getFileListRequest.skip > 0)
            {
                options.Add("skip", getFileListRequest.skip.ToString());
            }
            if (getFileListRequest.tags != null)
            {
                options.Add("tags", string.Join(",", getFileListRequest.tags));
            }

            foreach (KeyValuePair<string, string> entry in options)
            {
                queryMaker.Add(string.Format("{0}={1}", entry.Key, entry.Value));
            }

            return queryMaker.get();
        }
    }


    public class QueryMaker
    {
        private string query;

        public void Add(string q)
        {
            if (null != query)
            {
                query += "&";
            }
            else
            {
                query = "";
            }
            query += q;
        }

        public string get()
        {
            return query;
        }

    }
}
