using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Files.Bulk;

[JsonConverter(typeof(JsonModelConverter<BulkRemoveTagsResponse, BulkRemoveTagsResponseFromRaw>))]
public sealed record class BulkRemoveTagsResponse : JsonModel
{
    /// <summary>
    /// An array of fileIds that in which tags were successfully removed.
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

    public BulkRemoveTagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkRemoveTagsResponse(BulkRemoveTagsResponse bulkRemoveTagsResponse)
        : base(bulkRemoveTagsResponse) { }
#pragma warning restore CS8618

    public BulkRemoveTagsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkRemoveTagsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkRemoveTagsResponseFromRaw.FromRawUnchecked"/>
    public static BulkRemoveTagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkRemoveTagsResponseFromRaw : IFromRawJson<BulkRemoveTagsResponse>
{
    /// <inheritdoc/>
    public BulkRemoveTagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BulkRemoveTagsResponse.FromRawUnchecked(rawData);
}
