using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SelectOptionVariants = Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties.SelectOptionVariants;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties;

[JsonConverter(typeof(SelectOptionConverter))]
public abstract record class SelectOption
{
    internal SelectOption() { }

    public static implicit operator SelectOption(string value) =>
        new SelectOptionVariants::String(value);

    public static implicit operator SelectOption(double value) =>
        new SelectOptionVariants::Double(value);

    public static implicit operator SelectOption(bool value) =>
        new SelectOptionVariants::Bool(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as SelectOptionVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as SelectOptionVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = (this as SelectOptionVariants::Bool)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SelectOptionVariants::String> @string,
        Action<SelectOptionVariants::Double> @double,
        Action<SelectOptionVariants::Bool> @bool
    )
    {
        switch (this)
        {
            case SelectOptionVariants::String inner:
                @string(inner);
                break;
            case SelectOptionVariants::Double inner:
                @double(inner);
                break;
            case SelectOptionVariants::Bool inner:
                @bool(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<SelectOptionVariants::String, T> @string,
        Func<SelectOptionVariants::Double, T> @double,
        Func<SelectOptionVariants::Bool, T> @bool
    )
    {
        return this switch
        {
            SelectOptionVariants::String inner => @string(inner),
            SelectOptionVariants::Double inner => @double(inner),
            SelectOptionVariants::Bool inner => @bool(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class SelectOptionConverter : JsonConverter<SelectOption>
{
    public override SelectOption? Read(
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
                return new SelectOptionVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new SelectOptionVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new SelectOptionVariants::Bool(
                JsonSerializer.Deserialize<bool>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SelectOption value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            SelectOptionVariants::String(var @string) => @string,
            SelectOptionVariants::Double(var @double) => @double,
            SelectOptionVariants::Bool(var @bool) => @bool,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
