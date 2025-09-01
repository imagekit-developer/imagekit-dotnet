using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileUploadParamsProperties.ExtensionProperties;
using ExtensionVariants = Imagekit.Models.Files.FileUploadParamsProperties.ExtensionVariants;

namespace Imagekit.Models.Files.FileUploadParamsProperties;

[JsonConverter(typeof(ExtensionConverter))]
public abstract record class Extension
{
    internal Extension() { }

    public static implicit operator Extension(RemoveBg value) =>
        new ExtensionVariants::RemoveBg(value);

    public static implicit operator Extension(AutoTaggingExtension value) =>
        new ExtensionVariants::AutoTaggingExtension(value);

    public bool TryPickRemoveBg([NotNullWhen(true)] out RemoveBg? value)
    {
        value = (this as ExtensionVariants::RemoveBg)?.Value;
        return value != null;
    }

    public bool TryPickAutoTagging([NotNullWhen(true)] out AutoTaggingExtension? value)
    {
        value = (this as ExtensionVariants::AutoTaggingExtension)?.Value;
        return value != null;
    }

    public bool TryPickAIAutoDescription([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as ExtensionVariants::AIAutoDescription)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ExtensionVariants::RemoveBg> removeBg,
        Action<ExtensionVariants::AutoTaggingExtension> autoTagging,
        Action<ExtensionVariants::AIAutoDescription> aiAutoDescription
    )
    {
        switch (this)
        {
            case ExtensionVariants::RemoveBg inner:
                removeBg(inner);
                break;
            case ExtensionVariants::AutoTaggingExtension inner:
                autoTagging(inner);
                break;
            case ExtensionVariants::AIAutoDescription inner:
                aiAutoDescription(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<ExtensionVariants::RemoveBg, T> removeBg,
        Func<ExtensionVariants::AutoTaggingExtension, T> autoTagging,
        Func<ExtensionVariants::AIAutoDescription, T> aiAutoDescription
    )
    {
        return this switch
        {
            ExtensionVariants::RemoveBg inner => removeBg(inner),
            ExtensionVariants::AutoTaggingExtension inner => autoTagging(inner),
            ExtensionVariants::AIAutoDescription inner => aiAutoDescription(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ExtensionConverter : JsonConverter<Extension>
{
    public override Extension? Read(
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
                        return new ExtensionVariants::RemoveBg(deserialized);
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
                    return new ExtensionVariants::AIAutoDescription(
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
                        return new ExtensionVariants::AutoTaggingExtension(deserialized);
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
        Extension value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ExtensionVariants::RemoveBg(var removeBg) => removeBg,
            ExtensionVariants::AutoTaggingExtension(var autoTagging) => autoTagging,
            ExtensionVariants::AIAutoDescription(var aiAutoDescription) => aiAutoDescription,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
