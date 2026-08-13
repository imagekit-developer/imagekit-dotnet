using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.NamedTransformations;

[JsonConverter(
    typeof(JsonModelConverter<
        NamedTransformationDeleteResponse,
        NamedTransformationDeleteResponseFromRaw
    >)
)]
public sealed record class NamedTransformationDeleteResponse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public NamedTransformationDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NamedTransformationDeleteResponse(
        NamedTransformationDeleteResponse namedTransformationDeleteResponse
    )
        : base(namedTransformationDeleteResponse) { }
#pragma warning restore CS8618

    public NamedTransformationDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NamedTransformationDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NamedTransformationDeleteResponseFromRaw.FromRawUnchecked"/>
    public static NamedTransformationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NamedTransformationDeleteResponseFromRaw : IFromRawJson<NamedTransformationDeleteResponse>
{
    /// <inheritdoc/>
    public NamedTransformationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NamedTransformationDeleteResponse.FromRawUnchecked(rawData);
}
