using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Folders.Job.JobGetResponseProperties;

namespace Imagekit.Models.Folders.Job;

[JsonConverter(typeof(ModelConverter<JobGetResponse>))]
public sealed record class JobGetResponse : ModelBase, IFromRaw<JobGetResponse>
{
    /// <summary>
    /// Unique identifier of the bulk job.
    /// </summary>
    public string? JobID
    {
        get
        {
            if (!this.Properties.TryGetValue("jobId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["jobId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Unique identifier of the purge request. This will be present only if `purgeCache`
    /// is set to `true` in the rename folder API request.
    /// </summary>
    public string? PurgeRequestID
    {
        get
        {
            if (!this.Properties.TryGetValue("purgeRequestId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["purgeRequestId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Status of the bulk job.
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

    /// <summary>
    /// Type of the bulk job.
    /// </summary>
    public ApiEnum<string, Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Type>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.JobID;
        _ = this.PurgeRequestID;
        this.Status?.Validate();
        this.Type?.Validate();
    }

    public JobGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobGetResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static JobGetResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
