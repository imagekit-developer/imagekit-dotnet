using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Folders;

/// <summary>
/// Job submitted successfully. A `jobId` will be returned.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FolderRenameResponse, FolderRenameResponseFromRaw>))]
public sealed record class FolderRenameResponse : JsonModel
{
    /// <summary>
    /// Unique identifier of the bulk job. This can be used to check the status of
    /// the bulk job.
    /// </summary>
    public required string JobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("jobId");
        }
        init { this._rawData.Set("jobId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.JobID;
    }

    public FolderRenameResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderRenameResponse(FolderRenameResponse folderRenameResponse)
        : base(folderRenameResponse) { }
#pragma warning restore CS8618

    public FolderRenameResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderRenameResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderRenameResponseFromRaw.FromRawUnchecked"/>
    public static FolderRenameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FolderRenameResponse(string jobID)
        : this()
    {
        this.JobID = jobID;
    }
}

class FolderRenameResponseFromRaw : IFromRawJson<FolderRenameResponse>
{
    /// <inheritdoc/>
    public FolderRenameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FolderRenameResponse.FromRawUnchecked(rawData);
}
