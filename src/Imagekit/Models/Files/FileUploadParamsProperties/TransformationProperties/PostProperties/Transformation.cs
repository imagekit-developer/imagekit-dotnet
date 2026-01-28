using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.FileUploadParamsProperties.TransformationProperties.PostProperties;

[JsonConverter(
    typeof(ModelConverter<global::Imagekit.Models.Files.FileUploadParamsProperties.TransformationProperties.PostProperties.Transformation>)
)]
public sealed record class Transformation
    : ModelBase,
        IFromRaw<global::Imagekit.Models.Files.FileUploadParamsProperties.TransformationProperties.PostProperties.Transformation>
{
    /// <summary>
    /// Transformation type.
    /// </summary>
    public TransformationProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<TransformationProperties::Type>(
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
    /// Transformation string (e.g. `w-200,h-200`).   Same syntax as ImageKit URL-based
    /// transformations.
    /// </summary>
    public required string Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out JsonElement element))
                throw new ArgumentOutOfRangeException("value", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("value");
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

    public Transformation()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transformation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Imagekit.Models.Files.FileUploadParamsProperties.TransformationProperties.PostProperties.Transformation FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Transformation(string value)
        : this()
    {
        this.Value = value;
    }
}
