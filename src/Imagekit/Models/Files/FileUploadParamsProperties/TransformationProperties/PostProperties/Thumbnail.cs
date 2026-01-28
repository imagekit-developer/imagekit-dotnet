using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.FileUploadParamsProperties.TransformationProperties.PostProperties;

[JsonConverter(typeof(ModelConverter<Thumbnail>))]
public sealed record class Thumbnail : ModelBase, IFromRaw<Thumbnail>
{
    /// <summary>
    /// Generates a thumbnail image.
    /// </summary>
    public ThumbnailProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<ThumbnailProperties::Type>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new ImageKitInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentNullException("type")
                );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional transformation string.   **Example**: `w-150,h-150`
    /// </summary>
    public string? Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Type.Validate();
        _ = this.Value;
    }

    public Thumbnail()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Thumbnail(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Thumbnail FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
