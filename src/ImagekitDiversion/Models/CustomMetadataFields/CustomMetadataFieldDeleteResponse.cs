using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.CustomMetadataFields;

[JsonConverter(
    typeof(JsonModelConverter<
        CustomMetadataFieldDeleteResponse,
        CustomMetadataFieldDeleteResponseFromRaw
    >)
)]
public sealed record class CustomMetadataFieldDeleteResponse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public CustomMetadataFieldDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomMetadataFieldDeleteResponse(
        CustomMetadataFieldDeleteResponse customMetadataFieldDeleteResponse
    )
        : base(customMetadataFieldDeleteResponse) { }
#pragma warning restore CS8618

    public CustomMetadataFieldDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomMetadataFieldDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CustomMetadataFieldDeleteResponseFromRaw.FromRawUnchecked"/>
    public static CustomMetadataFieldDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CustomMetadataFieldDeleteResponseFromRaw : IFromRawJson<CustomMetadataFieldDeleteResponse>
{
    /// <inheritdoc/>
    public CustomMetadataFieldDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CustomMetadataFieldDeleteResponse.FromRawUnchecked(rawData);
}
