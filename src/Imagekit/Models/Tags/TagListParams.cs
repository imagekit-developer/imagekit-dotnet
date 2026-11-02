using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Tags;

/// <summary>
/// This API lists the distinct tags in use across your media library, with the number
/// of assets each tag is applied to and when it was last used. Tags are matched case-insensitively,
/// so `Summer` and `summer` are one entry: `name` is the lowercased form and `label`
/// is the spelling that was used most recently.
///
/// <para>Use `tagSource` and `fileType` to list only the tags in use on matching
/// assets. `lastUsedAt` and the `ASC_LAST_USED` / `DESC_LAST_USED` sorts follow
/// those filters, while `assetCount` always counts every asset carrying the tag.
/// Use `search` or `prefix` to narrow the listing and `cursor` to page through it.</para>
///
/// <para>Tag counts are updated asynchronously. Changes to a file's tags usually
/// appear in this list within about a minute, but can take longer during heavy tagging
/// activity, so a tag you just added or removed may not be reflected immediately.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TagListParams : ParamsBase
{
    /// <summary>
    /// The `nextCursor` value from the previous response, to fetch the next page.
    /// A cursor is bound to the `tagSource`, `fileType`, `sort`, `search` and `prefix`
    /// it was issued with; sending it with different values returns a 400.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Filter tags by the type of asset they are applied to.
    ///
    /// <para>- `image` — tags in use on images   - `video` — tags in use on videos
    ///   - `static` — tags in use on any other file, such as documents, scripts
    /// and stylesheets   - `all` — tags in use on any asset </para>
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
    /// The maximum number of tags to return in response.
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
    /// Only return tags that begin with this value. Matching is case-insensitive.
    /// </summary>
    public string? Prefix
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("prefix", value);
        }
    }

    /// <summary>
    /// Only return tags that contain this text. Every word in the value must appear
    /// in the tag and the last word may be incomplete, which suits search-as-you-type.
    /// Matching is case-insensitive.
    /// </summary>
    public string? Search
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("search");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("search", value);
        }
    }

    /// <summary>
    /// Sort the results.
    ///
    /// <para>- `ASC_NAME` / `DESC_NAME` — by `name`   - `ASC_LAST_USED` / `DESC_LAST_USED`
    /// — by `lastUsedAt` within the requested `tagSource` and `fileType`, ties broken
    /// by `name` </para>
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
    /// Filter tags by who added them.
    ///
    /// <para>- `user` — tags added by users through the dashboard or the API   -
    /// `ai` — tags added by AI auto-tagging extensions   - `all` — both </para>
    /// </summary>
    public ApiEnum<string, TagSource>? TagSource
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, TagSource>>("tagSource");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("tagSource", value);
        }
    }

    public TagListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TagListParams(TagListParams tagListParams)
        : base(tagListParams) { }
#pragma warning restore CS8618

    public TagListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TagListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TagListParams FromRawUnchecked(
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

    public virtual bool Equals(TagListParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/tags")
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
/// Filter tags by the type of asset they are applied to.
///
/// <para>- `image` — tags in use on images   - `video` — tags in use on videos
///  - `static` — tags in use on any other file, such as documents, scripts and stylesheets
///   - `all` — tags in use on any asset </para>
/// </summary>
[JsonConverter(typeof(FileTypeConverter))]
public enum FileType
{
    Image,
    Video,
    Static,
    All,
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
            "image" => FileType.Image,
            "video" => FileType.Video,
            "static" => FileType.Static,
            "all" => FileType.All,
            _ => (FileType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, FileType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileType.Image => "image",
                FileType.Video => "video",
                FileType.Static => "static",
                FileType.All => "all",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Sort the results.
///
/// <para>- `ASC_NAME` / `DESC_NAME` — by `name`   - `ASC_LAST_USED` / `DESC_LAST_USED`
/// — by `lastUsedAt` within the requested `tagSource` and `fileType`, ties broken
/// by `name` </para>
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    AscName,
    DescName,
    AscLastUsed,
    DescLastUsed,
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
            "ASC_LAST_USED" => Sort.AscLastUsed,
            "DESC_LAST_USED" => Sort.DescLastUsed,
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
                Sort.AscLastUsed => "ASC_LAST_USED",
                Sort.DescLastUsed => "DESC_LAST_USED",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Filter tags by who added them.
///
/// <para>- `user` — tags added by users through the dashboard or the API   - `ai`
/// — tags added by AI auto-tagging extensions   - `all` — both </para>
/// </summary>
[JsonConverter(typeof(TagSourceConverter))]
public enum TagSource
{
    User,
    AI,
    All,
}

sealed class TagSourceConverter : JsonConverter<TagSource>
{
    public override TagSource Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => TagSource.User,
            "ai" => TagSource.AI,
            "all" => TagSource.All,
            _ => (TagSource)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TagSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TagSource.User => "user",
                TagSource.AI => "ai",
                TagSource.All => "all",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
