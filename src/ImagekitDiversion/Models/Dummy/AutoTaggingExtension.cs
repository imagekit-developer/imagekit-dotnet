using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;

namespace ImagekitDiversion.Models.Dummy;

[JsonConverter(typeof(JsonModelConverter<AutoTaggingExtension, AutoTaggingExtensionFromRaw>))]
public sealed record class AutoTaggingExtension : JsonModel
{
    /// <summary>
    /// Maximum number of tags to attach to the asset.
    /// </summary>
    public required long MaxTags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("maxTags");
        }
        init { this._rawData.Set("maxTags", value); }
    }

    /// <summary>
    /// Minimum confidence level for tags to be considered valid.
    /// </summary>
    public required long MinConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("minConfidence");
        }
        init { this._rawData.Set("minConfidence", value); }
    }

    /// <summary>
    /// Specifies the auto-tagging extension used.
    /// </summary>
    public required ApiEnum<string, Name> Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Name>>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaxTags;
        _ = this.MinConfidence;
        this.Name.Validate();
    }

    public AutoTaggingExtension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoTaggingExtension(AutoTaggingExtension autoTaggingExtension)
        : base(autoTaggingExtension) { }
#pragma warning restore CS8618

    public AutoTaggingExtension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoTaggingExtension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutoTaggingExtensionFromRaw.FromRawUnchecked"/>
    public static AutoTaggingExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutoTaggingExtensionFromRaw : IFromRawJson<AutoTaggingExtension>
{
    /// <inheritdoc/>
    public AutoTaggingExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutoTaggingExtension.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the auto-tagging extension used.
/// </summary>
[JsonConverter(typeof(NameConverter))]
public enum Name
{
    GoogleAutoTagging,
    AwsAutoTagging,
}

sealed class NameConverter : JsonConverter<Name>
{
    public override Name Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "google-auto-tagging" => Name.GoogleAutoTagging,
            "aws-auto-tagging" => Name.AwsAutoTagging,
            _ => (Name)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Name value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Name.GoogleAutoTagging => "google-auto-tagging",
                Name.AwsAutoTagging => "aws-auto-tagging",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
