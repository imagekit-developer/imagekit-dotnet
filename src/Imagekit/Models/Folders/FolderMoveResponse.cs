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
[JsonConverter(typeof(JsonModelConverter<FolderMoveResponse, FolderMoveResponseFromRaw>))]
public sealed record class FolderMoveResponse : JsonModel
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

    public FolderMoveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderMoveResponse(FolderMoveResponse folderMoveResponse)
        : base(folderMoveResponse) { }
#pragma warning restore CS8618

    public FolderMoveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderMoveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderMoveResponseFromRaw.FromRawUnchecked"/>
    public static FolderMoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FolderMoveResponse(string jobID)
        : this()
    {
        this.JobID = jobID;
    }
}

class FolderMoveResponseFromRaw : IFromRawJson<FolderMoveResponse>
{
    /// <inheritdoc/>
    public FolderMoveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FolderMoveResponse.FromRawUnchecked(rawData);
}
