using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Imagekit.Core;
using Text = System.Text;

namespace Imagekit.Models.Folders;

/// <summary>
/// This API allows you to rename an existing folder. The folder and all its nested
/// assets and sub-folders will remain unchanged, but their paths will be updated
/// to reflect the new folder name.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FolderRenameParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The full path to the folder you want to rename.
    /// </summary>
    public required string FolderPath
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("folderPath");
        }
        init { this._rawBodyData.Set("folderPath", value); }
    }

    /// <summary>
    /// The new name for the folder.
    ///
    /// <para>All characters except alphabets and numbers (inclusive of unicode letters,
    /// marks, and numerals in other languages) and `-` will be replaced by an underscore
    /// i.e. `_`. </para>
    /// </summary>
    public required string NewFolderName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("newFolderName");
        }
        init { this._rawBodyData.Set("newFolderName", value); }
    }

    /// <summary>
    /// Option to purge cache for the old nested files and their versions' URLs.
    ///
    /// <para>When set to true, it will internally issue a purge cache request on
    /// CDN to remove the cached content of the old nested files and their versions.
    /// There will only be one purge request for all the nested files, which will
    /// be counted against your monthly purge quota.</para>
    ///
    /// <para>Note: A purge cache request will be issued against `https://ik.imagekit.io/old/folder/path*`
    /// (with a wildcard at the end). This will remove all nested files, their versions'
    /// URLs, and any transformations made using query parameters on these files or
    /// their versions. However, the cache for file transformations made using path
    /// parameters will persist. You can purge them using the purge API. For more
    /// details, refer to the purge API documentation.</para>
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

    public FolderRenameParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderRenameParams(FolderRenameParams folderRenameParams)
        : base(folderRenameParams)
    {
        this._rawBodyData = new(folderRenameParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FolderRenameParams(
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
    FolderRenameParams(
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
    public static FolderRenameParams FromRawUnchecked(
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

    public virtual bool Equals(FolderRenameParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/bulkJobs/renameFolder")
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
