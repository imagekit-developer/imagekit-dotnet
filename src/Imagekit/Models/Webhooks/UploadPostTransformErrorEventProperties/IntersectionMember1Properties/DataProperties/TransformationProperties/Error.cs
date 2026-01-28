using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Webhooks.UploadPostTransformErrorEventProperties.DataProperties.TransformationProperties;

[JsonConverter(typeof(ModelConverter<Error>))]
public sealed record class Error : ModelBase, IFromRaw<Error>
{
    /// <summary>
    /// Reason for the post-transformation failure.
    /// </summary>
    public required string Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                throw new ArgumentOutOfRangeException("reason", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("reason");
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Reason;
    }

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Error FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Error(string reason)
        : this()
    {
        this.Reason = reason;
    }
}
