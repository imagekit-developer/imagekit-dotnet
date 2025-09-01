using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Cache.Invalidation.InvalidationGetResponseProperties;

namespace Imagekit.Models.Cache.Invalidation;

[JsonConverter(typeof(ModelConverter<InvalidationGetResponse>))]
public sealed record class InvalidationGetResponse : ModelBase, IFromRaw<InvalidationGetResponse>
{
    /// <summary>
    /// Status of the purge request.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Status>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Status?.Validate();
    }

    public InvalidationGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvalidationGetResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InvalidationGetResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
