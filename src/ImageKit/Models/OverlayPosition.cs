using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;

namespace ImageKit.Models;

[JsonConverter(typeof(JsonModelConverter<OverlayPosition, OverlayPositionFromRaw>))]
public sealed record class OverlayPosition : JsonModel
{
    /// <summary>
    /// Specifies the position of the overlay relative to the parent image or video.
    /// Maps to `lfo` in the URL.
    /// </summary>
    public ApiEnum<string, Focus>? Focus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Focus>>("focus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("focus", value);
        }
    }

    /// <summary>
    /// Specifies the x-coordinate of the top-left corner of the base asset where
    /// the overlay's top-left corner will be positioned. It also accepts arithmetic
    /// expressions such as `bw_mul_0.4` or `bw_sub_cw`. Maps to `lx` in the URL.
    /// Learn about [Arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
    /// </summary>
    public X? X
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<X>("x");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("x", value);
        }
    }

    /// <summary>
    /// Specifies the y-coordinate of the top-left corner of the base asset where
    /// the overlay's top-left corner will be positioned. It also accepts arithmetic
    /// expressions such as `bh_mul_0.4` or `bh_sub_ch`. Maps to `ly` in the URL.
    /// Learn about [Arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
    /// </summary>
    public Y? Y
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Y>("y");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("y", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Focus?.Validate();
        this.X?.Validate();
        this.Y?.Validate();
    }

    public OverlayPosition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OverlayPosition(OverlayPosition overlayPosition)
        : base(overlayPosition) { }
#pragma warning restore CS8618

    public OverlayPosition(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OverlayPosition(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OverlayPositionFromRaw.FromRawUnchecked"/>
    public static OverlayPosition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OverlayPositionFromRaw : IFromRawJson<OverlayPosition>
{
    /// <inheritdoc/>
    public OverlayPosition FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OverlayPosition.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the position of the overlay relative to the parent image or video. Maps
/// to `lfo` in the URL.
/// </summary>
[JsonConverter(typeof(FocusConverter))]
public enum Focus
{
    Center,
    Top,
    Left,
    Bottom,
    Right,
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
}

sealed class FocusConverter : JsonConverter<Focus>
{
    public override Focus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "center" => Focus.Center,
            "top" => Focus.Top,
            "left" => Focus.Left,
            "bottom" => Focus.Bottom,
            "right" => Focus.Right,
            "top_left" => Focus.TopLeft,
            "top_right" => Focus.TopRight,
            "bottom_left" => Focus.BottomLeft,
            "bottom_right" => Focus.BottomRight,
            _ => (Focus)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Focus value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Focus.Center => "center",
                Focus.Top => "top",
                Focus.Left => "left",
                Focus.Bottom => "bottom",
                Focus.Right => "right",
                Focus.TopLeft => "top_left",
                Focus.TopRight => "top_right",
                Focus.BottomLeft => "bottom_left",
                Focus.BottomRight => "bottom_right",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Specifies the x-coordinate of the top-left corner of the base asset where the
/// overlay's top-left corner will be positioned. It also accepts arithmetic expressions
/// such as `bw_mul_0.4` or `bw_sub_cw`. Maps to `lx` in the URL. Learn about [Arithmetic
/// expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
/// </summary>
[JsonConverter(typeof(XConverter))]
public record class X : ModelBase
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

    public X(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public X(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public X(JsonElement element)
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
                throw new ImageKitInvalidDataException("Data did not match any variant of X");
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
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of X"),
        };
    }

    public static implicit operator X(double value) => new(value);

    public static implicit operator X(string value) => new(value);

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
            throw new ImageKitInvalidDataException("Data did not match any variant of X");
        }
    }

    public virtual bool Equals(X? other) =>
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

sealed class XConverter : JsonConverter<X>
{
    public override X? Read(
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

    public override void Write(Utf8JsonWriter writer, X value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Specifies the y-coordinate of the top-left corner of the base asset where the
/// overlay's top-left corner will be positioned. It also accepts arithmetic expressions
/// such as `bh_mul_0.4` or `bh_sub_ch`. Maps to `ly` in the URL. Learn about [Arithmetic
/// expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
/// </summary>
[JsonConverter(typeof(YConverter))]
public record class Y : ModelBase
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

    public Y(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Y(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Y(JsonElement element)
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
                throw new ImageKitInvalidDataException("Data did not match any variant of Y");
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
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Y"),
        };
    }

    public static implicit operator Y(double value) => new(value);

    public static implicit operator Y(string value) => new(value);

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
            throw new ImageKitInvalidDataException("Data did not match any variant of Y");
        }
    }

    public virtual bool Equals(Y? other) =>
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

sealed class YConverter : JsonConverter<Y>
{
    public override Y? Read(
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

    public override void Write(Utf8JsonWriter writer, Y value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
