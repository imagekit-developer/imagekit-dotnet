using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileUploadParamsProperties.ExtensionProperties.RemoveBgProperties;

namespace Imagekit.Models.Files.FileUploadParamsProperties.ExtensionProperties;

[JsonConverter(typeof(ModelConverter<RemoveBg>))]
public sealed record class RemoveBg : ModelBase, IFromRaw<RemoveBg>
{
    /// <summary>
    /// Specifies the background removal extension.
    /// </summary>
    public Name Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<Name>(element, ModelBase.SerializerOptions)
                ?? throw new ImageKitInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Options? Options
    {
        get
        {
            if (!this.Properties.TryGetValue("options", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Options?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["options"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Name.Validate();
        this.Options?.Validate();
    }

    public RemoveBg()
    {
        this.Name = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RemoveBg(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RemoveBg FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
