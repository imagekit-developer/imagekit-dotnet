using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
