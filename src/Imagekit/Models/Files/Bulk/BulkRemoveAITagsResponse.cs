using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Files.Bulk;

[JsonConverter(
    typeof(JsonModelConverter<BulkRemoveAITagsResponse, BulkRemoveAITagsResponseFromRaw>)
)]
public sealed record class BulkRemoveAITagsResponse : JsonModel
{
    /// <summary>
    /// An array of fileIds that in which AITags were successfully removed.
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

    public BulkRemoveAITagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkRemoveAITagsResponse(BulkRemoveAITagsResponse bulkRemoveAITagsResponse)
        : base(bulkRemoveAITagsResponse) { }
#pragma warning restore CS8618

    public BulkRemoveAITagsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkRemoveAITagsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkRemoveAITagsResponseFromRaw.FromRawUnchecked"/>
    public static BulkRemoveAITagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkRemoveAITagsResponseFromRaw : IFromRawJson<BulkRemoveAITagsResponse>
{
    /// <inheritdoc/>
    public BulkRemoveAITagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BulkRemoveAITagsResponse.FromRawUnchecked(rawData);
}
