using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldProperties.SchemaProperties.MinValueVariants;
using System = System;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldProperties.SchemaProperties;

/// <summary>
/// Minimum value of the field. Only set if field type is `Date` or `Number`. For
/// `Date` type field, the value will be in ISO8601 string format. For `Number` type
/// field, it will be a numeric value.
/// </summary>
[JsonConverter(typeof(MinValueConverter))]
public record class MinValue
{
    public object Value { get; private init; }

    public MinValue(string value)
    {
        Value = value;
    }

    public MinValue(double value)
    {
        Value = value;
    }

    MinValue(UnknownVariant value)
    {
        Value = value;
    }

    public static MinValue CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public void Switch(System::Action<string> @string, System::Action<double> @double)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new System::InvalidOperationException();
        }
    }

    public T Match<T>(System::Func<string, T> @string, System::Func<double, T> @double)
    {
        return this.Value switch
        {
            String inner => @string(inner),
            Double inner => @double(inner),
            _ => throw new System::InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of MinValue");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class MinValueConverter : JsonConverter<MinValue>
{
    public override MinValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new MinValue(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new MinValue(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, MinValue value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            String(var @string) => @string,
            Double(var @double) => @double,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
