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
            HttpContent content = new StringContent("");
            MultipartFormDataContent formdata = new MultipartFormDataContent(boundary);
            formdata.Headers.Remove("Content-Type");
            formdata.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);
            formdata.Add(new StringContent(fileCreateRequest.FileName), "fileName");
            if (fileCreateRequest.file.GetType().Name == "Byte[]")
            {
                formdata.Add(new StringContent(GetJsonBody.GetBase64(fileCreateRequest.file)), "file");
            }
            else
            {
                formdata.Add(new StringContent(fileCreateRequest.file.ToString()), "file");
            }

            if (fileCreateRequest.UseUniqueFileName)
            {
                formdata.Add(new StringContent("true"), "useUniqueFileName");
            }
            else
            {
                formdata.Add(new StringContent("false"), "useUniqueFileName");
            }

            if (fileCreateRequest.Tags != null)
            {
                formdata.Add(new StringContent(Utils.ListToString(fileCreateRequest.Tags)), "tags");
            }

            if (!string.IsNullOrEmpty(fileCreateRequest.Folder))
            {
                formdata.Add(new StringContent(fileCreateRequest.Folder), "folder");
            }

            if (fileCreateRequest.IsPrivateFileValue)
            {
                formdata.Add(new StringContent("true"), "isPrivateFile");
            }

            if (!string.IsNullOrEmpty(fileCreateRequest.CustomCoordinates))
            {
                formdata.Add(new StringContent(fileCreateRequest.CustomCoordinates), "customCoordinates");
            }

            if (fileCreateRequest.ResponseFields != null)
            {
                formdata.Add(new StringContent(Utils.ListToString(fileCreateRequest.ResponseFields)), "responseFields");
            }

            if (fileCreateRequest.OverwriteFile)
            {
                formdata.Add(new StringContent("true"), "overwriteFile");
            }

            if (fileCreateRequest.OverwriteAITags)
            {
                formdata.Add(new StringContent("true"), "overwriteAITags");
            }

            if (fileCreateRequest.OverwriteTags)
            {
                formdata.Add(new StringContent("true"), "overwriteTags");
            }

            if (fileCreateRequest.OverwriteCustomMetadata)
            {
                formdata.Add(new StringContent("false"), "overwriteCustomMetadata");
            }

            if (fileCreateRequest.Extensions != null)
            {
                var myContent = JsonConvert.SerializeObject(
                    fileCreateRequest.Extensions,
                    new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    });
                formdata.Add(new StringContent(myContent), "extensions");
            }

            if (fileCreateRequest.WebhookUrl != null)
            {
                formdata.Add(new StringContent(fileCreateRequest.WebhookUrl), "webhookUrl");
            }

            if (fileCreateRequest.CustomMetadata != null)
            {
                string jsonResult = JsonConvert.SerializeObject(fileCreateRequest.CustomMetadata);
                formdata.Add(new StringContent(jsonResult), "customMetadata");
            }

            return formdata;
        }

        public static MultipartFormDataContent BuildUpdateFile(FileUpdateRequest fileCreateRequest)
        {
            MultipartFormDataContent formdata = new MultipartFormDataContent(boundary);
            formdata.Headers.Remove("Content-Type");
            formdata.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);

            if (fileCreateRequest.Tags != null)
            {
                formdata.Add(new StringContent(Utils.ListToString(fileCreateRequest.Tags)), "tags");
            }

            if (fileCreateRequest.RemoveAITags != null)
            {
                formdata.Add(new StringContent(Utils.ListToString(fileCreateRequest.RemoveAITags)), "removeAITags");
            }

            if (!string.IsNullOrEmpty(fileCreateRequest.CustomCoordinates))
            {
                formdata.Add(new StringContent(fileCreateRequest.CustomCoordinates), "customCoordinates");
            }

            if (fileCreateRequest.Extensions != null)
            {
                var myContent = JsonConvert.SerializeObject(
                    fileCreateRequest.Extensions,
                    new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    });
                formdata.Add(new StringContent(myContent), "extensions");
            }

            if (fileCreateRequest.WebhookUrl != null)
            {
                formdata.Add(new StringContent(fileCreateRequest.WebhookUrl), "webhookUrl");
            }

            if (fileCreateRequest.CustomMetadata != null)
            {
                string jSONresult = JsonConvert.SerializeObject(fileCreateRequest.CustomMetadata);
                formdata.Add(new StringContent(jSONresult), "customMetadata");
            }

            return formdata;
        }
    }
}
