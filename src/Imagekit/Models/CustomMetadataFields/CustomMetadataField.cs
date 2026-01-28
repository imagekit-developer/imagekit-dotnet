using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldProperties;

namespace Imagekit.Models.CustomMetadataFields;

/// <summary>
/// Object containing details of a custom metadata field.
/// </summary>
[JsonConverter(typeof(ModelConverter<CustomMetadataField>))]
public sealed record class CustomMetadataField : ModelBase, IFromRaw<CustomMetadataField>
{
    /// <summary>
    /// Unique identifier for the custom metadata field. Use this to update the field.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("id");
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Human readable name of the custom metadata field. This name is displayed as
    /// form field label to the users while setting field value on the asset in the
    /// media library UI.
    /// </summary>
    public required string Label
    {
        get
        {
            if (!this.Properties.TryGetValue("label", out JsonElement element))
                throw new ArgumentOutOfRangeException("label", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("label");
        }
        set
        {
            this.Properties["label"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// API name of the custom metadata field. This becomes the key while setting
    /// `customMetadata` (key-value object) for an asset using upload or update API.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An object that describes the rules for the custom metadata field value.
    /// </summary>
    public required Schema Schema
    {
        get
        {
            if (!this.Properties.TryGetValue("schema", out JsonElement element))
                throw new ArgumentOutOfRangeException("schema", "Missing required argument");

            return JsonSerializer.Deserialize<Schema>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("schema");
        }
        set
        {
            this.Properties["schema"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Label;
        _ = this.Name;
        this.Schema.Validate();
    }

    public CustomMetadataField() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomMetadataField(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomMetadataField FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
