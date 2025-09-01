using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files;
using AssetListResponseVariants = Imagekit.Models.Assets.AssetListResponseVariants;

namespace Imagekit.Models.Assets;

/// <summary>
/// Object containing details of a file or file version.
/// </summary>
[JsonConverter(typeof(AssetListResponseConverter))]
public abstract record class AssetListResponse
{
    internal AssetListResponse() { }

    public static implicit operator AssetListResponse(File value) =>
        new AssetListResponseVariants::File(value);

    public static implicit operator AssetListResponse(Folder value) =>
        new AssetListResponseVariants::Folder(value);

    public bool TryPickFile([NotNullWhen(true)] out File? value)
    {
        value = (this as AssetListResponseVariants::File)?.Value;
        return value != null;
    }

    public bool TryPickFolder([NotNullWhen(true)] out Folder? value)
    {
        value = (this as AssetListResponseVariants::Folder)?.Value;
        return value != null;
    }

    public void Switch(
        Action<AssetListResponseVariants::File> file,
        Action<AssetListResponseVariants::Folder> folder
    )
    {
        switch (this)
        {
            case AssetListResponseVariants::File inner:
                file(inner);
                break;
            case AssetListResponseVariants::Folder inner:
                folder(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<AssetListResponseVariants::File, T> file,
        Func<AssetListResponseVariants::Folder, T> folder
    )
    {
        return this switch
        {
            AssetListResponseVariants::File inner => file(inner),
            AssetListResponseVariants::Folder inner => folder(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
                        return new AssetListResponseVariants::Folder(deserialized);
                    }
                }
                catch (JsonException e)
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
                        return new AssetListResponseVariants::File(deserialized);
                    }
                }
                catch (JsonException e)
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
