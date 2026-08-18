using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.AIFilterSearch;

[JsonConverter(
    typeof(JsonModelConverter<AIFilterSearchCreateResponse, AIFilterSearchCreateResponseFromRaw>)
)]
public sealed record class AIFilterSearchCreateResponse : JsonModel
{
    /// <summary>
    /// Suggested asset-type filter derived from the prompt. Empty string means no
    /// file-type restriction.
    /// </summary>
    public ApiEnum<string, FileType>? FileType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FileType>>("fileType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fileType", value);
        }
    }

    /// <summary>
    /// Whether previous file versions should be included in the search results.
    /// </summary>
    public bool? IsVersionIncludedInSearch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isVersionIncludedInSearch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isVersionIncludedInSearch", value);
        }
    }

    /// <summary>
    /// Generated query in ImageKit's Lucene-like syntax. Pass this as the `searchQuery`
    /// parameter to the list and search assets API. Empty string when no filters
    /// could be derived from the prompt.
    /// </summary>
    public string? SearchQuery
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("searchQuery");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("searchQuery", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FileType?.Validate();
        _ = this.IsVersionIncludedInSearch;
        _ = this.SearchQuery;
    }

    public AIFilterSearchCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AIFilterSearchCreateResponse(AIFilterSearchCreateResponse aiFilterSearchCreateResponse)
        : base(aiFilterSearchCreateResponse) { }
#pragma warning restore CS8618

    public AIFilterSearchCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AIFilterSearchCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AIFilterSearchCreateResponseFromRaw.FromRawUnchecked"/>
    public static AIFilterSearchCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AIFilterSearchCreateResponseFromRaw : IFromRawJson<AIFilterSearchCreateResponse>
{
    /// <inheritdoc/>
    public AIFilterSearchCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AIFilterSearchCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Suggested asset-type filter derived from the prompt. Empty string means no file-type
/// restriction.
/// </summary>
[JsonConverter(typeof(FileTypeConverter))]
public enum FileType
{
    Undefined,
    Images,
    Videos,
    CssJs,
    Others,
}

sealed class FileTypeConverter : JsonConverter<FileType>
{
    public override FileType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "" => FileType.Undefined,
            "images" => FileType.Images,
            "videos" => FileType.Videos,
            "cssJs" => FileType.CssJs,
            "others" => FileType.Others,
            _ => (FileType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, FileType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileType.Undefined => "",
                FileType.Images => "images",
                FileType.Videos => "videos",
                FileType.CssJs => "cssJs",
                FileType.Others => "others",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
