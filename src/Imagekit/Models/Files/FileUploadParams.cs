using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using FileUploadParamsProperties = Imagekit.Models.Files.FileUploadParamsProperties;

namespace Imagekit.Models.Files;

/// <summary>
/// ImageKit.io allows you to upload files directly from both the server and client
/// sides. For server-side uploads, private API key authentication is used. For client-side
/// uploads, generate a one-time `token`, `signature`, and `expire` from your secure
/// backend using private API. [Learn more](/docs/api-reference/upload-file/upload-file#how-to-implement-client-side-file-upload)
/// about how to implement client-side file upload.
///
/// The [V2 API](/docs/api-reference/upload-file/upload-file-v2) enhances security
/// by verifying the entire payload using JWT.
///
/// **File size limit** \ On the free plan, the maximum upload file sizes are 20MB
/// for images, audio, and raw files and 100MB for videos. On the paid plan, these
/// limits increase to 40MB for images, audio, and raw files and 2GB for videos. These
/// limits can be further increased with higher-tier plans.
///
/// **Version limit** \ A file can have a maximum of 100 versions.
///
/// **Demo applications**
///
/// - A full-fledged [upload widget using Uppy](https://github.com/imagekit-samples/uppy-uploader),
/// supporting file selections from local storage, URL, Dropbox, Google Drive, Instagram,
/// and more. - [Quick start guides](/docs/quick-start-guides) for various frameworks
/// and technologies.
/// </summary>
public sealed record class FileUploadParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The API accepts any of the following:
    ///
    /// - **Binary data** – send the raw bytes as `multipart/form-data`. - **HTTP
    /// / HTTPS URL** – a publicly reachable URL that ImageKit’s servers can fetch.
    /// - **Base64 string** – the file encoded as a Base64 data URI or plain Base64.
    ///
    /// When supplying a URL, the server must receive the response headers within
    /// 8 seconds; otherwise the request fails with 400 Bad Request.
    /// </summary>
    public required string File
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("file", out JsonElement element))
                throw new ArgumentOutOfRangeException("file", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("file");
        }
        set
        {
            this.BodyProperties["file"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The name with which the file has to be uploaded. The file name can contain:
    ///
    ///   - Alphanumeric Characters: `a-z`, `A-Z`, `0-9`.   - Special Characters:
    /// `.`, `-`
    ///
    /// Any other character including space will be replaced by `_`
    /// </summary>
    public required string FileName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("fileName", out JsonElement element))
                throw new ArgumentOutOfRangeException("fileName", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("fileName");
        }
        set
        {
            this.BodyProperties["fileName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A unique value that the ImageKit.io server will use to recognize and prevent
    /// subsequent retries for the same request. We suggest using V4 UUIDs, or another
    /// random string with enough entropy to avoid collisions. This field is only
    /// required for authentication when uploading a file from the client side.
    ///
    /// **Note**: Sending a value that has been used in the past will result in a
    /// validation error. Even if your previous request resulted in an error, you
    /// should always send a new value for this field.
    /// </summary>
    public string? Token
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Server-side checks to run on the asset. Read more about [Upload API checks](/docs/api-reference/upload-file/upload-file#upload-api-checks).
    /// </summary>
    public string? Checks
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("checks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["checks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Define an important area in the image. This is only relevant for image type files.
    ///
    ///   - To be passed as a string with the x and y coordinates of the top-left
    /// corner, and width and height of the area of interest in the format `x,y,width,height`.
    /// For example - `10,10,100,100`   - Can be used with fo-customtransformation.
    ///   - If this field is not specified and the file is overwritten, then customCoordinates
    /// will be removed.
    /// </summary>
    public string? CustomCoordinates
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customCoordinates", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["customCoordinates"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// JSON key-value pairs to associate with the asset. Create the custom metadata
    /// fields before setting these values.
    /// </summary>
    public Dictionary<string, JsonElement>? CustomMetadata
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("customMetadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["customMetadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional text to describe the contents of the file.
    /// </summary>
    public string? Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time until your signature is valid. It must be a [Unix time](https://en.wikipedia.org/wiki/Unix_time)
    /// in less than 1 hour into the future. It should be in seconds. This field is
    /// only required for authentication when uploading a file from the client side.
    /// </summary>
    public long? Expire
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("expire", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["expire"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of extensions to be applied to the asset. Each extension can be configured
    /// with specific parameters based on the extension type.
    /// </summary>
    public List<FileUploadParamsProperties::Extension>? Extensions
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("extensions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<FileUploadParamsProperties::Extension>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["extensions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The folder path in which the image has to be uploaded. If the folder(s) didn't
    /// exist before, a new folder(s) is created.
    ///
    /// The folder name can contain:
    ///
    ///   - Alphanumeric Characters: `a-z` , `A-Z` , `0-9`   - Special Characters:
    /// `/` , `_` , `-`
    ///
    /// Using multiple `/` creates a nested folder.
    /// </summary>
    public string? Folder
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("folder", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["folder"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to mark the file as private or not.
    ///
    /// If `true`, the file is marked as private and is accessible only using named
    /// transformation or signed URL.
    /// </summary>
    public bool? IsPrivateFile
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("isPrivateFile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["isPrivateFile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to upload file as published or not.
    ///
    /// If `false`, the file is marked as unpublished, which restricts access to the
    /// file only via the media library. Files in draft or unpublished state can only
    /// be publicly accessed after being published.
    ///
    /// The option to upload in draft state is only available in custom enterprise
    /// pricing plans.
    /// </summary>
    public bool? IsPublished
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("isPublished", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["isPublished"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If set to `true` and a file already exists at the exact location, its AITags
    /// will be removed. Set `overwriteAITags` to `false` to preserve AITags.
    /// </summary>
    public bool? OverwriteAITags
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("overwriteAITags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["overwriteAITags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the request does not have `customMetadata`, and a file already exists at
    /// the exact location, existing customMetadata will be removed.
    /// </summary>
    public bool? OverwriteCustomMetadata
    {
        get
        {
            if (
                !this.BodyProperties.TryGetValue("overwriteCustomMetadata", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["overwriteCustomMetadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If `false` and `useUniqueFileName` is also `false`, and a file already exists
    /// at the exact location, upload API will return an error immediately.
    /// </summary>
    public bool? OverwriteFile
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("overwriteFile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["overwriteFile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the request does not have `tags`, and a file already exists at the exact
    /// location, existing tags will be removed.
    /// </summary>
    public bool? OverwriteTags
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("overwriteTags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["overwriteTags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Your ImageKit.io public key. This field is only required for authentication
    /// when uploading a file from the client side.
    /// </summary>
    public string? PublicKey
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("publicKey", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["publicKey"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of response field keys to include in the API response body.
    /// </summary>
    public List<ApiEnum<string, FileUploadParamsProperties::ResponseField>>? ResponseFields
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("responseFields", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<
                ApiEnum<string, FileUploadParamsProperties::ResponseField>
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["responseFields"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// HMAC-SHA1 digest of the token+expire using your ImageKit.io private API key
    /// as a key. Learn how to create a signature on the page below. This should be
    /// in lowercase.
    ///
    /// Signature must be calculated on the server-side. This field is only required
    /// for authentication when uploading a file from the client side.
    /// </summary>
    public string? Signature
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("signature", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["signature"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Set the tags while uploading the file. Provide an array of tag strings (e.g.
    /// `["tag1", "tag2", "tag3"]`). The combined length of all tag characters must
    /// not exceed 500, and the `%` character is not allowed. If this field is not
    /// specified and the file is overwritten, the existing tags will be removed.
    /// </summary>
    public List<string>? Tags
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["tags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configure pre-processing (`pre`) and post-processing (`post`) transformations.
    ///
    /// - `pre` — applied before the file is uploaded to the Media Library.     Useful
    /// for reducing file size or applying basic optimizations upfront (e.g., resize, compress).
    ///
    /// - `post` — applied immediately after upload.     Ideal for generating transformed
    /// versions (like video encodes or thumbnails) in advance, so they're ready for
    /// delivery without delay.
    ///
    /// You can mix and match any combination of post-processing types.
    /// </summary>
    public FileUploadParamsProperties::Transformation? Transformation
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("transformation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<FileUploadParamsProperties::Transformation?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["transformation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to use a unique filename for this file or not.
    ///
    /// If `true`, ImageKit.io will add a unique suffix to the filename parameter
    /// to get a unique filename.
    ///
    /// If `false`, then the image is uploaded with the provided filename parameter,
    /// and any existing file with the same name is replaced.
    /// </summary>
    public bool? UseUniqueFileName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("useUniqueFileName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["useUniqueFileName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The final status of extensions after they have completed execution will be
    /// delivered to this endpoint as a POST request. [Learn more](/docs/api-reference/digital-asset-management-dam/managing-assets/update-file-details#webhook-payload-structure)
    /// about the webhook payload structure.
    /// </summary>
    public string? WebhookURL
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("webhookUrl", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["webhookUrl"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/api/v1/files/upload")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IImageKitClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
