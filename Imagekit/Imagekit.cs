// <copyright file="ImageKit.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Sdk
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::Imagekit.Models;

    public class ImageKitClient : BaseImagekit<ImageKitClient>
    {
        private RestClient restClient;

        public RestClient RestClient { get => this.restClient; set => this.restClient = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageKit"/> class.
        /// </summary>
        public ImageKitClient(string privateKey, string apiBaseUrl)
            : base(privateKey, apiBaseUrl, "path")
        {
            this.restClient = new RestClient(privateKey, apiBaseUrl, new System.Net.Http.HttpClient());
            this.Add("privateKey", privateKey);
        }

        public ResponseMetaData Upload(FileCreateRequest fileCreateRequest)
        {
            return this.restClient.Upload(fileCreateRequest);
        }

        public ResponseMetaData PurgeCache(string url)
        {
            return this.restClient.PurgeCache(url);
        }

        public async Task<ResponseMetaData> PurgeCacheAsync(string url)
        {
            return await this.restClient.PurgeCacheAsync(url);
        }

        public ResponseMetaData PurgeStatus(string purgeRequestId)
        {
            return this.restClient.PurgeStatus(purgeRequestId);
        }

        public async Task<ResponseMetaData> PurgeStatusAsync(string url)
        {
            return await this.restClient.PurgeStatusAsync(url);
        }

        public ResponseMetaData GetFileDetail(string url)
        {
            return this.restClient.GetFileDetail(url);
        }

        public ResponseMetaData GetFileListRequest()
        {
            return this.restClient.GetFileListRequest();
        }

        public ResponseMetaData GetFileMetadata(string fileId)
        {
            return this.restClient.GetFileMetaData(fileId);
        }

        public ResponseMetaData GetRemoteFileMetadata(string url)
        {
            return this.restClient.GetRemoteFileMetaData(url);
        }

        public ResponseMetaData DeleteFile(string fileId)
        {
            return this.restClient.DeleteFile(fileId);
        }

        public ResponseMetaData BulkDeleteFiles(List<string> fileIds)
        {
            return this.restClient.BulkDeleteFiles(fileIds);
        }

        // public ResultCache PurgeCache(string url)
        // {
        //    return this.restClient.purgeCache(url);
        // }

        // public ResultCacheStatus GetPurgeCacheStatus(string requestId)
        // {
        //    return this.restClient.getPurgeCacheStatus(requestId);
        // }

        // public Dictionary<string, string> GetAuthenticationParameters()
        // {
        //    return Calculation.GetAuthenticatedParams(null, 0, this.configuration.GetPrivateKey());
        // }

        // public Dictionary<string, string> GetAuthenticationParameters(string token)
        // {
        //    return Calculation.GetAuthenticatedParams(token, 0, this.configuration.GetPrivateKey());
        // }

        // public Dictionary<string, string> GetAuthenticationParameters(string token, long expire)
        // {
        //    return Calculation.GetAuthenticatedParams(token, expire, this.configuration.GetPrivateKey());
        // }

        // public int PHashDistance(string firstHex, string secondHex)
        // {
        //    return Calculation.GetHammingDistance(firstHex, secondHex);
        // }
        public ResponseMetaData AddTags(TagsRequest tagsRequest)
        {
            return this.restClient.ManageTags(tagsRequest, "addTags");
        }

        public ResponseMetaData RemoveAiTags(AiTagsRequest aiTagsRequest)
        {
            return this.restClient.RemoveAiTags(aiTagsRequest);
        }

        public ResponseMetaData RemoveTags(TagsRequest tagsRequest)
        {
            return this.restClient.ManageTags(tagsRequest, "removeTags");
        }

        public ResponseMetaData GetCustomMetaDataFields(bool includeDeleted)
        {
            return this.restClient.GetCustomMetaDataFields(includeDeleted);
        }

        public ResponseMetaData CreateCustomMetaDataFields(
           CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest)
        {
            return this.restClient.CreateCustomMetaDataFields(customMetaDataFieldCreateRequest);
        }

        public ResponseMetaData DeleteCustomMetaDataField(string id)
        {
            return this.restClient.DeleteCustomMetaDataField(id);
        }

        public ResponseMetaData UpdateCustomMetaDataFields(
           CustomMetaDataFieldUpdateRequest customMetaDataFieldUpdateRequest)
        {
            return this.restClient.UpdateCustomMetaDataFields(customMetaDataFieldUpdateRequest);
        }

        public ResponseMetaData DeleteFileVersion(DeleteFileVersionRequest deleteFileVersionRequest)
        {
            return this.restClient.DeleteFileVersion(deleteFileVersionRequest);
        }

        public ResponseMetaData CopyFile(CopyFileRequest copyFileRequest)
        {
            return this.restClient.CopyFile(copyFileRequest);
        }

        public ResponseMetaData MoveFile(MoveFileRequest moveFileRequest)
        {
            return this.restClient.MoveFile(moveFileRequest);
        }

        public ResponseMetaData RenameFile(RenameFileRequest renameFileRequest)
        {
            return this.restClient.RenameFile(renameFileRequest);
        }

        public ResponseMetaData RestoreFileVersion(string fileId, string versionId)
        {
            return this.restClient.RestoreFileVersion(fileId, versionId);
        }

        public ResponseMetaData CreateFolder(CreateFolderRequest createFolderRequest)
        {
            return this.restClient.CreateFolder(createFolderRequest);
        }

        public ResponseMetaData DeleteFolder(DeleteFolderRequest deleteFolderRequest)
        {
            return this.restClient.DeleteFolder(deleteFolderRequest);
        }

        public ResponseMetaData CopyFolder(CopyFolderRequest copyFolderRequest)
        {
            return this.restClient.CopyFolder(copyFolderRequest);
        }

        public ResponseMetaData MoveFolder(MoveFolderRequest moveFolderRequest)
        {
            return this.restClient.MoveFolder(moveFolderRequest);
        }

        public ResponseMetaData GetBulkJobStatus(string jobId)
        {
            return this.restClient.GetBulkJobStatus(jobId);
        }

        public ResponseMetaData GetFileVersions(string fileId)
        {
            return this.restClient.GetFileVersions(fileId);
        }

        public ResponseMetaData GetFileVersionDetails(string fileId, string versionId)
        {
            return this.restClient.GetFileVersionDetails(fileId, versionId);
        }

        public async Task<ResponseMetaData> UploadAsync(FileCreateRequest fileCreateRequest)
        {
            return await this.restClient.UploadAsync(fileCreateRequest);
        }

        public async Task<ResponseMetaData> GetFileDetailAsync(string fileId)
        {
            return await this.restClient.GetFileDetailAsync(fileId);
        }

        public async Task<ResponseMetaData> GetFileMetadataAsync(string fileId)
        {
            return await this.restClient.GetFileMetaDataAsync(fileId);
        }

        public async Task<ResponseMetaData> GetRemoteFileMetadataAsync(string url)
        {
            return await this.restClient.GetRemoteFileMetaDataAsync(url);
        }

        public async Task<ResponseMetaData> DeleteFileAsync(string fileId)
        {
            return await this.restClient.DeleteFileAsync(fileId);
        }

        public async Task<ResponseMetaData> BulkDeleteFilesAsync(List<string> fileIds)
        {
            return await this.restClient.BulkDeleteFilesAsync(fileIds);
        }

        public async Task<ResponseMetaData> AddTagsAsync(TagsRequest tagsRequest)
        {
            return await this.restClient.ManageTagsAsync(tagsRequest, "addTags");
        }

        public async Task<ResponseMetaData> RemoveAiTagsAsync(AiTagsRequest aiTagsRequest)
        {
            return await this.restClient.RemoveAiTagsAsync(aiTagsRequest);
        }

        public async Task<ResponseMetaData> RemoveTagsAsync(TagsRequest tagsRequest)
        {
            return await this.restClient.ManageTagsAsync(tagsRequest, "removeTags");
        }

        public async Task<ResponseMetaData> GetCustomMetaDataFieldsAsync(bool includeDeleted)
        {
            return await this.restClient.GetCustomMetaDataFieldsAsync(includeDeleted);
        }

        public async Task<ResponseMetaData> CreateCustomMetaDataFieldsAsync(
           CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest)
        {
            return await this.restClient.CreateCustomMetaDataFieldsAsync(customMetaDataFieldCreateRequest);
        }

        public async Task<ResponseMetaData> DeleteCustomMetaDataFieldAsync(string id)
        {
            return await this.restClient.DeleteCustomMetaDataFieldAsync(id);
        }

        public async Task<ResponseMetaData> UpdateCustomMetaDataFieldsAsync(
           CustomMetaDataFieldUpdateRequest customMetaDataFieldUpdateRequest)
        {
            return await this.restClient.UpdateCustomMetaDataFieldsAsync(customMetaDataFieldUpdateRequest);
        }

        public async Task<ResponseMetaData> DeleteFileVersionAsync(DeleteFileVersionRequest deleteFileVersionRequest)
        {
            return await this.restClient.DeleteFileVersionAsync(deleteFileVersionRequest);
        }

        public async Task<ResponseMetaData> CopyFileAsync(CopyFileRequest copyFileRequest)
        {
            return await this.restClient.CopyFileAsync(copyFileRequest);
        }

        public async Task<ResponseMetaData> MoveFileAsync(MoveFileRequest moveFileRequest)
        {
            return await this.restClient.MoveFileAsync(moveFileRequest);
        }

        public async Task<ResponseMetaData> RenameFileAsync(RenameFileRequest renameFileRequest)
        {
            return await this.restClient.RenameFileAsync(renameFileRequest);
        }

        public async Task<ResponseMetaData> RestoreFileVersionAsync(string fileId, string versionId)
        {
            return await this.restClient.RestoreFileVersionAsync(fileId, versionId);
        }

        public async Task<ResponseMetaData> CreateFolderAsync(CreateFolderRequest createFolderRequest)
        {
            return await this.restClient.CreateFolderAsync(createFolderRequest);
        }

        public async Task<ResponseMetaData> DeleteFolderAsync(DeleteFolderRequest deleteFolderRequest)
        {
            return await this.restClient.DeleteFolderAsync(deleteFolderRequest);
        }

        public async Task<ResponseMetaData> CopyFolderAsync(CopyFolderRequest copyFolderRequest)
        {
            return await this.restClient.CopyFolderAsync(copyFolderRequest);
        }

        public async Task<ResponseMetaData> MoveFolderAsync(MoveFolderRequest moveFolderRequest)
        {
            return await this.restClient.MoveFolderAsync(moveFolderRequest);
        }

        public async Task<ResponseMetaData> GetBulkJobStatusAsync(string jobId)
        {
            return await this.restClient.GetBulkJobStatusAsync(jobId);
        }

        public async Task<ResponseMetaData> GetFileVersionsAsync(string fileId)
        {
            return await this.restClient.GetFileVersionsAsync(fileId);
        }

        public async Task<ResponseMetaData> GetFileVersionDetailsAsync(string fileId, string versionId)
        {
            return await this.restClient.GetFileVersionDetailsAsync(fileId, versionId);
        }

        public async Task<ResponseMetaData> GetFileListRequestAsync()
        {
            return await this.restClient.GetFileListRequestAsync();
        }
    }
}