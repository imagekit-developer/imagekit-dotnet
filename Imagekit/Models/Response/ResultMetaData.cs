using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagekit.Models.Response
{
    [ExcludeFromCodeCoverage]
    public class ResultMetaData :ResponseMetaData
    {
        public string help { get; set; }

        public string raw { get; set; }
        public MetaData results { get; set; }
    }
}
