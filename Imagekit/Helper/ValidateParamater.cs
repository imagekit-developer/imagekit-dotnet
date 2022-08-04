namespace Imagekit.Helper
{
    using System.Collections.Generic;
    using global::Imagekit.Constant;
    using global::Imagekit.Models;

    public static class ValidateParamater
    {
        public static string IsValidateUpload(FileCreateRequest obj)
        {
            bool isValidateUpload = false;
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidFileUploadObjValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.FileName))
            {
                flag = ErrorMessages.MissingUploadFilenameParameter;
                return flag;
            }

            if (!string.IsNullOrEmpty(obj.Base64))
            {
                isValidateUpload = true;

                return flag = string.Empty;
            }

            if (obj.Bytes != null)
            {
                isValidateUpload = true;
                return flag = string.Empty;
            }

            if (obj.Url != null)
            {
                isValidateUpload = true;
                return flag = string.Empty;
            }

            if (!isValidateUpload)
            {
                flag = ErrorMessages.InvalidFileValue;
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

            if (obj.Tags == null)
            {
                flag = ErrorMessages.InvalidTagParamValue;
                return flag;
            }

            if (obj.FileIds == null)
            {
                flag = ErrorMessages.InvalidFiledParamValue;
                return flag;
            }

            return flag;
        }

        public static string IsValidateAiTagRequest(AiTagsRequest obj)
        {
            string flag = string.Empty;
            if (obj == null)
            {
                flag = ErrorMessages.InvalidTagValue;
                return flag;
            }

            if (obj.AiTags == null)
            {
                flag = ErrorMessages.InvalidTagParamValue;
                return flag;
            }

            if (obj.FileIds == null)
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

            if (obj.Schema == null)
            {
                flag = ErrorMessages.InvalidMetaTagSchemaValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.Name))
            {
                flag = ErrorMessages.InvalidMetaTagNameValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.Label))
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

            if (obj.Schema == null)
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

            if (string.IsNullOrEmpty(obj.SourceFilePath))
            {
                flag = ErrorMessages.InvalidSourceValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.DestinationPath))
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

            if (string.IsNullOrEmpty(obj.SourceFilePath))
            {
                flag = ErrorMessages.InvalidSourceValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.DestinationPath))
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

            if (string.IsNullOrEmpty(obj.FilePath))
            {
                flag = ErrorMessages.InvalidRenameFilePathValue;
                return flag;
            }

            if (string.IsNullOrEmpty(obj.NewFileName))
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

            if (string.IsNullOrEmpty(createFolderRequest.FolderName))
            {
                flag = ErrorMessages.InvalidFolderNameValue;
                return flag;
            }

            if (string.IsNullOrEmpty(createFolderRequest.ParentFolderPath))
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

            if (!string.IsNullOrEmpty(createFolderRequest.FolderPath))
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

            if (string.IsNullOrEmpty(createFolderRequest.SourceFolderPath))
            {
                flag = ErrorMessages.InvalidCopySourceFolderPathValue;
                return flag;
            }

            if (string.IsNullOrEmpty(createFolderRequest.DestinationPath))
            {
                flag = ErrorMessages.InvalidCopyDestinationPathValue;
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

            if (string.IsNullOrEmpty(createFolderRequest.SourceFolderPath))
            {
                flag = ErrorMessages.InvalidCopySourceFolderPathValue;
                return flag;
            }

            if (string.IsNullOrEmpty(createFolderRequest.DestinationPath))
            {
                flag = ErrorMessages.InvalidCopyDestinationPathValue;
                return flag;
            }

            return flag;
        }
    }
}
