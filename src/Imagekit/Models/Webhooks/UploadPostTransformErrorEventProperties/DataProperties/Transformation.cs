using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Webhooks.UploadPostTransformErrorEventProperties.DataProperties.TransformationProperties;

namespace Imagekit.Models.Webhooks.UploadPostTransformErrorEventProperties.DataProperties;

[JsonConverter(typeof(ModelConverter<Transformation>))]
public sealed record class Transformation : ModelBase, IFromRaw<Transformation>
{
    public required Error Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out JsonElement element))
                throw new ArgumentOutOfRangeException("error", "Missing required argument");

            return JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("error");
        }
        set
        {
            this.Properties["error"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Error.Validate();
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
    public Transformation(Error error)
        : this()
    {
        this.Error = error;
    }
}
