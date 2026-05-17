using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models;

[JsonConverter(
    typeof(JsonModelConverter<
        SolidColorOverlayTransformation,
        SolidColorOverlayTransformationFromRaw
    >)
)]
public sealed record class SolidColorOverlayTransformation : JsonModel
{
    /// <summary>
    /// Specifies the transparency level of the overlaid solid color layer. Supports
    /// integers from `1` to `9`.
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
    /// Specifies the background color of the solid color overlay. Accepts an RGB
    /// hex code (e.g., `FF0000`), an RGBA code (e.g., `FFAABB50`), or a color name.
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
    /// Creates a linear gradient with two colors. Pass `true` for a default gradient,
    /// or provide a string for a custom gradient. Only works if the base asset is
    /// an image. See [gradient](https://imagekit.io/docs/effects-and-enhancements#gradient---e-gradient).
    /// </summary>
    public Gradient? Gradient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Gradient>("gradient");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gradient", value);
        }
    }

    /// <summary>
    /// Controls the height of the solid color overlay. Accepts a numeric value or
    /// an arithmetic expression. Learn about [arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
    /// </summary>
    public Height? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Height>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    /// <summary>
    /// Specifies the corner radius of the solid color overlay. - Single value (positive
    /// integer): Applied to all corners (e.g., `20`). - `max`: Creates a circular
    /// or oval shape. - Per-corner array: Provide four underscore-separated values
    /// representing top-left, top-right, bottom-right, and bottom-left corners respectively
    /// (e.g., `10_20_30_40`). See [Radius](https://imagekit.io/docs/effects-and-enhancements#radius---r).
    /// </summary>
    public Radius? Radius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Radius>("radius");
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
    /// Controls the width of the solid color overlay. Accepts a numeric value or
    /// an arithmetic expression (e.g., `bw_mul_0.2` or `bh_div_2`). Learn about
    /// [arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
    /// </summary>
    public Width? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Width>("width");
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
        this.Gradient?.Validate();
        this.Height?.Validate();
        this.Radius?.Validate();
        this.Width?.Validate();
    }

    public SolidColorOverlayTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SolidColorOverlayTransformation(
        SolidColorOverlayTransformation solidColorOverlayTransformation
    )
        : base(solidColorOverlayTransformation) { }
