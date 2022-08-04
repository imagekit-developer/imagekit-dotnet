namespace Imagekit
{
    public partial class BaseImagekit<T>
    {
        public T Path(string value)
        {
            return this.Add("path", value);
        }

        public T Src(string value)
        {
            return this.Add("src", value);
        }

        public T UrlEndpoint(string value)
        {
            return this.Add("urlEndpoint", value);
        }

        public T Url(Transformation value)
        {
            return this.Add("transformation", value);
        }

        public T QueryParameters(params string[] value)
        {
            return this.Add("queryParameters", value);
        }

        public T TransformationPosition(string value)
        {
            return this.Add("transformationPosition", value);
        }

        public T Signed(bool value = true)
        {
            return this.Add("signed", value);
        }

        public T ExpireSeconds(int value)
        {
            return this.Add("expireSeconds", value);
        }

        public T Limit(int value = 1000)
        {
            return this.Add("limit", value);
        }

        public T Skip(int value = 0)
        {
            return this.Add("skip", value);
        }

        public T Name(string value)
        {
            return this.Add("name", value);
        }

        public T IncludeFolder(bool value = false)
        {
            return this.Add("includeFolder", value);
        }

        public T Tags(string value)
        {
            return this.Add("tags", value);
        }

        public T Tags(params string[] value)
        {
            return this.Add("tagsList", value);
        }

        public T FileType(string value = "all")
        {
            return this.Add("fileType", value);
        }

        public T Sort(string value)
        {
            return this.Add("sort", value);
        }

        public T SearchQuery(string value)
        {
            return this.Add("searchQuery", value);
        }

        public T FileName(string value)
        {
            return this.Add("fileName", value);
        }

        public T UseUniqueFileName(bool value = true)
        {
            return this.Add("useUniqueFileName", value);
        }

        public T Folder(string value = "/")
        {
            return this.Add("folder", value);
        }

        public T IsPrivateFile(bool value = false)
        {
            return this.Add("isPrivateFile", value);
        }

        public T CustomCoordinates(string value)
        {
            return this.Add("customCoordinates", value);
        }

        public T ResponseFields(string value)
        {
            return this.Add("responseFields", value);
        }

        /// <summary>
        /// Add transformation parameter.
        /// </summary>
        /// <param name="key">The name.</param>
        /// <param name="value">The value.</param>
        public T Add(string key, object value)
        {
            if (this.Options.ContainsKey(key))
            {
                this.Options[key] = value;
            }
            else
            {
                this.Options.Add(key, value);
            }

            return (T)this;
        }
    }
}
