using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagekit.Models
{
    public class GetFileListRequest
    {
        public string type { get; set; }
        public string sort { get; set; }
        public string path { get; set; }
        public string searchQuery { get; set; }
        public string fileType { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
        public string[] tags { get; set; }
    }
}
