using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MaxValueVariants = Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties.MaxValueVariants;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties;

/// <summary>
/// Maximum value of the field. Only set this property if field type is `Date` or
/// `Number`. For `Date` type field, set the minimum date in ISO8601 string format.
/// For `Number` type field, set the minimum numeric value.
/// </summary>
[JsonConverter(typeof(MaxValueConverter))]
public abstract record class MaxValue
{
    internal MaxValue() { }

    public static implicit operator MaxValue(string value) => new MaxValueVariants::String(value);

    public static implicit operator MaxValue(double value) => new MaxValueVariants::Double(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as MaxValueVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as MaxValueVariants::Double)?.Value;
        return value != null;
    }

    public void Switch(
        Action<MaxValueVariants::String> @string,
        Action<MaxValueVariants::Double> @double
    )
    {
        switch (this)
        {
            case MaxValueVariants::String inner:
                @string(inner);
                break;
            case MaxValueVariants::Double inner:
                @double(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<MaxValueVariants::String, T> @string,
        Func<MaxValueVariants::Double, T> @double
    )
    {
        return this switch
        {
            MaxValueVariants::String inner => @string(inner),
            MaxValueVariants::Double inner => @double(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class MaxValueConverter : JsonConverter<MaxValue>
{
    public override MaxValue? Read(
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
                return new MaxValueVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new MaxValueVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, MaxValue value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            MaxValueVariants::String(var @string) => @string,
            MaxValueVariants::Double(var @double) => @double,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
