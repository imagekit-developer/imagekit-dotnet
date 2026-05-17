using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files;

[JsonConverter(typeof(JsonModelConverter<FileRemoveTagsResponse, FileRemoveTagsResponseFromRaw>))]
public sealed record class FileRemoveTagsResponse : JsonModel
{
    /// <summary>
    /// An array of fileIds that in which tags were successfully removed.
    /// </summary>
    public IReadOnlyList<string>? SuccessfullyUpdatedFileIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "successfullyUpdatedFileIds"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "successfullyUpdatedFileIds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SuccessfullyUpdatedFileIds;
    }

    public FileRemoveTagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileRemoveTagsResponse(FileRemoveTagsResponse fileRemoveTagsResponse)
        : base(fileRemoveTagsResponse) { }
#pragma warning restore CS8618

    public FileRemoveTagsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileRemoveTagsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileRemoveTagsResponseFromRaw.FromRawUnchecked"/>
    public static FileRemoveTagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileRemoveTagsResponseFromRaw : IFromRawJson<FileRemoveTagsResponse>
{
    /// <inheritdoc/>
    public FileRemoveTagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileRemoveTagsResponse.FromRawUnchecked(rawData);
}
