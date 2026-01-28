using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.ImageOverlayProperties.IntersectionMember1Properties;

namespace Imagekit.Models;

[JsonConverter(typeof(ModelConverter<ImageOverlay>))]
public sealed record class ImageOverlay : ModelBase, IFromRaw<ImageOverlay>
{
    public OverlayPosition? Position
    {
        get
        {
            if (!this.Properties.TryGetValue("position", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OverlayPosition?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["position"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public OverlayTiming? Timing
    {
        get
        {
            if (!this.Properties.TryGetValue("timing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OverlayTiming?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the relative path to the image used as an overlay.
    /// </summary>
    public required string Input
    {
        get
        {
            if (!this.Properties.TryGetValue("input", out JsonElement element))
                throw new ArgumentOutOfRangeException("input", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("input");
        }
        set
        {
            this.Properties["input"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    /// The input path can be included in the layer as either `i-{input}` or `ie-{base64_encoded_input}`.
    ///  By default, the SDK determines the appropriate format automatically.  To
    /// always use base64 encoding (`ie-{base64}`), set this parameter to `base64`.
    ///  To always use plain text (`i-{input}`), set it to `plain`.
    /// </summary>
    public ApiEnum<string, Encoding>? Encoding
    {
        get
        {
            if (!this.Properties.TryGetValue("encoding", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Encoding>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["encoding"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of transformations to be applied to the overlay image. Supported transformations
    /// depends on the base/parent asset. See overlays on [Images](https://imagekit.io/docs/add-overlays-on-images#list-of-supported-image-transformations-in-image-layers)
    /// and [Videos](https://imagekit.io/docs/add-overlays-on-videos#list-of-transformations-supported-on-image-overlay).
    /// </summary>
    public List<Transformation>? Transformation
    {
        get
        {
            if (!this.Properties.TryGetValue("transformation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Transformation>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["transformation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator BaseOverlay(ImageOverlay imageOverlay) =>
        new() { Position = imageOverlay.Position, Timing = imageOverlay.Timing };

    public override void Validate()
    {
        this.Position?.Validate();
        this.Timing?.Validate();
        _ = this.Input;
        _ = this.Type;
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public ImageOverlay()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageOverlay(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ImageOverlay FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ImageOverlay(string input)
        : this()
    {
        this.Input = input;
    }
}
