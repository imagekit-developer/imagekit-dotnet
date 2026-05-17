using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Dummy;
using Files = ImagekitDiversion.Models.Api.V1.Files;

namespace ImagekitDiversion.Models.Api.V2.Files;

/// <summary>
/// The V2 API enhances security by verifying the entire payload using JWT. This API
/// is in beta.
///
/// <para>ImageKit.io allows you to upload files directly from both the server and
/// client sides. For server-side uploads, private API key authentication is used.
/// For client-side uploads, generate a one-time `token` from your secure backend
/// using private API. [Learn more](/docs/api-reference/upload-file/upload-file-v2#how-to-implement-secure-client-side-file-upload)
/// about how to implement secure client-side file upload.</para>
///
/// <para>**File size limit** \ On the free plan, the maximum upload file sizes are
/// 25MB for images, audio, and raw files, and 100MB for videos. On the Lite paid
/// plan, these limits increase to 40MB for images, audio, and raw files and 300MB
/// for videos, whereas on the Pro paid plan, these limits increase to 50MB for images,
/// audio, and raw files and 2GB for videos. These limits can be further increased
/// with enterprise plans.</para>
///
/// <para>**Version limit** \ A file can have a maximum of 100 versions.</para>
///
/// <para>**Demo applications**</para>
///
/// <para>- A full-fledged [upload widget using Uppy](https://github.com/imagekit-samples/uppy-uploader),
/// supporting file selections from local storage, URL, Dropbox, Google Drive, Instagram,
/// and more. - [Quick start guides](/docs/quick-start-guides) for various frameworks
/// and technologies.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FileUploadParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The API accepts any of the following:
    ///
    /// <para>- **Binary data** – send the raw bytes as `multipart/form-data`. - **HTTP
    /// / HTTPS URL** – a publicly reachable URL that ImageKit’s servers can fetch.
    /// - **Base64 string** – the file encoded as a Base64 data URI or plain Base64.</para>
    ///
    /// <para>When supplying a URL, the server must receive the response headers within
    /// 8 seconds; otherwise the request fails with 400 Bad Request.</para>
    /// </summary>
    public required BinaryContent File
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<BinaryContent>("file");
        }
        init { this._rawBodyData.Set("file", value); }
    }

    /// <summary>
    /// The name with which the file has to be uploaded.
    /// </summary>
    public required string FileName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("fileName");
        }
        init { this._rawBodyData.Set("fileName", value); }
    }

    /// <summary>
    /// This is the client-generated JSON Web Token (JWT). The ImageKit.io server
    /// uses it to authenticate and check that the upload request parameters have
    /// not been tampered with after the token has been generated. Learn how to create
    /// the token on the page below. This field is only required for authentication
    /// when uploading a file from the client side.
    ///
    /// <para>**Note**: Sending a JWT that has been used in the past will result in
    /// a validation error. Even if your previous request resulted in an error, you
    /// should always send a new token.</para>
    ///
    /// <para>**⚠️Warning**: JWT must be generated on the server-side because it
    /// is generated using your account's private API key. This field is required
    /// for authentication when uploading a file from the client-side.</para>
    /// </summary>
    public string? Token
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("token");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("token", value);
        }
    }

    /// <summary>
    /// Server-side checks to run on the asset. Read more about [Upload API checks](/docs/api-reference/upload-file/upload-file-v2#upload-api-checks).
    /// </summary>
    public string? Checks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("checks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("checks", value);
        }
    }

    /// <summary>
    /// Define an important area in the image. This is only relevant for image type files.
    ///
    /// <para>  - To be passed as a string with the x and y coordinates of the top-left
    /// corner, and width and height of the area of interest in the format `x,y,width,height`.
    /// For example - `10,10,100,100`   - Can be used with fo-customtransformation.
    ///   - If this field is not specified and the file is overwritten, then customCoordinates
    /// will be removed.</para>
    /// </summary>
    public string? CustomCoordinates
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("customCoordinates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("customCoordinates", value);
        }
    }

    /// <summary>
    /// JSON key-value pairs to associate with the asset. Create the custom metadata
    /// fields before setting these values.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? CustomMetadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "customMetadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>?>(
                "customMetadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// Array of extensions to be applied to the asset. Each extension can be configured
    /// with specific parameters based on the extension type.
    /// </summary>
    public IReadOnlyList<ExtensionsItem>? Extensions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ExtensionsItem>>(
                "extensions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ExtensionsItem>?>(
                "extensions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The folder path in which the image has to be uploaded. If the folder(s) didn't
    /// exist before, a new folder(s) is created. Using multiple `/` creates a nested folder.
    /// </summary>
    public string? Folder
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("folder");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("folder", value);
        }
    }

    /// <summary>
    /// Whether to mark the file as private or not.
    ///
    /// <para>If `true`, the file is marked as private and is accessible only using
    /// named transformation or signed URL.</para>
    /// </summary>
    public bool? IsPrivateFile
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("isPrivateFile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("isPrivateFile", value);
        }
    }

    /// <summary>
    /// Whether to upload file as published or not.
    ///
    /// <para>If `false`, the file is marked as unpublished, which restricts access
    /// to the file only via the media library. Files in draft or unpublished state
    /// can only be publicly accessed after being published.</para>
    ///
    /// <para>The option to upload in draft state is only available in custom enterprise
    /// pricing plans.</para>
    /// </summary>
    public bool? IsPublished
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("isPublished");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("isPublished", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("overwriteAITags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("overwriteAITags", value);
        }
    }

    /// <summary>
    /// If the request does not have `customMetadata`, and a file already exists
    /// at the exact location, existing customMetadata will be removed.
    /// </summary>
    public bool? OverwriteCustomMetadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("overwriteCustomMetadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("overwriteCustomMetadata", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("overwriteFile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("overwriteFile", value);
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("overwriteTags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("overwriteTags", value);
        }
    }

    /// <summary>
    /// Array of response field keys to include in the API response body.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ResponseField>>? ResponseFields
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ResponseField>>
            >("responseFields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, ResponseField>>?>(
                "responseFields",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Set the tags while uploading the file. Provide an array of tag strings (e.g.
    /// `["tag1", "tag2", "tag3"]`). The combined length of all tag characters must
    /// not exceed 500, and the `%` character is not allowed. If this field is not
    /// specified and the file is overwritten, the existing tags will be removed.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Configure pre-processing (`pre`) and post-processing (`post`) transformations.
    ///
    /// <para>- `pre` — applied before the file is uploaded to the Media Library.
    ///     Useful for reducing file size or applying basic optimizations upfront
    /// (e.g., resize, compress).</para>
    ///
    /// <para>- `post` — applied immediately after upload.     Ideal for generating
    /// transformed versions (like video encodes or thumbnails) in advance, so they're
    /// ready for delivery without delay.</para>
    ///
    /// <para>You can mix and match any combination of post-processing types.</para>
    /// </summary>
    public Files::TransformationObject? Transformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Files::TransformationObject>(
                "transformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("transformation", value);
        }
    }

    /// <summary>
    /// Whether to use a unique filename for this file or not.
    ///
    /// <para>If `true`, ImageKit.io will add a unique suffix to the filename parameter
    /// to get a unique filename.</para>
    ///
    /// <para>If `false`, then the image is uploaded with the provided filename parameter,
    /// and any existing file with the same name is replaced.</para>
    /// </summary>
    public bool? UseUniqueFileName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("useUniqueFileName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("useUniqueFileName", value);
        }
    }

    /// <summary>
    /// The final status of extensions after they have completed execution will be
    /// delivered to this endpoint as a POST request. [Learn more](/docs/api-reference/digital-asset-management-dam/managing-assets/update-file-details#webhook-payload-structure)
    /// about the webhook payload structure.
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("webhookUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("webhookUrl", value);
        }
    }

    public FileUploadParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUploadParams(FileUploadParams fileUploadParams)
        : base(fileUploadParams)
    {
        this._rawBodyData = new(fileUploadParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FileUploadParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUploadParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FileUploadParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, MultipartJsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FileUploadParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v2/files/upload")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return MultipartJsonSerializer.Serialize(RawBodyData);
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(ResponseFieldConverter))]
public enum ResponseField
{
    Tags,
    CustomCoordinates,
    IsPrivateFile,
    EmbeddedMetadata,
    IsPublished,
    CustomMetadata,
    Metadata,
    SelectedFieldsSchema,
}

sealed class ResponseFieldConverter : JsonConverter<ResponseField>
{
    public override ResponseField Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tags" => ResponseField.Tags,
            "customCoordinates" => ResponseField.CustomCoordinates,
            "isPrivateFile" => ResponseField.IsPrivateFile,
            "embeddedMetadata" => ResponseField.EmbeddedMetadata,
            "isPublished" => ResponseField.IsPublished,
            "customMetadata" => ResponseField.CustomMetadata,
            "metadata" => ResponseField.Metadata,
            "selectedFieldsSchema" => ResponseField.SelectedFieldsSchema,
            _ => (ResponseField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResponseField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResponseField.Tags => "tags",
                ResponseField.CustomCoordinates => "customCoordinates",
                ResponseField.IsPrivateFile => "isPrivateFile",
                ResponseField.EmbeddedMetadata => "embeddedMetadata",
                ResponseField.IsPublished => "isPublished",
                ResponseField.CustomMetadata => "customMetadata",
                ResponseField.Metadata => "metadata",
                ResponseField.SelectedFieldsSchema => "selectedFieldsSchema",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
