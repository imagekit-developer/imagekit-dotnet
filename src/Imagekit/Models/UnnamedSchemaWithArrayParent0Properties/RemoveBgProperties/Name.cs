using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;

namespace Imagekit.Models.UnnamedSchemaWithArrayParent0Properties.RemoveBgProperties;

/// <summary>
/// Specifies the background removal extension.
/// </summary>
[JsonConverter(typeof(Converter))]
public class Name
{
    public JsonElement Json { get; private init; }

    public Name()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("\"remove-bg\"");
    }

    Name(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new Name().Json))
        {
            throw new ImageKitInvalidDataException("Invalid constant given for 'Name'");
        }
    }

    class Converter : JsonConverter<Name>
    {
        public override Name? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(Utf8JsonWriter writer, Name value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
