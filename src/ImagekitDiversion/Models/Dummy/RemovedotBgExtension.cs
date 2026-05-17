using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;

namespace ImagekitDiversion.Models.Dummy;

[JsonConverter(typeof(JsonModelConverter<RemovedotBgExtension, RemovedotBgExtensionFromRaw>))]
public sealed record class RemovedotBgExtension : JsonModel
{
    /// <summary>
    /// Specifies the background removal extension.
    /// </summary>
    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public Options? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Options>("options");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("options", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("remove-bg")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        this.Options?.Validate();
    }

    public RemovedotBgExtension()
    {
        this.Name = JsonSerializer.SerializeToElement("remove-bg");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RemovedotBgExtension(RemovedotBgExtension removedotBgExtension)
        : base(removedotBgExtension) { }
#pragma warning restore CS8618

    public RemovedotBgExtension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("remove-bg");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemovedotBgExtension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RemovedotBgExtensionFromRaw.FromRawUnchecked"/>
    public static RemovedotBgExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RemovedotBgExtensionFromRaw : IFromRawJson<RemovedotBgExtension>
{
    /// <inheritdoc/>
    public RemovedotBgExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RemovedotBgExtension.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : JsonModel
{
    /// <summary>
    /// Whether to add an artificial shadow to the result. Default is false. Note:
    /// Adding shadows is currently only supported for car photos.
    /// </summary>
    public bool? AddShadow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("add_shadow");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("add_shadow", value);
        }
    }

    /// <summary>
    /// Specifies a solid color background using hex code (e.g., "81d4fa", "fff")
    /// or color name (e.g., "green"). If this parameter is set, `bg_image_url` must
    /// be empty.
    /// </summary>
    public string? BgColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bg_color");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bg_color", value);
        }
    }

    /// <summary>
    /// Sets a background image from a URL. If this parameter is set, `bg_color` must
    /// be empty.
    /// </summary>
    public string? BgImageUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bg_image_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bg_image_url", value);
        }
    }

    /// <summary>
    /// Allows semi-transparent regions in the result. Default is true. Note: Semitransparency
    /// is currently only supported for car windows.
    /// </summary>
    public bool? Semitransparency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("semitransparency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("semitransparency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddShadow;
        _ = this.BgColor;
        _ = this.BgImageUrl;
        _ = this.Semitransparency;
    }

    public Options() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Options(Options options)
        : base(options) { }
#pragma warning restore CS8618

    public Options(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptionsFromRaw.FromRawUnchecked"/>
    public static Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptionsFromRaw : IFromRawJson<Options>
{
    /// <inheritdoc/>
    public Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Options.FromRawUnchecked(rawData);
}
