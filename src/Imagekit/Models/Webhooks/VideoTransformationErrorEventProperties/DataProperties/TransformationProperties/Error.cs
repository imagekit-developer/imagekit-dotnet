using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Webhooks.VideoTransformationErrorEventProperties.DataProperties.TransformationProperties.ErrorProperties;
using System = System;

namespace Imagekit.Models.Webhooks.VideoTransformationErrorEventProperties.DataProperties.TransformationProperties;

/// <summary>
/// Details about the transformation error.
/// </summary>
[JsonConverter(typeof(ModelConverter<Error>))]
public sealed record class Error : ModelBase, IFromRaw<Error>
{
    /// <summary>
    /// Specific reason for the transformation failure: - `encoding_failed`: Error
    /// during video encoding process - `download_failed`: Could not download source
    /// video - `internal_server_error`: Unexpected server error
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "reason",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
                element,
                ModelBase.SerializerOptions
            );
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
        this.Reason.Validate();
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
    public Error(ApiEnum<string, Reason> reason)
        : this()
    {
        this.Reason = reason;
    }
}
