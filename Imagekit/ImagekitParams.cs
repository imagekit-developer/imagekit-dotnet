namespace Imagekit

{
    public partial class Imagekit
    {
        
        public Imagekit Path(string value) { return Add("path", value); }
        public Imagekit Src(string value) { return Add("src", value); }
        public Imagekit UrlEndpoint(string value) { return Add("urlEndpoint", value); }
        public Imagekit Url(Transformation value) { return Add("transformation", value); }
        public Imagekit QueryParameters(params string[] value) { return Add("queryParameters", value); }
        public Imagekit TransformationPosition(string value) { return Add("transformationPosition", value); }
        public Imagekit Signed(bool value=true) { return Add("signed", value); }
        public Imagekit ExpireSeconds(int value) { return Add("expireSeconds", value); }

        public Imagekit Limit(int value = 1000) { return Add("limit", value); }
        public Imagekit Skip(int value = 0) { return Add("skip", value); }
        public Imagekit Name(string value) { return Add("name", value); }
        public Imagekit IncludeFolder(bool value = false) { return Add("includeFolder", value); }
        public Imagekit Tags(string value) { return Add("tags", value); }
        public Imagekit Tags(params string[] value) { return Add("tagsList", value); }
        public Imagekit FileType(string value = "all") { return Add("fileType", value); }

        public Imagekit FileName(string value) { return Add("fileName", value); }
        public Imagekit UseUniqueFileName(string value = "true") { return Add("useUniqueFileName", value); }
        public Imagekit Folder(string value = "/") { return Add("folder", value); }
        public Imagekit IsPrivate(bool value = false) { return Add("isPrivate", value); }
        public Imagekit CustomCoordinates(string value) { return Add("customCoordinates", value); }
        public Imagekit ResponseFields(string value) { return Add("responseFields", value); }



        /// <summary>
        /// Add transformation parameter.
        /// </summary>
        /// <param name="key">The name.</param>
        /// <param name="value">The value.</param>
        public Imagekit Add(string key, object value)
        {
            if (options.ContainsKey(key))
                options[key] = value;
            else
                options.Add(key, value);

            return this;
        }
    }
}
