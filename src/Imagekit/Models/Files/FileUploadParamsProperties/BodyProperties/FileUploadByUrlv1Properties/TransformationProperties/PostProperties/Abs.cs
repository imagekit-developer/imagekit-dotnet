using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties.FileUploadByUrlv1Properties.TransformationProperties.PostProperties.AbsProperties;

namespace Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties.FileUploadByUrlv1Properties.TransformationProperties.PostProperties;

[JsonConverter(typeof(ModelConverter<Abs>))]
public sealed record class Abs : ModelBase, IFromRaw<Abs>
{
    /// <summary>
    /// Streaming protocol to use (`hls` or `dash`).
    /// </summary>
    public required ApiEnum<string, Protocol> Protocol
    {
        get
        {
            if (!this.Properties.TryGetValue("protocol", out JsonElement element))
                throw new ArgumentOutOfRangeException("protocol", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, Protocol>>(
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
    /// Adaptive Bitrate Streaming (ABS) setup.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
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
    /// List of different representations you want to create separated by an underscore.
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
        this.Protocol.Validate();
        _ = this.Value;
    }

    public Abs()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"abs\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Abs(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Abs FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
