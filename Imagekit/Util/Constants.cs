namespace Imagekit.Util
{
    public static class Constants
    {
        public const string TRANSFORMATION_PARAMETER = "tr";
        public const string SIGNATURE_PARAMETER = "ik-s";
        public const string TIMESTAMP_PARAMETER = "ik-t";
        public const string CHAIN_TRANSFORM_DELIMITER = ":";
        public const string TRANSFORM_DELIMITER = ",";
        public const string TRANSFORM_KEY_VALUE_DELIMITER = "-";
        public const string DEFAULT_TIMESTAMP = "9999999999";
        public const string PROTOCOL_QUERY = @"/http[s]?\:\/\//";

        public const string HTTPS_PROTOCOL = "https://";
        public const string HTTP_PROTOCOL = "http://";
        public const string API_HOST = "api.imagekit.io";
        public const string FILE_API = "/v1/files";
        public const string UPLOAD_API = "/v1/files/upload";

    }
}
