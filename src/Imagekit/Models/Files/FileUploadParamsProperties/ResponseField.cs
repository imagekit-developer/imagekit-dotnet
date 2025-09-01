using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.FileUploadParamsProperties;

[JsonConverter(typeof(ResponseFieldConverter))]
public enum ResponseField
{
    Tags,
    CustomCoordinates,
    IsPrivateFile,
    EmbeddedMetadata,
    IsPublished,
    CustomMetadata,
    Metadata,
}

sealed class ResponseFieldConverter : JsonConverter<ResponseField>
{
    public override ResponseField Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tags" => ResponseField.Tags,
            "customCoordinates" => ResponseField.CustomCoordinates,
            "isPrivateFile" => ResponseField.IsPrivateFile,
            "embeddedMetadata" => ResponseField.EmbeddedMetadata,
            "isPublished" => ResponseField.IsPublished,
            "customMetadata" => ResponseField.CustomMetadata,
            "metadata" => ResponseField.Metadata,
            _ => (ResponseField)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResponseField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResponseField.Tags => "tags",
                ResponseField.CustomCoordinates => "customCoordinates",
                ResponseField.IsPrivateFile => "isPrivateFile",
                ResponseField.EmbeddedMetadata => "embeddedMetadata",
                ResponseField.IsPublished => "isPublished",
                ResponseField.CustomMetadata => "customMetadata",
                ResponseField.Metadata => "metadata",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
