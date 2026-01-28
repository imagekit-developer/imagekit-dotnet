using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Webhooks.UploadPreTransformErrorEventProperties;

[JsonConverter(typeof(ModelConverter<Request>))]
public sealed record class Request : ModelBase, IFromRaw<Request>
{
    /// <summary>
    /// The requested pre-transformation string.
    /// </summary>
    public required string Transformation
    {
        get
        {
            if (!this.Properties.TryGetValue("transformation", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "transformation",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("transformation");
        }
        set
        {
            this.Properties["transformation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier for the originating request.
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

    public override void Validate()
    {
        _ = this.Transformation;
        _ = this.XRequestID;
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
