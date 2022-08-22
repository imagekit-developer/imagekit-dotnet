using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagekit.Models
{
    public class Extension
    {
        public string name { get; set; }
    }

    public class Options
    {
        public bool add_shadow { get; set; }
        public bool? semitransparency { get; set; }
        public string? bg_color { get; set; }
        public string? bg_image_url { get; set; }
    }

    public class Root
    {
        public List<Extension> extensions { get; set; }
    }

    public class BackGroundImage : Extension
    {
        public Options options { get; set; }
    }

    public class AutoTags : Extension
    {
        public string name { get; set; }
        public int? minConfidence { get; set; }
        public int? maxTags { get; set; }
    }
}
