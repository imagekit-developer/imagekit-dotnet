using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using Imagekit.Models.UnnamedSchemaWithArrayParent0Properties;

namespace Imagekit.Models;

[JsonConverter(typeof(UnnamedSchemaWithArrayParent0Converter))]
public record class UnnamedSchemaWithArrayParent0
{
    public object Value { get; private init; }

    public UnnamedSchemaWithArrayParent0(RemoveBg value)
    {
        Value = value;
    }

    public UnnamedSchemaWithArrayParent0(AutoTaggingExtension value)
    {
        Value = value;
    }

    public UnnamedSchemaWithArrayParent0(AIAutoDescription value)
    {
        Value = value;
    }

    UnnamedSchemaWithArrayParent0(UnknownVariant value)
    {
        Value = value;
    }

    public static UnnamedSchemaWithArrayParent0 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickRemoveBg([NotNullWhen(true)] out RemoveBg? value)
    {
        value = this.Value as RemoveBg;
        return value != null;
    }

    public bool TryPickAutoTaggingExtension([NotNullWhen(true)] out AutoTaggingExtension? value)
    {
        value = this.Value as AutoTaggingExtension;
        return value != null;
    }

    public bool TryPickAIAutoDescription([NotNullWhen(true)] out AIAutoDescription? value)
    {
        value = this.Value as AIAutoDescription;
        return value != null;
    }

    public void Switch(
        Action<RemoveBg> removeBg,
        Action<AutoTaggingExtension> autoTaggingExtension,
        Action<AIAutoDescription> aiAutoDescription
    )
    {
        switch (this.Value)
        {
            case RemoveBg value:
                removeBg(value);
                break;
            case AutoTaggingExtension value:
                autoTaggingExtension(value);
                break;
            case AIAutoDescription value:
                aiAutoDescription(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent0"
                );
        }
    }

    public T Match<T>(
        Func<RemoveBg, T> removeBg,
        Func<AutoTaggingExtension, T> autoTaggingExtension,
        Func<AIAutoDescription, T> aiAutoDescription
    )
    {
        return this.Value switch
        {
            RemoveBg value => removeBg(value),
            AutoTaggingExtension value => autoTaggingExtension(value),
            AIAutoDescription value => aiAutoDescription(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent0"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                List<ImageKitInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<RemoveBg>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new UnnamedSchemaWithArrayParent0(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(
                        new ImageKitInvalidDataException(
                            "Data does not match union variant 'RemoveBg'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "ai-auto-description":
            {
                List<ImageKitInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AIAutoDescription>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new UnnamedSchemaWithArrayParent0(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(
                        new ImageKitInvalidDataException(
                            "Data does not match union variant 'AIAutoDescription'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                List<ImageKitInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AutoTaggingExtension>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new UnnamedSchemaWithArrayParent0(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(
                        new ImageKitInvalidDataException(
                            "Data does not match union variant 'AutoTaggingExtension'",
                            e
                        )
                    );
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
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
