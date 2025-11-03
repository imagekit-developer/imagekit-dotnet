using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;

namespace Imagekit.Models.TransformationProperties.AIDropShadowProperties;

[JsonConverter(typeof(Converter))]
public class UnionMember0
{
    public JsonElement Json { get; private init; }

    public UnionMember0()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("true");
    }

    UnionMember0(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new UnionMember0().Json))
        {
            throw new ImageKitInvalidDataException("Invalid constant given for 'UnionMember0'");
        }
    }

    class Converter : JsonConverter<UnionMember0>
    {
        public override UnionMember0? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            UnionMember0 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
