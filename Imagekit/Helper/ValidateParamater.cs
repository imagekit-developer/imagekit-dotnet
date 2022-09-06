// <copyright file="ValidateParamater.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Helper
{
    using System.Collections.Generic;
    using global::Imagekit.Constant;
    using global::Imagekit.Models;

    public static class ValidateParamater
    {
        public static string IsValidateUpload(FileCreateRequest obj)
        {
            string flag = ErrorMessages.InvalidFileValue;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidFileUploadObjValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.fileName))
            {
                flag = ErrorMessages.MissingUploadFilenameParameter;
                return flag;
            }

            if (obj.file != null)
            {
                flag = string.Empty;
                return flag;
            }

            return flag;
        }

        public static bool IsValidateParam(string input)
        {
            bool flag = false;

            if (!string.IsNullOrEmpty(input))
            {
                flag = true;
                return flag;
            }

            return flag;
        }

        public static bool IsListCheck(List<string> input)
        {
            bool flag = false;

            if (input.Count > 0)
            {
                flag = true;
                return flag;
            }

            return flag;
        }

        public static string IsValidateTagRequest(TagsRequest obj)
        {
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidTagValue;
                return flag;
            }

            if (obj.tags == null)
            {
                flag = ErrorMessages.InvalidTagParamValue;
                return flag;
            }

            if (obj.fileIds == null)
            {
                flag = ErrorMessages.InvalidFiledParamValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateAiTagRequest(AITagsRequest obj)
        {
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidTagValue;
                return flag;
            }

            if (obj.AITags == null)
            {
                flag = ErrorMessages.InvalidTagParamValue;
                return flag;
            }

            if (obj.fileIds == null)
            {
                flag = ErrorMessages.InvalidFiledParamValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateCustomMetaDataFieldCreateRequest(CustomMetaDataFieldCreateRequest obj)
        {
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidMetaTagValue;
                return flag;
            }

            if (obj.schema == null)
            {
                flag = ErrorMessages.InvalidMetaTagSchemaValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.name))
            {
                flag = ErrorMessages.InvalidMetaTagNameValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.label))
            {
                flag = ErrorMessages.InvalidMetaTagLabelValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateCustomMetaDataFieldUpdateRequest(CustomMetaDataFieldUpdateRequest obj)
        {
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidMetaTagValue;
                return flag;
            }

            if (obj.schema == null)
            {
                flag = ErrorMessages.InvalidMetaTagSchemaValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.Id))
            {
                flag = ErrorMessages.InvalidMetaTagIdValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateDeleteFileVersionRequest(DeleteFileVersionRequest obj)
        {
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidDelVerValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.FileId))
            {
                flag = ErrorMessages.InvalidFieldIdDelVerValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.VersionId))
            {
                flag = ErrorMessages.InvalidVersionIdDelVerValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateCopyRequest(CopyFileRequest obj)
        {
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidMoveValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.sourceFilePath))
            {
                flag = ErrorMessages.InvalidSourceValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.destinationPath))
            {
                flag = ErrorMessages.InvalidDestinationValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateMoveRequest(MoveFileRequest obj)
        {
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidMoveValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.sourceFilePath))
            {
                flag = ErrorMessages.InvalidSourceValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.destinationPath))
            {
                flag = ErrorMessages.InvalidDestinationValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateRenameRequest(RenameFileRequest obj)
        {
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidRenameValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.filePath))
            {
                flag = ErrorMessages.InvalidRenameFilePathValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.newFileName))
            {
                flag = ErrorMessages.InvalidRenameNewFileNameValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateParam(string input, string versonid)
        {
            string flag = string.Empty;

            if (string.IsNullOrEmpty(input) && string.IsNullOrEmpty(versonid))
            {
                flag = ErrorMessages.InvalidDelVerValue;
                return flag;
            }

            if (string.IsNullOrEmpty(input))
            {
                flag = ErrorMessages.InvalidFieldIdDelVerValue;
                return flag;
            }

            if (string.IsNullOrEmpty(versonid))
            {
                flag = ErrorMessages.InvalidVersionIdDelVerValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateFolder(CreateFolderRequest createFolderRequest)
        {
            string flag = string.Empty;

            if (createFolderRequest == null)
            {
                flag = ErrorMessages.InvalidCreateFolderValue;
                return flag;
            }

            if (string.IsNullOrEmpty(createFolderRequest.folderName))
            {
                flag = ErrorMessages.InvalidfolderNameValue;
                return flag;
            }

            if (string.IsNullOrEmpty(createFolderRequest.parentFolderPath))
            {
                flag = ErrorMessages.InvalidFolderPathValue;
                return flag;
            }

            return flag;
        }

        public static bool IsValidateDeleteFolder(DeleteFolderRequest createFolderRequest)
        {
            bool flag = false;

            if (createFolderRequest == null)
            {
                return flag;
            }

            if (!string.IsNullOrEmpty(createFolderRequest.folderPath))
            {
                flag = true;
                return flag;
            }

            return flag;
        }

        public static string IsValidateCopyFolder(CopyFolderRequest createFolderRequest)
        {
            string flag = string.Empty;

            if (createFolderRequest == null)
            {
                flag = ErrorMessages.InvalidCopyFolderValue;
                return flag;
            }

            if (string.IsNullOrEmpty(createFolderRequest.sourceFolderPath))
            {
                flag = ErrorMessages.InvalidCopysourceFolderPathValue;
                return flag;
            }

            if (string.IsNullOrEmpty(createFolderRequest.destinationPath))
            {
                flag = ErrorMessages.InvalidCopydestinationPathValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateMoveFolder(MoveFolderRequest createFolderRequest)
        {
            string flag = string.Empty;

            if (createFolderRequest == null)
            {
                flag = ErrorMessages.InvalidCopyFolderValue;
                return flag;
            }

            if (string.IsNullOrEmpty(createFolderRequest.sourceFolderPath))
            {
                flag = ErrorMessages.InvalidCopysourceFolderPathValue;
                return flag;
            }

            if (string.IsNullOrEmpty(createFolderRequest.destinationPath))
            {
                flag = ErrorMessages.InvalidCopydestinationPathValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateUpdateFile(FileUpdateRequest obj)
        {
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.FileIdMissing;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.fileId))
            {
                flag = ErrorMessages.FileIdMissing;
                return flag;
            }

            return flag;
        }
    }
}
