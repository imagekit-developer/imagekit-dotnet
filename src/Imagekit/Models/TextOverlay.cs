using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.TextOverlayProperties.IntersectionMember1Properties;

namespace Imagekit.Models;

[JsonConverter(typeof(ModelConverter<TextOverlay>))]
public sealed record class TextOverlay : ModelBase, IFromRaw<TextOverlay>
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
    /// Specifies the text to be displayed in the overlay. The SDK automatically handles
    /// special characters and encoding.
    /// </summary>
    public required string Text
    {
        get
        {
            if (!this.Properties.TryGetValue("text", out JsonElement element))
                throw new ArgumentOutOfRangeException("text", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("text");
        }
        set
        {
            this.Properties["text"] = JsonSerializer.SerializeToElement(
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
    /// Text can be included in the layer as either `i-{input}` (plain text) or `ie-{base64_encoded_input}`
    /// (base64).  By default, the SDK selects the appropriate format based on the
    /// input text.  To always use base64 (`ie-{base64}`), set this parameter to
    /// `base64`.  To always use plain text (`i-{input}`), set it to `plain`.
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
    /// Control styling of the text overlay. See [Text overlays](https://imagekit.io/docs/add-overlays-on-images#text-overlay).
    /// </summary>
    public List<TextOverlayTransformation>? Transformation
    {
        get
        {
            if (!this.Properties.TryGetValue("transformation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<TextOverlayTransformation>?>(
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

    public static implicit operator BaseOverlay(TextOverlay textOverlay) =>
        new() { Position = textOverlay.Position, Timing = textOverlay.Timing };

    public override void Validate()
    {
        this.Position?.Validate();
        this.Timing?.Validate();
        _ = this.Text;
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public TextOverlay()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextOverlay(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TextOverlay FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public TextOverlay(string text)
        : this()
    {
        this.Text = text;
    }
}
