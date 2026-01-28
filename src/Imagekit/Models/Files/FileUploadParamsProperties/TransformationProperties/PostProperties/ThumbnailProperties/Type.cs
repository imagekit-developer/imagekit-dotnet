using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Files.FileUploadParamsProperties.TransformationProperties.PostProperties.ThumbnailProperties;

/// <summary>
/// Generates a thumbnail image.
/// </summary>
[JsonConverter(typeof(Converter))]
public class Type
{
    public JsonElement Json { get; private init; }

    public Type()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"thumbnail\"");
    }

    Type(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new Type().Json))
        {
            throw new ImageKitInvalidDataException("Invalid constant given for 'Type'");
        }
    }

    private class Converter : JsonConverter<Type>
    {
        public override Type? Read(
            ref Utf8JsonReader reader,
            System::Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
