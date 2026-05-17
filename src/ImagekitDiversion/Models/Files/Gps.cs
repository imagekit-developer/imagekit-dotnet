using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files;

/// <summary>
/// Object containing GPS information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Gps, GpsFromRaw>))]
public sealed record class Gps : JsonModel
{
    public IReadOnlyList<long>? GpsVersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("GPSVersionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "GPSVersionID",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GpsVersionID;
    }

    public Gps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Gps(Gps gps)
        : base(gps) { }
#pragma warning restore CS8618

    public Gps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Gps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GpsFromRaw.FromRawUnchecked"/>
    public static Gps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GpsFromRaw : IFromRawJson<Gps>
{
    /// <inheritdoc/>
    public Gps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Gps.FromRawUnchecked(rawData);
}
