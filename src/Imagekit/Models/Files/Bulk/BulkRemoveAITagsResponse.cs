using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Files.Bulk;

[JsonConverter(typeof(ModelConverter<BulkRemoveAITagsResponse>))]
public sealed record class BulkRemoveAITagsResponse : ModelBase, IFromRaw<BulkRemoveAITagsResponse>
{
    /// <summary>
    /// An array of fileIds that in which AITags were successfully removed.
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
        _ = this.SuccessfullyUpdatedFileIDs;
    }

    public BulkRemoveAITagsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkRemoveAITagsResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkRemoveAITagsResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
