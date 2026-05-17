using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using Dummy = ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Models.SavedExtensions;

/// <summary>
/// Saved extension object containing extension configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SavedExtension, SavedExtensionFromRaw>))]
public sealed record class SavedExtension : JsonModel
{
    /// <summary>
    /// Unique identifier of the saved extension.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Configuration object for an extension (base extensions only, not saved extension references).
    /// </summary>
    public Dummy::ExtensionConfig? Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Dummy::ExtensionConfig>("config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("config", value);
        }
    }

    /// <summary>
    /// Timestamp when the saved extension was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// Description of the saved extension.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Name of the saved extension.
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
    /// Timestamp when the saved extension was last updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Config?.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Name;
        _ = this.UpdatedAt;
    }

    public SavedExtension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SavedExtension(SavedExtension savedExtension)
        : base(savedExtension) { }
#pragma warning restore CS8618

    public SavedExtension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SavedExtension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SavedExtensionFromRaw.FromRawUnchecked"/>
    public static SavedExtension FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SavedExtensionFromRaw : IFromRawJson<SavedExtension>
{
    /// <inheritdoc/>
    public SavedExtension FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SavedExtension.FromRawUnchecked(rawData);
}
