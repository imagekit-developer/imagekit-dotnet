using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Accounts.URLEndpoints.URLEndpointCreateParamsProperties.URLRewriterProperties;

[JsonConverter(typeof(ModelConverter<Cloudinary>))]
public sealed record class Cloudinary : ModelBase, IFromRaw<Cloudinary>
{
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
    /// Whether to preserve `<asset_type>/<delivery_type>` in the rewritten URL.
    /// </summary>
    public bool? PreserveAssetDeliveryTypes
    {
        get
        {
            if (!this.Properties.TryGetValue("preserveAssetDeliveryTypes", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["preserveAssetDeliveryTypes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PreserveAssetDeliveryTypes;
    }

    public Cloudinary()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"CLOUDINARY\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cloudinary(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Cloudinary FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
