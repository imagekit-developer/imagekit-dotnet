using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Beta.V2.Files.FileUploadResponseProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueProperties;

[JsonConverter(typeof(UnnamedSchemaWithArrayParent6Converter))]
public record class UnnamedSchemaWithArrayParent6
{
    public object Value { get; private init; }

    public UnnamedSchemaWithArrayParent6(string value)
    {
        Value = value;
    }

    public UnnamedSchemaWithArrayParent6(double value)
    {
        Value = value;
    }

    public UnnamedSchemaWithArrayParent6(bool value)
    {
        Value = value;
    }

    UnnamedSchemaWithArrayParent6(UnknownVariant value)
    {
        Value = value;
    }

    public static UnnamedSchemaWithArrayParent6 CreateUnknownVariant(JsonElement value)
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

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent6"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent6"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent6"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class UnnamedSchemaWithArrayParent6Converter : JsonConverter<UnnamedSchemaWithArrayParent6>
{
    public override UnnamedSchemaWithArrayParent6? Read(
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
                return new UnnamedSchemaWithArrayParent6(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        try
        {
            return new UnnamedSchemaWithArrayParent6(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant 'double'", e)
            );
        }

        try
        {
            return new UnnamedSchemaWithArrayParent6(
                JsonSerializer.Deserialize<bool>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent6 value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
