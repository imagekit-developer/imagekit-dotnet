// <copyright file="RestClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using global::Imagekit.Constant;
    using global::Imagekit.Helper;
    using global::Imagekit.Models;
    using global::Imagekit.Util;

    using Newtonsoft.Json;

    public class RestClient
    {
        private readonly string apiBaseUrl = string.Empty;
        private readonly string uploadBaseUrl = string.Empty;
        private readonly HttpClient client;

        public RestClient(string privateKey, string apiBaseUrl, HttpClient httpClient)
        {
            if (string.IsNullOrEmpty(privateKey))
            {
                throw new Exception(ErrorMessages.InvalidKey);
            }

            if (string.IsNullOrEmpty(apiBaseUrl))
            {
                throw new Exception(ErrorMessages.InvalidApiUrl);
            }

            this.apiBaseUrl = apiBaseUrl;
            this.uploadBaseUrl = apiBaseUrl;
            this.client = httpClient;
            this.client.DefaultRequestHeaders.Add("Authorization", "Basic " + Utils.EncodeTo64(privateKey));
        }

        public ResponseMetaData GetFileListRequest()
        {
            try
            {
                string url = string.Format(this.apiBaseUrl + UrlHandler.GetFileRequest);
                HttpResponseMessage response = this.client.GetAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> GetFileListRequestAsync()
        {
            try
            {
                string url = string.Format(this.apiBaseUrl + UrlHandler.GetFileRequest);

                HttpResponseMessage response = await this.client.GetAsync(url);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData PurgeCache(string path)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(path))
                {
                    throw new Exception(ErrorMessages.InvalidUrlValue);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetPurge);

                object data = new
                {
                    url = path,
                };
                var content = JsonConvert.SerializeObject(data);
                var stringContent =
                    new StringContent(content, Encoding.UTF8,
                        "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

                HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> PurgeCacheAsync(string path)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(path))
                {
                    throw new Exception(ErrorMessages.InvalidUrlValue);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetPurge);
                object data = new
                {
                    url = path,
                };
                var content = JsonConvert.SerializeObject(data);
                var stringContent =
                    new StringContent(content, Encoding.UTF8,
                        "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

                HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData PurgeStatus(string purgeRequestId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(purgeRequestId))
                {
                    throw new Exception(ErrorMessages.InvalidPurgeUrl);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetPurgeStatus, purgeRequestId);

                HttpResponseMessage response = this.client.GetAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> PurgeStatusAsync(string purgeRequestId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(purgeRequestId))
                {
                    throw new Exception(ErrorMessages.InvalidPurgeUrl);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetPurgeStatus, purgeRequestId);

                HttpResponseMessage response = await this.client.GetAsync(url);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData GetFileDetail(string fileId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(fileId))
                {
                    throw new Exception(ErrorMessages.FileIdMissing);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetFileDetails, fileId);

                HttpResponseMessage response = this.client.GetAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<ResponseMetaData> GetFileDetailAsync(string fileId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(fileId))
                {
                    throw new Exception(ErrorMessages.FileIdMissing);
                }

                Dictionary<string, string> headers = Utils.GetHeaders();
                string url = string.Format(this.apiBaseUrl + UrlHandler.GetFileDetails, fileId);

                HttpResponseMessage response = await this.client.GetAsync(url);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData Upload(FileCreateRequest fileCreateRequest)
        {
            try
            {
                string validate = ValidateParamater.IsValidateUpload(fileCreateRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = this.uploadBaseUrl + UrlHandler.UploadFile;
                Dictionary<string, string> headers = Utils.GetHeaders();
                var formdata = new MultipartFormDataContent
                {
                    { new StringContent(fileCreateRequest.FileName), "fileName" },
                };
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
                    formdata.Add(new StringContent(GetJsonBody.GetBase64Uri(fileCreateRequest.Url.ToString())), "file");
                }

                HttpResponseMessage response = this.client.PostAsync(url, formdata).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileCreateRequest"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<ResponseMetaData> UploadAsync(FileCreateRequest fileCreateRequest)
        {
            try
            {
                string validate = ValidateParamater.IsValidateUpload(fileCreateRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = this.uploadBaseUrl + UrlHandler.UploadFile;
                Dictionary<string, string> headers = Utils.GetHeaders();
                var formdata = new MultipartFormDataContent
                {
                    { new StringContent(fileCreateRequest.FileName), "fileName" },
                };

                if (!string.IsNullOrEmpty(fileCreateRequest.Base64))
                {
                    formdata.Add(new StringContent(fileCreateRequest.Base64), "file");
                }
                else if (fileCreateRequest.Bytes != null)
                {
                    ByteArrayContent byteContent = new ByteArrayContent(fileCreateRequest.Bytes);
                    formdata.Add(byteContent, "file");
                }
                else if (fileCreateRequest.Url != null)
                {
                    formdata.Add(new StringContent(fileCreateRequest.Url.ToString()), "file");
                }

                HttpResponseMessage response = await this.client.PostAsync(url, formdata);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData DeleteFile(string fileId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(fileId))
                {
                    throw new Exception(ErrorMessages.FileIdMissing);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.DeleteFile, fileId);

                HttpResponseMessage response = this.client.DeleteAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<ResponseMetaData> DeleteFileAsync(string fileId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(fileId))
                {
                    throw new Exception(ErrorMessages.FileIdMissing);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.DeleteFile, fileId);

                HttpResponseMessage response = await this.client.DeleteAsync(url);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData BulkDeleteFiles(List<string> fileIds)
        {
            try
            {
                if (!ValidateParamater.IsListCheck(fileIds))
                {
                    throw new Exception(ErrorMessages.ListFilesInputMissing);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.BulkDelete);

                object data = new
                {
                    fileIds = fileIds,
                };
                var content = JsonConvert.SerializeObject(data);
                var stringContent =
                    new StringContent(content, Encoding.UTF8,
                        "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

                HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileIds"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<ResponseMetaData> BulkDeleteFilesAsync(List<string> fileIds)
        {
            try
            {
                if (!ValidateParamater.IsListCheck(fileIds))
                {
                    throw new Exception(ErrorMessages.ListFilesInputMissing);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.BulkDelete);

                object data = new
                {
                    fileIds = fileIds,
                };
                var content = JsonConvert.SerializeObject(data);
                var stringContent =
                    new StringContent(content, Encoding.UTF8,
                        mediaType: "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

                HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData GetFileMetaData(string fileId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(fileId))
                {
                    throw new Exception(ErrorMessages.FileIdMissing);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetMetaData, fileId);

                HttpResponseMessage response = this.client.GetAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> GetFileMetaDataAsync(string fileId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(fileId))
                {
                    throw new Exception(ErrorMessages.FileIdMissing);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetMetaData, fileId);

                HttpResponseMessage response = await this.client.GetAsync(url);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData GetRemoteFileMetaData(string url)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(url))
                {
                    throw new Exception(ErrorMessages.InvalidUrlValue);
                }

                string apIurl = string.Format(this.apiBaseUrl + UrlHandler.GetRemoteData, url);

                HttpResponseMessage response = this.client.GetAsync(apIurl).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> GetRemoteFileMetaDataAsync(string url)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(url))
                {
                    throw new Exception(ErrorMessages.InvalidUrlValue);
                }

                string apIurl = string.Format(this.apiBaseUrl + UrlHandler.GetRemoteData, url);

                HttpResponseMessage response = await this.client.GetAsync(apIurl);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData ManageTags(TagsRequest tagsRequest, string action)
        {
            try
            {
                var validate = ValidateParamater.IsValidateTagRequest(tagsRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;

                if (action == "addTags")
                {
                    url = this.uploadBaseUrl + UrlHandler.AddTags;
                }
                else if (action == "removeTags")
                {
                    url = this.uploadBaseUrl + UrlHandler.RemoveTags;
                }

                var content = JsonConvert.SerializeObject(tagsRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> ManageTagsAsync(TagsRequest tagsRequest, string action)
        {
            try
            {
                var validate = ValidateParamater.IsValidateTagRequest(tagsRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;

                if (action == "addTags")
                {
                    url = this.uploadBaseUrl + UrlHandler.AddTags;
                }
                else if (action == "removeTags")
                {
                    url = this.uploadBaseUrl + UrlHandler.RemoveTags;
                }

                var content = JsonConvert.SerializeObject(tagsRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData RemoveAiTags(AiTagsRequest aiTagsRequest)
        {
            try
            {
                var validate = ValidateParamater.IsValidateAiTagRequest(aiTagsRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                // removeAITags
                string url = string.Empty;

                url = this.uploadBaseUrl + UrlHandler.RemoveAiTags;

                var content = JsonConvert.SerializeObject(aiTagsRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> RemoveAiTagsAsync(AiTagsRequest aiTagsRequest)
        {
            try
            {
                var validate = ValidateParamater.IsValidateAiTagRequest(aiTagsRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                // removeAITags
                string url = string.Empty;

                url = this.uploadBaseUrl + UrlHandler.RemoveAiTags;

                var content = JsonConvert.SerializeObject(aiTagsRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData GetCustomMetaDataFields(bool includeDeleted)
        {
            try
            {
                string url = string.Format(this.apiBaseUrl + UrlHandler.CustomMetadataFields, includeDeleted);

                HttpResponseMessage response = this.client.GetAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> GetCustomMetaDataFieldsAsync(bool includeDeleted)
        {
            try
            {
                string url = string.Format(this.apiBaseUrl + UrlHandler.CustomMetadataFields, includeDeleted);

                HttpResponseMessage response = await this.client.GetAsync(url);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData CreateCustomMetaDataFields(
                 CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest)
        {
            try
            {
                var validate =
                    ValidateParamater.IsValidateCustomMetaDataFieldCreateRequest(customMetaDataFieldCreateRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;
                url = this.apiBaseUrl + UrlHandler.CreareCustomMetaDataFields;

                string body = GetJsonBody.CreateCustomMetaDataBody(customMetaDataFieldCreateRequest);
                var stringContent = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> CreateCustomMetaDataFieldsAsync(
              CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest)
        {
            try
            {
                var validate =
                    ValidateParamater.IsValidateCustomMetaDataFieldCreateRequest(customMetaDataFieldCreateRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;
                url = this.apiBaseUrl + UrlHandler.CreareCustomMetaDataFields;

                string body = GetJsonBody.CreateCustomMetaDataBody(customMetaDataFieldCreateRequest);
                var stringContent = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData DeleteCustomMetaDataField(string id)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(id))
                {
                    throw new Exception(ErrorMessages.InvalidFileidsValue);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.DeleteCustomMetaDataFields, id);

                HttpResponseMessage response = this.client.DeleteAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> DeleteCustomMetaDataFieldAsync(string id)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(id))
                {
                    throw new Exception(ErrorMessages.InvalidFileidsValue);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.DeleteCustomMetaDataFields, id);

                HttpResponseMessage response = await this.client.DeleteAsync(url);
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData UpdateCustomMetaDataFields(
            CustomMetaDataFieldUpdateRequest customMetaDataFieldUpdateRequest)
        {
            try
            {
                var validate =
                    ValidateParamater.IsValidateCustomMetaDataFieldUpdateRequest(customMetaDataFieldUpdateRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;
                url = string.Format(
                    this.apiBaseUrl + UrlHandler.UpdateCustomMetadataFields,
                    customMetaDataFieldUpdateRequest.Id);
                string body = GetJsonBody.UpdateCustomMetaDataBody(customMetaDataFieldUpdateRequest);

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(body, Encoding.UTF8, "application/json"),
                };
                HttpResponseMessage response = this.client.SendAsync(request).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res, null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> UpdateCustomMetaDataFieldsAsync(
         CustomMetaDataFieldUpdateRequest customMetaDataFieldUpdateRequest)
        {
            try
            {
                var validate =
                    ValidateParamater.IsValidateCustomMetaDataFieldUpdateRequest(customMetaDataFieldUpdateRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;
                url = string.Format(
                    this.apiBaseUrl + UrlHandler.UpdateCustomMetadataFields,
                    customMetaDataFieldUpdateRequest.Id);
                string body = GetJsonBody.UpdateCustomMetaDataBody(customMetaDataFieldUpdateRequest);

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(body, Encoding.UTF8, "application/json"),
                };

                HttpResponseMessage response = await this.client.SendAsync(request);
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData DeleteFileVersion(DeleteFileVersionRequest deleteFileVersionRequest)
        {
            try
            {
                var validate = ValidateParamater.IsValidateDeleteFileVersionRequest(deleteFileVersionRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.DeleteVesrion, deleteFileVersionRequest.FileId,
                    deleteFileVersionRequest.VersionId);

                HttpResponseMessage response = this.client.DeleteAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> DeleteFileVersionAsync(DeleteFileVersionRequest deleteFileVersionRequest)
        {
            try
            {
                var validate = ValidateParamater.IsValidateDeleteFileVersionRequest(deleteFileVersionRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.DeleteVesrion, deleteFileVersionRequest.FileId,
                    deleteFileVersionRequest.VersionId);

                HttpResponseMessage response = await this.client.DeleteAsync(url);
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData CopyFile(CopyFileRequest copyFileRequest)
        {
            try
            {
                string validate = ValidateParamater.IsValidateCopyRequest(copyFileRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;
                url = string.Format(this.apiBaseUrl + UrlHandler.CopyFile);
                var content = JsonConvert.SerializeObject(copyFileRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> CopyFileAsync(CopyFileRequest copyFileRequest)
        {
            try
            {
                string validate = ValidateParamater.IsValidateCopyRequest(copyFileRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;
                url = string.Format(this.apiBaseUrl + UrlHandler.CopyFile);
                var content = JsonConvert.SerializeObject(copyFileRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData MoveFile(MoveFileRequest moveFileRequest)
        {
            try
            {
                string validate = ValidateParamater.IsValidateMoveRequest(moveFileRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;
                url = string.Format(this.apiBaseUrl + UrlHandler.MoveFile);
                var content = JsonConvert.SerializeObject(moveFileRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> MoveFileAsync(MoveFileRequest moveFileRequest)
        {
            try
            {
                string validate = ValidateParamater.IsValidateMoveRequest(moveFileRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;
                url = string.Format(this.apiBaseUrl + UrlHandler.MoveFile);
                var content = JsonConvert.SerializeObject(moveFileRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData RenameFile(RenameFileRequest renameFileRequest)
        {
            try
            {
                var validate = ValidateParamater.IsValidateRenameRequest(renameFileRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;
                url = string.Format(this.apiBaseUrl + UrlHandler.RenameFile);
                var content = JsonConvert.SerializeObject(renameFileRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = this.client.PutAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> RenameFileAsync(RenameFileRequest renameFileRequest)
        {
            try
            {
                var validate = ValidateParamater.IsValidateRenameRequest(renameFileRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Empty;
                url = string.Format(this.apiBaseUrl + UrlHandler.RenameFile);
                var content = JsonConvert.SerializeObject(renameFileRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PutAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData CreateFolder(CreateFolderRequest createFolderRequest)
        {
            try
            {
                var isValidateFolder = ValidateParamater.IsValidateFolder(createFolderRequest);
                if (!string.IsNullOrEmpty(isValidateFolder))
                {
                    throw new Exception(isValidateFolder);
                }

                string url = string.Empty;
                url = string.Format(this.apiBaseUrl + UrlHandler.CreateFolder);
                var content = JsonConvert.SerializeObject(createFolderRequest);
                Console.WriteLine(content);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> CreateFolderAsync(CreateFolderRequest createFolderRequest)
        {
            try
            {
                var isValidateFolder = ValidateParamater.IsValidateFolder(createFolderRequest);
                if (!string.IsNullOrEmpty(isValidateFolder))
                {
                    throw new Exception(isValidateFolder);
                }

                string url = string.Empty;
                url = string.Format(this.apiBaseUrl + UrlHandler.CreateFolder);
                var content = JsonConvert.SerializeObject(createFolderRequest);
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData DeleteFolder(DeleteFolderRequest deleteFolderRequest)
        {
            try
            {
                if (!ValidateParamater.IsValidateDeleteFolder(deleteFolderRequest))
                {
                    throw new Exception(ErrorMessages.InvalidDelFolderValue);
                }

                var body = GetJsonBody.DeleteFolderBody(deleteFolderRequest);

                string url = string.Format(this.apiBaseUrl + UrlHandler.DeleteFolder);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url),
                    Content = new StringContent(body, Encoding.UTF8, "application/json"),
                };

                HttpResponseMessage response = this.client.SendAsync(request).Result;
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> DeleteFolderAsync(DeleteFolderRequest deleteFolderRequest)
        {
            try
            {
                if (!ValidateParamater.IsValidateDeleteFolder(deleteFolderRequest))
                {
                    throw new Exception(ErrorMessages.InvalidDelFolderValue);
                }

                var body = GetJsonBody.DeleteFolderBody(deleteFolderRequest);

                string url = string.Format(this.apiBaseUrl + UrlHandler.DeleteFolder);
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url),
                    Content = new StringContent(body, Encoding.UTF8, "application/json"),
                };

                HttpResponseMessage response = await this.client.SendAsync(request);
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData CopyFolder(CopyFolderRequest copyFolderRequest)
        {
            try
            {
                var validate = ValidateParamater.IsValidateCopyFolder(copyFolderRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.CopyFolder);
                var content = JsonConvert.SerializeObject(copyFolderRequest);
                var stringContent =
                    new StringContent(content, Encoding.UTF8,
                        "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

                HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> CopyFolderAsync(CopyFolderRequest copyFolderRequest)
        {
            try
            {
                var validate = ValidateParamater.IsValidateCopyFolder(copyFolderRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.CopyFolder);
                var content = JsonConvert.SerializeObject(copyFolderRequest);
                var stringContent =
                    new StringContent(content, Encoding.UTF8,
                        "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

                HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData MoveFolder(MoveFolderRequest moveFolderRequest)
        {
            try
            {
                var validate = ValidateParamater.IsValidateMoveFolder(moveFolderRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.MoveFolder);
                var content = JsonConvert.SerializeObject(moveFolderRequest);
                var stringContent =
                    new StringContent(content, Encoding.UTF8,
                        "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

                HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> MoveFolderAsync(MoveFolderRequest moveFolderRequest)
        {
            try
            {
                var validate = ValidateParamater.IsValidateMoveFolder(moveFolderRequest);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.MoveFolder);
                var content = JsonConvert.SerializeObject(moveFolderRequest);
                var stringContent =
                    new StringContent(content, Encoding.UTF8,
                        "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

                HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData GetBulkJobStatus(string jobId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(jobId))
                {
                    throw new Exception(ErrorMessages.InvalidJobValue);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetJobStatus, jobId);

                HttpResponseMessage response = this.client.GetAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> GetBulkJobStatusAsync(string jobId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(jobId))
                {
                    throw new Exception(ErrorMessages.InvalidJobValue);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetJobStatus, jobId);

                HttpResponseMessage response = await this.client.GetAsync(url);
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData GetFileVersions(string fileId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(fileId))
                {
                    throw new Exception(ErrorMessages.FileIdMissing);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetJobStatus, fileId);
                HttpResponseMessage response = this.client.GetAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> GetFileVersionsAsync(string fileId)
        {
            try
            {
                if (!ValidateParamater.IsValidateParam(fileId))
                {
                    throw new Exception(ErrorMessages.FileIdMissing);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetJobStatus, fileId);
                HttpResponseMessage response = this.client.GetAsync(url).Result;
                string res = await response.Content.ReadAsStringAsync();

                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData GetFileVersionDetails(string fileId, string versionId)
        {
            try
            {
                var validate = ValidateParamater.IsValidateParam(fileId, versionId);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetFileVersionDetail, fileId, versionId);
                HttpResponseMessage response = this.client.GetAsync(url).Result;
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> GetFileVersionDetailsAsync(string fileId, string versionId)
        {
            try
            {
                var validate = ValidateParamater.IsValidateParam(fileId, versionId);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.GetFileVersionDetail, fileId, versionId);
                HttpResponseMessage response = await this.client.GetAsync(url);
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public ResponseMetaData RestoreFileVersion(string fileId, string versionId)
        {
            try
            {
                var validate = ValidateParamater.IsValidateParam(fileId, versionId);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.RestoreVesrion, fileId, versionId);
                HttpResponseMessage response = this.client.PutAsync(url, null).Result;
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public async Task<ResponseMetaData> RestoreFileVersionAsync(string fileId, string versionId)
        {
            try
            {
                var validate = ValidateParamater.IsValidateParam(fileId, versionId);
                if (!string.IsNullOrEmpty(validate))
                {
                    throw new Exception(validate);
                }

                string url = string.Format(this.apiBaseUrl + UrlHandler.RestoreVesrion, fileId, versionId);
                HttpResponseMessage response = await this.client.PutAsync(url, null);
                string res = response.Content.ReadAsStringAsync().Result;
                return Utils.PopulateResponseMetadata(
                    res,
                    null,
                    Convert.ToInt32(response.StatusCode),
                    responseHeaders: null);
            }
            catch (Exception ex)
            {
                throw new ImageKitException(ex.Message);
            }
        }

        public virtual string MockThis()
        {
            return "Missing API Key parameters";
        }
    }
}
