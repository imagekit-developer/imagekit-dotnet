namespace Imagekit

{
    public partial class BaseImagekit<T>
    {
        public T Path(string value) { return Add("path", value); }
        public T Src(string value) { return Add("src", value); }
        public T UrlEndpoint(string value) { return Add("urlEndpoint", value); }
        public T Url(Transformation value) { return Add("transformation", value); }
        public T QueryParameters(params string[] value) { return Add("queryParameters", value); }
        public T TransformationPosition(string value) { return Add("transformationPosition", value); }
        public T Signed(bool value=true) { return Add("signed", value); }
        public T ExpireSeconds(int value) { return Add("expireSeconds", value); }

        public T Limit(int value = 1000) { return Add("limit", value); }
        public T Skip(int value = 0) { return Add("skip", value); }
        public T Name(string value) { return Add("name", value); }
        public T IncludeFolder(bool value = false) { return Add("includeFolder", value); }
        public T Tags(string value) { return Add("tags", value); }
        public T Tags(params string[] value) { return Add("tagsList", value); }
        public T FileType(string value = "all") { return Add("fileType", value); }
        public T Sort(string value) { return Add("sort", value); }
        public T SearchQuery(string value) { return Add("searchQuery", value); }

        public T FileName(string value) { return Add("fileName", value); }
        public T UseUniqueFileName(bool value = true) { return Add("useUniqueFileName", value); }
        public T Folder(string value = "/") { return Add("folder", value); }
        public T isPrivateFile(bool value = false) { return Add("isPrivateFile", value); }
        public T CustomCoordinates(string value) { return Add("customCoordinates", value); }
        public T ResponseFields(string value) { return Add("responseFields", value); }



        /// <summary>
        /// Add transformation parameter.
        /// </summary>
        /// <param name="key">The name.</param>
        /// <param name="value">The value.</param>
        public T Add(string key, object value)
        {
            if (options.ContainsKey(key))
                options[key] = value;
            else
                options.Add(key, value);

            return (T)this;
        }
    }
}
