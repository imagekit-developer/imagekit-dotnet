using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Cache.Invalidation;

[JsonConverter(typeof(ModelConverter<InvalidationCreateResponse>))]
public sealed record class InvalidationCreateResponse
    : ModelBase,
        IFromRaw<InvalidationCreateResponse>
{
    /// <summary>
    /// Unique identifier of the purge request. This can be used to check the status
    /// of the purge request.
    /// </summary>
    public string? RequestID
    {
        get
        {
            if (!this.Properties.TryGetValue("requestId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["requestId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.RequestID;
    }

    public InvalidationCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InvalidationCreateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InvalidationCreateResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