#pragma warning restore CS8618

    public SolidColorOverlayTransformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SolidColorOverlayTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SolidColorOverlayTransformationFromRaw.FromRawUnchecked"/>
    public static SolidColorOverlayTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SolidColorOverlayTransformationFromRaw : IFromRawJson<SolidColorOverlayTransformation>
{
    /// <inheritdoc/>
    public SolidColorOverlayTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SolidColorOverlayTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Creates a linear gradient with two colors. Pass `true` for a default gradient,
/// or provide a string for a custom gradient. Only works if the base asset is an
/// image. See [gradient](https://imagekit.io/docs/effects-and-enhancements#gradient---e-gradient).
/// </summary>
[JsonConverter(typeof(GradientConverter))]
public record class Gradient : ModelBase
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

    public Gradient(Default value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Gradient(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Gradient(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Default"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDefault(out var value)) {
    ///     // `value` is of type `Default`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDefault([NotNullWhen(true)] out Default? value)
    {
        value = this.Value as Default;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (Default value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<Default> default_, Action<string> @string)
    {
        switch (this.Value)
        {
            case Default value:
                default_(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of Gradient"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (Default value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<Default, T> default_, Func<string, T> @string)
    {
        return this.Value switch
        {
            Default value => default_(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of Gradient"
            ),
        };
    }

    public static implicit operator Gradient(Default value) => new(value);

    public static implicit operator Gradient(string value) => new(value);

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
            throw new ImageKitInvalidDataException("Data did not match any variant of Gradient");
        }
        this.Switch((default_) => default_.Validate(), (_) => { });
    }

    public virtual bool Equals(Gradient? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Default _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class GradientConverter : JsonConverter<Gradient>
{
    public override Gradient? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Default>(element, options);
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

    public override void Write(Utf8JsonWriter writer, Gradient value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(DefaultConverter))]
public record class Default
{
    public JsonElement Element { get; private init; }

    public Default()
    {
        Element = JsonSerializer.SerializeToElement(true);
    }

    internal Default(JsonElement element)
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
        if (this != new Default())
        {
            throw new ImageKitInvalidDataException("Invalid value given for 'Default'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(Default? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class DefaultConverter : JsonConverter<Default>
{
    public override Default? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, Default value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Controls the height of the solid color overlay. Accepts a numeric value or an
/// arithmetic expression. Learn about [arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
/// </summary>
[JsonConverter(typeof(HeightConverter))]
public record class Height : ModelBase
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

    public Height(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Height(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Height(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
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
                throw new ImageKitInvalidDataException("Data did not match any variant of Height");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
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
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Height"),
        };
    }

    public static implicit operator Height(double value) => new(value);

    public static implicit operator Height(string value) => new(value);

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
            throw new ImageKitInvalidDataException("Data did not match any variant of Height");
        }
    }

    public virtual bool Equals(Height? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

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

sealed class HeightConverter : JsonConverter<Height>
{
    public override Height? Read(
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

    public override void Write(Utf8JsonWriter writer, Height value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Specifies the corner radius of the solid color overlay. - Single value (positive
/// integer): Applied to all corners (e.g., `20`). - `max`: Creates a circular or
/// oval shape. - Per-corner array: Provide four underscore-separated values representing
/// top-left, top-right, bottom-right, and bottom-left corners respectively (e.g.,
/// `10_20_30_40`). See [Radius](https://imagekit.io/docs/effects-and-enhancements#radius---r).
/// </summary>
[JsonConverter(typeof(RadiusConverter))]
public record class Radius : ModelBase
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

    public Radius(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Radius(Max value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Radius(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Radius(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// type <see cref="Max"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMax(out var value)) {
    ///     // `value` is of type `Max`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMax([NotNullWhen(true)] out Max? value)
    {
        value = this.Value as Max;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (double value) =&gt; {...},
    ///     (Max value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<Max> max, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case Max value:
                max(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException("Data did not match any variant of Radius");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (double value) =&gt; {...},
    ///     (Max value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<Max, T> max, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            Max value => max(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Radius"),
        };
    }

    public static implicit operator Radius(double value) => new(value);

    public static implicit operator Radius(Max value) => new(value);

    public static implicit operator Radius(string value) => new(value);

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
            throw new ImageKitInvalidDataException("Data did not match any variant of Radius");
        }
        this.Switch((_) => { }, (max) => max.Validate(), (_) => { });
    }

    public virtual bool Equals(Radius? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            Max _ => 1,
            string _ => 2,
            _ => -1,
        };
    }
}

sealed class RadiusConverter : JsonConverter<Radius>
{
    public override Radius? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Max>(element, options);
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

    public override void Write(Utf8JsonWriter writer, Radius value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(MaxConverter))]
public record class Max
{
    public JsonElement Element { get; private init; }

    public Max()
    {
        Element = JsonSerializer.SerializeToElement("max");
    }

    internal Max(JsonElement element)
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
        if (this != new Max())
        {
            throw new ImageKitInvalidDataException("Invalid value given for 'Max'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(Max? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class MaxConverter : JsonConverter<Max>
{
    public override Max? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, Max value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Controls the width of the solid color overlay. Accepts a numeric value or an
/// arithmetic expression (e.g., `bw_mul_0.2` or `bh_div_2`). Learn about [arithmetic
/// expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
/// </summary>
[JsonConverter(typeof(WidthConverter))]
public record class Width : ModelBase
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

    public Width(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Width(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Width(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
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
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
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
                throw new ImageKitInvalidDataException("Data did not match any variant of Width");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
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
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Width"),
        };
    }

    public static implicit operator Width(double value) => new(value);

    public static implicit operator Width(string value) => new(value);

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
            throw new ImageKitInvalidDataException("Data did not match any variant of Width");
        }
    }

    public virtual bool Equals(Width? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

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

sealed class WidthConverter : JsonConverter<Width>
{
    public override Width? Read(
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

    public override void Write(Utf8JsonWriter writer, Width value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
