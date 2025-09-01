using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.Bulk;

[JsonConverter(typeof(ModelConverter<BulkAddTagsResponse>))]
public sealed record class BulkAddTagsResponse : ModelBase, IFromRaw<BulkAddTagsResponse>
{
    /// <summary>
    /// An array of fileIds that in which tags were successfully added.
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

    public BulkAddTagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkAddTagsResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkAddTagsResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
