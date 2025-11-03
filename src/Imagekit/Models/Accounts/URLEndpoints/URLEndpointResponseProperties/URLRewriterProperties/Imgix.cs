using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;

namespace Imagekit.Models.Accounts.URLEndpoints.URLEndpointResponseProperties.URLRewriterProperties;

[JsonConverter(typeof(Converter))]
public class Imgix
{
    public JsonElement Json { get; private init; }

    public Imgix()
    {
        Json = JsonSerializer.Deserialize<JsonElement>("{\"type\":\"IMGIX\"}");
    }

    Imgix(JsonElement json)
    {
        Json = json;
    }

    public void Validate()
    {
        if (JsonElement.DeepEquals(this.Json, new Imgix().Json))
        {
            throw new ImageKitInvalidDataException("Invalid constant given for 'Imgix'");
        }
    }

    class Converter : JsonConverter<Imgix>
    {
        public override Imgix? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
        }

        public override void Write(
            Utf8JsonWriter writer,
            Imgix value,
            JsonSerializerOptions options
        )
        {
            JsonSerializer.Serialize(writer, value.Json, options);
        }
    }
}
