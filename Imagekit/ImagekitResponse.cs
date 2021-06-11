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

        /// <summary>
        /// The exception status
        /// </summary>
        [JsonProperty("exception")]
        public bool Exception { get; set; }

        /// <summary>
        /// Status code of the API response
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        /// <summary>
        /// Error message from the API
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Help message in case of error
        /// </summary>
        [JsonProperty("help")]
        public string Help { get; set; }

        /// <summary>
        /// Request Id for API response debugging
        /// </summary>
        [JsonProperty("xikrequestid")]
        public string XIkRequestId { get; set; }
    }
    
    public class MetadataResponse
    {
        /// <summary>
        /// Format of the image
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Size of the image
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Image Height
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Image Width
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Color Profile Status
        /// </summary>
        [JsonProperty("hasColorProfile")]
        public bool HasColorProfile { get; set; }

        /// <summary>
        /// Image Quality
        /// </summary>
        [JsonProperty("quality")]
        public int Quality { get; set; }

        /// <summary>
        /// Image Density
        /// </summary>
        [JsonProperty("density")]
        public int Density { get; set; }

        /// <summary>
        /// Image Transparency in case of PNG
        /// </summary>
        [JsonProperty("hasTransparency")]
        public bool HasTransparency { get; set; }

        /// <summary>
        /// Phash value of the Image
        /// </summary>
        [JsonProperty("phash")]
        public string PHash { get; set; }

        /// <summary>
        /// Exif data of the Image
        /// </summary>
        [JsonProperty("exif")]
        public object Exif { get; set; }

        /// <summary>
        /// Exception status of API
        /// </summary>
        [JsonProperty("exception")]
        public bool Exception { get; set; }

        /// <summary>
        /// Status code of the API
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        /// <summary>
        /// Error message from the API
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Help message incase of Error
        /// </summary>
        [JsonProperty("help")]
        public string Help { get; set; }

        /// <summary>
        /// Type of the Error
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Request Id for API response debugging
        /// </summary>
        [JsonProperty("xikrequestid")]
        public string XIkRequestId { get; set; }
    }


    public class PurgeAPIResponse
    {
        /// <summary>
        /// Request Id for Purge 
        /// </summary>
        [JsonProperty("requestid")]
        public string RequestId { get; set; }

        /// <summary>
        /// Exception status of API
        /// </summary>
        [JsonProperty("exception")]
        public bool Exception { get; set; }

        /// <summary>
        /// Status code of the API
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        /// <summary>
        /// Error message from the API
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Help message incase of Error
        /// </summary>
        [JsonProperty("help")]
        public string Help { get; set; }

        /// <summary>
        /// Request Id for API response debugging
        /// </summary>
        [JsonProperty("xikrequestid")]
        public string XIkRequestId { get; set; }
    }

    public class PurgeCacheStatusResponse
    {
        /// <summary>
        /// Status of the Purge Cache Request
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Exception status of API
        /// </summary>
        [JsonProperty("exception")]
        public bool Exception { get; set; }

        /// <summary>
        /// Status code of the API
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        /// <summary>
        /// Error message from the API
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Help message incase of Error
        /// </summary>
        [JsonProperty("help")]
        public string Help { get; set; }

        /// <summary>
        /// Request Id for API response debugging
        /// </summary>
        [JsonProperty("xikrequestid")]
        public string XIkRequestId { get; set; }
    }

    public class DeleteAPIResponse
    {
        /// <summary>
        /// Exception status of API
        /// </summary>
        [JsonProperty("exception")]
        public bool Exception { get; set; }

        /// <summary>
        /// Status code of the API
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        /// <summary>
        /// Error message from the API
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Help message incase of Error
        /// </summary>
        [JsonProperty("help")]
        public string Help { get; set; }

        /// <summary>
        /// Request Id for API response debugging
        /// </summary>
        [JsonProperty("xikrequestid")]
        public string XIkRequestId { get; set; }
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

        /// <summary>The unique fileId of the uploaded file.</summary>
        [JsonProperty("fileId")]
        public string FileId { get; set; }

        /// <summary>Type of item. It can either be `file` or `folder`.</summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        
        /// <summary>Name of the file or folder.</summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// The relative path of the file. In the case of an image, you can use this path
        /// to construct different transformations.
        /// </summary>
        [JsonProperty("filePath")]
        public string FilePath { get; set; }
        
        /// <summary>Array of tags associated with the image. If no tags are set, this will be `null`.</summary>
        [JsonProperty("tags")]
        public string[] Tags { get; set; }
        
        /// <summary>Is the file marked as private. It can be either `true` or `false`.</summary>
        [JsonProperty("isPrivateFile")]
        public bool IsPrivateFile { get; set; }
        
        /// <summary>
        /// Value of custom coordinates associated with the image in format `x,y,width,height`.
        /// If customCoordinates are not defined, it will be `null`.
        /// </summary>
        [JsonProperty("customCoordinates")]
        public string CustomCoordinates { get; set; }
        
        /// <summary>A publicly accessible URL of the file.</summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        
        /// <summary>In case of an image, a small thumbnail URL.</summary>
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        /// <summary>The type of file, it could be either `image` or `non-image`.</summary>
        [JsonProperty("fileType")]
        public string FileType { get; set; }

        /// <summary>Mime Type of the file.</summary>
        [JsonProperty("mime")]
        public string Mime { get; set; }

        /// <summary>Width of the image.</summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>Height of the image.</summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>Size of the image.</summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>If PNG image has alpha channel.</summary>
        [JsonProperty("hasAlpha")]
        public bool HasAlpha { get; set; }

        /// <summary>The date and time when the file was first uploaded. The format is `YYYY-MM-DDTHH:mm:ss.sssZ`</summary>
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        /// <summary>The date and time when the file was first uploaded. The format is `YYYY-MM-DDTHH:mm:ss.sssZ`</summary>
        [JsonProperty("updateAt")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// Status code of the API request
        /// </summary>
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        /// <summary>
        /// API error message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// help message in case of error
        /// </summary>
        [JsonProperty("help")]
        public string Help { get; set; }

        /// <summary>
        /// Request Id for API response debugging
        /// </summary>
        [JsonProperty("xikrequestid")]
        public string XIkRequestId { get; set; }
    }
}
