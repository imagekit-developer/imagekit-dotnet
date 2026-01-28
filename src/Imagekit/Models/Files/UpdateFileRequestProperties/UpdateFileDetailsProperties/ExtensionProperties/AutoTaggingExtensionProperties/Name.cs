using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.FileUpdateParamsProperties.UpdateProperties.UpdateFileDetailsProperties.ExtensionProperties.AutoTaggingExtensionProperties;

/// <summary>
/// Specifies the auto-tagging extension used.
/// </summary>
[JsonConverter(typeof(NameConverter))]
public enum Name
{
    GoogleAutoTagging,
    AwsAutoTagging,
}

sealed class NameConverter : JsonConverter<Name>
{
    public override Name Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "google-auto-tagging" => Name.GoogleAutoTagging,
            "aws-auto-tagging" => Name.AwsAutoTagging,
            _ => (Name)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Name value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Name.GoogleAutoTagging => "google-auto-tagging",
                Name.AwsAutoTagging => "aws-auto-tagging",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
