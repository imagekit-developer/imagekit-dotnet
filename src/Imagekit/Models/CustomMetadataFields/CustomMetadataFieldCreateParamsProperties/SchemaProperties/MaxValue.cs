using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldCreateParamsProperties.SchemaProperties.MaxValueVariants;
using System = System;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldCreateParamsProperties.SchemaProperties;

/// <summary>
/// Maximum value of the field. Only set this property if field type is `Date` or
/// `Number`. For `Date` type field, set the minimum date in ISO8601 string format.
/// For `Number` type field, set the minimum numeric value.
/// </summary>
[JsonConverter(typeof(MaxValueConverter))]
public record class MaxValue
{
    public object Value { get; private init; }

    public MaxValue(string value)
    {
        Value = value;
    }

    public MaxValue(double value)
    {
        Value = value;
    }

    MaxValue(UnknownVariant value)
    {
        Value = value;
    }

    public static MaxValue CreateUnknownVariant(JsonElement value)
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
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of MaxValue");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class MaxValueConverter : JsonConverter<MaxValue>
{
    public override MaxValue? Read(
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
                return new MaxValue(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new MaxValue(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, MaxValue value, JsonSerializerOptions options)
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
