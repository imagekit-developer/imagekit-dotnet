namespace Imagekit.Helper
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using global::Imagekit.Constant;
    using global::Imagekit.Models;
    using global::Imagekit.Util;
    using Newtonsoft.Json;

    public static class MultipartFormDataModel
    {
        private static string boundary = UrlHandler.GetBoundaryString;

        public static MultipartFormDataContent Build(FileCreateRequest fileCreateRequest)
        {
            HttpContent content = new StringContent(string.Empty);
            MultipartFormDataContent formdata = new MultipartFormDataContent(boundary);
            formdata.Headers.Remove("Content-Type");
            formdata.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);
            formdata.Add(new StringContent(fileCreateRequest.fileName), "fileName");
            if (fileCreateRequest.file.GetType().Name == "Byte[]")
            {
                formdata.Add(new StringContent(GetJsonBody.GetBase64(fileCreateRequest.file)), "file");
            }
            else
            {
                formdata.Add(new StringContent(fileCreateRequest.file.ToString()), "file");
            }

            if (fileCreateRequest.useUniqueFileName)
            {
                formdata.Add(new StringContent("true"), "useUniqueFileName");
            }
            else
            {
                formdata.Add(new StringContent("false"), "useUniqueFileName");
            }

            if (fileCreateRequest.tags != null)
            {
                formdata.Add(new StringContent(Utils.ListToString(fileCreateRequest.tags)), "tags");
            }

            if (!string.IsNullOrEmpty(fileCreateRequest.folder))
            {
                formdata.Add(new StringContent(fileCreateRequest.folder), "folder");
            }

            if (fileCreateRequest.isPrivateFile)
            {
                formdata.Add(new StringContent("true"), "isPrivateFile");
            }

            if (!string.IsNullOrEmpty(fileCreateRequest.customCoordinates))
            {
                formdata.Add(new StringContent(fileCreateRequest.customCoordinates), "customCoordinates");
            }

            if (fileCreateRequest.responseFields != null)
            {
                formdata.Add(new StringContent(Utils.ListToString(fileCreateRequest.responseFields)), "responseFields");
            }

            if (fileCreateRequest.overwriteFile)
            {
                formdata.Add(new StringContent("true"), "overwriteFile");
            }

            if (fileCreateRequest.overwriteAITags)
            {
                formdata.Add(new StringContent("true"), "overwriteAITags");
            }

            if (fileCreateRequest.overwriteTags)
            {
                formdata.Add(new StringContent("true"), "overwriteTags");
            }

            if (fileCreateRequest.overwriteCustomMetadata)
            {
                formdata.Add(new StringContent("false"), "overwriteCustomMetadata");
            }

            if (fileCreateRequest.extensions != null)
            {
                var myContent = JsonConvert.SerializeObject(
                    fileCreateRequest.extensions,
                    new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    });
                formdata.Add(new StringContent(myContent), "extensions");
            }

            if (fileCreateRequest.webhookUrl != null)
            {
                formdata.Add(new StringContent(fileCreateRequest.webhookUrl), "webhookUrl");
            }

            if (fileCreateRequest.customMetadata != null)
            {
                string jsonResult = JsonConvert.SerializeObject(fileCreateRequest.customMetadata);
                formdata.Add(new StringContent(jsonResult), "customMetadata");
            }

            if (fileCreateRequest.transformation != null)
            {
                string jsonResult = JsonConvert.SerializeObject(fileCreateRequest.transformation);
                formdata.Add(new StringContent(jsonResult), "transformation");
            }

            return formdata;
        }

        public static MultipartFormDataContent BuildUpdateFile(FileUpdateRequest fileCreateRequest)
        {
            MultipartFormDataContent formdata = new MultipartFormDataContent(boundary);
            formdata.Headers.Remove("Content-Type");
            formdata.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);

            if (fileCreateRequest.tags != null)
            {
                formdata.Add(new StringContent(Utils.ListToString(fileCreateRequest.tags)), "tags");
            }

            if (fileCreateRequest.removeAITags != null)
            {
                formdata.Add(new StringContent(Utils.ListToString(fileCreateRequest.removeAITags)), "removeAITags");
            }

            if (!string.IsNullOrEmpty(fileCreateRequest.customCoordinates))
            {
                formdata.Add(new StringContent(fileCreateRequest.customCoordinates), "customCoordinates");
            }

            if (fileCreateRequest.extensions != null)
            {
                var myContent = JsonConvert.SerializeObject(
                    fileCreateRequest.extensions,
                    new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    });
                formdata.Add(new StringContent(myContent), "extensions");
            }

            if (fileCreateRequest.webhookUrl != null)
            {
                formdata.Add(new StringContent(fileCreateRequest.webhookUrl), "webhookUrl");
            }

            if (fileCreateRequest.customMetadata != null)
            {
                string jSONresult = JsonConvert.SerializeObject(fileCreateRequest.customMetadata);
                formdata.Add(new StringContent(jSONresult), "customMetadata");
            }

            return formdata;
        }
    }
}
