using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Files;

[JsonConverter(typeof(JsonModelConverter<Folder, FolderFromRaw>))]
public sealed record class Folder : JsonModel
{
    /// <summary>
    /// Date and time when the folder was created. The date and time is in ISO8601
    /// format.
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt");
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
    /// An object with custom metadata for the folder. Returns empty object if no
    /// custom metadata is set.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? CustomMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "customMetadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "customMetadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Unique identifier of the asset.
    /// </summary>
    public string? FolderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folderId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("folderId", value);
        }
    }

    /// <summary>
    /// Path of the folder. This is the path you would use in the URL to access the
    /// folder. For example, if the folder is at the root of the media library, the
    /// path will be /folder. If the folder is inside another folder named images,
    /// the path will be /images/folder.
    /// </summary>
    public string? FolderPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("folderPath");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("folderPath", value);
        }
    }

    /// <summary>
    /// Name of the asset.
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
    /// Type of the asset.
    /// </summary>
    public ApiEnum<string, FolderType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FolderType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// Date and time when the folder was last updated. The date and time is in ISO8601
    /// format.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updatedAt");
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
        _ = this.CreatedAt;
        _ = this.CustomMetadata;
        _ = this.FolderID;
        _ = this.FolderPath;
        _ = this.Name;
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public Folder() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Folder(Folder folder)
        : base(folder) { }
#pragma warning restore CS8618

    public Folder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Folder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderFromRaw.FromRawUnchecked"/>
    public static Folder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderFromRaw : IFromRawJson<Folder>
{
    /// <inheritdoc/>
    public Folder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Folder.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the asset.
/// </summary>
[JsonConverter(typeof(FolderTypeConverter))]
public enum FolderType
{
    Folder,
}

sealed class FolderTypeConverter : JsonConverter<FolderType>
{
    public override FolderType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "folder" => FolderType.Folder,
            _ => (FolderType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FolderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FolderType.Folder => "folder",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
