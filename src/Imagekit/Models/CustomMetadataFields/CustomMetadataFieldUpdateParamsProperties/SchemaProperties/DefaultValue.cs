using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties.DefaultValueProperties;
using DefaultValueVariants = Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties.DefaultValueVariants;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties;

/// <summary>
/// The default value for this custom metadata field. This property is only required
/// if `isValueRequired` property is set to `true`. The value should match the `type`
/// of custom metadata field.
/// </summary>
[JsonConverter(typeof(DefaultValueConverter))]
public abstract record class DefaultValue
{
    internal DefaultValue() { }

    public static implicit operator DefaultValue(string value) =>
        new DefaultValueVariants::String(value);

    public static implicit operator DefaultValue(double value) =>
        new DefaultValueVariants::Double(value);

    public static implicit operator DefaultValue(bool value) =>
        new DefaultValueVariants::Bool(value);

    public static implicit operator DefaultValue(List<UnnamedSchemaWithArrayParent2> value) =>
        new DefaultValueVariants::Mixed(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as DefaultValueVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as DefaultValueVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = (this as DefaultValueVariants::Bool)?.Value;
        return value != null;
    }

    public bool TryPickMixed([NotNullWhen(true)] out List<UnnamedSchemaWithArrayParent2>? value)
    {
        value = (this as DefaultValueVariants::Mixed)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DefaultValueVariants::String> @string,
        Action<DefaultValueVariants::Double> @double,
        Action<DefaultValueVariants::Bool> @bool,
        Action<DefaultValueVariants::Mixed> mixed
    )
    {
        switch (this)
        {
            case DefaultValueVariants::String inner:
                @string(inner);
                break;
            case DefaultValueVariants::Double inner:
                @double(inner);
                break;
            case DefaultValueVariants::Bool inner:
                @bool(inner);
                break;
            case DefaultValueVariants::Mixed inner:
                mixed(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<DefaultValueVariants::String, T> @string,
        Func<DefaultValueVariants::Double, T> @double,
        Func<DefaultValueVariants::Bool, T> @bool,
        Func<DefaultValueVariants::Mixed, T> mixed
    )
    {
        return this switch
        {
            DefaultValueVariants::String inner => @string(inner),
            DefaultValueVariants::Double inner => @double(inner),
            DefaultValueVariants::Bool inner => @bool(inner),
            DefaultValueVariants::Mixed inner => mixed(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
                return new DefaultValueVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new DefaultValueVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new DefaultValueVariants::Bool(
                JsonSerializer.Deserialize<bool>(ref reader, options)
            );
        }
        catch (JsonException e)
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
                return new DefaultValueVariants::Mixed(deserialized);
            }
        }
        catch (JsonException e)
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
