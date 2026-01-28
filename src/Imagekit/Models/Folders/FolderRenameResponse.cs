using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Folders;

/// <summary>
/// Job submitted successfully. A `jobId` will be returned.
/// </summary>
[JsonConverter(typeof(ModelConverter<FolderRenameResponse>))]
public sealed record class FolderRenameResponse : ModelBase, IFromRaw<FolderRenameResponse>
{
    /// <summary>
    /// Unique identifier of the bulk job. This can be used to check the status of
    /// the bulk job.
    /// </summary>
    public required string JobID
    {
        get
        {
            if (!this.Properties.TryGetValue("jobId", out JsonElement element))
                throw new ArgumentOutOfRangeException("jobId", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("jobId");
        }
        set
        {
            this.Properties["jobId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.JobID;
    }

    public FolderRenameResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderRenameResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FolderRenameResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public FolderRenameResponse(string jobID)
        : this()
    {
        this.JobID = jobID;
    }
}
