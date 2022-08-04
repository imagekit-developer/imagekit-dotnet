// <copyright file="ImageKit.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Sdk
{
    using System.Collections.Generic;
    using global::Imagekit.Models;

    public interface IImageKit
    {
        ResponseMetaData AddTags(TagsRequest tagsRequest);

        ResponseMetaData BulkDeleteFiles(List<string> fileIds);

        ResponseMetaData CopyFile(CopyFileRequest copyFileRequest);

        ResponseMetaData CopyFolder(CopyFolderRequest copyFolderRequest);

        ResponseMetaData CreateCustomMetaDataFields(CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest);

        ResponseMetaData CreateFolder(CreateFolderRequest createFolderRequest);

        ResponseMetaData DeleteCustomMetaDataField(string id);

        ResponseMetaData DeleteFile(string fileId);

        ResponseMetaData DeleteFileVersion(DeleteFileVersionRequest deleteFileVersionRequest);

        ResponseMetaData DeleteFolder(DeleteFolderRequest deleteFolderRequest);

        ResponseMetaData GetBulkJobStatus(string jobId);

        ResponseMetaData GetCustomMetaDataFields(bool includeDeleted);

        ResponseMetaData GetFileDetail(string fileId);

        ResponseMetaData GetFileMetadata(string fileId);

        ResponseMetaData GetFileVersionDetails(string fileId, string versionId);

        ResponseMetaData GetFileVersions(string fileId);

        ResponseMetaData GetRemoteFileMetadata(string url);

        ResponseMetaData MoveFile(MoveFileRequest moveFileRequest);

        ResponseMetaData MoveFolder(MoveFolderRequest moveFolderRequest);

        ResponseMetaData RemoveAiTags(AiTagsRequest aiTagsRequest);

        ResponseMetaData RemoveTags(TagsRequest tagsRequest);

        ResponseMetaData RenameFile(RenameFileRequest renameFileRequest);

        ResponseMetaData RestoreFileVersion(string fileId, string versionId);

        ResponseMetaData UpdateCustomMetaDataFields(CustomMetaDataFieldUpdateRequest customMetaDataFieldUpdateRequest);

        ResponseMetaData Upload(FileCreateRequest fileCreateRequest);
    }
}