using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.FileUploadResponseProperties;

[JsonConverter(typeof(ModelConverter<AITag>))]
public sealed record class AITag : ModelBase, IFromRaw<AITag>
{
    /// <summary>
    /// Confidence score of the tag.
    /// </summary>
    public double? Confidence
    {
        get
        {
            if (!this.Properties.TryGetValue("confidence", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["confidence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the tag.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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
    /// Array of `AITags` associated with the image. If no `AITags` are set, it will
    /// be null. These tags can be added using the `google-auto-tagging` or `aws-auto-tagging` extensions.
    /// </summary>
    public string? Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Name;
        _ = this.Source;
    }

    public AITag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AITag(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AITag FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
