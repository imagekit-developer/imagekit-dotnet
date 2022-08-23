namespace Imagekit.Models
{
    using System.Collections.Generic;

    public class Extension
    {
        public string Name { get; set; }
    }

    public class Options
    {
        public bool Add_shadow { get; set; }

        public bool? Semitransparency { get; set; }

        public string? Bg_color { get; set; }

        public string? Bg_image_url { get; set; }
    }

    public class BackGroundImage : Extension
    {
        public Options Options { get; set; }
    }

    public class AutoTags : Extension
    {
        public int? MinConfidence { get; set; }

        public int? MaxTags { get; set; }
    }
}
