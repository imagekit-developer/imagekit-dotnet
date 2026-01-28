using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using ImageKit.Core;

namespace ImageKit.Models.CustomMetadataFields;

/// <summary>
/// This API returns the array of created custom metadata field objects. By default
/// the API returns only non deleted field objects, but you can include deleted fields
/// in the API response.
///
/// <para>You can also filter results by a specific folder path to retrieve custom
/// metadata fields applicable at that location. This path-specific filtering is useful
/// when using the **Path policy** feature to determine which custom metadata fields
/// are selected for a given path.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CustomMetadataFieldListParams : ParamsBase
{
    /// <summary>
    /// The folder path (e.g., `/path/to/folder`) for which to retrieve applicable
    /// custom metadata fields. Useful for determining path-specific field selections
    /// when the [Path policy](https://imagekit.io/docs/dam/path-policy) feature
    /// is in use.
    /// </summary>
    public string? FolderPath
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("folderPath");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("folderPath", value);
        }
    }

    /// <summary>
    /// Set it to `true` to include deleted field objects in the API response.
    /// </summary>
    public bool? IncludeDeleted
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("includeDeleted");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("includeDeleted", value);
        }
    }

    public CustomMetadataFieldListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomMetadataFieldListParams(
        CustomMetadataFieldListParams customMetadataFieldListParams
    )
        : base(customMetadataFieldListParams) { }
#pragma warning restore CS8618

    public CustomMetadataFieldListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomMetadataFieldListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CustomMetadataFieldListParams FromRawUnchecked(
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
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CustomMetadataFieldListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/customMetadataFields")
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
