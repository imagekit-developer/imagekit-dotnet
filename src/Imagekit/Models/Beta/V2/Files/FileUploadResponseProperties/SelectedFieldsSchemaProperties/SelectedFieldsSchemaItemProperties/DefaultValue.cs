using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using Imagekit.Models.Beta.V2.Files.FileUploadResponseProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueProperties;
using System = System;

namespace Imagekit.Models.Beta.V2.Files.FileUploadResponseProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties;

/// <summary>
/// The default value for this custom metadata field. The value should match the
/// `type` of custom metadata field.
/// </summary>
[JsonConverter(typeof(DefaultValueConverter))]
public record class DefaultValue
{
    public object Value { get; private init; }

    public DefaultValue(string value)
    {
        Value = value;
    }

    public DefaultValue(double value)
    {
        Value = value;
    }

    public DefaultValue(bool value)
    {
        Value = value;
    }

    public DefaultValue(List<UnnamedSchemaWithArrayParent6> value)
    {
        Value = value;
    }

    DefaultValue(UnknownVariant value)
    {
        Value = value;
    }

    public static DefaultValue CreateUnknownVariant(JsonElement value)
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

    public bool TryPickMixed([NotNullWhen(true)] out List<UnnamedSchemaWithArrayParent6>? value)
    {
        value = this.Value as List<UnnamedSchemaWithArrayParent6>;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool,
        System::Action<List<UnnamedSchemaWithArrayParent6>> mixed
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
            case List<UnnamedSchemaWithArrayParent6> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of DefaultValue"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool,
        System::Func<List<UnnamedSchemaWithArrayParent6>, T> mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            List<UnnamedSchemaWithArrayParent6> value => mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of DefaultValue"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of DefaultValue"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class DefaultValueConverter : JsonConverter<DefaultValue>
{
    public override DefaultValue? Read(
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
                return new DefaultValue(deserialized);
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
            return new DefaultValue(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant 'double'", e)
            );
        }

        try
        {
            return new DefaultValue(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent6>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new DefaultValue(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant 'List<UnnamedSchemaWithArrayParent6>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        DefaultValue value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
