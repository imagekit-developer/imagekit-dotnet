using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.IntersectionMember1Properties.DataProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.MaxValueVariants;
using System = System;

namespace Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.IntersectionMember1Properties.DataProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties;

/// <summary>
/// Maximum value of the field. Only set if field type is `Date` or `Number`. For
/// `Date` type field, the value will be in ISO8601 string format. For `Number` type
/// field, it will be a numeric value.
/// </summary>
[JsonConverter(typeof(MaxValueConverter))]
public abstract record class MaxValue
{
    internal MaxValue() { }

    public static implicit operator MaxValue(string value) => new String(value);

    public static implicit operator MaxValue(double value) => new Double(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as String)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as Double)?.Value;
        return value != null;
    }

    public void Switch(System::Action<String> @string, System::Action<Double> @double)
    {
        switch (this)
        {
            case String inner:
                @string(inner);
                break;
            case Double inner:
                @double(inner);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of MaxValue"
                );
        }
    }

    public T Match<T>(System::Func<String, T> @string, System::Func<Double, T> @double)
    {
        return this switch
        {
            String inner => @string(inner),
            Double inner => @double(inner),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of MaxValue"
            ),
        };
    }

    public abstract void Validate();
}

sealed class MaxValueConverter : JsonConverter<MaxValue>
{
    public override MaxValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<ImageKitInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant String", e)
            );
        }

        try
        {
            return new Double(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant Double", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, MaxValue value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            String(var @string) => @string,
            Double(var @double) => @double,
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of MaxValue"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
