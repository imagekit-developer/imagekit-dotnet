namespace Imagekit.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class FileUpdateRequest
    {
        public string fileId { get; set; }

        public List<string> removeAITags { get; set; }

        public string webhookUrl { get; set; }

        public List<Extension> extensions { get; set; }

        public List<string> tags { get; set; }

        public string customCoordinates { get; set; }

        public Hashtable customMetadata { get; set; }

        public PublishStatus publish { get; set; }
    }
}
