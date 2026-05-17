using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files;

/// <summary>
/// Object containing Thumbnail information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Thumbnail, ThumbnailFromRaw>))]
public sealed record class Thumbnail : JsonModel
{
    public long? Compression
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("Compression");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("Compression", value);
        }
    }

    public long? ResolutionUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ResolutionUnit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ResolutionUnit", value);
        }
    }

    public long? ThumbnailLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ThumbnailLength");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ThumbnailLength", value);
        }
    }

    public long? ThumbnailOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ThumbnailOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ThumbnailOffset", value);
        }
    }

    public long? XResolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("XResolution");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("XResolution", value);
        }
    }

    public long? YResolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("YResolution");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("YResolution", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Compression;
        _ = this.ResolutionUnit;
        _ = this.ThumbnailLength;
        _ = this.ThumbnailOffset;
        _ = this.XResolution;
        _ = this.YResolution;
    }

    public Thumbnail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Thumbnail(Thumbnail thumbnail)
        : base(thumbnail) { }
#pragma warning restore CS8618

    public Thumbnail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Thumbnail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThumbnailFromRaw.FromRawUnchecked"/>
    public static Thumbnail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThumbnailFromRaw : IFromRawJson<Thumbnail>
{
    /// <inheritdoc/>
    public Thumbnail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Thumbnail.FromRawUnchecked(rawData);
}
