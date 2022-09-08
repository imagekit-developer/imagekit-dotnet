namespace Imagekit.Models
{
    using System.Collections.Generic;

    public class Extension
    {
        public string name { get; set; }
    }

    public class options
    {
        public bool add_shadow { get; set; }

        public bool? semitransparency { get; set; }

        public string? bg_color { get; set; }

        public string? bg_image_url { get; set; }
    }

    public class BackGroundImage : Extension
    {
        public options options { get; set; }
    }

    public class AutoTags : Extension
    {
        public int? minConfidence { get; set; }

        public int? maxTags { get; set; }
    }
}
