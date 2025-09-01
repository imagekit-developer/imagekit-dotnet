using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files;

[JsonConverter(typeof(ModelConverter<FileRenameResponse>))]
public sealed record class FileRenameResponse : ModelBase, IFromRaw<FileRenameResponse>
{
    /// <summary>
    /// Unique identifier of the purge request. This can be used to check the status
    /// of the purge request.
    /// </summary>
    public string? PurgeRequestID
    {
        get
        {
            if (!this.Properties.TryGetValue("purgeRequestId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["purgeRequestId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.PurgeRequestID;
    }

    public FileRenameResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileRenameResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FileRenameResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
