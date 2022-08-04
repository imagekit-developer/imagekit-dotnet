// <copyright file="UrlHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Constant
{
    public static class UrlHandler
    {
        public const string ApiBaseUrl = "https://api.imagekit.io/";
        public const string UploadBaseUrl = "https://dasdsad.dad.io/";
        public const string UploadFile = @"api/v1/files/upload";
        public const string GetFileRequest = @"v1/files/";
        public const string GetPurge = @"v1/files/purge";
        public const string GetPurgeStatus = @"v1/files/purge/{0}";
        public const string GetFileDetails = @"v1/files/{0}/details";
        public const string DeleteFile = @"v1/files/{0}/";
        public const string BulkDelete = @"v1/files/batch/deleteByFileIds";
        public const string GetMetaData = @"v1/files/{0}/metadata";
        public const string GetRemoteData = @"v1/metadata?url={0}";
        public const string RemoveTags = @"v1/files/removeTags";
        public const string AddTags = @"v1/files/addTags";
        public const string RemoveAiTags = @"v1/files/removeAITags";
        public const string CustomMetadataFields = @"v1/customMetadataFields?includeDeleted={0}";
        public const string CreareCustomMetaDataFields = @"v1/customMetadataFields";
        public const string DeleteCustomMetaDataFields = @"v1/customMetadataFields/{0}";
        public const string UpdateCustomMetadataFields = @"v1/customMetadataFields/{0}";
        public const string DeleteVesrion = @"v1/files/{0}/versions/{1}";
        public const string CopyFile = @"v1/files/copy";
        public const string MoveFile = @"v1/files/move";
        public const string RenameFile = @"v1/files/rename";
        public const string RestoreVesrion = @"v1/files/{0}/versions/{1}/restore";
        public const string CreateFolder = @"v1/folder/";
        public const string DeleteFolder = @"v1/folder/";
        public const string CopyFolder = @"v1/bulkJobs/moveFolder";
        public const string MoveFolder = @"v1/bulkJobs/moveFolder";
        public const string GetJobStatus = @"v1/bulkJobs/{0}";
        public const string GetFileVersion = @"v1/files/{0}/versions";
        public const string GetFileVersionDetail = @"v1/files/{0}/versions/{1}";
    }
}