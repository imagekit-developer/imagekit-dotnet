using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files.Batch;

[JsonConverter(typeof(JsonModelConverter<BatchDeleteResponse, BatchDeleteResponseFromRaw>))]
public sealed record class BatchDeleteResponse : JsonModel
{
    /// <summary>
    /// An array of fileIds that were successfully deleted.
    /// </summary>
    public IReadOnlyList<string>? SuccessfullyDeletedFileIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "successfullyDeletedFileIds"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "successfullyDeletedFileIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SuccessfullyDeletedFileIds;
    }

    public BatchDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchDeleteResponse(BatchDeleteResponse batchDeleteResponse)
        : base(batchDeleteResponse) { }
#pragma warning restore CS8618

    public BatchDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchDeleteResponseFromRaw.FromRawUnchecked"/>
    public static BatchDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchDeleteResponseFromRaw : IFromRawJson<BatchDeleteResponse>
{
    /// <inheritdoc/>
    public BatchDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchDeleteResponse.FromRawUnchecked(rawData);
}
