using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;
using System = System;

namespace ImageKit.Models.Files;

/// <summary>
/// ImageKit.io allows you to upload files directly from both the server and client
/// sides. For server-side uploads, private API key authentication is used. For client-side
/// uploads, generate a one-time `token`, `signature`, and `expire` from your secure
/// backend using private API. [Learn more](/docs/api-reference/upload-file/upload-file#how-to-implement-client-side-file-upload)
/// about how to implement client-side file upload.
///
/// <para>The [V2 API](/docs/api-reference/upload-file/upload-file-v2) enhances security
/// by verifying the entire payload using JWT.</para>
///
/// <para>**File size limit** \ On the free plan, the maximum upload file sizes are
/// 20MB for images, audio, and raw files and 100MB for videos. On the paid plan,
/// these limits increase to 40MB for images, audio, and raw files and 2GB for videos.
/// These limits can be further increased with higher-tier plans.</para>
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
    /// 8 seconds; otherwise the request fails with 400 Bad Request. </para>
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
    /// The name with which the file has to be uploaded. The file name can contain:
    ///
    /// <para>  - Alphanumeric Characters: `a-z`, `A-Z`, `0-9`.   - Special Characters:
    /// `.`, `-`</para>
    ///
    /// <para>Any other character including space will be replaced by `_` </para>
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
    /// A unique value that the ImageKit.io server will use to recognize and prevent
    /// subsequent retries for the same request. We suggest using V4 UUIDs, or another
    /// random string with enough entropy to avoid collisions. This field is only
    /// required for authentication when uploading a file from the client side.
    ///
    /// <para>**Note**: Sending a value that has been used in the past will result
    /// in a validation error. Even if your previous request resulted in an error,
    /// you should always send a new value for this field. </para>
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
    /// Server-side checks to run on the asset. Read more about [Upload API checks](/docs/api-reference/upload-file/upload-file#upload-api-checks).
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
    /// will be removed. </para>
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
    /// The time until your signature is valid. It must be a [Unix time](https://en.wikipedia.org/wiki/Unix_time)
    /// in less than 1 hour into the future. It should be in seconds. This field
    /// is only required for authentication when uploading a file from the client
    /// side.
    /// </summary>
    public long? Expire
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("expire");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("expire", value);
        }
    }

    /// <summary>
    /// Array of extensions to be applied to the asset. Each extension can be configured
    /// with specific parameters based on the extension type.
    /// </summary>
    public IReadOnlyList<UnnamedSchemaWithArrayParent0>? Extensions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<UnnamedSchemaWithArrayParent0>
            >("extensions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0>?>(
                "extensions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The folder path in which the image has to be uploaded. If the folder(s) didn't
    /// exist before, a new folder(s) is created.
    ///
    /// <para>The folder name can contain:</para>
    ///
    /// <para>  - Alphanumeric Characters: `a-z` , `A-Z` , `0-9`   - Special Characters:
    /// `/` , `_` , `-`</para>
    ///
    /// <para>Using multiple `/` creates a nested folder. </para>
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
    /// named transformation or signed URL. </para>
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
    /// pricing plans. </para>
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
    /// Your ImageKit.io public key. This field is only required for authentication
    /// when uploading a file from the client side.
    /// </summary>
    public string? PublicKey
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("publicKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("publicKey", value);
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
    /// HMAC-SHA1 digest of the token+expire using your ImageKit.io private API key
    /// as a key. Learn how to create a signature on the page below. This should
    /// be in lowercase.
    ///
    /// <para>Signature must be calculated on the server-side. This field is only
    /// required for authentication when uploading a file from the client side. </para>
    /// </summary>
    public string? Signature
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("signature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("signature", value);
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
    /// <para>You can mix and match any combination of post-processing types. </para>
    /// </summary>
    public Transformation? Transformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Transformation>("transformation");
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
    /// and any existing file with the same name is replaced. </para>
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/files/upload"
        )
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
        System::Type typeToConvert,
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
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configure pre-processing (`pre`) and post-processing (`post`) transformations.
///
/// <para>- `pre` — applied before the file is uploaded to the Media Library.
/// Useful for reducing file size or applying basic optimizations upfront (e.g.,
/// resize, compress).</para>
///
/// <para>- `post` — applied immediately after upload.     Ideal for generating transformed
/// versions (like video encodes or thumbnails) in advance, so they're ready for delivery
/// without delay.</para>
///
/// <para>You can mix and match any combination of post-processing types. </para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Transformation, TransformationFromRaw>))]
public sealed record class Transformation : JsonModel
{
    /// <summary>
    /// List of transformations to apply *after* the file is uploaded.   Each item
    /// must match one of the following types: `transformation`, `gif-to-video`, `thumbnail`,
    /// `abs`.
    /// </summary>
    public IReadOnlyList<Post>? Post
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Post>>("post");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Post>?>(
                "post",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Transformation string to apply before uploading the file to the Media Library.
    /// Useful for optimizing files at ingestion.
    /// </summary>
    public string? Pre
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pre");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pre", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Post ?? [])
        {
            item.Validate();
        }
        _ = this.Pre;
    }

    public Transformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transformation(Transformation transformation)
        : base(transformation) { }
#pragma warning restore CS8618

    public Transformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransformationFromRaw.FromRawUnchecked"/>
    public static Transformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransformationFromRaw : IFromRawJson<Transformation>
{
    /// <inheritdoc/>
    public Transformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transformation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PostConverter))]
