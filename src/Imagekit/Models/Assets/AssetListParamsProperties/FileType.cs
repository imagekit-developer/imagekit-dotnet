using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Assets.AssetListParamsProperties;

/// <summary>
/// Filter results by file type.
///
/// - `all` — include all file types   - `image` — include only image files   - `non-image`
/// — include only non-image files (e.g., JS, CSS, video)
/// </summary>
[JsonConverter(typeof(FileTypeConverter))]
public enum FileType
{
    All,
    Image,
    NonImage,
}

sealed class FileTypeConverter : JsonConverter<FileType>
{
    public override FileType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => FileType.All,
            "image" => FileType.Image,
            "non-image" => FileType.NonImage,
            _ => (FileType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, FileType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileType.All => "all",
                FileType.Image => "image",
                FileType.NonImage => "non-image",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
