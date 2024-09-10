namespace Imagekit.Models
{
    using System.Collections.Generic;

    public class PostTransformation
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public enum Protocol
    {
        hls,
        dash
    }

    public class TransformationObject : PostTransformation
    {
        public string type { get; } = "transformation";
        public string value { get; set; }
    }

    public class GifToVideoObject : PostTransformation
    {
        public string type { get; } = "gif-to-video";
        public string? value { get; set; }
    }
    public class ThumbnailObject : PostTransformation
    {
        public string type { get; } = "thumbnail";
        public string? value { get; set; }
    }

    public class AbsObject : PostTransformation
    {
        public string type { get; } = "abs";
        public string value { get; set; }
        public Protocol protocol { get; set; }
    }

    public class UploadTransformation
    {
        public string? pre { get; set; }
        public List<PostTransformation>? post { get; set; }
    }
    
}
