namespace Imagekit

{
    public partial class BaseImagekit
    {

        public BaseImagekit Path(string value) { return Add("path", value); }
        public BaseImagekit Src(string value) { return Add("src", value); }
        public BaseImagekit UrlEndpoint(string value) { return Add("urlEndpoint", value); }
        public BaseImagekit Url(Transformation value) { return Add("transformation", value); }
        public BaseImagekit QueryParameters(params string[] value) { return Add("queryParameters", value); }
        public BaseImagekit TransformationPosition(string value) { return Add("transformationPosition", value); }
        public BaseImagekit Signed(bool value=true) { return Add("signed", value); }
        public BaseImagekit ExpireSeconds(int value) { return Add("expireSeconds", value); }

        public BaseImagekit Limit(int value = 1000) { return Add("limit", value); }
        public BaseImagekit Skip(int value = 0) { return Add("skip", value); }
        public BaseImagekit Name(string value) { return Add("name", value); }
        public BaseImagekit IncludeFolder(bool value = false) { return Add("includeFolder", value); }
        public BaseImagekit Tags(string value) { return Add("tags", value); }
        public BaseImagekit Tags(params string[] value) { return Add("tagsList", value); }
        public BaseImagekit FileType(string value = "all") { return Add("fileType", value); }

        public BaseImagekit FileName(string value) { return Add("fileName", value); }
        public BaseImagekit UseUniqueFileName(bool value = true) { return Add("useUniqueFileName", value); }
        public BaseImagekit Folder(string value = "/") { return Add("folder", value); }
        public BaseImagekit IsPrivate(bool value = false) { return Add("isPrivateFile", value); }
        public BaseImagekit CustomCoordinates(string value) { return Add("customCoordinates", value); }
        public BaseImagekit ResponseFields(string value) { return Add("responseFields", value); }



        /// <summary>
        /// Add transformation parameter.
        /// </summary>
        /// <param name="key">The name.</param>
        /// <param name="value">The value.</param>
        public BaseImagekit Add(string key, object value)
        {
            if (options.ContainsKey(key))
                options[key] = value;
            else
                options.Add(key, value);

            return this;
        }
    }
}
