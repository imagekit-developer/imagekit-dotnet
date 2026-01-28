using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Webhooks.UploadPostTransformSuccessEventProperties;

[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    /// <summary>
    /// Unique identifier of the originally uploaded file.
    /// </summary>
    public required string FileID
    {
        get
        {
            if (!this.Properties.TryGetValue("fileId", out JsonElement element))
                throw new ArgumentOutOfRangeException("fileId", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("fileId");
        }
        set
        {
            this.Properties["fileId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the file.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL of the generated post-transformation.
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new ArgumentOutOfRangeException("url", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("url");
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.FileID;
        _ = this.Name;
        _ = this.URL;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
