using Newtonsoft.Json;

namespace Imagekit
{
    public class ImagekitResponse
    {
        [JsonProperty("field")]
        public string Field { get; set; }
        [JsonProperty("filePath")]
        public string FilePath { get; set; }
        [JsonProperty("fileType")]
        public string FileType { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("tags")]
        public string[] Tags { get; set; }
        [JsonProperty("isPrivateFile")]
        public bool IsPrivateFile { get; set; }
        [JsonProperty("customCoordinates")]
        public bool CustomCoordinates { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty("url")]
        public string URL { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("metadata")]
        public MetadataResponse Metadata { get; set; }
        [JsonProperty("exception")]
        public bool exception { get; set; }
        [JsonProperty("statusNumber")]
        public int statusNumber { get; set; }
        [JsonProperty("statusCode")]
        public string statusCode { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("help")]
        public string help { get; set; }
    }

    public class MetadataResponse
    {
        public int errorMessage;
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("hasColorProfile")]
        public bool HasColorProfile { get; set; }
        [JsonProperty("quality")]
        public int Quality { get; set; }
        [JsonProperty("hasTransparency")]
        public bool HasTransparency { get; set; }
        [JsonProperty("exif")]
        public Exif Exif { get; set; }
        [JsonProperty("exception")]
        public bool Exception { get; set; }
        [JsonProperty("statusNumber")]
        public int StatusNumber { get; set; }
        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("help")]
        public string help { get; set; }
        [JsonProperty("image")]
        public ImageData Image { get; set; }
        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }
        [JsonProperty("gps")]
        public Gps Gps { get; set; }
        [JsonProperty("interoperability")]
        public object Interoperability { get; set; }
        [JsonProperty("makernote")]
        public object Makernote { get; set; }
    }

    public class Gps
    {
        public string GPSLatitudeRef { get; set; }
        public int[] GPSLatitude { get; set; }
        public string GPSLongitudeRef { get; set; }
        public int[] GPSLongitude { get; set; }
        public int GPSAltitudeRef { get; set; }
        public int GPSAltitude { get; set; }
        public int[] GPSTimeStamp { get; set; }
        public string GPSImgDirectionRef { get; set; }
        public float GPSImgDirection { get; set; }
        public string GPSDateStamp { get; set; }
    }

    public class Exif
    {
        public string ExifVersion { get; set; }
        public int Flash { get; set; }
        public string FlashpixVersion { get; set; }
        public int ColorSpace { get; set; }
        public int ExifImageWidth { get; set; }
        public int ExifImageHeight { get; set; }
    }

    public class Thumbnail
    {
        public int Compression { get; set; }
        public int XResolution { get; set; }
        public int YResolution { get; set; }
        public int ResolutionUnit { get; set; }
        public int ThumbnailOffset { get; set; }
        public int ThumbnailLength { get; set; }
    }
    public class ImageData
    {
        public string ImageDescription { get; set; }
        public int Orientation { get; set; }
        public int XResolution { get; set; }
        public int YResolution { get; set; }
        public int ResolutionUnit { get; set; }
        public string Software { get; set; }
        public string ModifyDate { get; set; }
        public string Artist { get; set; }
        public string Copyright { get; set; }
        public int ExifOffset { get; set; }
    }

    public class PurgeAPIResponse
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }
        [JsonProperty("exception")]
        public bool exception { get; set; }
        [JsonProperty("statusNumber")]
        public int statusNumber { get; set; }
        [JsonProperty("statusCode")]
        public string statusCode { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("help")]
        public string help { get; set; }
    }

    public class PurgeCacheStatusResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("exception")]
        public bool exception { get; set; }
        [JsonProperty("statusNumber")]
        public int statusNumber { get; set; }
        [JsonProperty("statusCode")]
        public string statusCode { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("help")]
        public string help { get; set; }
    }

    public class DeleteAPIResponse
    {
        [JsonProperty("success")]
        public bool success { get; set; }
        [JsonProperty("exception")]
        public bool exception { get; set; }
        [JsonProperty("statusNumber")]
        public int statusNumber { get; set; }
        [JsonProperty("statusCode")]
        public string statusCode { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("help")]
        public string help { get; set; }
    }

    public class AuthParamResponse
    {
        [JsonProperty("token")]
        public string token { get; set; }
        [JsonProperty("expire")]
        public string expire { get; set; }
        [JsonProperty("signature")]
        public string signature { get; set; }
    }

    public class ListAPIResponse
    {
        [JsonProperty("fileId")]
        public string FileId { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("filePath")]
        public string FilePath { get; set; }
        [JsonProperty("tags")]
        public string[] Tags { get; set; }
        [JsonProperty("isPrivateFile")]
        public bool IsPrivateFile { get; set; }
        [JsonProperty("customCoordinates")]
        public string CustomCoordinates { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty("fileType")]
        public string FileType { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("help")]
        public string help { get; set; }
    }
}
