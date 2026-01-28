using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.UnnamedSchemaWithArrayParent0Properties;
using UnnamedSchemaWithArrayParent0Variants = Imagekit.Models.UnnamedSchemaWithArrayParent0Variants;

namespace Imagekit.Models;

[JsonConverter(typeof(UnnamedSchemaWithArrayParent0Converter))]
public abstract record class UnnamedSchemaWithArrayParent0
{
    internal UnnamedSchemaWithArrayParent0() { }

    public static implicit operator UnnamedSchemaWithArrayParent0(RemoveBg value) =>
        new UnnamedSchemaWithArrayParent0Variants::RemoveBg(value);

    public static implicit operator UnnamedSchemaWithArrayParent0(AutoTaggingExtension value) =>
        new UnnamedSchemaWithArrayParent0Variants::AutoTaggingExtension(value);

    public bool TryPickRemoveBg([NotNullWhen(true)] out RemoveBg? value)
    {
        value = (this as UnnamedSchemaWithArrayParent0Variants::RemoveBg)?.Value;
        return value != null;
    }

    public bool TryPickAutoTaggingExtension([NotNullWhen(true)] out AutoTaggingExtension? value)
    {
        value = (this as UnnamedSchemaWithArrayParent0Variants::AutoTaggingExtension)?.Value;
        return value != null;
    }

    public bool TryPickAIAutoDescription([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as UnnamedSchemaWithArrayParent0Variants::AIAutoDescription)?.Value;
        return value != null;
    }

    public void Switch(
        Action<UnnamedSchemaWithArrayParent0Variants::RemoveBg> removeBg,
        Action<UnnamedSchemaWithArrayParent0Variants::AutoTaggingExtension> autoTaggingExtension,
        Action<UnnamedSchemaWithArrayParent0Variants::AIAutoDescription> aiAutoDescription
    )
    {
        switch (this)
        {
            case UnnamedSchemaWithArrayParent0Variants::RemoveBg inner:
                removeBg(inner);
                break;
            case UnnamedSchemaWithArrayParent0Variants::AutoTaggingExtension inner:
                autoTaggingExtension(inner);
                break;
            case UnnamedSchemaWithArrayParent0Variants::AIAutoDescription inner:
                aiAutoDescription(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<UnnamedSchemaWithArrayParent0Variants::RemoveBg, T> removeBg,
        Func<UnnamedSchemaWithArrayParent0Variants::AutoTaggingExtension, T> autoTaggingExtension,
        Func<UnnamedSchemaWithArrayParent0Variants::AIAutoDescription, T> aiAutoDescription
    )
    {
        return this switch
        {
            UnnamedSchemaWithArrayParent0Variants::RemoveBg inner => removeBg(inner),
            UnnamedSchemaWithArrayParent0Variants::AutoTaggingExtension inner =>
                autoTaggingExtension(inner),
            UnnamedSchemaWithArrayParent0Variants::AIAutoDescription inner => aiAutoDescription(
                inner
            ),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class UnnamedSchemaWithArrayParent0Converter : JsonConverter<UnnamedSchemaWithArrayParent0>
{
    public override UnnamedSchemaWithArrayParent0? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? name;
        try
        {
            name = json.GetProperty("name").GetString();
        }
        catch
        {
            name = null;
        }

        switch (name)
        {
            case "remove-bg":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<RemoveBg>(json, options);
                    if (deserialized != null)
                    {
                        return new UnnamedSchemaWithArrayParent0Variants::RemoveBg(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "ai-auto-description":
            {
                List<JsonException> exceptions = [];

                try
                {
                    return new UnnamedSchemaWithArrayParent0Variants::AIAutoDescription(
                        JsonSerializer.Deserialize<JsonElement>(json, options)
                    );
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AutoTaggingExtension>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new UnnamedSchemaWithArrayParent0Variants::AutoTaggingExtension(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0 value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            UnnamedSchemaWithArrayParent0Variants::RemoveBg(var removeBg) => removeBg,
            UnnamedSchemaWithArrayParent0Variants::AutoTaggingExtension(var autoTaggingExtension) =>
                autoTaggingExtension,
            UnnamedSchemaWithArrayParent0Variants::AIAutoDescription(var aiAutoDescription) =>
                aiAutoDescription,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
