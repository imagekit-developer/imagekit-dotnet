// <copyright file="RestClient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using global::Imagekit.Constant;
using global::Imagekit.Helper;
using global::Imagekit.Models;
using global::Imagekit.Models.Response;
using global::Imagekit.Util;
using Imagekit;
using Newtonsoft.Json;

internal class RestClient
{
    private readonly string mediaAPIBaseUrl = UrlHandler.MediaAPIBaseUrl;
    private readonly string uploadAPIBaseUrl = UrlHandler.UploadAPIBaseUrl;
    private readonly HttpClient client;

    public RestClient(string privateKey, string mediaAPIBaseUrl, HttpClient httpClient)
    {
        if (string.IsNullOrEmpty(privateKey))
        {
            throw new Exception(ErrorMessages.InvalidKey);
        }

        if (string.IsNullOrEmpty(mediaAPIBaseUrl))
        {
            throw new Exception(ErrorMessages.InvalidApiUrl);
        }

        this.client = httpClient;
        this.client.DefaultRequestHeaders.Add("Authorization", "Basic " + Utils.EncodeTo64(privateKey));
    }

    public ResponseMetaData GetFileListRequest(GetFileListRequest getFileListRequest)
    {
        try
        {
            ResultList model = new ResultList();
            string param = GetJsonBody.GetFileRequestBody(getFileListRequest);
            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetFileRequest, param);
            HttpResponseMessage response = this.client.GetAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultList>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> GetFileListRequestAsync(GetFileListRequest getFileListRequest)
    {
        try
        {
            ResultList model = new ResultList();
            string param = GetJsonBody.GetFileRequestBody(getFileListRequest);
            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetFileRequest, param);

            HttpResponseMessage response = await this.client.GetAsync(url);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultList>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData PurgeCache(string path)
    {
        try
        {
            ResultCache model = new ResultCache();
            if (!ValidateParamater.IsValidateParam(path))
            {
                throw new Exception(ErrorMessages.InvalidUrlValue);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetPurge);

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
            model = JsonConvert.DeserializeObject<ResultCache>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> PurgeCacheAsync(string path)
    {
        try
        {
            ResultCache model = new ResultCache();
            if (!ValidateParamater.IsValidateParam(path))
            {
                throw new Exception(ErrorMessages.InvalidUrlValue);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetPurge);
            object data = new
            {
                url = path,
            };
            var content = JsonConvert.SerializeObject(data);
            var stringContent =
                new StringContent(content: content, encoding: Encoding.UTF8,
                    mediaType: "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

            HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultCache>(res);
            Utils.PopulateResponseMetadata(
              res,
              model,
              Convert.ToInt32(response.StatusCode),
              responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData PurgeStatus(string purgeRequestId)
    {
        try
        {
            ResultCacheStatus model = new ResultCacheStatus();
            if (!ValidateParamater.IsValidateParam(purgeRequestId))
            {
                throw new Exception(ErrorMessages.InvalidPurgeUrl);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetPurgeStatus, purgeRequestId);

            HttpResponseMessage response = this.client.GetAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultCacheStatus>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> PurgeStatusAsync(string purgeRequestId)
    {
        try
        {
            ResultCacheStatus model = new ResultCacheStatus();
            if (!ValidateParamater.IsValidateParam(purgeRequestId))
            {
                throw new Exception(ErrorMessages.InvalidPurgeUrl);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetPurgeStatus, purgeRequestId);

            HttpResponseMessage response = await this.client.GetAsync(url);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultCacheStatus>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData GetFileDetail(string fileId)
    {
        try
        {
            Result model = new Result();
            if (!ValidateParamater.IsValidateParam(fileId))
            {
                throw new Exception(ErrorMessages.FileIdMissing);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetFileDetails, fileId);

            HttpResponseMessage response = this.client.GetAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<Result>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> GetFileDetailAsync(string fileId)
    {
        try
        {
            Result model = new Result();
            if (!ValidateParamater.IsValidateParam(fileId))
            {
                throw new Exception(ErrorMessages.FileIdMissing);
            }

            Dictionary<string, string> headers = Utils.GetHeaders();
            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetFileDetails, fileId);

            HttpResponseMessage response = await this.client.GetAsync(url);
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<Result>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData Upload(FileCreateRequest fileCreateRequest)
    {
        try
        {
            Result model = new Result();
            string validate = ValidateParamater.IsValidateUpload(fileCreateRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = this.uploadAPIBaseUrl + UrlHandler.UploadFile;
            Dictionary<string, string> headers = Utils.GetHeaders();
            var formdata = MultipartFormDataModel.Build(fileCreateRequest);
            HttpResponseMessage response = this.client.PostAsync(url, formdata).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<Result>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
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
            Result model = new Result();
            string validate = ValidateParamater.IsValidateUpload(fileCreateRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = this.uploadAPIBaseUrl + UrlHandler.UploadFile;
            Dictionary<string, string> headers = Utils.GetHeaders();
            var formdata = MultipartFormDataModel.Build(fileCreateRequest);

            HttpResponseMessage response = await this.client.PostAsync(url, formdata);
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<Result>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData UpdateFileDetail(FileUpdateRequest fileUpdateRequest)
    {
        try
        {
            Result model = new Result();
            string validate = ValidateParamater.IsValidateUpdateFile(fileUpdateRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.UpdateFileRequest, fileUpdateRequest.FileId);
            Dictionary<string, string> headers = Utils.GetHeaders();
            var formdata = MultipartFormDataModel.BuildUpdateFile(fileUpdateRequest);

            HttpResponseMessage response = this.client.PostAsync(url, formdata).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<Result>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> UpdateFileDetailAsync(FileUpdateRequest fileUpdateRequest)
    {
        try
        {
            Result model = new Result();
            string validate = ValidateParamater.IsValidateUpdateFile(fileUpdateRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.UpdateFileRequest, fileUpdateRequest.FileId);
            Dictionary<string, string> headers = Utils.GetHeaders();
            var formdata = MultipartFormDataModel.BuildUpdateFile(fileUpdateRequest);

            HttpResponseMessage response = await this.client.PostAsync(url, formdata);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<Result>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData DeleteFile(string fileId)
    {
        try
        {
            ResultDelete model = new ResultDelete();
            if (!ValidateParamater.IsValidateParam(fileId))
            {
                throw new Exception(ErrorMessages.FileIdMissing);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.DeleteFile, fileId);

            HttpResponseMessage response = this.client.DeleteAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model.Raw = res;
            model.FileId = fileId;
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
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
            ResultDelete model = new ResultDelete();
            if (!ValidateParamater.IsValidateParam(fileId))
            {
                throw new Exception(ErrorMessages.FileIdMissing);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.DeleteFile, fileId);

            HttpResponseMessage response = await this.client.DeleteAsync(url);
            string res = response.Content.ReadAsStringAsync().Result;
            model.Raw = res;
            model.FileId = fileId;
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData BulkDeleteFiles(List<string> fileIds)
    {
        try
        {
            ResultFileDelete model = new ResultFileDelete();
            if (!ValidateParamater.IsListCheck(fileIds))
            {
                throw new Exception(ErrorMessages.ListFilesInputMissing);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.BulkDelete);

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
            model = JsonConvert.DeserializeObject<ResultFileDelete>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
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
            ResultFileDelete model = new ResultFileDelete();
            if (!ValidateParamater.IsListCheck(fileIds))
            {
                throw new Exception(ErrorMessages.ListFilesInputMissing);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.BulkDelete);

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

            model = JsonConvert.DeserializeObject<ResultFileDelete>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData GetFileMetaData(string fileId)
    {
        try
        {
            ResultMetaData model = new ResultMetaData();
            if (!ValidateParamater.IsValidateParam(fileId))
            {
                throw new Exception(ErrorMessages.FileIdMissing);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetMetaData, fileId);

            HttpResponseMessage response = this.client.GetAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultMetaData>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> GetFileMetaDataAsync(string fileId)
    {
        try
        {
            ResultMetaData model = new ResultMetaData();
            if (!ValidateParamater.IsValidateParam(fileId))
            {
                throw new Exception(ErrorMessages.FileIdMissing);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetMetaData, fileId);

            HttpResponseMessage response = await this.client.GetAsync(url);
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<ResultMetaData>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData GetRemoteFileMetaData(string url)
    {
        try
        {
            ResultMetaData model = new ResultMetaData();
            if (!ValidateParamater.IsValidateParam(url))
            {
                throw new Exception(ErrorMessages.InvalidUrlValue);
            }

            string apIurl = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetRemoteData, url);

            HttpResponseMessage response = this.client.GetAsync(apIurl).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultMetaData>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> GetRemoteFileMetaDataAsync(string url)
    {
        try
        {
            ResultMetaData model = new ResultMetaData();
            if (!ValidateParamater.IsValidateParam(url))
            {
                throw new Exception(ErrorMessages.InvalidUrlValue);
            }

            string apIurl = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetRemoteData, url);

            HttpResponseMessage response = await this.client.GetAsync(apIurl);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultMetaData>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData ManageTags(TagsRequest tagsRequest, string action)
    {
        try
        {
            ResultTags model = new ResultTags();
            var validate = ValidateParamater.IsValidateTagRequest(tagsRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;

            if (action == "addTags")
            {
                url = this.uploadAPIBaseUrl + UrlHandler.AddTags;
            }
            else if (action == "removeTags")
            {
                url = this.uploadAPIBaseUrl + UrlHandler.RemoveTags;
            }

            var content = JsonConvert.SerializeObject(tagsRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultTags>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> ManageTagsAsync(TagsRequest tagsRequest, string action)
    {
        try
        {
            ResultTags model = new ResultTags();
            var validate = ValidateParamater.IsValidateTagRequest(tagsRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;

            if (action == "addTags")
            {
                url = this.uploadAPIBaseUrl + UrlHandler.AddTags;
            }
            else if (action == "removeTags")
            {
                url = this.uploadAPIBaseUrl + UrlHandler.RemoveTags;
            }

            var content = JsonConvert.SerializeObject(tagsRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultTags>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData RemoveAiTags(AiTagsRequest aiTagsRequest)
    {
        try
        {
            ResultTags model = new ResultTags();
            var validate = ValidateParamater.IsValidateAiTagRequest(aiTagsRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            // removeAITags
            string url = string.Empty;

            url = this.uploadAPIBaseUrl + UrlHandler.RemoveAiTags;

            var content = JsonConvert.SerializeObject(aiTagsRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<ResultTags>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> RemoveAiTagsAsync(AiTagsRequest aiTagsRequest)
    {
        try
        {
            ResultTags model = new ResultTags();
            var validate = ValidateParamater.IsValidateAiTagRequest(aiTagsRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            // removeAITags
            string url = string.Empty;

            url = this.uploadAPIBaseUrl + UrlHandler.RemoveAiTags;

            var content = JsonConvert.SerializeObject(aiTagsRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<ResultTags>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData GetCustomMetaDataFields(bool includeDeleted)
    {
        try
        {
            ResultCustomMetaDataFieldList model = new ResultCustomMetaDataFieldList();
            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.CustomMetadataFields, includeDeleted);

            HttpResponseMessage response = this.client.GetAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultCustomMetaDataFieldList>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> GetCustomMetaDataFieldsAsync(bool includeDeleted)
    {
        try
        {
            ResultCustomMetaDataFieldList model = new ResultCustomMetaDataFieldList();
            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.CustomMetadataFields, includeDeleted);

            HttpResponseMessage response = await this.client.GetAsync(url);
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<ResultCustomMetaDataFieldList>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData CreateCustomMetaDataFields(
             CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest)
    {
        try
        {
            ResultCustomMetaDataField model = new ResultCustomMetaDataField();
            var validate =
                ValidateParamater.IsValidateCustomMetaDataFieldCreateRequest(customMetaDataFieldCreateRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;
            url = this.mediaAPIBaseUrl + UrlHandler.CreareCustomMetaDataFields;

            string body = GetJsonBody.CreateCustomMetaDataBody(customMetaDataFieldCreateRequest);
            var stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultCustomMetaDataField>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> CreateCustomMetaDataFieldsAsync(
          CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest)
    {
        try
        {
            ResultCustomMetaDataField model = new ResultCustomMetaDataField();
            var validate =
                ValidateParamater.IsValidateCustomMetaDataFieldCreateRequest(customMetaDataFieldCreateRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;
            url = this.mediaAPIBaseUrl + UrlHandler.CreareCustomMetaDataFields;

            string body = GetJsonBody.CreateCustomMetaDataBody(customMetaDataFieldCreateRequest);
            var stringContent = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<ResultCustomMetaDataField>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData DeleteCustomMetaDataField(string id)
    {
        try
        {
            ResultNoContent model = new ResultNoContent();
            if (!ValidateParamater.IsValidateParam(id))
            {
                throw new Exception(ErrorMessages.InvalidFileidsValue);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.DeleteCustomMetaDataFields, id);

            HttpResponseMessage response = this.client.DeleteAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultNoContent>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> DeleteCustomMetaDataFieldAsync(string id)
    {
        try
        {
            ResultNoContent model = new ResultNoContent();
            if (!ValidateParamater.IsValidateParam(id))
            {
                throw new Exception(ErrorMessages.InvalidFileidsValue);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.DeleteCustomMetaDataFields, id);

            HttpResponseMessage response = await this.client.DeleteAsync(url);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultNoContent>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData UpdateCustomMetaDataFields(
        CustomMetaDataFieldUpdateRequest customMetaDataFieldUpdateRequest)
    {
        try
        {
            ResultCustomMetaDataField model = new ResultCustomMetaDataField();
            var validate =
                ValidateParamater.IsValidateCustomMetaDataFieldUpdateRequest(customMetaDataFieldUpdateRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;
            url = string.Format(
                this.mediaAPIBaseUrl + UrlHandler.UpdateCustomMetadataFields,
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
            model = JsonConvert.DeserializeObject<ResultCustomMetaDataField>(res);
            Utils.PopulateResponseMetadata(
               res, model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> UpdateCustomMetaDataFieldsAsync(
     CustomMetaDataFieldUpdateRequest customMetaDataFieldUpdateRequest)
    {
        try
        {
            ResultCustomMetaDataField model = new ResultCustomMetaDataField();
            var validate =
                ValidateParamater.IsValidateCustomMetaDataFieldUpdateRequest(customMetaDataFieldUpdateRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;
            url = string.Format(
                this.mediaAPIBaseUrl + UrlHandler.UpdateCustomMetadataFields,
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
            model = JsonConvert.DeserializeObject<ResultCustomMetaDataField>(res);
            Utils.PopulateResponseMetadata(
                res, model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData DeleteFileVersion(DeleteFileVersionRequest deleteFileVersionRequest)
    {
        try
        {
            ResultNoContent model = new ResultNoContent();
            var validate = ValidateParamater.IsValidateDeleteFileVersionRequest(deleteFileVersionRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.DeleteVesrion, deleteFileVersionRequest.FileId,
                deleteFileVersionRequest.VersionId);

            HttpResponseMessage response = this.client.DeleteAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultNoContent>(res);

            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> DeleteFileVersionAsync(DeleteFileVersionRequest deleteFileVersionRequest)
    {
        try
        {
            ResultNoContent model = new ResultNoContent();
            var validate = ValidateParamater.IsValidateDeleteFileVersionRequest(deleteFileVersionRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.DeleteVesrion, deleteFileVersionRequest.FileId,
                deleteFileVersionRequest.VersionId);

            HttpResponseMessage response = await this.client.DeleteAsync(url);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultNoContent>(res);

            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData CopyFile(CopyFileRequest copyFileRequest)
    {
        try
        {
            ResultNoContent model = new ResultNoContent();
            string validate = ValidateParamater.IsValidateCopyRequest(copyFileRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;
            url = string.Format(this.mediaAPIBaseUrl + UrlHandler.CopyFile);
            var content = JsonConvert.SerializeObject(copyFileRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<ResultNoContent>(res);

            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> CopyFileAsync(CopyFileRequest copyFileRequest)
    {
        try
        {
            ResultNoContent model = new ResultNoContent();
            string validate = ValidateParamater.IsValidateCopyRequest(copyFileRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;
            url = string.Format(this.mediaAPIBaseUrl + UrlHandler.CopyFile);
            var content = JsonConvert.SerializeObject(copyFileRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<ResultNoContent>(res);

            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData MoveFile(MoveFileRequest moveFileRequest)
    {
        try
        {
            ResultNoContent model = new ResultNoContent();
            string validate = ValidateParamater.IsValidateMoveRequest(moveFileRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;
            url = string.Format(this.mediaAPIBaseUrl + UrlHandler.MoveFile);
            var content = JsonConvert.SerializeObject(moveFileRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultNoContent>(res);

            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> MoveFileAsync(MoveFileRequest moveFileRequest)
    {
        try
        {
            ResultNoContent model = new ResultNoContent();
            string validate = ValidateParamater.IsValidateMoveRequest(moveFileRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;
            url = string.Format(this.mediaAPIBaseUrl + UrlHandler.MoveFile);
            var content = JsonConvert.SerializeObject(moveFileRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultNoContent>(res);

            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData RenameFile(RenameFileRequest renameFileRequest)
    {
        try
        {
            ResultRenameFile model = new ResultRenameFile();
            var validate = ValidateParamater.IsValidateRenameRequest(renameFileRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;
            url = string.Format(this.mediaAPIBaseUrl + UrlHandler.RenameFile);
            var content = JsonConvert.SerializeObject(renameFileRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = this.client.PutAsync(url, stringContent).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultRenameFile>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> RenameFileAsync(RenameFileRequest renameFileRequest)
    {
        try
        {
            ResultRenameFile model = new ResultRenameFile();
            var validate = ValidateParamater.IsValidateRenameRequest(renameFileRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Empty;
            url = string.Format(this.mediaAPIBaseUrl + UrlHandler.RenameFile);
            var content = JsonConvert.SerializeObject(renameFileRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PutAsync(url, stringContent);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultRenameFile>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData CreateFolder(CreateFolderRequest createFolderRequest)
    {
        try
        {
            ResultEmptyBlock model = new ResultEmptyBlock();
            var isValidateFolder = ValidateParamater.IsValidateFolder(createFolderRequest);
            if (!string.IsNullOrEmpty(isValidateFolder))
            {
                throw new Exception(isValidateFolder);
            }

            string url = string.Empty;
            url = string.Format(this.mediaAPIBaseUrl + UrlHandler.CreateFolder);
            var content = JsonConvert.SerializeObject(createFolderRequest);
            Console.WriteLine(content);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultEmptyBlock>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> CreateFolderAsync(CreateFolderRequest createFolderRequest)
    {
        try
        {
            ResultEmptyBlock model = new ResultEmptyBlock();
            var isValidateFolder = ValidateParamater.IsValidateFolder(createFolderRequest);
            if (!string.IsNullOrEmpty(isValidateFolder))
            {
                throw new Exception(isValidateFolder);
            }

            string url = string.Empty;
            url = string.Format(this.mediaAPIBaseUrl + UrlHandler.CreateFolder);
            var content = JsonConvert.SerializeObject(createFolderRequest);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultEmptyBlock>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData DeleteFolder(DeleteFolderRequest deleteFolderRequest)
    {
        try
        {
            ResultNoContent model = new ResultNoContent();
            if (!ValidateParamater.IsValidateDeleteFolder(deleteFolderRequest))
            {
                throw new Exception(ErrorMessages.InvalidDelFolderValue);
            }

            var body = GetJsonBody.DeleteFolderBody(deleteFolderRequest);

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.DeleteFolder);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };

            HttpResponseMessage response = this.client.SendAsync(request).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultNoContent>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> DeleteFolderAsync(DeleteFolderRequest deleteFolderRequest)
    {
        try
        {
            ResultNoContent model = new ResultNoContent();
            if (!ValidateParamater.IsValidateDeleteFolder(deleteFolderRequest))
            {
                throw new Exception(ErrorMessages.InvalidDelFolderValue);
            }

            var body = GetJsonBody.DeleteFolderBody(deleteFolderRequest);

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.DeleteFolder);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };

            HttpResponseMessage response = await this.client.SendAsync(request);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultNoContent>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData CopyFolder(CopyFolderRequest copyFolderRequest)
    {
        try
        {
            ResultOfFolderActions model = new ResultOfFolderActions();
            var validate = ValidateParamater.IsValidateCopyFolder(copyFolderRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.CopyFolder);
            var content = JsonConvert.SerializeObject(copyFolderRequest);
            var stringContent =
                new StringContent(content, Encoding.UTF8,
                    "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

            HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultOfFolderActions>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> CopyFolderAsync(CopyFolderRequest copyFolderRequest)
    {
        try
        {
            ResultOfFolderActions model = new ResultOfFolderActions();
            var validate = ValidateParamater.IsValidateCopyFolder(copyFolderRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.CopyFolder);
            var content = JsonConvert.SerializeObject(copyFolderRequest);
            var stringContent =
                new StringContent(content, Encoding.UTF8,
                    "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

            HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<ResultOfFolderActions>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData MoveFolder(MoveFolderRequest moveFolderRequest)
    {
        try
        {
            ResultOfFolderActions model = new ResultOfFolderActions();
            var validate = ValidateParamater.IsValidateMoveFolder(moveFolderRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.MoveFolder);
            var content = JsonConvert.SerializeObject(moveFolderRequest);
            var stringContent =
                new StringContent(content, Encoding.UTF8,
                    "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

            HttpResponseMessage response = this.client.PostAsync(url, stringContent).Result;
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<ResultOfFolderActions>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> MoveFolderAsync(MoveFolderRequest moveFolderRequest)
    {
        try
        {
            ResultOfFolderActions model = new ResultOfFolderActions();

            var validate = ValidateParamater.IsValidateMoveFolder(moveFolderRequest);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.MoveFolder);
            var content = JsonConvert.SerializeObject(moveFolderRequest);
            var stringContent =
                new StringContent(content, Encoding.UTF8,
                    "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

            HttpResponseMessage response = await this.client.PostAsync(url, stringContent);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultOfFolderActions>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData GetBulkJobStatus(string jobId)
    {
        try
        {
            ResultBulkJobStatus model = new ResultBulkJobStatus();
            if (!ValidateParamater.IsValidateParam(jobId))
            {
                throw new Exception(ErrorMessages.InvalidJobValue);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetJobStatus, jobId);

            HttpResponseMessage response = this.client.GetAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultBulkJobStatus>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> GetBulkJobStatusAsync(string jobId)
    {
        try
        {
            ResultBulkJobStatus model = new ResultBulkJobStatus();
            if (!ValidateParamater.IsValidateParam(jobId))
            {
                throw new Exception(ErrorMessages.InvalidJobValue);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetJobStatus, jobId);

            HttpResponseMessage response = await this.client.GetAsync(url);
            string res = response.Content.ReadAsStringAsync().Result;

            model = JsonConvert.DeserializeObject<ResultBulkJobStatus>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData GetFileVersions(string fileId)
    {
        try
        {
            ResultFileVersions model = new ResultFileVersions();
            if (!ValidateParamater.IsValidateParam(fileId))
            {
                throw new Exception(ErrorMessages.FileIdMissing);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetJobStatus, fileId);
            HttpResponseMessage response = this.client.GetAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultFileVersions>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> GetFileVersionsAsync(string fileId)
    {
        try
        {
            ResultFileVersions model = new ResultFileVersions();
            if (!ValidateParamater.IsValidateParam(fileId))
            {
                throw new Exception(ErrorMessages.FileIdMissing);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetJobStatus, fileId);
            HttpResponseMessage response = this.client.GetAsync(url).Result;
            string res = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<ResultFileVersions>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData GetFileVersionDetails(string fileId, string versionId)
    {
        try
        {
            ResultFileVersionDetails model = new ResultFileVersionDetails();
            var validate = ValidateParamater.IsValidateParam(fileId, versionId);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetFileVersionDetail, fileId, versionId);
            HttpResponseMessage response = this.client.GetAsync(url).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultFileVersionDetails>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> GetFileVersionDetailsAsync(string fileId, string versionId)
    {
        try
        {
            ResultFileVersionDetails model = new ResultFileVersionDetails();
            var validate = ValidateParamater.IsValidateParam(fileId, versionId);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.GetFileVersionDetail, fileId, versionId);
            HttpResponseMessage response = await this.client.GetAsync(url);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<ResultFileVersionDetails>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public ResponseMetaData RestoreFileVersion(string fileId, string versionId)
    {
        try
        {
            Result model = new Result();
            var validate = ValidateParamater.IsValidateParam(fileId, versionId);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.RestoreVesrion, fileId, versionId);
            HttpResponseMessage response = this.client.PutAsync(url, null).Result;
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<Result>(res);
            Utils.PopulateResponseMetadata(
               res,
               model,
               Convert.ToInt32(response.StatusCode),
               responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }

    public async Task<ResponseMetaData> RestoreFileVersionAsync(string fileId, string versionId)
    {
        try
        {
            Result model = new Result();
            var validate = ValidateParamater.IsValidateParam(fileId, versionId);
            if (!string.IsNullOrEmpty(validate))
            {
                throw new Exception(validate);
            }

            string url = string.Format(this.mediaAPIBaseUrl + UrlHandler.RestoreVesrion, fileId, versionId);
            HttpResponseMessage response = await this.client.PutAsync(url, null);
            string res = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<Result>(res);
            Utils.PopulateResponseMetadata(
                res,
                model,
                Convert.ToInt32(response.StatusCode),
                responseHeaders: null);
            return model;
        }
        catch (Exception ex)
        {
            throw new ImagekitException(ex.Message);
        }
    }
}