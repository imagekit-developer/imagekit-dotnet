
namespace Imagekit
{
    public class Client
    {
        public Client(string apiKey, string apiSecret, string imageKitID, bool useSubdomain=false, bool useSecure=false)
        {
            ApiKey = apiKey;
            ApiSecret = apiSecret;
            ImageKitId = imageKitID;
            UseSubdomain = useSubdomain;
            UseSecure = useSecure;
        }

        public string ImageKitId { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public bool UseSubdomain { get; set; }
        public bool UseSecure { get; set; }
    }
}
