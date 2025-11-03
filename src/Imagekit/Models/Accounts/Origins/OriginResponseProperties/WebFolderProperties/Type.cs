using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Accounts.Origins.OriginResponseProperties.WebFolderProperties;

[JsonConverter(typeof(Converter))]
public class Type
{
    public JsonElement Json { get; private init; }

    public Type()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"WEB_FOLDER\"");
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

    class Converter : JsonConverter<Type>
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
