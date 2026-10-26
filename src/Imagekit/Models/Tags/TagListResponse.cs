using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Tags;

[JsonConverter(typeof(JsonModelConverter<TagListResponse, TagListResponseFromRaw>))]
public sealed record class TagListResponse : JsonModel
{
    /// <summary>
    /// Cursor for the next page, or `null` when there are no more tags.
    /// </summary>
    public required string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init { this._rawData.Set("nextCursor", value); }
    }

    /// <summary>
    /// Tags matching the request, in the requested order.
    /// </summary>
    public required IReadOnlyList<Tag> Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Tag>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Tag>>("tags", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NextCursor;
        foreach (var item in this.Tags)
        {
            item.Validate();
        }
    }

    public TagListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TagListResponse(TagListResponse tagListResponse)
        : base(tagListResponse) { }
#pragma warning restore CS8618

    public TagListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TagListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TagListResponseFromRaw.FromRawUnchecked"/>
    public static TagListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TagListResponseFromRaw : IFromRawJson<TagListResponse>
{
    /// <inheritdoc/>
    public TagListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TagListResponse.FromRawUnchecked(rawData);
}
