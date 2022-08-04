// I've left this file with the name `Imagekit.cs` and the obsolete Imagekit in the same file to
// make the github differences easier to see for the PR. Any subsequent PR can rename this file
// and split out the obsolete Imagekit into its own file.

namespace Imagekit
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.RegularExpressions;

    [ExcludeFromCodeCoverage]
    public abstract partial class BaseImagekit<T> where T : BaseImagekit<T>
    {
        public Dictionary<string, object> Options = new Dictionary<string, object>();

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
            Transformation transformation = (Transformation)this.Options["transformation"];
            string tranformationString = transformation.Generate();
            return new Url(this.Options).UrlBuilder(tranformationString);
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
            string transformationPosition = "path") : base(publicKey, privateKey, urlEndpoint, transformationPosition)
        {
        }
    }
}
