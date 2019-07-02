using Newtonsoft.Json;

namespace Imagekit
{
    public class ImagekitResponse
    {
        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("fileFolder")]
        public string FileFolder { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty("url")]
        public string URL { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("transformation")]
        public string Transformation { get; set; }
        [JsonProperty("exception")]
        public bool exception { get; set; }
        [JsonProperty("statusNumber")]
        public int statusNumber { get; set; }
        [JsonProperty("statusCode")]
        public string statusCode { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
    }

    public class MetadataRespone
    { 
        public string format { get; set; }
        public int size { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public bool hasColorProfile { get; set; }
        public int quality { get; set; }
        public bool hasTransparency { get; set; }
        public Exif exif { get; set; }
        public bool exception { get; set; }
        public int statusNumber { get; set; }
        public string statusCode { get; set; }
        public string message { get; set; }
    }

    public class Exif
    {
        
        public ImageData image { get; set; }
        public string thumbnail { get; set; }
        public string gps { get; set; }
        public string interoperability { get; set; }
        public string makernote { get; set; }
    }
    public class ImageData
    {
        public int Orientation { get; set; }
        public int XResolution { get; set; }
        public int YResolution { get; set; }
        public int ResolutionUnit { get; set; }
        public int YCbCrPositioning { get; set; }
        public int ExifOffset { get; set; }
    }

    public class PurgeAPIResponse
    {
        [JsonProperty("requestId")]
        public string requestId { get; set; }
        [JsonProperty("exception")]
        public bool exception { get; set; }
        [JsonProperty("statusNumber")]
        public int statusNumber { get; set; }
        [JsonProperty("statusCode")]
        public string statusCode { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
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
    }

    public class ListAPIResponse
    {
        [JsonProperty("itemType")]
        public string itemType { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("itemPath")]
        public string itemPath { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("thumbnail")]
        public string thumbnail { get; set; }
        [JsonProperty("fileType")]
        public string fileType { get; set; }
    }

    public class ApiResponse
    {
        public int StatusCode { get; private set; }
        public string StatusDescription { get; private set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; private set; }

        public ApiResponse(int statusCode, string statusDescription)
        {
            this.StatusCode = statusCode;
            this.StatusDescription = statusDescription;
        }

        public ApiResponse(int statusCode, string statusDescription, string message)
            : this(statusCode, statusDescription)
        {
            this.Message = message;
        }
    }
}
