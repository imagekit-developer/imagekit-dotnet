// <copyright file="Imagekit.cs" company="ImageKit">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::Imagekit.Models;
    using global::Imagekit.Models.Response;
    using global::Imagekit.Util;

    public class ImagekitClient : BaseImagekit<ImagekitClient>
    {
        private readonly RestClient restClient;
        private readonly string privateKey;

        public ImagekitClient(string publicKey, string privateKey, string urlEndPoint)
            : base(privateKey, urlEndPoint, "path")
        {
            this.restClient = new RestClient(privateKey, urlEndPoint, new System.Net.Http.HttpClient());
            this.Add("privateKey", privateKey);
            this.Add("publicKey", publicKey);
            this.privateKey = privateKey;
        }

        public Result Upload(FileCreateRequest fileCreateRequest)
        {
            return (Result)this.restClient.Upload(fileCreateRequest);
        }

        public Result UpdateFileDetail(FileUpdateRequest fileUpdateRequest)
        {
            return (Result)this.restClient.UpdateFileDetail(fileUpdateRequest);
        }

        public async Task<Result> UpdateFileDetailAsync(FileUpdateRequest fileUpdateRequest)
        {
            return (Result)await this.restClient.UpdateFileDetailAsync(fileUpdateRequest);
        }

        public ResultCache PurgeCache(string url)
        {
            return (ResultCache)this.restClient.PurgeCache(url);
        }

        public async Task<ResultCache> PurgeCacheAsync(string url)
        {
            return (ResultCache)await this.restClient.PurgeCacheAsync(url);
        }

        public ResultCacheStatus PurgeStatus(string purgeRequestId)
        {
            return (ResultCacheStatus)this.restClient.PurgeStatus(purgeRequestId);
        }

        public async Task<ResultCacheStatus> PurgeStatusAsync(string url)
        {
            return (ResultCacheStatus)await this.restClient.PurgeStatusAsync(url);
        }

        public Result GetFileDetail(string url)
        {
            return (Result)this.restClient.GetFileDetail(url);
        }

        public ResultList GetFileListRequest(GetFileListRequest getFileListRequest)
        {
            return (ResultList)this.restClient.GetFileListRequest(getFileListRequest);
        }

        public ResultMetaData GetFileMetadata(string fileId)
        {
            return (ResultMetaData)this.restClient.GetFileMetaData(fileId);
        }

        public ResultMetaData GetRemoteFileMetadata(string url)
        {
            return (ResultMetaData)this.restClient.GetRemoteFileMetaData(url);
        }

        public ResultDelete DeleteFile(string fileId)
        {
            return (ResultDelete)this.restClient.DeleteFile(fileId);
        }

        public ResultFileDelete BulkDeleteFiles(List<string> fileIds)
        {
            return (ResultFileDelete)this.restClient.BulkDeleteFiles(fileIds);
        }

        public ResultTags AddTags(TagsRequest tagsRequest)
        {
            return (ResultTags)this.restClient.ManageTags(tagsRequest, "addTags");
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public ResultTags RemoveAITags(AITagsRequest aITagsRequest)
        {
            return (ResultTags)this.restClient.RemoveAITags(aITagsRequest);
        }

        public ResultTags RemoveTags(TagsRequest tagsRequest)
        {
            return (ResultTags)this.restClient.ManageTags(tagsRequest, "removeTags");
        }

        public ResultCustomMetaDataFieldList GetCustomMetaDataFields(bool includeDeleted)
        {
            return (ResultCustomMetaDataFieldList)this.restClient.GetCustomMetaDataFields(includeDeleted);
        }

        public ResultCustomMetaDataField CreateCustomMetaDataFields(
           CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest)
        {
            return (ResultCustomMetaDataField)this.restClient.CreateCustomMetaDataFields(customMetaDataFieldCreateRequest);
        }

        public ResultNoContent DeleteCustomMetaDataField(string id)
        {
            return (ResultNoContent)this.restClient.DeleteCustomMetaDataField(id);
        }

        public ResultCustomMetaDataField UpdateCustomMetaDataFields(
           CustomMetaDataFieldUpdateRequest customMetaDataFieldUpdateRequest)
        {
            return (ResultCustomMetaDataField)this.restClient.UpdateCustomMetaDataFields(customMetaDataFieldUpdateRequest);
        }

        public ResultNoContent DeleteFileVersion(DeleteFileVersionRequest deleteFileVersionRequest)
        {
            return (ResultNoContent)this.restClient.DeleteFileVersion(deleteFileVersionRequest);
        }

        public ResultNoContent CopyFile(CopyFileRequest copyFileRequest)
        {
            return (ResultNoContent)this.restClient.CopyFile(copyFileRequest);
        }

        public ResultNoContent MoveFile(MoveFileRequest moveFileRequest)
        {
            return (ResultNoContent)this.restClient.MoveFile(moveFileRequest);
        }

        public ResultRenameFile RenameFile(RenameFileRequest renameFileRequest)
        {
            return (ResultRenameFile)this.restClient.RenameFile(renameFileRequest);
        }

        public Result RestoreFileVersion(string fileId, string versionId)
        {
            return (Result)this.restClient.RestoreFileVersion(fileId, versionId);
        }

        public ResultEmptyBlock CreateFolder(CreateFolderRequest createFolderRequest)
        {
            return (ResultEmptyBlock)this.restClient.CreateFolder(createFolderRequest);
        }

        public ResultNoContent DeleteFolder(DeleteFolderRequest deleteFolderRequest)
        {
            return (ResultNoContent)this.restClient.DeleteFolder(deleteFolderRequest);
        }

        public ResultOfFolderActions CopyFolder(CopyFolderRequest copyFolderRequest)
        {
            return (ResultOfFolderActions)this.restClient.CopyFolder(copyFolderRequest);
        }

        public ResultOfFolderActions MoveFolder(MoveFolderRequest moveFolderRequest)
        {
            return (ResultOfFolderActions)this.restClient.MoveFolder(moveFolderRequest);
        }

        public ResultBulkJobStatus GetBulkJobStatus(string jobId)
        {
            return (ResultBulkJobStatus)this.restClient.GetBulkJobStatus(jobId);
        }

        public ResultFileVersions GetFileVersions(string fileId)
        {
            return (ResultFileVersions)this.restClient.GetFileVersions(fileId);
        }

        public ResultFileVersionDetails GetFileVersionDetails(string fileId, string versionId)
        {
            return (ResultFileVersionDetails)this.restClient.GetFileVersionDetails(fileId, versionId);
        }

        public async Task<Result> UploadAsync(FileCreateRequest fileCreateRequest)
        {
            return (Result)await this.restClient.UploadAsync(fileCreateRequest);
        }

        public async Task<ResponseMetaData> GetFileDetailAsync(string fileId)
        {
            return await this.restClient.GetFileDetailAsync(fileId);
        }

        public async Task<Result> GetFileMetadataAsync(string fileId)
        {
            return (Result)await this.restClient.GetFileMetaDataAsync(fileId);
        }

        public async Task<ResultMetaData> GetRemoteFileMetadataAsync(string url)
        {
            return (ResultMetaData)await this.restClient.GetRemoteFileMetaDataAsync(url);
        }

        public async Task<ResultDelete> DeleteFileAsync(string fileId)
        {
            return (ResultDelete)await this.restClient.DeleteFileAsync(fileId);
        }

        public async Task<ResultFileDelete> BulkDeleteFilesAsync(List<string> fileIds)
        {
            return (ResultFileDelete)await this.restClient.BulkDeleteFilesAsync(fileIds);
        }

        public async Task<ResultTags> AddTagsAsync(TagsRequest tagsRequest)
        {
            return (ResultTags)await this.restClient.ManageTagsAsync(tagsRequest, "addTags");
        }

        public async Task<ResultTags> RemoveAITagsAsync(AITagsRequest aITagsRequest)
        {
            return (ResultTags)await this.restClient.RemoveAITagsAsync(aITagsRequest);
        }

        public async Task<ResultTags> RemoveTagsAsync(TagsRequest tagsRequest)
        {
            return (ResultTags)await this.restClient.ManageTagsAsync(tagsRequest, "removeTags");
        }

        public async Task<ResultCustomMetaDataFieldList> GetCustomMetaDataFieldsAsync(bool includeDeleted)
        {
            return (ResultCustomMetaDataFieldList)await this.restClient.GetCustomMetaDataFieldsAsync(includeDeleted);
        }

        public async Task<ResultCustomMetaDataField> CreateCustomMetaDataFieldsAsync(
           CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest)
        {
            return (ResultCustomMetaDataField)await this.restClient.CreateCustomMetaDataFieldsAsync(customMetaDataFieldCreateRequest);
        }

        public async Task<ResultNoContent> DeleteCustomMetaDataFieldAsync(string id)
        {
            return (ResultNoContent)await this.restClient.DeleteCustomMetaDataFieldAsync(id);
        }

        public async Task<ResultCustomMetaDataField> UpdateCustomMetaDataFieldsAsync(
           CustomMetaDataFieldUpdateRequest customMetaDataFieldUpdateRequest)
        {
            return (ResultCustomMetaDataField)await this.restClient.UpdateCustomMetaDataFieldsAsync(customMetaDataFieldUpdateRequest);
        }

        public async Task<ResultNoContent> DeleteFileVersionAsync(DeleteFileVersionRequest deleteFileVersionRequest)
        {
            return (ResultNoContent)await this.restClient.DeleteFileVersionAsync(deleteFileVersionRequest);
        }

        public async Task<ResultNoContent> CopyFileAsync(CopyFileRequest copyFileRequest)
        {
            return (ResultNoContent)await this.restClient.CopyFileAsync(copyFileRequest);
        }

        public async Task<ResultNoContent> MoveFileAsync(MoveFileRequest moveFileRequest)
        {
            return (ResultNoContent)await this.restClient.MoveFileAsync(moveFileRequest);
        }

        public async Task<ResponseMetaData> RenameFileAsync(RenameFileRequest renameFileRequest)
        {
            return await this.restClient.RenameFileAsync(renameFileRequest);
        }

        public async Task<ResultRenameFile> RestoreFileVersionAsync(string fileId, string versionId)
        {
            return (ResultRenameFile)await this.restClient.RestoreFileVersionAsync(fileId, versionId);
        }

        public async Task<ResultEmptyBlock> CreateFolderAsync(CreateFolderRequest createFolderRequest)
        {
            return (ResultEmptyBlock)await this.restClient.CreateFolderAsync(createFolderRequest);
        }

        public async Task<ResultNoContent> DeleteFolderAsync(DeleteFolderRequest deleteFolderRequest)
        {
            return (ResultNoContent)await this.restClient.DeleteFolderAsync(deleteFolderRequest);
        }

        public async Task<ResultOfFolderActions> CopyFolderAsync(CopyFolderRequest copyFolderRequest)
        {
            return (ResultOfFolderActions)await this.restClient.CopyFolderAsync(copyFolderRequest);
        }

        public async Task<ResponseMetaData> MoveFolderAsync(MoveFolderRequest moveFolderRequest)
        {
            return await this.restClient.MoveFolderAsync(moveFolderRequest);
        }

        public async Task<ResultOfFolderActions> GetBulkJobStatusAsync(string jobId)
        {
            return (ResultOfFolderActions)await this.restClient.GetBulkJobStatusAsync(jobId);
        }

        public async Task<ResultFileVersions> GetFileVersionsAsync(string fileId)
        {
            return (ResultFileVersions)await this.restClient.GetFileVersionsAsync(fileId);
        }

        public async Task<ResultFileVersionDetails> GetFileVersionDetailsAsync(string fileId, string versionId)
        {
            return (ResultFileVersionDetails)await this.restClient.GetFileVersionDetailsAsync(fileId, versionId);
        }

        public async Task<ResultList> GetFileListRequestAsync(GetFileListRequest getFileListRequest)
        {
            return (ResultList)await this.restClient.GetFileListRequestAsync(getFileListRequest);
        }

        public int PHashDistance(string firstHex, string secondHex)
        {
            return Calculation.GetHammingDistance(firstHex, secondHex);
        }
    }
}