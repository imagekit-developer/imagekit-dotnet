namespace Imagekit.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class FileUpdateRequest
    {
        private string fileId;
        private List<string> removeAITags;
        private string webhookUrl;
        private List<Extension> extensions;
        private List<string> tags;
        private string customCoordinates;
        private Hashtable customMetadata;

        public string FileId
        {
            get => this.fileId; set => this.fileId = value;
        }

        public List<string> RemoveAITags
        {
            get => this.removeAITags; set => this.removeAITags = value;
        }

        public List<string> Tags
        {
            get => this.tags; set => this.tags = value;
        }

        public List<Extension> Extensions
        {
            get => this.extensions; set => this.extensions = value;
        }

        public string CustomCoordinates
        {
            get => this.customCoordinates; set => this.customCoordinates = value;
        }

        public string WebhookUrl { get => this.webhookUrl; set => this.webhookUrl = value; }

        public Hashtable CustomMetadata { get => this.customMetadata; set => this.customMetadata = value; }
    }
}
