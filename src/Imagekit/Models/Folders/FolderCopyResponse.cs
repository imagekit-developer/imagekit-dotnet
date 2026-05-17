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
[JsonConverter(typeof(JsonModelConverter<FolderCopyResponse, FolderCopyResponseFromRaw>))]
public sealed record class FolderCopyResponse : JsonModel
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

    public FolderCopyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderCopyResponse(FolderCopyResponse folderCopyResponse)
        : base(folderCopyResponse) { }
#pragma warning restore CS8618

    public FolderCopyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderCopyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderCopyResponseFromRaw.FromRawUnchecked"/>
    public static FolderCopyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FolderCopyResponse(string jobID)
        : this()
    {
        this.JobID = jobID;
    }
}

class FolderCopyResponseFromRaw : IFromRawJson<FolderCopyResponse>
{
    /// <inheritdoc/>
    public FolderCopyResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FolderCopyResponse.FromRawUnchecked(rawData);
}
