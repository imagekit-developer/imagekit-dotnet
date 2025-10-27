using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files;

namespace Imagekit.Models.Assets;

/// <summary>
/// Object containing details of a file or file version.
/// </summary>
[JsonConverter(typeof(AssetListResponseConverter))]
public record class AssetListResponse
{
    public object Value { get; private init; }

    public DateTime? CreatedAt
    {
        get { return Match<DateTime?>(file: (x) => x.CreatedAt, folder: (x) => x.CreatedAt); }
    }

    public string? Name
    {
        get { return Match<string?>(file: (x) => x.Name, folder: (x) => x.Name); }
    }

    public DateTime? UpdatedAt
    {
        get { return Match<DateTime?>(file: (x) => x.UpdatedAt, folder: (x) => x.UpdatedAt); }
    }

    public AssetListResponse(File value)
    {
        Value = value;
    }

    public AssetListResponse(Folder value)
    {
        Value = value;
    }

    AssetListResponse(UnknownVariant value)
    {
        Value = value;
    }

    public static AssetListResponse CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickFile([NotNullWhen(true)] out File? value)
    {
        value = this.Value as File;
        return value != null;
    }

    public bool TryPickFolder([NotNullWhen(true)] out Folder? value)
    {
        value = this.Value as Folder;
        return value != null;
    }

    public void Switch(Action<File> file, Action<Folder> folder)
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
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<File, T> file, Func<Folder, T> folder)
    {
        return this.Value switch
        {
            AssetListResponseVariants::File inner => file(inner),
            AssetListResponseVariants::Folder inner => folder(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of AssetListResponse"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class AssetListResponseConverter : JsonConverter<AssetListResponse>
{
    public override AssetListResponse? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "folder":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Folder>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new AssetListResponse(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<File>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new AssetListResponse(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AssetListResponse value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            AssetListResponseVariants::File(var file) => file,
            AssetListResponseVariants::Folder(var folder) => folder,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
