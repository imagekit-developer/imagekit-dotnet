using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Tags;

[JsonConverter(typeof(JsonModelConverter<TagListPageResponse, TagListPageResponseFromRaw>))]
public sealed record class TagListPageResponse : JsonModel
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

    public TagListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TagListPageResponse(TagListPageResponse tagListPageResponse)
        : base(tagListPageResponse) { }
#pragma warning restore CS8618

    public TagListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TagListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TagListPageResponseFromRaw.FromRawUnchecked"/>
    public static TagListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TagListPageResponseFromRaw : IFromRawJson<TagListPageResponse>
{
    /// <inheritdoc/>
    public TagListPageResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TagListPageResponse.FromRawUnchecked(rawData);
}
