using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Files.Versions;

[JsonConverter(typeof(JsonModelConverter<VersionDeleteResponse, VersionDeleteResponseFromRaw>))]
public sealed record class VersionDeleteResponse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public VersionDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionDeleteResponse(VersionDeleteResponse versionDeleteResponse)
        : base(versionDeleteResponse) { }
#pragma warning restore CS8618

    public VersionDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionDeleteResponseFromRaw.FromRawUnchecked"/>
    public static VersionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionDeleteResponseFromRaw : IFromRawJson<VersionDeleteResponse>
{
    /// <inheritdoc/>
    public VersionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionDeleteResponse.FromRawUnchecked(rawData);
}
