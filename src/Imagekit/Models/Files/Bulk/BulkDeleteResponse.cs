using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Files.Bulk;

[JsonConverter(typeof(JsonModelConverter<BulkDeleteResponse, BulkDeleteResponseFromRaw>))]
public sealed record class BulkDeleteResponse : JsonModel
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

    public BulkDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkDeleteResponse(BulkDeleteResponse bulkDeleteResponse)
        : base(bulkDeleteResponse) { }
#pragma warning restore CS8618

    public BulkDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkDeleteResponseFromRaw.FromRawUnchecked"/>
    public static BulkDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkDeleteResponseFromRaw : IFromRawJson<BulkDeleteResponse>
{
    /// <inheritdoc/>
    public BulkDeleteResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BulkDeleteResponse.FromRawUnchecked(rawData);
}
