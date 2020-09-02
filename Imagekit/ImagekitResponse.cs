using Newtonsoft.Json;

namespace Imagekit
{
    public class ImagekitResponse
    {
        /// <summary>
        /// Unique fileId. Store this fileld in your database, as this will be used to perform update action on this file.
        /// </summary>
        [JsonProperty("fileId")]
        public string FileId { get; set; }

        // TODO: is this actually a property that is ever returned or was this a type of fileId, which was previously missing?
        [JsonProperty("field")]
        public string Field { get; set; }

        /// <summary>
        /// The path of the file uploaded. It includes any folder that you specified while uploading.
        /// </summary>
        [JsonProperty("filePath")]
        public string FilePath { get; set; }

        /// <summary>
        /// Type of file. It can either be `image` or `non-image`.
        /// </summary>
        [JsonProperty("fileType")]
        public string FileType { get; set; }

        /// <summary>
        /// Size of the uploaded file in bytes.
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Height of the uploaded image file. Only applicable when file type is image.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Width of the uploaded image file. Only applicable when file type is image.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Array of tags associated with the image.
        /// </summary>
        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        /// <summary>
        /// Is the file marked as private. It can be either true or false.
        /// </summary>
        [JsonProperty("isPrivateFile")]
        public bool IsPrivateFile { get; set; }

        /// <summary>
        /// Value of custom coordinates associated with the image in format x,y,width,height.
        /// </summary>
        [JsonProperty("customCoordinates")]
        public bool CustomCoordinates { get; set; }

        /// <summary>
        /// In case of an image, a small thumbnail URL.
        /// </summary>
        [JsonProperty("thumbnailUrl")]
        public string Thumbnail { get; set; }

        /// <summary>
        /// The URL of the file.
        /// </summary>
        [JsonProperty("url")]
        public string URL { get; set; }

        /// <summary>
        /// The name of the uploaded file.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The metadata of the upload file. Use responseFields property in request to get the metadata returned in response of upload API.
        /// </summary>
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
        public double[] GPSLatitude { get; set; }
        public string GPSLongitudeRef { get; set; }
        public double[] GPSLongitude { get; set; }
        public int GPSAltitudeRef { get; set; }
        public int GPSAltitude { get; set; }
        public double[] GPSTimeStamp { get; set; }
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
