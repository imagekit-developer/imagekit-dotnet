using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagekit.Models.Response
{
    public class MetaData
    {
        public float height { get; set; }
        public float width { get; set; }
        public float size { get; set; }
        public string format { get; set; }
        public bool hasColorProfile { get; set; }
        public float quality { get; set; }
        public float density { get; set; }
        public bool hasTransparency { get; set; }
        public string pHash { get; set; }
    }
}
