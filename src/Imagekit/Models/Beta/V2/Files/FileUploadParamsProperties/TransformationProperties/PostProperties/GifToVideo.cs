using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.TransformationProperties.PostProperties;

[JsonConverter(typeof(ModelConverter<GifToVideo>))]
public sealed record class GifToVideo : ModelBase, IFromRaw<GifToVideo>
{
    /// <summary>
    /// Converts an animated GIF into an MP4.
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
    /// Optional transformation string to apply to the output video.   **Example**:
    /// `q-80`
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
        _ = this.Value;
    }

    public GifToVideo()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"gif-to-video\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GifToVideo(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GifToVideo FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
