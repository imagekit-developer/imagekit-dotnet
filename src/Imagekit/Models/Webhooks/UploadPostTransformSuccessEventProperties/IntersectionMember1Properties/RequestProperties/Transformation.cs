using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TransformationProperties = Imagekit.Models.Webhooks.UploadPostTransformSuccessEventProperties.RequestProperties.TransformationProperties;

namespace Imagekit.Models.Webhooks.UploadPostTransformSuccessEventProperties.RequestProperties;

[JsonConverter(
    typeof(ModelConverter<global::Imagekit.Models.Webhooks.UploadPostTransformSuccessEventProperties.IntersectionMember1Properties.RequestProperties.Transformation>)
)]
public sealed record class Transformation
    : ModelBase,
        IFromRaw<global::Imagekit.Models.Webhooks.UploadPostTransformSuccessEventProperties.IntersectionMember1Properties.RequestProperties.Transformation>
{
    /// <summary>
    /// Type of the requested post-transformation.
    /// </summary>
    public required ApiEnum<string, TransformationProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, TransformationProperties::Type>>(
                element,
                ModelBase.SerializerOptions
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
    /// Only applicable if transformation type is 'abs'. Streaming protocol used.
    /// </summary>
    public ApiEnum<string, TransformationProperties::Protocol>? Protocol
    {
        get
        {
            if (!this.Properties.TryGetValue("protocol", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, TransformationProperties::Protocol>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["protocol"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Value for the requested transformation type.
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
        this.Protocol?.Validate();
        _ = this.Value;
    }

    public Transformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transformation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Imagekit.Models.Webhooks.UploadPostTransformSuccessEventProperties.IntersectionMember1Properties.RequestProperties.Transformation FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Transformation(ApiEnum<string, TransformationProperties::Type> type)
        : this()
    {
        this.Type = type;
    }
}
