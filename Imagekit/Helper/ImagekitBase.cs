// <copyright file="ImagekitBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.RegularExpressions;

    [ExcludeFromCodeCoverage]
    public abstract partial class BaseImagekit<T>
        where T : BaseImagekit<T>
    {
        public Dictionary<string, object> options = new Dictionary<string, object>();

        public BaseImagekit(string publicKey, string urlEndpoint, string transformationPosition = "path")
        {
            if (string.IsNullOrEmpty(publicKey))
            {
                throw new ArgumentNullException(nameof(publicKey));
            }

            if (string.IsNullOrEmpty(urlEndpoint))
            {
                throw new ArgumentNullException(nameof(urlEndpoint));
            }

            Regex rgx = new Regex("^(path|query)$");
            if (transformationPosition == null || !rgx.IsMatch(transformationPosition))
            {
                throw new Exception(Constant.ErrorMessages.InvalidTransformationPosition);
            }

            this.Add("publicKey", publicKey);
            this.Add("urlEndpoint", urlEndpoint);
            this.Add("transformationPosition", transformationPosition);
        }

        public string Generate()
        {
            Transformation transformation = (Transformation)this.options["transformation"];
            string tranformationString = transformation.Generate();
            return new Url(this.options).UrlBuilder(tranformationString);
        }
    }

    public class ServerImagekit : BaseImagekit<ServerImagekit>
    {
        public ServerImagekit(
            string publicKey,
            string privateKey,
            string urlEndpoint,
            string transformationPosition = "path")
            : base(publicKey, urlEndpoint, transformationPosition)
        {
            if (string.IsNullOrEmpty(privateKey))
            {
                throw new ArgumentNullException(nameof(privateKey));
            }

            this.Add("privateKey", privateKey);
        }
    }

    // Leaving this for backwards compatibility.
    // Renaming the class:
    // a) solves the issue where Imagekit must always be fully qualified since the name is the same as the assembly
    // b) allows for clarification between a server-side imagekit and a client-side imagekit
    [Obsolete("Use ServerImagekit")]
    public class Imagekit : ServerImagekit
    {
        public Imagekit(
            string publicKey,
            string privateKey,
            string urlEndpoint,
            string transformationPosition = "path")
            : base(publicKey, privateKey, urlEndpoint, transformationPosition)
        {
        }
    }
}
