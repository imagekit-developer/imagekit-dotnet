using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.FileUploadParamsProperties.ExtensionProperties.RemoveBgProperties;

[JsonConverter(typeof(ModelConverter<Options>))]
public sealed record class Options : ModelBase, IFromRaw<Options>
{
    /// <summary>
    /// Whether to add an artificial shadow to the result. Default is false. Note:
    /// Adding shadows is currently only supported for car photos.
    /// </summary>
    public bool? AddShadow
    {
        get
        {
            if (!this.Properties.TryGetValue("add_shadow", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["add_shadow"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies a solid color background using hex code (e.g., "81d4fa", "fff")
    /// or color name (e.g., "green"). If this parameter is set, `bg_image_url` must
    /// be empty.
    /// </summary>
    public string? BgColor
    {
        get
        {
            if (!this.Properties.TryGetValue("bg_color", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["bg_color"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Sets a background image from a URL. If this parameter is set, `bg_color`
    /// must be empty.
    /// </summary>
    public string? BgImageURL
    {
        get
        {
            if (!this.Properties.TryGetValue("bg_image_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["bg_image_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Allows semi-transparent regions in the result. Default is true. Note: Semitransparency
    /// is currently only supported for car windows.
    /// </summary>
    public bool? Semitransparency
    {
        get
        {
            if (!this.Properties.TryGetValue("semitransparency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["semitransparency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AddShadow;
        _ = this.BgColor;
        _ = this.BgImageURL;
        _ = this.Semitransparency;
    }

    public Options() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Options FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
