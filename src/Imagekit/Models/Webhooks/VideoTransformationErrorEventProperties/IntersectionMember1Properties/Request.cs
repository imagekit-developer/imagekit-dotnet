using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Webhooks.VideoTransformationErrorEventProperties;

/// <summary>
/// Information about the original request that triggered the video transformation.
/// </summary>
[JsonConverter(typeof(ModelConverter<Request>))]
public sealed record class Request : ModelBase, IFromRaw<Request>
{
    /// <summary>
    /// Full URL of the transformation request that was submitted.
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new ArgumentOutOfRangeException("url", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("url");
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier for the originating transformation request.
    /// </summary>
    public required string XRequestID
    {
        get
        {
            if (!this.Properties.TryGetValue("x_request_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("x_request_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("x_request_id");
        }
        set
        {
            this.Properties["x_request_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User-Agent header from the original request that triggered the transformation.
    /// </summary>
    public string? UserAgent
    {
        get
        {
            if (!this.Properties.TryGetValue("user_agent", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["user_agent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.URL;
        _ = this.XRequestID;
        _ = this.UserAgent;
    }

    public Request() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Request(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Request FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
