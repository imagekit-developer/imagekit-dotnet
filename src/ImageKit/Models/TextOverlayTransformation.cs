using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;

namespace ImageKit.Models;

[JsonConverter(
    typeof(JsonModelConverter<TextOverlayTransformation, TextOverlayTransformationFromRaw>)
)]
public sealed record class TextOverlayTransformation : JsonModel
{
    /// <summary>
    /// Specifies the transparency level of the text overlay. Accepts integers from
    /// `1` to `9`.
    /// </summary>
    public double? Alpha
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("alpha");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("alpha", value);
        }
    }

    /// <summary>
    /// Specifies the background color of the text overlay. Accepts an RGB hex code,
    /// an RGBA code, or a color name.
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
    /// Flip/mirror the text horizontally, vertically, or in both directions. Acceptable
    /// values: `h` (horizontal), `v` (vertical), `h_v` (horizontal and vertical),
    /// or `v_h`.
    /// </summary>
    public ApiEnum<string, Flip>? Flip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Flip>>("flip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("flip", value);
        }
    }

    /// <summary>
    /// Specifies the font color of the overlaid text. Accepts an RGB hex code (e.g.,
    /// `FF0000`), an RGBA code (e.g., `FFAABB50`), or a color name.
    /// </summary>
    public string? FontColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fontColor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fontColor", value);
        }
    }

    /// <summary>
    /// Specifies the font family of the overlaid text. Choose from the supported
    /// fonts list or use a custom font. See [Supported fonts](https://imagekit.io/docs/add-overlays-on-images#supported-text-font-list)
    /// and [Custom font](https://imagekit.io/docs/add-overlays-on-images#change-font-family-in-text-overlay).
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
    /// Specifies the font size of the overlaid text. Accepts a numeric value or an
    /// arithmetic expression.
    /// </summary>
    public FontSize? FontSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FontSize>("fontSize");
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
    /// Specifies the inner alignment of the text when width is more than the text
    /// length.
    /// </summary>
    public ApiEnum<string, InnerAlignment>? InnerAlignment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InnerAlignment>>(
                "innerAlignment"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("innerAlignment", value);
        }
    }

    /// <summary>
    /// Specifies the line height for multi-line text overlays. It will come into
    /// effect only if the text wraps over multiple lines. Accepts either an integer
    /// value or an arithmetic expression.
    /// </summary>
    public LineHeight? LineHeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LineHeight>("lineHeight");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lineHeight", value);
        }
    }

    /// <summary>
    /// Specifies the padding around the overlaid text. Can be provided as a single
    /// positive integer or multiple values separated by underscores (following CSS
    /// shorthand order). Arithmetic expressions are also accepted.
    /// </summary>
    public Padding? Padding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Padding>("padding");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("padding", value);
        }
    }

    /// <summary>
    /// Specifies the corner radius: - Single value (positive integer): Applied to
    /// all corners (e.g., `20`). - `max`: Creates a circular or oval shape. - Per-corner
    /// array: Provide four underscore-separated values representing top-left, top-right,
    /// bottom-right, and bottom-left corners respectively (e.g., `10_20_30_40`).
    /// See [Radius](https://imagekit.io/docs/effects-and-enhancements#radius---r).
    /// </summary>
    public TextOverlayTransformationRadius? Radius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TextOverlayTransformationRadius>("radius");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("radius", value);
        }
    }

    /// <summary>
    /// Specifies the rotation angle of the text overlay. Accepts a numeric value
    /// for clockwise rotation or a string prefixed with "N" for counter-clockwise
    /// rotation.
    /// </summary>
    public Rotation? Rotation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Rotation>("rotation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rotation", value);
        }
    }

    /// <summary>
    /// Specifies the typography style of the text. Supported values:    - Single
    /// styles: `b` (bold), `i` (italic), `strikethrough`.   - Combinations: Any
    /// combination separated by underscores, e.g., `b_i`, `b_i_strikethrough`.
    /// </summary>
    public string? Typography
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("typography");
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

    /// <summary>
    /// Specifies the maximum width (in pixels) of the overlaid text. The text wraps
    /// automatically, and arithmetic expressions (e.g., `bw_mul_0.2` or `bh_div_2`)
    /// are supported. Useful when used in conjunction with the `background`. Learn
    /// about [Arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
    /// </summary>
    public TextOverlayTransformationWidth? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TextOverlayTransformationWidth>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alpha;
        _ = this.Background;
        this.Flip?.Validate();
        _ = this.FontColor;
        _ = this.FontFamily;
        this.FontSize?.Validate();
        this.InnerAlignment?.Validate();
        this.LineHeight?.Validate();
        this.Padding?.Validate();
        this.Radius?.Validate();
        this.Rotation?.Validate();
        _ = this.Typography;
        this.Width?.Validate();
    }

    public TextOverlayTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextOverlayTransformation(TextOverlayTransformation textOverlayTransformation)
        : base(textOverlayTransformation) { }
