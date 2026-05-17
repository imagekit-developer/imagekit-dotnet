using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Files.Bulk;

[JsonConverter(typeof(JsonModelConverter<BulkAddTagsResponse, BulkAddTagsResponseFromRaw>))]
public sealed record class BulkAddTagsResponse : JsonModel
{
    /// <summary>
    /// An array of fileIds that in which tags were successfully added.
    /// </summary>
    public IReadOnlyList<string>? SuccessfullyUpdatedFileIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "successfullyUpdatedFileIds"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "successfullyUpdatedFileIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SuccessfullyUpdatedFileIds;
    }

    public BulkAddTagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkAddTagsResponse(BulkAddTagsResponse bulkAddTagsResponse)
        : base(bulkAddTagsResponse) { }
#pragma warning restore CS8618

    public BulkAddTagsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkAddTagsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkAddTagsResponseFromRaw.FromRawUnchecked"/>
    public static BulkAddTagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkAddTagsResponseFromRaw : IFromRawJson<BulkAddTagsResponse>
{
    /// <inheritdoc/>
    public BulkAddTagsResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BulkAddTagsResponse.FromRawUnchecked(rawData);
}
