using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Api.V1.Files;

/// <summary>
/// AI-generated tag associated with an image. These tags can be added using the `google-auto-tagging`
/// or `aws-auto-tagging` extensions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AITag, AITagFromRaw>))]
public sealed record class AITag : JsonModel
{
    /// <summary>
    /// Confidence score of the tag.
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// Name of the tag.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Source of the tag. Possible values are `google-auto-tagging` and `aws-auto-tagging`.
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Name;
        _ = this.Source;
    }

    public AITag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AITag(AITag aiTag)
        : base(aiTag) { }
#pragma warning restore CS8618

    public AITag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AITag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AITagFromRaw.FromRawUnchecked"/>
    public static AITag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AITagFromRaw : IFromRawJson<AITag>
{
    /// <inheritdoc/>
    public AITag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AITag.FromRawUnchecked(rawData);
}
