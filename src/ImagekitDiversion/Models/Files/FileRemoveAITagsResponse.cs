using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files;

[JsonConverter(
    typeof(JsonModelConverter<FileRemoveAITagsResponse, FileRemoveAITagsResponseFromRaw>)
)]
public sealed record class FileRemoveAITagsResponse : JsonModel
{
    /// <summary>
    /// An array of fileIds that in which AITags were successfully removed.
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

    public FileRemoveAITagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileRemoveAITagsResponse(FileRemoveAITagsResponse fileRemoveAITagsResponse)
        : base(fileRemoveAITagsResponse) { }
#pragma warning restore CS8618

    public FileRemoveAITagsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileRemoveAITagsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileRemoveAITagsResponseFromRaw.FromRawUnchecked"/>
    public static FileRemoveAITagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileRemoveAITagsResponseFromRaw : IFromRawJson<FileRemoveAITagsResponse>
{
    /// <inheritdoc/>
    public FileRemoveAITagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileRemoveAITagsResponse.FromRawUnchecked(rawData);
}
