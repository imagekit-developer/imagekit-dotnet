using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.Bulk;

[JsonConverter(typeof(ModelConverter<BulkRemoveTagsResponse>))]
public sealed record class BulkRemoveTagsResponse : ModelBase, IFromRaw<BulkRemoveTagsResponse>
{
    /// <summary>
    /// An array of fileIds that in which tags were successfully removed.
    /// </summary>
    public List<string>? SuccessfullyUpdatedFileIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("successfullyUpdatedFileIds", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["successfullyUpdatedFileIds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.SuccessfullyUpdatedFileIDs ?? [])
        {
            _ = item;
        }
    }

    public BulkRemoveTagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkRemoveTagsResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkRemoveTagsResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
