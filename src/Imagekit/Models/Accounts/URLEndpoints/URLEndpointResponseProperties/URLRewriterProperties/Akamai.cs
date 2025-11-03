using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;

namespace Imagekit.Models.Accounts.URLEndpoints.URLEndpointResponseProperties.URLRewriterProperties;

[JsonConverter(typeof(Converter))]
public class Akamai
{
    public JsonElement Json { get; private init; }

    public Akamai()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("{\"type\":\"AKAMAI\"}");
    }

    Akamai(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new Akamai().Json))
        {
            throw new ImageKitInvalidDataException("Invalid constant given for 'Akamai'");
        }
    }

    class Converter : JsonConverter<Akamai>
    {
        public override Akamai? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            Akamai value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
