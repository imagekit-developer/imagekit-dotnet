using Imagekit.Models;
using Imagekit.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Imagekit.Helper
{
    public static class MultipartFormDataModel
    {
        public static MultipartFormDataContent build(FileCreateRequest fileCreateRequest)
        {
            MultipartFormDataContent formdata = new MultipartFormDataContent();
            formdata.Add(new StringContent(fileCreateRequest.FileName), "fileName");
            if (!string.IsNullOrEmpty(fileCreateRequest.Base64))
            {
                formdata.Add(new StringContent(fileCreateRequest.Base64), "file");
            }
            else if (fileCreateRequest.Bytes != null)
            {
                formdata.Add(new StringContent(GetJsonBody.GetBase64(fileCreateRequest.Bytes)), "file");
            }
            else if (!string.IsNullOrEmpty(fileCreateRequest.Url.ToString()))
            {
                var webClient = new WebClient();
                byte[] imageBytes = webClient.DownloadData(fileCreateRequest.Url.ToString());
                formdata.Add(new StringContent(GetJsonBody.GetBase64(imageBytes)), "file");
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
                formdata.Add(new StringContent(Utils.listToString(fileCreateRequest.Tags)), "tags");
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
                formdata.Add(new StringContent(Utils.listToString(fileCreateRequest.ResponseFields)), "responseFields");
            }

            if (fileCreateRequest.OverwriteFile)
            {
                formdata.Add(new StringContent("true"), "overwriteFile");
            }

            if (fileCreateRequest.OverwriteAiTags)
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
                var myContent = JsonConvert.SerializeObject(fileCreateRequest.Extensions,
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


        public static MultipartFormDataContent buildUpdateFile(FileUpdateRequest fileCreateRequest)
        {
            MultipartFormDataContent formdata = new MultipartFormDataContent();
           
            if (fileCreateRequest.Tags != null)
            {
                formdata.Add(new StringContent(Utils.listToString(fileCreateRequest.Tags)), "tags");
            }
            if (fileCreateRequest.RemoveAITags != null)
            {
                formdata.Add(new StringContent(Utils.listToString(fileCreateRequest.RemoveAITags)), "removeAITags");
            }
            if (!string.IsNullOrEmpty(fileCreateRequest.CustomCoordinates))
            {
                formdata.Add(new StringContent(fileCreateRequest.CustomCoordinates), "customCoordinates");
            }

            if (fileCreateRequest.Extensions != null)
            {
                var myContent = JsonConvert.SerializeObject(fileCreateRequest.Extensions,
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
