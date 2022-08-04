namespace Imagekit.Constant
{
    public static class ErrorMessages
    {
        public const string MandatoryInitializationMissing = "{ \"message\": \"Missing publicKey or privateKey or urlEndpoint during ImageKit initialization\", \"help\": \"\" }";
        public const string MandatoryPublicKeyMissing = "{ \"message\": \"Missing publicKey during ImageKit initialization\", \"help\": \"\" }";
        public const string PrivateKeyMissing = "{ \"message\": \"Missing privateKey during ImageKit initialization\", \"help\": \"\" }";
        public const string MandatoryUrlEndpointKeyMissing = "{ \"message\": \"Missing urlEndpoint during ImageKit initialization\", \"help\": \"\" }";
        public const string InvalidTransformationPosition = "{ \"message\": \"Invalid transformationPosition parameter\", \"help\": \"\" }";
        public const string CachePurgeUrlMissing = "{ \"message\": \"Missing URL parameter for this request\", \"help\": \"\" }";
        public const string CachePurgeStatusIdMissing = "{ message: \"Missing Request ID parameter for this request\", \"help\": \"\" }";
        public const string FileIdMissing = "{ \"message\": \"Missing File ID parameter for this request\", \"help\": \"\" }";
        public const string InvalidUri = "{ \"message\": \"Invalid URI\", \"help\": \"Only HTTP or HTTPS Type Absolute URL are valid.\" }";
        public const string UpdateDataMissing = "{ \"message\": \"Missing file update data for this request\", \"help\": \"\" }";
        public const string UpdateDataTagsInvalid = "{ \"message\": \"Invalid tags parameter for this request\", \"help\": \"tags should be passed as 'null', a string like 'tag1,tag2', or an array like (new string[] { 'tag1', 'tag2' })\" }";
        public const string UpdateDataCoordsInvalid = "{ \"message\": \"Invalid customCoordinates parameter for this request\", \"help\": \"customCoordinates should be passed as null or a string like 'x,y,width,height'\" }";
        public const string ListFilesInputMissing = "{ \"message\": \"Missing options for list files\", \"help\": \"If you do not want to pass any parameter for listing, pass an empty object\" }";
        public const string MissingUploadData = "{ \"message\": \"Missing data for upload\", \"help\": \"\" }";
        public const string MissingUploadFileParameter = "{ \"message\": \"Missing file parameter for upload\", \"help\": \"\" }";
        public const string InvalidPhashValue = "{ \"message: \"Invalid pHash value\", \"help\": \"Both pHash strings must be valid hexadecimal numbers\" }";
        public const string MissingPhashValue = "{ \"message: \"Missing pHash value\", \"help\": \"Please pass two pHash values\" }";
        public const string UnequalStringLength = "{ \"message: \"Unequal pHash string length\", \"help\": \"For distance calucation, the two pHash strings must have equal length\" }";
        public const string InvalidFileidsValue = "{ \"message: \"Invalid value for fileId\", \"help\": \"fileIds should be an string array of fileId of the files to delete. The array should have atleast one fileId.\" }";
        public const string InvalidUrlValue = "{ \"message: \"Missing URL parameter for this request\", \"help\": \"\" }";
        public const string InvalidCopyValue = "{ \"message: \"SourceFilePath and DestinationFilePath  both parameter are required\", \"help\": \"\" }";
        public const string InvalidJobValue = "{ \"message: \"JobId parameter are required\", \"help\": \"\" }";
        public const string InvalidFolderValue = "{ \"message: \"FilePath and NewFileName  both parameter are required\", \"help\": \"\" }";

        public const string MissingUploadFilenameParameter = "{ \"message\": \"Missing fileName parameter for upload\", \"help\": \"\" }";
        public const string InvalidMetaTagValue = "{ \"message: \"Invalid MetaData parameter for this request\", \"help\": \"\" }";
        public const string InvalidMetaTagNameValue = "{ \"message: \"Invalid MetaData name parameter for this request\", \"help\": \"\" }";

        public const string InvalidMetaTagLabelValue = "{ \"message: \"Invalid MetaData label parameter for this request\", \"help\": \"\" }";
        public const string InvalidMetaTagSchemaValue = "{ \"message: \"Invalid MetaData Schema parameter for this request\", \"help\": \"\" }";
        public const string InvalidDelVerValue = "{ \"message: \"FieldId and VersionId  both parameters are required\", \"help\": \"\" }";

        public const string InvalidFileUploadObjValue = "{ \"message: \"Missing data for upload\", \"help\": \"\" }";

        public const string InvalidFileValue = "{ \"message: \"Missing file parameter for upload\", \"help\": \"\" }";

        public const string InvalidTagValue = "{ \"message: \"Invalid  parameter for this request\", \"help\": \"\" }";

        public const string InvalidTagParamValue = "{ \"message: \"Invalid value for tags\", \"help\": \"tags should be a non empty array of string like ['tag1', 'tag2'].\" }";
        public const string InvalidFiledParamValue = "{ \"message: \"Invalid value for fileIds\", \"help\": \"fileIds should be an array of fileId of the files. The array should have atleast one fileId.\" }";

        public const string InvalidMetaTagIdValue = "{ \"message: \"Invalid MetaData Id parameter for this request\", \"help\": \"\" }";

        public const string InvalidFieldIdDelVerValue = "{ \"message: \"Missing fileId parameter for this request\", \"help\": \"\" }";
        public const string InvalidVersionIdDelVerValue = "{ \"message: \"Missing versionid parameter for this request\", \"help\": \"\" }";
        public const string InvalidMoveValue = "{ \"message: \"SourceFilePath and DestinationFilePath  both parameter are required\", \"help\": \"\" }";
        public const string InvalidSourceValue = "{ \"message: \"Missing SourceFilePath parameter for this request\", \"help\": \"\" }";
        public const string InvalidDestinationValue = "{ \"message: \"Missing DestinationFilePath parameter for this request\", \"help\": \"\" }";
        public const string InvalidDelFolderValue = "{ \"message: \"FolderPath parameter are required\", \"help\": \"\" }";

        public const string InvalidCreateFolderValue = "{ \"message: \"Missing FolderName and FolderPath parameters\", \"help\": \"\" }";
        public const string InvalidFolderNameValue = "{ \"message: \"Missing FolderName  parameters\", \"help\": \"\" }";
        public const string InvalidFolderPathValue = "{ \"message: \"Missing FolderPath parameters\", \"help\": \"\" }";

        public const string InvalidCopyFolderValue = "{ \"message: \"Missing FolderName and FolderPath parameters\", \"help\": \"\" }";
        public const string InvalidCopySourceFolderPathValue = "{ \"message: \"Missing SourceFolderPath  parameters\", \"help\": \"\" }";
        public const string InvalidCopyDestinationPathValue = "{ \"message: \"Missing DestinationPath parameters\", \"help\": \"\" }";

        public const string InvalidRenameValue = "{ \"message: \"FilePath and NewFileName  both parameters are required\", \"help\": \"\" }";
        public const string InvalidRenameFilePathValue = "{ \"message: \"Missing FilePath  parameters\", \"help\": \"\" }";
        public const string InvalidRenameNewFileNameValue = "{ \"message: \"Missing NewFileName parameters\", \"help\": \"\" }";
        public const string InvalidKey = "{ \"message: \"Missing API Key parameters\", \"help\": \"\" }";
        public const string InvalidApiUrl = "{ \"message: \"Missing API URL parameters\", \"help\": \"\" }";
        public const string InvalidPurgeUrl = "{ \"message: \"Missing Purge Request URL parameters\", \"help\": \"\" }";
    }
}
