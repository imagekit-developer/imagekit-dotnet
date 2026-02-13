using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models.Files;
using System = System;

namespace ImageKit.Models.Assets;

/// <summary>
/// Object containing details of a file or file version.
/// </summary>
[JsonConverter(typeof(AssetListResponseConverter))]
public record class AssetListResponse : ModelBase
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
                file: (x) => x.CreatedAt,
                folder: (x) => x.CreatedAt
            );
        }
    }

    public string? Name
    {
        get { return Match<string?>(file: (x) => x.Name, folder: (x) => x.Name); }
    }

    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            return Match<System::DateTimeOffset?>(
                file: (x) => x.UpdatedAt,
                folder: (x) => x.UpdatedAt
            );
        }
    }

    public AssetListResponse(File value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssetListResponse(Folder value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssetListResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="File"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFile(out var value)) {
    ///     // `value` is of type `File`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFile([NotNullWhen(true)] out File? value)
    {
        value = this.Value as File;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Folder"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFolder(out var value)) {
    ///     // `value` is of type `Folder`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFolder([NotNullWhen(true)] out Folder? value)
    {
        value = this.Value as Folder;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (File value) => {...},
    ///     (Folder value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<File> file, System::Action<Folder> folder)
    {
        switch (this.Value)
        {
            case File value:
                file(value);
                break;
            case Folder value:
                folder(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of AssetListResponse"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (File value) => {...},
    ///     (Folder value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<File, T> file, System::Func<Folder, T> folder)
    {
        return this.Value switch
        {
            File value => file(value),
            Folder value => folder(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of AssetListResponse"
            ),
        };
    }

    public static implicit operator AssetListResponse(File value) => new(value);

    public static implicit operator AssetListResponse(Folder value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of AssetListResponse"
            );
        }
        this.Switch((file) => file.Validate(), (folder) => folder.Validate());
    }

    public virtual bool Equals(AssetListResponse? other) =>
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
            File _ => 0,
            Folder _ => 1,
            _ => -1,
        };
    }
}

sealed class AssetListResponseConverter : JsonConverter<AssetListResponse>
{
    public override AssetListResponse? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Folder>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<File>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AssetListResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
