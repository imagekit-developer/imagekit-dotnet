using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;
using System = System;

namespace ImageKit.Models.Assets;

/// <summary>
/// This API can list all the uploaded files and folders in your ImageKit.io media
/// library. In addition, you can fine-tune your query by specifying various filters
/// by generating a query string in a Lucene-like syntax and provide this generated
/// string as the value of the `searchQuery`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AssetListParams : ParamsBase
{
    /// <summary>
    /// Filter results by file type.
    ///
    /// <para>- `all` — include all file types   - `image` — include only image files
    ///   - `non-image` — include only non-image files (e.g., JS, CSS, video) </para>
    /// </summary>
    public ApiEnum<string, FileType>? FileType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, FileType>>("fileType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("fileType", value);
        }
    }

    /// <summary>
    /// The maximum number of results to return in response.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Folder path if you want to limit the search within a specific folder. For
    /// example, `/sales-banner/` will only search in folder sales-banner.
    ///
    /// <para>Note : If your use case involves searching within a folder as well as
    /// its subfolders, you can use `path` parameter in `searchQuery` with appropriate
    /// operator. Checkout [Supported parameters](/docs/api-reference/digital-asset-management-dam/list-and-search-assets#supported-parameters)
    /// for more information. </para>
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("path", value);
        }
    }

    /// <summary>
    /// Query string in a Lucene-like query language e.g. `createdAt > "7d"`.
    ///
    /// <para>Note : When the searchQuery parameter is present, the following query
    /// parameters will have no effect on the result:</para>
    ///
    /// <para>1. `tags` 2. `type` 3. `name`</para>
    ///
    /// <para>[Learn more](/docs/api-reference/digital-asset-management-dam/list-and-search-assets#advanced-search-queries)
    /// from examples. </para>
    /// </summary>
    public string? SearchQuery
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("searchQuery");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("searchQuery", value);
        }
    }

    /// <summary>
    /// The number of results to skip before returning results.
    /// </summary>
    public long? Skip
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("skip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("skip", value);
        }
    }

    /// <summary>
    /// Sort the results by one of the supported fields in ascending or descending
    /// order.
    /// </summary>
    public ApiEnum<string, Sort>? Sort
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Sort>>("sort");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("sort", value);
        }
    }

    /// <summary>
    /// Filter results by asset type.
    ///
    /// <para>- `file` — returns only files   - `file-version` — returns specific
    /// file versions   - `folder` — returns only folders   - `all` — returns both
    /// files and folders (excludes `file-version`) </para>
    /// </summary>
    public ApiEnum<string, global::ImageKit.Models.Assets.Type>? Type
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, global::ImageKit.Models.Assets.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("type", value);
        }
    }

    public AssetListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssetListParams(AssetListParams assetListParams)
        : base(assetListParams) { }
#pragma warning restore CS8618

    public AssetListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AssetListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static AssetListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(AssetListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/files")
        {
            Query = this.QueryString(options),
        }.Uri;
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

/// <summary>
/// Filter results by file type.
///
/// <para>- `all` — include all file types   - `image` — include only image files
///   - `non-image` — include only non-image files (e.g., JS, CSS, video) </para>
/// </summary>
[JsonConverter(typeof(FileTypeConverter))]
public enum FileType
{
    All,
    Image,
    NonImage,
}

sealed class FileTypeConverter : JsonConverter<FileType>
{
    public override FileType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => FileType.All,
            "image" => FileType.Image,
            "non-image" => FileType.NonImage,
            _ => (FileType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, FileType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileType.All => "all",
                FileType.Image => "image",
                FileType.NonImage => "non-image",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sort the results by one of the supported fields in ascending or descending order.
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    AscName,
    DescName,
    AscCreated,
    DescCreated,
    AscUpdated,
    DescUpdated,
    AscHeight,
    DescHeight,
    AscWidth,
    DescWidth,
    AscSize,
    DescSize,
    AscRelevance,
    DescRelevance,
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ASC_NAME" => Sort.AscName,
            "DESC_NAME" => Sort.DescName,
            "ASC_CREATED" => Sort.AscCreated,
            "DESC_CREATED" => Sort.DescCreated,
            "ASC_UPDATED" => Sort.AscUpdated,
            "DESC_UPDATED" => Sort.DescUpdated,
            "ASC_HEIGHT" => Sort.AscHeight,
            "DESC_HEIGHT" => Sort.DescHeight,
            "ASC_WIDTH" => Sort.AscWidth,
            "DESC_WIDTH" => Sort.DescWidth,
            "ASC_SIZE" => Sort.AscSize,
            "DESC_SIZE" => Sort.DescSize,
            "ASC_RELEVANCE" => Sort.AscRelevance,
            "DESC_RELEVANCE" => Sort.DescRelevance,
            _ => (Sort)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Sort value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Sort.AscName => "ASC_NAME",
                Sort.DescName => "DESC_NAME",
                Sort.AscCreated => "ASC_CREATED",
                Sort.DescCreated => "DESC_CREATED",
                Sort.AscUpdated => "ASC_UPDATED",
                Sort.DescUpdated => "DESC_UPDATED",
                Sort.AscHeight => "ASC_HEIGHT",
                Sort.DescHeight => "DESC_HEIGHT",
                Sort.AscWidth => "ASC_WIDTH",
                Sort.DescWidth => "DESC_WIDTH",
                Sort.AscSize => "ASC_SIZE",
                Sort.DescSize => "DESC_SIZE",
                Sort.AscRelevance => "ASC_RELEVANCE",
                Sort.DescRelevance => "DESC_RELEVANCE",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter results by asset type.
///
/// <para>- `file` — returns only files   - `file-version` — returns specific file
/// versions   - `folder` — returns only folders   - `all` — returns both files and
/// folders (excludes `file-version`) </para>
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    File,
    FileVersion,
    Folder,
    All,
}

sealed class TypeConverter : JsonConverter<global::ImageKit.Models.Assets.Type>
{
    public override global::ImageKit.Models.Assets.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file" => global::ImageKit.Models.Assets.Type.File,
            "file-version" => global::ImageKit.Models.Assets.Type.FileVersion,
            "folder" => global::ImageKit.Models.Assets.Type.Folder,
            "all" => global::ImageKit.Models.Assets.Type.All,
            _ => (global::ImageKit.Models.Assets.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::ImageKit.Models.Assets.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::ImageKit.Models.Assets.Type.File => "file",
                global::ImageKit.Models.Assets.Type.FileVersion => "file-version",
                global::ImageKit.Models.Assets.Type.Folder => "folder",
                global::ImageKit.Models.Assets.Type.All => "all",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
