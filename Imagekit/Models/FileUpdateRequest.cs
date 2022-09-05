namespace Imagekit.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class FileUpdateRequest
    {
        public string fileId { get; set; }
        public List<string> removeAITags;
        public string webhookUrl;
        public List<Extension> extensions;
        public List<string> tags;
        public string customCoordinates;
        public Hashtable customMetadata;
    }
}
