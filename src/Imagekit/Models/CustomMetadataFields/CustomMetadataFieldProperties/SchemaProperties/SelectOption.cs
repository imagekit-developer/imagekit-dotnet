using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldProperties.SchemaProperties.SelectOptionVariants;
using System = System;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldProperties.SchemaProperties;

[JsonConverter(typeof(SelectOptionConverter))]
public record class SelectOption
{
    public object Value { get; private init; }

    public SelectOption(string value)
    {
        Value = value;
    }

    public SelectOption(double value)
    {
        Value = value;
    }

    public SelectOption(bool value)
    {
        Value = value;
    }

    SelectOption(UnknownVariant value)
    {
        Value = value;
    }

    public static SelectOption CreateUnknownVariant(JsonElement value)
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
                throw new System::InvalidOperationException();
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
            String inner => @string(inner),
            Double inner => @double(inner),
            Bool inner => @bool(inner),
            _ => throw new System::InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of SelectOption"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class SelectOptionConverter : JsonConverter<SelectOption>
{
    public override SelectOption? Read(
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
                return new SelectOption(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new SelectOption(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new SelectOption(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SelectOption value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            String(var @string) => @string,
            Double(var @double) => @double,
            Bool(var @bool) => @bool,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
