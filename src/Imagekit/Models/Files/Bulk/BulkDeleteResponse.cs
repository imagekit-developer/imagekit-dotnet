using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.Bulk;

[JsonConverter(typeof(ModelConverter<BulkDeleteResponse>))]
public sealed record class BulkDeleteResponse : ModelBase, IFromRaw<BulkDeleteResponse>
{
    /// <summary>
    /// An array of fileIds that were successfully deleted.
    /// </summary>
    public List<string>? SuccessfullyDeletedFileIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("successfullyDeletedFileIds", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["successfullyDeletedFileIds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.SuccessfullyDeletedFileIDs ?? [])
        {
            _ = item;
        }
    }

    public BulkDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkDeleteResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkDeleteResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
