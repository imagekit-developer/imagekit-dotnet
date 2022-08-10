// <copyright file="Constants.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Util
{
    public static class Constants
    {
        public const string TransformationParameter = "tr";
        public const string SignatureParameter = "ik-s";
        public const string TimestampParameter = "ik-t";
        public const string ChainTransformDelimiter = ":";
        public const string TransformDelimiter = ",";
        public const string TransformKeyValueDelimiter = "-";
        public const string DefaultTimestamp = "9999999999";
        public const string ProtocolQuery = @"/http[s]?\:\/\//";

        public const string HttpsProtocol = "https://";
        public const string HttpProtocol = "http://";
        public const string ApiHost = "api.imagekit.io";
        public const string UploadApiHost = "dasdasd.sadsdasd.io";
        public const string FileApi = "/v1/files";
        public const string UploadApi = "/api/v1/files/upload";
        public const string SdkVersion = "3.1.6";
    }
}