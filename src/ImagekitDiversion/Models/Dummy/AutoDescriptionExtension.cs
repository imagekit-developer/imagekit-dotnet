using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;

namespace ImagekitDiversion.Models.Dummy;

[JsonConverter(
    typeof(JsonModelConverter<AutoDescriptionExtension, AutoDescriptionExtensionFromRaw>)
)]
public sealed record class AutoDescriptionExtension : JsonModel
{
    /// <summary>
    /// Specifies the auto description extension.
    /// </summary>
    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Name,
                JsonSerializer.SerializeToElement("ai-auto-description")
            )
        )
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
    }

    public AutoDescriptionExtension()
    {
        this.Name = JsonSerializer.SerializeToElement("ai-auto-description");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoDescriptionExtension(AutoDescriptionExtension autoDescriptionExtension)
        : base(autoDescriptionExtension) { }
#pragma warning restore CS8618

    public AutoDescriptionExtension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("ai-auto-description");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoDescriptionExtension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutoDescriptionExtensionFromRaw.FromRawUnchecked"/>
    public static AutoDescriptionExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutoDescriptionExtensionFromRaw : IFromRawJson<AutoDescriptionExtension>
{
    /// <inheritdoc/>
    public AutoDescriptionExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutoDescriptionExtension.FromRawUnchecked(rawData);
}
