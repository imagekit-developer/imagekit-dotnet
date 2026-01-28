using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TransformationProperties = Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties;

namespace Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties;

[JsonConverter(typeof(ModelConverter<Transformation>))]
public sealed record class Transformation : ModelBase, IFromRaw<Transformation>
{
    /// <summary>
    /// Type of video transformation: - `video-transformation`: Standard video processing
    /// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF to
    /// video format - `video-thumbnail`: Generate thumbnail image from video
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
    /// Configuration options for video transformations.
    /// </summary>
    public TransformationProperties::Options? Options
    {
        get
        {
            if (!this.Properties.TryGetValue("options", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TransformationProperties::Options?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["options"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Information about the transformed output video.
    /// </summary>
    public TransformationProperties::Output? Output
    {
        get
        {
            if (!this.Properties.TryGetValue("output", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TransformationProperties::Output?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["output"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Type.Validate();
        this.Options?.Validate();
        this.Output?.Validate();
    }

    public Transformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transformation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Transformation FromRawUnchecked(Dictionary<string, JsonElement> properties)
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
