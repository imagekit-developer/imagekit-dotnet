using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;

namespace Imagekit.Models.TextOverlayTransformationProperties.RadiusProperties;

[JsonConverter(typeof(Converter))]
public class UnionMember1
{
    public JsonElement Json { get; private init; }

    public UnionMember1()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"max\"");
    }

    UnionMember1(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new UnionMember1().Json))
        {
            throw new ImageKitInvalidDataException("Invalid constant given for 'UnionMember1'");
        }
    }

    class Converter : JsonConverter<UnionMember1>
    {
        public override UnionMember1? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            UnionMember1 value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
