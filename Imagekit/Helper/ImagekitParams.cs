// <copyright file="ImagekitParams.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit
{
    using global::Imagekit.Helper;

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

        /// <summary>
        /// Add transformation parameter.
        /// </summary>
        /// <param name="key">The name.</param>
        /// <param name="value">The value.</param>
        public T Add(string key, object value)
        {
            if (this.options.ContainsKey(key))
            {
                this.options[key] = value;
                if (key == "transformation")
                {
                    this.options.Remove("path");
                    this.options.Remove("src");
                }
            }
            else
            {
                this.options.Add(key, value);
            }

            return (T)this;
        }
    }
}