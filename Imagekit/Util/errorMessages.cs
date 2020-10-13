namespace Imagekit.Util
{
    public class errorMessages
    {
        public const string MANDATORY_INITIALIZATION_MISSING = "{ \"message\": \"Missing publicKey or privateKey or urlEndpoint during ImageKit initialization\", \"help\": \"\" }";
        public const string MANDATORY_PUBLIC_KEY_MISSING = "{ \"message\": \"Missing publicKey during ImageKit initialization\", \"help\": \"\" }";
        public const string PRIVATE_KEY_MISSING = "{ \"message\": \"Missing privateKey during ImageKit initialization\", \"help\": \"\" }";
        public const string MANDATORY_URL_ENDPOINT_KEY_MISSING = "{ \"message\": \"Missing urlEndpoint during ImageKit initialization\", \"help\": \"\" }";
        public const string INVALID_TRANSFORMATION_POSITION = "{ \"message\": \"Invalid transformationPosition parameter\", \"help\": \"\" }";
        public const string CACHE_PURGE_URL_MISSING = "{ \"message\": \"Missing URL parameter for this request\", \"help\": \"\" }";
        public const string CACHE_PURGE_STATUS_ID_MISSING = "{ message: \"Missing Request ID parameter for this request\", \"help\": \"\" }";
        public const string FILE_ID_MISSING = "{ \"message\": \"Missing File ID parameter for this request\", \"help\": \"\" }";
        public const string INVALID_URI = "{ \"message\": \"Invalid URI\", \"help\": \"Only HTTP or HTTPS Type Absolute URL are valid.\" }";
        public const string UPDATE_DATA_MISSING = "{ \"message\": \"Missing file update data for this request\", \"help\": \"\" }";
        public const string UPDATE_DATA_TAGS_INVALID = "{ \"message\": \"Invalid tags parameter for this request\", \"help\": \"tags should be passed as 'null', a string like 'tag1,tag2', or an array like (new string[] { 'tag1', 'tag2' })\" }";
        public const string UPDATE_DATA_COORDS_INVALID = "{ \"message\": \"Invalid customCoordinates parameter for this request\", \"help\": \"customCoordinates should be passed as null or a string like 'x,y,width,height'\" }";
        public const string LIST_FILES_INPUT_MISSING = "{ \"message\": \"Missing options for list files\", \"help\": \"If you do not want to pass any parameter for listing, pass an empty object\" }";
        public const string MISSING_UPLOAD_DATA = "{ \"message\": \"Missing data for upload\", \"help\": \"\" }";
        public const string MISSING_UPLOAD_FILE_PARAMETER = "{ \"message\": \"Missing file parameter for upload\", \"help\": \"\" }";
        public const string MISSING_UPLOAD_FILENAME_PARAMETER = "{ \"message\": \"Missing fileName parameter for upload\", \"help\": \"\" }";
        public const string INVALID_PHASH_VALUE = "{ \"message: \"Invalid pHash value\", \"help\": \"Both pHash strings must be valid hexadecimal numbers\" }";
        public const string MISSING_PHASH_VALUE = "{ \"message: \"Missing pHash value\", \"help\": \"Please pass two pHash values\" }";
        public const string UNEQUAL_STRING_LENGTH = "{ \"message: \"Unequal pHash string length\", \"help\": \"For distance calucation, the two pHash strings must have equal length\" }";
        public const string INVALID_FILEIDS_VALUE = "{ \"message: \"Invalid value for fileIds\", \"help\": \"fileIds should be an string array of fileId of the files to delete. The array should have atleast one fileId.\" }";
    }
};
