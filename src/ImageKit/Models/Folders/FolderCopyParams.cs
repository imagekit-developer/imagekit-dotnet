using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using ImageKit.Core;
using Text = System.Text;

namespace ImageKit.Models.Folders;

/// <summary>
/// This will copy one folder into another. The selected folder, its nested folders,
/// files, and their versions (in `includeVersions` is set to true) are copied in
/// this operation. Note: If any file at the destination has the same name as the
/// source file, then the source file and its versions will be appended to the destination
/// file version history.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FolderCopyParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Full path to the destination folder where you want to copy the source folder
    /// into.
    /// </summary>
    public required string DestinationPath
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("destinationPath");
        }
        init { this._rawBodyData.Set("destinationPath", value); }
    }

    /// <summary>
    /// The full path to the source folder you want to copy.
    /// </summary>
    public required string SourceFolderPath
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("sourceFolderPath");
        }
        init { this._rawBodyData.Set("sourceFolderPath", value); }
    }

    /// <summary>
    /// Option to copy all versions of files that are nested inside the selected folder.
    /// By default, only the current version of each file will be copied. When set
    /// to true, all versions of each file will be copied. Default value - `false`.
    /// </summary>
    public bool? IncludeVersions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("includeVersions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("includeVersions", value);
        }
    }

    public FolderCopyParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderCopyParams(FolderCopyParams folderCopyParams)
        : base(folderCopyParams)
    {
        this._rawBodyData = new(folderCopyParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FolderCopyParams(
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
    FolderCopyParams(
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

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static FolderCopyParams FromRawUnchecked(
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

    public virtual bool Equals(FolderCopyParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/bulkJobs/copyFolder")
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
