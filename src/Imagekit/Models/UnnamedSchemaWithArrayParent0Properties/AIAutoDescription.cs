using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;

namespace Imagekit.Models.UnnamedSchemaWithArrayParent0Properties;

[JsonConverter(typeof(Converter))]
public class AIAutoDescription
{
    public JsonElement Json { get; private init; }

    public AIAutoDescription()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("{\"name\":\"ai-auto-description\"}");
    }

    AIAutoDescription(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new AIAutoDescription().Json))
        {
            throw new ImageKitInvalidDataException(
                "Invalid constant given for 'AIAutoDescription'"
            );
        }
    }

    class Converter : JsonConverter<AIAutoDescription>
    {
        public override AIAutoDescription? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            AIAutoDescription value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
