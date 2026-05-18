using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models;

/// <summary>
/// An object containing the file or file version's `id` (versionId) and `name`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VersionInfo, VersionInfoFromRaw>))]
public sealed record class VersionInfo : JsonModel
{
    /// <summary>
    /// Unique identifier of the file version.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Name of the file version.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public VersionInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionInfo(VersionInfo versionInfo)
        : base(versionInfo) { }
#pragma warning restore CS8618

    public VersionInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionInfoFromRaw.FromRawUnchecked"/>
    public static VersionInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionInfoFromRaw : IFromRawJson<VersionInfo>
{
    /// <inheritdoc/>
    public VersionInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VersionInfo.FromRawUnchecked(rawData);
}
