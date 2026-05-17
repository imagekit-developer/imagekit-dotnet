using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files;

[JsonConverter(typeof(JsonModelConverter<FileAddTagsResponse, FileAddTagsResponseFromRaw>))]
public sealed record class FileAddTagsResponse : JsonModel
{
    /// <summary>
    /// An array of fileIds that in which tags were successfully added.
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

    public FileAddTagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileAddTagsResponse(FileAddTagsResponse fileAddTagsResponse)
        : base(fileAddTagsResponse) { }
#pragma warning restore CS8618

    public FileAddTagsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileAddTagsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileAddTagsResponseFromRaw.FromRawUnchecked"/>
    public static FileAddTagsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileAddTagsResponseFromRaw : IFromRawJson<FileAddTagsResponse>
{
    /// <inheritdoc/>
    public FileAddTagsResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileAddTagsResponse.FromRawUnchecked(rawData);
}
