using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MinValueVariants = Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties.MinValueVariants;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties;

/// <summary>
/// Minimum value of the field. Only set this property if field type is `Date` or
/// `Number`. For `Date` type field, set the minimum date in ISO8601 string format.
/// For `Number` type field, set the minimum numeric value.
/// </summary>
[JsonConverter(typeof(MinValueConverter))]
public abstract record class MinValue
{
    internal MinValue() { }

    public static implicit operator MinValue(string value) => new MinValueVariants::String(value);

    public static implicit operator MinValue(double value) => new MinValueVariants::Double(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as MinValueVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as MinValueVariants::Double)?.Value;
        return value != null;
    }

    public void Switch(
        Action<MinValueVariants::String> @string,
        Action<MinValueVariants::Double> @double
    )
    {
        switch (this)
        {
            case MinValueVariants::String inner:
                @string(inner);
                break;
            case MinValueVariants::Double inner:
                @double(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<MinValueVariants::String, T> @string,
        Func<MinValueVariants::Double, T> @double
    )
    {
        return this switch
        {
            MinValueVariants::String inner => @string(inner),
            MinValueVariants::Double inner => @double(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class MinValueConverter : JsonConverter<MinValue>
{
    public override MinValue? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new MinValueVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new MinValueVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, MinValue value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            MinValueVariants::String(var @string) => @string,
            MinValueVariants::Double(var @double) => @double,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
