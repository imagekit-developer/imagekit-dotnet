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
    }
}
