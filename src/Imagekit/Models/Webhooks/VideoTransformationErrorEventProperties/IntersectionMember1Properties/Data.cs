using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataProperties = Imagekit.Models.Webhooks.VideoTransformationErrorEventProperties.DataProperties;

namespace Imagekit.Models.Webhooks.VideoTransformationErrorEventProperties;

[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    /// <summary>
    /// Information about the source video asset being transformed.
    /// </summary>
    public required DataProperties::Asset Asset
    {
        get
        {
            if (!this.Properties.TryGetValue("asset", out JsonElement element))
                throw new ArgumentOutOfRangeException("asset", "Missing required argument");

            return JsonSerializer.Deserialize<DataProperties::Asset>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("asset");
        }
        set
        {
            this.Properties["asset"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required DataProperties::Transformation Transformation
    {
        get
        {
            if (!this.Properties.TryGetValue("transformation", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "transformation",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<DataProperties::Transformation>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("transformation");
        }
        set
        {
            this.Properties["transformation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Asset.Validate();
        this.Transformation.Validate();
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