#pragma warning restore CS8618

    public TextOverlayTransformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextOverlayTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextOverlayTransformationFromRaw.FromRawUnchecked"/>
    public static TextOverlayTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextOverlayTransformationFromRaw : IFromRawJson<TextOverlayTransformation>
{
    /// <inheritdoc/>
    public TextOverlayTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextOverlayTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Flip/mirror the text horizontally, vertically, or in both directions. Acceptable
/// values: `h` (horizontal), `v` (vertical), `h_v` (horizontal and vertical), or
/// `v_h`.
/// </summary>
[JsonConverter(typeof(FlipConverter))]
public enum Flip
{
    H,
    V,
    HV,
    VH,
}

sealed class FlipConverter : JsonConverter<Flip>
{
    public override Flip Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h" => Flip.H,
            "v" => Flip.V,
            "h_v" => Flip.HV,
            "v_h" => Flip.VH,
            _ => (Flip)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Flip value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Flip.H => "h",
                Flip.V => "v",
                Flip.HV => "h_v",
                Flip.VH => "v_h",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Specifies the font size of the overlaid text. Accepts a numeric value or an arithmetic expression.
/// </summary>
[JsonConverter(typeof(FontSizeConverter))]
public record class FontSize : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public FontSize(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FontSize(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FontSize(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of FontSize"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of FontSize"
            ),
        };
    }

    public static implicit operator FontSize(double value) => new(value);

    public static implicit operator FontSize(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of FontSize");
        }
    }

    public virtual bool Equals(FontSize? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class FontSizeConverter : JsonConverter<FontSize>
{
    public override FontSize? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, FontSize value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Specifies the inner alignment of the text when width is more than the text length.
/// </summary>
[JsonConverter(typeof(InnerAlignmentConverter))]
public enum InnerAlignment
{
    Left,
    Right,
    Center,
}

sealed class InnerAlignmentConverter : JsonConverter<InnerAlignment>
{
    public override InnerAlignment Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "left" => InnerAlignment.Left,
            "right" => InnerAlignment.Right,
            "center" => InnerAlignment.Center,
            _ => (InnerAlignment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InnerAlignment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InnerAlignment.Left => "left",
                InnerAlignment.Right => "right",
                InnerAlignment.Center => "center",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Specifies the line height for multi-line text overlays. It will come into effect
/// only if the text wraps over multiple lines. Accepts either an integer value or
/// an arithmetic expression.
/// </summary>
[JsonConverter(typeof(LineHeightConverter))]
public record class LineHeight : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public LineHeight(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LineHeight(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public LineHeight(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of LineHeight"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of LineHeight"
            ),
        };
    }

    public static implicit operator LineHeight(double value) => new(value);

    public static implicit operator LineHeight(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of LineHeight");
        }
    }

    public virtual bool Equals(LineHeight? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class LineHeightConverter : JsonConverter<LineHeight>
{
    public override LineHeight? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        LineHeight value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Specifies the padding around the overlaid text. Can be provided as a single positive
/// integer or multiple values separated by underscores (following CSS shorthand
/// order). Arithmetic expressions are also accepted.
/// </summary>
[JsonConverter(typeof(PaddingConverter))]
public record class Padding : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Padding(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Padding(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Padding(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException("Data did not match any variant of Padding");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of Padding"
            ),
        };
    }

    public static implicit operator Padding(double value) => new(value);

    public static implicit operator Padding(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Padding");
        }
    }

    public virtual bool Equals(Padding? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PaddingConverter : JsonConverter<Padding>
{
    public override Padding? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Padding value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Specifies the corner radius: - Single value (positive integer): Applied to all
/// corners (e.g., `20`). - `max`: Creates a circular or oval shape. - Per-corner
/// array: Provide four underscore-separated values representing top-left, top-right,
/// bottom-right, and bottom-left corners respectively (e.g., `10_20_30_40`). See
/// [Radius](https://imagekit.io/docs/effects-and-enhancements#radius---r).
/// </summary>
[JsonConverter(typeof(TextOverlayTransformationRadiusConverter))]
public record class TextOverlayTransformationRadius : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TextOverlayTransformationRadius(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TextOverlayTransformationRadius(
        TextOverlayTransformationRadiusUnionMember1 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TextOverlayTransformationRadius(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TextOverlayTransformationRadius(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextOverlayTransformationRadiusUnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMax(out var value)) {
    ///     // `value` is of type `TextOverlayTransformationRadiusUnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMax(
        [NotNullWhen(true)] out TextOverlayTransformationRadiusUnionMember1? value
    )
    {
        value = this.Value as TextOverlayTransformationRadiusUnionMember1;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) => {...},
    ///     (TextOverlayTransformationRadiusUnionMember1 value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<double> @double,
        Action<TextOverlayTransformationRadiusUnionMember1> max,
        Action<string> @string
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case TextOverlayTransformationRadiusUnionMember1 value:
                max(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TextOverlayTransformationRadius"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) => {...},
    ///     (TextOverlayTransformationRadiusUnionMember1 value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<double, T> @double,
        Func<TextOverlayTransformationRadiusUnionMember1, T> max,
        Func<string, T> @string
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            TextOverlayTransformationRadiusUnionMember1 value => max(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TextOverlayTransformationRadius"
            ),
        };
    }

    public static implicit operator TextOverlayTransformationRadius(double value) => new(value);

    public static implicit operator TextOverlayTransformationRadius(
        TextOverlayTransformationRadiusUnionMember1 value
    ) => new(value);

    public static implicit operator TextOverlayTransformationRadius(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TextOverlayTransformationRadius"
            );
        }
        this.Switch((_) => { }, (max) => max.Validate(), (_) => { });
    }

    public virtual bool Equals(TextOverlayTransformationRadius? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            TextOverlayTransformationRadiusUnionMember1 _ => 1,
            string _ => 2,
            _ => -1,
        };
    }
}

sealed class TextOverlayTransformationRadiusConverter
    : JsonConverter<TextOverlayTransformationRadius>
{
    public override TextOverlayTransformationRadius? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<TextOverlayTransformationRadiusUnionMember1>(
                    element,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextOverlayTransformationRadius value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(TextOverlayTransformationRadiusUnionMember1Converter))]
public record class TextOverlayTransformationRadiusUnionMember1
{
    public JsonElement Element { get; private init; }

    public TextOverlayTransformationRadiusUnionMember1()
    {
        Element = JsonSerializer.SerializeToElement("max");
    }

    internal TextOverlayTransformationRadiusUnionMember1(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new TextOverlayTransformationRadiusUnionMember1())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'TextOverlayTransformationRadiusUnionMember1'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(TextOverlayTransformationRadiusUnionMember1? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class TextOverlayTransformationRadiusUnionMember1Converter
    : JsonConverter<TextOverlayTransformationRadiusUnionMember1>
{
    public override TextOverlayTransformationRadiusUnionMember1? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextOverlayTransformationRadiusUnionMember1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Specifies the rotation angle of the text overlay. Accepts a numeric value for
/// clockwise rotation or a string prefixed with "N" for counter-clockwise rotation.
/// </summary>
[JsonConverter(typeof(RotationConverter))]
public record class Rotation : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Rotation(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Rotation(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Rotation(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of Rotation"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of Rotation"
            ),
        };
    }

    public static implicit operator Rotation(double value) => new(value);

    public static implicit operator Rotation(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Rotation");
        }
    }

    public virtual bool Equals(Rotation? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class RotationConverter : JsonConverter<Rotation>
{
    public override Rotation? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Rotation value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Specifies the maximum width (in pixels) of the overlaid text. The text wraps automatically,
/// and arithmetic expressions (e.g., `bw_mul_0.2` or `bh_div_2`) are supported. Useful
/// when used in conjunction with the `background`. Learn about [Arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
/// </summary>
[JsonConverter(typeof(TextOverlayTransformationWidthConverter))]
public record class TextOverlayTransformationWidth : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TextOverlayTransformationWidth(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TextOverlayTransformationWidth(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TextOverlayTransformationWidth(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TextOverlayTransformationWidth"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) => {...},
    ///     (string value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TextOverlayTransformationWidth"
            ),
        };
    }

    public static implicit operator TextOverlayTransformationWidth(double value) => new(value);

    public static implicit operator TextOverlayTransformationWidth(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TextOverlayTransformationWidth"
            );
        }
    }

    public virtual bool Equals(TextOverlayTransformationWidth? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class TextOverlayTransformationWidthConverter : JsonConverter<TextOverlayTransformationWidth>
{
    public override TextOverlayTransformationWidth? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextOverlayTransformationWidth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
