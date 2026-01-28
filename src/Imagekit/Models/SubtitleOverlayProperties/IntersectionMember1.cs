using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.SubtitleOverlayProperties.IntersectionMember1Properties;

namespace Imagekit.Models.SubtitleOverlayProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1 : ModelBase, IFromRaw<IntersectionMember1>
{
    /// <summary>
    /// Specifies the relative path to the subtitle file used as an overlay.
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
    /// Control styling of the subtitle. See [Styling subtitles](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer).
    /// </summary>
    public List<SubtitleOverlayTransformation>? Transformation
    {
        get
        {
            if (!this.Properties.TryGetValue("transformation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<SubtitleOverlayTransformation>?>(
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

    public override void Validate()
    {
        _ = this.Input;
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public IntersectionMember1()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public IntersectionMember1(string input)
        : this()
    {
        this.Input = input;
    }
}
