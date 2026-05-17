using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Files;

[JsonConverter(typeof(JsonModelConverter<FileRenameResponse, FileRenameResponseFromRaw>))]
public sealed record class FileRenameResponse : JsonModel
{
    /// <summary>
    /// Unique identifier of the purge request. This can be used to check the status
    /// of the purge request.
    /// </summary>
    public string? PurgeRequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("purgeRequestId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("purgeRequestId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PurgeRequestID;
    }

    public FileRenameResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileRenameResponse(FileRenameResponse fileRenameResponse)
        : base(fileRenameResponse) { }
#pragma warning restore CS8618

    public FileRenameResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileRenameResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileRenameResponseFromRaw.FromRawUnchecked"/>
    public static FileRenameResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileRenameResponseFromRaw : IFromRawJson<FileRenameResponse>
{
    /// <inheritdoc/>
    public FileRenameResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileRenameResponse.FromRawUnchecked(rawData);
}
