using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files;

/// <summary>
/// JSON object.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Interoperability, InteroperabilityFromRaw>))]
public sealed record class Interoperability : JsonModel
{
    public string? InteropIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("InteropIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("InteropIndex", value);
        }
    }

    public string? InteropVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("InteropVersion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("InteropVersion", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InteropIndex;
        _ = this.InteropVersion;
    }

    public Interoperability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Interoperability(Interoperability interoperability)
        : base(interoperability) { }
#pragma warning restore CS8618

    public Interoperability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Interoperability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InteroperabilityFromRaw.FromRawUnchecked"/>
    public static Interoperability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InteroperabilityFromRaw : IFromRawJson<Interoperability>
{
    /// <inheritdoc/>
    public Interoperability FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Interoperability.FromRawUnchecked(rawData);
}
