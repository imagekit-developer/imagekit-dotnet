using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Assets.AssetListParamsProperties;

/// <summary>
/// Filter results by asset type.
///
/// - `file` — returns only files   - `file-version` — returns specific file versions
///   - `folder` — returns only folders   - `all` — returns both files and folders
/// (excludes `file-version`)
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    File,
    FileVersion,
    Folder,
    All,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file" => AssetListParamsProperties.Type.File,
            "file-version" => AssetListParamsProperties.Type.FileVersion,
            "folder" => AssetListParamsProperties.Type.Folder,
            "all" => AssetListParamsProperties.Type.All,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AssetListParamsProperties.Type.File => "file",
                AssetListParamsProperties.Type.FileVersion => "file-version",
                AssetListParamsProperties.Type.Folder => "folder",
                AssetListParamsProperties.Type.All => "all",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
