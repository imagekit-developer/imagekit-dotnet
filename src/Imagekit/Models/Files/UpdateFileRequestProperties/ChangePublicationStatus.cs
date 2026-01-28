using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Models.Files.UpdateFileRequestProperties.ChangePublicationStatusProperties;

namespace Imagekit.Models.Files.UpdateFileRequestProperties;

[JsonConverter(typeof(ModelConverter<ChangePublicationStatus>))]
public sealed record class ChangePublicationStatus : ModelBase, IFromRaw<ChangePublicationStatus>
{
    /// <summary>
    /// Configure the publication status of a file and its versions.
    /// </summary>
    public Publish? Publish
    {
        get
        {
            if (!this.Properties.TryGetValue("publish", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Publish?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["publish"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Publish?.Validate();
    }

    public ChangePublicationStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChangePublicationStatus(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ChangePublicationStatus FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
