using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models;

/// <summary>
/// Saved extension object containing extension configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SharedSavedExtension, SharedSavedExtensionFromRaw>))]
public sealed record class SharedSavedExtension : JsonModel
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
    public ExtensionConfig? Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExtensionConfig>("config");
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

    public SharedSavedExtension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SharedSavedExtension(SharedSavedExtension sharedSavedExtension)
        : base(sharedSavedExtension) { }
#pragma warning restore CS8618

    public SharedSavedExtension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SharedSavedExtension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SharedSavedExtensionFromRaw.FromRawUnchecked"/>
    public static SharedSavedExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SharedSavedExtensionFromRaw : IFromRawJson<SharedSavedExtension>
{
    /// <inheritdoc/>
    public SharedSavedExtension FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SharedSavedExtension.FromRawUnchecked(rawData);
}
