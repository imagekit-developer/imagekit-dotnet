using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Imagekit.Core;
using Text = System.Text;

namespace Imagekit.Models.Files;

/// <summary>
/// You can rename an already existing file in the media library using rename file
/// API. This operation would rename all file versions of the file.
///
/// <para>Note: The old URLs will stop working. The file/file version URLs cached
/// on CDN will continue to work unless a purge is requested.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FileRenameParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The full path of the file you want to rename.
    /// </summary>
    public required string FilePath
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("filePath");
        }
        init { this._rawBodyData.Set("filePath", value); }
    }

    /// <summary>
    /// The new name of the file. A filename can contain:
    ///
    /// <para>Alphanumeric Characters: `a-z`, `A-Z`, `0-9` (including Unicode letters,
    /// marks, and numerals in other languages). Special Characters: `.`, `_`, and `-`.</para>
    ///
    /// <para>Any other character, including space, will be replaced by `_`. </para>
    /// </summary>
    public required string NewFileName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("newFileName");
        }
        init { this._rawBodyData.Set("newFileName", value); }
    }

    /// <summary>
    /// Option to purge cache for the old file and its versions' URLs.
    ///
    /// <para>When set to true, it will internally issue a purge cache request on
    /// CDN to remove cached content of old file and its versions. This purge request
    /// is counted against your monthly purge quota.</para>
    ///
    /// <para>Note: If the old file were accessible at `https://ik.imagekit.io/demo/old-filename.jpg`,
    /// a purge cache request would be issued against `https://ik.imagekit.io/demo/old-filename.jpg*`
    /// (with a wildcard at the end). It will remove the file and its versions' URLs
    /// and any transformations made using query parameters on this file or its versions.
    /// However, the cache for file transformations made using path parameters will
    /// persist. You can purge them using the purge API. For more details, refer
    /// to the purge API documentation.</para>
    ///
    /// <para>Default value - `false` </para>
    /// </summary>
    public bool? PurgeCache
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("purgeCache");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("purgeCache", value);
        }
    }

    public FileRenameParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileRenameParams(FileRenameParams fileRenameParams)
        : base(fileRenameParams)
    {
        this._rawBodyData = new(fileRenameParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FileRenameParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileRenameParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FileRenameParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
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
                new Dictionary<string, JsonElement>()
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

    public virtual bool Equals(FileRenameParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/files/rename")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Text::Encoding.UTF8,
            "application/json"
        );
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
