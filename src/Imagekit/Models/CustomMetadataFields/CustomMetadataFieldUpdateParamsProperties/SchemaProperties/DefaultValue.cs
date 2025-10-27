using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties.DefaultValueProperties;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties;

/// <summary>
/// The default value for this custom metadata field. This property is only required
/// if `isValueRequired` property is set to `true`. The value should match the `type`
/// of custom metadata field.
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

    public static implicit operator DefaultValue(List<UnnamedSchemaWithArrayParent2> value) =>
        new DefaultValueVariants::Mixed(value);

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

    public bool TryPickMixed([NotNullWhen(true)] out List<UnnamedSchemaWithArrayParent2>? value)
    {
        value = this.Value as List<UnnamedSchemaWithArrayParent3>;
        return value != null;
    }

    public void Switch(
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool,
        Action<List<UnnamedSchemaWithArrayParent3>> mixed
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
            case List<UnnamedSchemaWithArrayParent3> value:
                mixed(value);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<List<UnnamedSchemaWithArrayParent3>, T> mixed
    )
    {
        return this.Value switch
        {
            DefaultValueVariants::String inner => @string(inner),
            DefaultValueVariants::Double inner => @double(inner),
            DefaultValueVariants::Bool inner => @bool(inner),
            DefaultValueVariants::Mixed inner => mixed(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
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
                return new DefaultValue(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new DefaultValue(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new DefaultValue(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent2>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new DefaultValue(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        DefaultValue value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            DefaultValueVariants::String(var @string) => @string,
            DefaultValueVariants::Double(var @double) => @double,
            DefaultValueVariants::Bool(var @bool) => @bool,
            DefaultValueVariants::Mixed(var mixed) => mixed,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