public record class Post : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                transformation: (x) => x.Type,
                gifToVideo: (x) => x.Type,
                thumbnail: (x) => x.Type,
                abs: (x) => x.Type
            );
        }
    }

    public string? Value1
    {
        get
        {
            return Match<string?>(
                transformation: (x) => x.Value,
                gifToVideo: (x) => x.Value,
                thumbnail: (x) => x.Value,
                abs: (x) => x.Value
            );
        }
    }

    public Post(PostTransformation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Post(GifToVideo value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Post(Thumbnail value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Post(Abs value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Post(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PostTransformation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTransformation(out var value)) {
    ///     // `value` is of type `PostTransformation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTransformation([NotNullWhen(true)] out PostTransformation? value)
    {
        value = this.Value as PostTransformation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GifToVideo"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGifToVideo(out var value)) {
    ///     // `value` is of type `GifToVideo`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGifToVideo([NotNullWhen(true)] out GifToVideo? value)
    {
        value = this.Value as GifToVideo;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Thumbnail"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThumbnail(out var value)) {
    ///     // `value` is of type `Thumbnail`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThumbnail([NotNullWhen(true)] out Thumbnail? value)
    {
        value = this.Value as Thumbnail;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Abs"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAbs(out var value)) {
    ///     // `value` is of type `Abs`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAbs([NotNullWhen(true)] out Abs? value)
    {
        value = this.Value as Abs;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (PostTransformation value) => {...},
    ///     (GifToVideo value) => {...},
    ///     (Thumbnail value) => {...},
    ///     (Abs value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<PostTransformation> transformation,
        System::Action<GifToVideo> gifToVideo,
        System::Action<Thumbnail> thumbnail,
        System::Action<Abs> abs
    )
    {
        switch (this.Value)
        {
            case PostTransformation value:
                transformation(value);
                break;
            case GifToVideo value:
                gifToVideo(value);
                break;
            case Thumbnail value:
                thumbnail(value);
                break;
            case Abs value:
                abs(value);
                break;
            default:
                throw new ImageKitInvalidDataException("Data did not match any variant of Post");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (PostTransformation value) => {...},
    ///     (GifToVideo value) => {...},
    ///     (Thumbnail value) => {...},
    ///     (Abs value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<PostTransformation, T> transformation,
        System::Func<GifToVideo, T> gifToVideo,
        System::Func<Thumbnail, T> thumbnail,
        System::Func<Abs, T> abs
    )
    {
        return this.Value switch
        {
            PostTransformation value => transformation(value),
            GifToVideo value => gifToVideo(value),
            Thumbnail value => thumbnail(value),
            Abs value => abs(value),
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Post"),
        };
    }

    public static implicit operator Post(PostTransformation value) => new(value);

    public static implicit operator Post(GifToVideo value) => new(value);

    public static implicit operator Post(Thumbnail value) => new(value);

    public static implicit operator Post(Abs value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Post");
        }
        this.Switch(
            (transformation) => transformation.Validate(),
            (gifToVideo) => gifToVideo.Validate(),
            (thumbnail) => thumbnail.Validate(),
            (abs) => abs.Validate()
        );
    }

    public virtual bool Equals(Post? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            PostTransformation _ => 0,
            GifToVideo _ => 1,
            Thumbnail _ => 2,
            Abs _ => 3,
            _ => -1,
        };
    }
}

sealed class PostConverter : JsonConverter<Post>
{
    public override Post? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "transformation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PostTransformation>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "gif-to-video":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GifToVideo>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thumbnail":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Thumbnail>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "abs":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Abs>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Post(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Post value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<PostTransformation, PostTransformationFromRaw>))]
public sealed record class PostTransformation : JsonModel
{
    /// <summary>
    /// Transformation type.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Transformation string (e.g. `w-200,h-200`).   Same syntax as ImageKit URL-based
    /// transformations.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("transformation")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public PostTransformation()
    {
        this.Type = JsonSerializer.SerializeToElement("transformation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostTransformation(PostTransformation postTransformation)
        : base(postTransformation) { }
#pragma warning restore CS8618

    public PostTransformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("transformation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostTransformationFromRaw.FromRawUnchecked"/>
    public static PostTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PostTransformation(string value)
        : this()
    {
        this.Value = value;
    }
}

class PostTransformationFromRaw : IFromRawJson<PostTransformation>
{
    /// <inheritdoc/>
    public PostTransformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PostTransformation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<GifToVideo, GifToVideoFromRaw>))]
public sealed record class GifToVideo : JsonModel
{
    /// <summary>
    /// Converts an animated GIF into an MP4.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Optional transformation string to apply to the output video.   **Example**:
    /// `q-80`
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("gif-to-video")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public GifToVideo()
    {
        this.Type = JsonSerializer.SerializeToElement("gif-to-video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GifToVideo(GifToVideo gifToVideo)
        : base(gifToVideo) { }
#pragma warning restore CS8618

    public GifToVideo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("gif-to-video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GifToVideo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GifToVideoFromRaw.FromRawUnchecked"/>
    public static GifToVideo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GifToVideoFromRaw : IFromRawJson<GifToVideo>
{
    /// <inheritdoc/>
    public GifToVideo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GifToVideo.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Thumbnail, ThumbnailFromRaw>))]
public sealed record class Thumbnail : JsonModel
{
    /// <summary>
    /// Generates a thumbnail image.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Optional transformation string.   **Example**: `w-150,h-150`
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("thumbnail")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public Thumbnail()
    {
        this.Type = JsonSerializer.SerializeToElement("thumbnail");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Thumbnail(Thumbnail thumbnail)
        : base(thumbnail) { }
#pragma warning restore CS8618

    public Thumbnail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thumbnail");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Thumbnail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThumbnailFromRaw.FromRawUnchecked"/>
    public static Thumbnail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThumbnailFromRaw : IFromRawJson<Thumbnail>
{
    /// <inheritdoc/>
    public Thumbnail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Thumbnail.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Abs, AbsFromRaw>))]
public sealed record class Abs : JsonModel
{
    /// <summary>
    /// Streaming protocol to use (`hls` or `dash`).
    /// </summary>
    public required ApiEnum<string, Protocol> Protocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Protocol>>("protocol");
        }
        init { this._rawData.Set("protocol", value); }
    }

    /// <summary>
    /// Adaptive Bitrate Streaming (ABS) setup.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// List of different representations you want to create separated by an underscore.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Protocol.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("abs")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public Abs()
    {
        this.Type = JsonSerializer.SerializeToElement("abs");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Abs(Abs abs)
        : base(abs) { }
#pragma warning restore CS8618

    public Abs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("abs");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Abs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AbsFromRaw.FromRawUnchecked"/>
    public static Abs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AbsFromRaw : IFromRawJson<Abs>
{
    /// <inheritdoc/>
    public Abs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Abs.FromRawUnchecked(rawData);
}

/// <summary>
/// Streaming protocol to use (`hls` or `dash`).
/// </summary>
[JsonConverter(typeof(ProtocolConverter))]
public enum Protocol
{
    Hls,
    Dash,
}

sealed class ProtocolConverter : JsonConverter<Protocol>
{
    public override Protocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hls" => Protocol.Hls,
            "dash" => Protocol.Dash,
            _ => (Protocol)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Protocol value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Protocol.Hls => "hls",
                Protocol.Dash => "dash",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
