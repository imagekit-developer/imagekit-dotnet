using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Tags;

/// <summary>
/// A tag in use in your media library, aggregated case-insensitively across the
/// assets that carry it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tag, TagFromRaw>))]
public sealed record class Tag : JsonModel
{
    /// <summary>
    /// The number of assets carrying the tag, counted across both tag sources (user-generated
    /// tags and AI-generated tags) and all file types regardless of the request's filters.
    /// </summary>
    public required long AssetCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("assetCount");
        }
        init { this._rawData.Set("assetCount", value); }
    }

    /// <summary>
    /// The tag as it was spelled when it was last applied to any asset. Use it for display.
    /// </summary>
    public required string Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("label");
        }
        init { this._rawData.Set("label", value); }
    }

    /// <summary>
    /// When the tag was last applied to an asset matching the `tagSource` and `fileType`
    /// filters of the request, in ISO 8601 format.
    /// </summary>
    public required DateTimeOffset LastUsedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("lastUsedAt");
        }
        init { this._rawData.Set("lastUsedAt", value); }
    }

    /// <summary>
    /// The tag in lowercase. Tags are case-insensitive, so this is the unique key
    /// of the tag within your account.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AssetCount;
        _ = this.Label;
        _ = this.LastUsedAt;
        _ = this.Name;
    }

    public Tag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Tag(Tag tag)
        : base(tag) { }
#pragma warning restore CS8618

    public Tag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TagFromRaw.FromRawUnchecked"/>
    public static Tag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TagFromRaw : IFromRawJson<Tag>
{
    /// <inheritdoc/>
    public Tag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tag.FromRawUnchecked(rawData);
}
