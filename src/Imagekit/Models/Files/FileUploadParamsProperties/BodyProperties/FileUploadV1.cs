using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using FileUploadV1Properties = Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties.FileUploadV1Properties;

namespace Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties;

[JsonConverter(typeof(ModelConverter<FileUploadV1>))]
public sealed record class FileUploadV1 : ModelBase, IFromRaw<FileUploadV1>
{
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
            if (!this.Properties.TryGetValue("file", out JsonElement element))
                throw new ArgumentOutOfRangeException("file", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("file");
        }
        set
        {
            this.Properties["file"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("fileName", out JsonElement element))
                throw new ArgumentOutOfRangeException("fileName", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("fileName");
        }
        set
        {
            this.Properties["fileName"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["token"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("checks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["checks"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("customCoordinates", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["customCoordinates"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("customMetadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["customMetadata"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("expire", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["expire"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of extensions to be applied to the image. Each extension can be configured
    /// with specific parameters based on the extension type.
    /// </summary>
    public List<FileUploadV1Properties::Extension>? Extensions
    {
        get
        {
            if (!this.Properties.TryGetValue("extensions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<FileUploadV1Properties::Extension>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["extensions"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("folder", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["folder"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("isPrivateFile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["isPrivateFile"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("isPublished", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["isPublished"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("overwriteAITags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["overwriteAITags"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("overwriteCustomMetadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["overwriteCustomMetadata"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("overwriteFile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["overwriteFile"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("overwriteTags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["overwriteTags"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("publicKey", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["publicKey"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of response field keys to include in the API response body.
    /// </summary>
    public List<ApiEnum<string, FileUploadV1Properties::ResponseField>>? ResponseFields
    {
        get
        {
            if (!this.Properties.TryGetValue("responseFields", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<
                ApiEnum<string, FileUploadV1Properties::ResponseField>
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["responseFields"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("signature", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["signature"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tags"] = JsonSerializer.SerializeToElement(
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
    public FileUploadV1Properties::Transformation? Transformation
    {
        get
        {
            if (!this.Properties.TryGetValue("transformation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<FileUploadV1Properties::Transformation?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["transformation"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("useUniqueFileName", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["useUniqueFileName"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("webhookUrl", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["webhookUrl"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.File;
        _ = this.FileName;
        _ = this.Token;
        _ = this.Checks;
        _ = this.CustomCoordinates;
        if (this.CustomMetadata != null)
        {
            foreach (var item in this.CustomMetadata.Values)
            {
                _ = item;
            }
        }
        _ = this.Description;
        _ = this.Expire;
        foreach (var item in this.Extensions ?? [])
        {
            item.Validate();
        }
        _ = this.Folder;
        _ = this.IsPrivateFile;
        _ = this.IsPublished;
        _ = this.OverwriteAITags;
        _ = this.OverwriteCustomMetadata;
        _ = this.OverwriteFile;
        _ = this.OverwriteTags;
        _ = this.PublicKey;
        foreach (var item in this.ResponseFields ?? [])
        {
            item.Validate();
        }
        _ = this.Signature;
        foreach (var item in this.Tags ?? [])
        {
            _ = item;
        }
        this.Transformation?.Validate();
        _ = this.UseUniqueFileName;
        _ = this.WebhookURL;
    }

    public FileUploadV1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUploadV1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FileUploadV1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
