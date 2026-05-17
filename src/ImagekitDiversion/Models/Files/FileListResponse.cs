using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Files.Details;
using System = System;

namespace ImagekitDiversion.Models.Files;

/// <summary>
/// Object containing details of a file or file version.
/// </summary>
[JsonConverter(typeof(FileListResponseConverter))]
public record class FileListResponse : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                details: (x) => x.CreatedAt,
                folder: (x) => x.CreatedAt
            );
        }
    }

    public string? Name
    {
        get { return Match<string?>(details: (x) => x.Name, folder: (x) => x.Name); }
    }

    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                details: (x) => x.UpdatedAt,
                folder: (x) => x.UpdatedAt
            );
        }
    }

    public FileListResponse(FileDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FileListResponse(FileListResponseFolder value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FileListResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDetails(out var value)) {
    ///     // `value` is of type `FileDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDetails([NotNullWhen(true)] out FileDetails? value)
    {
        value = this.Value as FileDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileListResponseFolder"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFolder(out var value)) {
    ///     // `value` is of type `FileListResponseFolder`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFolder([NotNullWhen(true)] out FileListResponseFolder? value)
    {
        value = this.Value as FileListResponseFolder;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (FileDetails value) =&gt; {...},
    ///     (FileListResponseFolder value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<FileDetails> details,
        System::Action<FileListResponseFolder> folder
    )
    {
        switch (this.Value)
        {
            case FileDetails value:
                details(value);
                break;
            case FileListResponseFolder value:
                folder(value);
                break;
            default:
                throw new ImagekitDiversionInvalidDataException(
                    "Data did not match any variant of FileListResponse"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (FileDetails value) =&gt; {...},
    ///     (FileListResponseFolder value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<FileDetails, T> details,
        System::Func<FileListResponseFolder, T> folder
    )
    {
        return this.Value switch
        {
            FileDetails value => details(value),
            FileListResponseFolder value => folder(value),
            _ => throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of FileListResponse"
            ),
        };
    }

    public static implicit operator FileListResponse(FileDetails value) => new(value);

    public static implicit operator FileListResponse(FileListResponseFolder value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of FileListResponse"
            );
        }
        this.Switch((details) => details.Validate(), (folder) => folder.Validate());
    }

    public virtual bool Equals(FileListResponse? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            FileDetails _ => 0,
            FileListResponseFolder _ => 1,
            _ => -1,
        };
    }
}

sealed class FileListResponseConverter : JsonConverter<FileListResponse>
{
    public override FileListResponse? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "folder":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileListResponseFolder>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileDetails>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileListResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<FileListResponseFolder, FileListResponseFolderFromRaw>))]
public sealed record class FileListResponseFolder : JsonModel
{
    /// <summary>
    /// Date and time when the folder was created. The date and time is in ISO8601 format.
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
    public ApiEnum<string, FileListResponseFolderType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FileListResponseFolderType>>(
                "type"
            );
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
    /// Date and time when the folder was last updated. The date and time is in ISO8601 format.
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

    public FileListResponseFolder() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileListResponseFolder(FileListResponseFolder fileListResponseFolder)
        : base(fileListResponseFolder) { }
#pragma warning restore CS8618

    public FileListResponseFolder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListResponseFolder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileListResponseFolderFromRaw.FromRawUnchecked"/>
    public static FileListResponseFolder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileListResponseFolderFromRaw : IFromRawJson<FileListResponseFolder>
{
    /// <inheritdoc/>
    public FileListResponseFolder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileListResponseFolder.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the asset.
/// </summary>
[JsonConverter(typeof(FileListResponseFolderTypeConverter))]
public enum FileListResponseFolderType
{
    Folder,
}

sealed class FileListResponseFolderTypeConverter : JsonConverter<FileListResponseFolderType>
{
    public override FileListResponseFolderType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "folder" => FileListResponseFolderType.Folder,
            _ => (FileListResponseFolderType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileListResponseFolderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileListResponseFolderType.Folder => "folder",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
