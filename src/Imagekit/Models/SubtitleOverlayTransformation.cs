using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models;

/// <summary>
/// Subtitle styling options. [Learn more](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer)
/// from the docs.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SubtitleOverlayTransformation, SubtitleOverlayTransformationFromRaw>)
)]
public sealed record class SubtitleOverlayTransformation : JsonModel
{
    /// <summary>
    /// Specifies the subtitle background color using a standard color name, an RGB
    /// color code (e.g., FF0000), or an RGBA color code (e.g., FFAABB50).
    ///
    /// <para>[Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer) </para>
    /// </summary>
    public string? Background
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("background");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("background", value);
        }
    }

    /// <summary>
    /// Sets the font color of the subtitle text using a standard color name, an
    /// RGB color code (e.g., FF0000), or an RGBA color code (e.g., FFAABB50).
    ///
    /// <para>[Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer) </para>
    /// </summary>
    public string? Color
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("color");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("color", value);
        }
    }

    /// <summary>
    /// Sets the font family of subtitle text. Refer to the [supported fonts documented](https://imagekit.io/docs/add-overlays-on-images#supported-text-font-list)
    /// in the ImageKit transformations guide.
    /// </summary>
    public string? FontFamily
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fontFamily");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fontFamily", value);
        }
    }

    /// <summary>
    /// Sets the font outline of the subtitle text.  Requires the outline width (an
    /// integer) and the outline color (as an RGB color code, RGBA color code, or
    /// standard web color name) separated by an underscore.  Example: `fol-2_blue`
    /// (outline width of 2px and outline color blue), `fol-2_A1CCDD` (outline width
    /// of 2px and outline color `#A1CCDD`) and `fol-2_A1CCDD50` (outline width of
    /// 2px and outline color `#A1CCDD` at 50% opacity).
    ///
    /// <para>[Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer) </para>
    /// </summary>
    public string? FontOutline
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fontOutline");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fontOutline", value);
        }
    }

    /// <summary>
    /// Sets the font shadow for the subtitle text.  Requires the shadow color (as
    /// an RGB color code, RGBA color code, or standard web color name) and shadow
    /// indent (an integer) separated by an underscore.  Example: `fsh-blue_2` (shadow
    /// color blue, indent of 2px), `fsh-A1CCDD_3` (shadow color `#A1CCDD`, indent
    /// of 3px), `fsh-A1CCDD50_3` (shadow color `#A1CCDD` at 50% opacity, indent of 3px).
    ///
    /// <para>[Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer) </para>
    /// </summary>
    public string? FontShadow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fontShadow");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fontShadow", value);
        }
    }

    /// <summary>
    /// Sets the font size of subtitle text.
    ///
    /// <para>[Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer) </para>
    /// </summary>
    public double? FontSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fontSize");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fontSize", value);
        }
    }

    /// <summary>
    /// Sets the typography style of the subtitle text. Supports values are `b` for
    /// bold, `i` for italics, and `b_i` for bold with italics.
    ///
    /// <para>[Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer) </para>
    /// </summary>
    public ApiEnum<string, Typography>? Typography
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Typography>>("typography");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("typography", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Background;
        _ = this.Color;
        _ = this.FontFamily;
        _ = this.FontOutline;
        _ = this.FontShadow;
        _ = this.FontSize;
        this.Typography?.Validate();
    }

    public SubtitleOverlayTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubtitleOverlayTransformation(
        SubtitleOverlayTransformation subtitleOverlayTransformation
    )
        : base(subtitleOverlayTransformation) { }
#pragma warning restore CS8618

    public SubtitleOverlayTransformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubtitleOverlayTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubtitleOverlayTransformationFromRaw.FromRawUnchecked"/>
    public static SubtitleOverlayTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubtitleOverlayTransformationFromRaw : IFromRawJson<SubtitleOverlayTransformation>
{
    /// <inheritdoc/>
    public SubtitleOverlayTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubtitleOverlayTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Sets the typography style of the subtitle text. Supports values are `b` for bold,
/// `i` for italics, and `b_i` for bold with italics.
///
/// <para>[Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer) </para>
/// </summary>
[JsonConverter(typeof(TypographyConverter))]
public enum Typography
{
    B,
    I,
    BI,
}

sealed class TypographyConverter : JsonConverter<Typography>
{
    public override Typography Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "b" => Typography.B,
            "i" => Typography.I,
            "b_i" => Typography.BI,
            _ => (Typography)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Typography value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Typography.B => "b",
                Typography.I => "i",
                Typography.BI => "b_i",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
