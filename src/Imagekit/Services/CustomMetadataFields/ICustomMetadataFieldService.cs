using System.Collections.Generic;
using System.Threading.Tasks;
using Imagekit.Models.CustomMetadataFields;

namespace Imagekit.Services.CustomMetadataFields;

public interface ICustomMetadataFieldService
{
    /// <summary>
    /// This API creates a new custom metadata field. Once a custom metadata field
    /// is created either through this API or using the dashboard UI, its value can
    /// be set on the assets. The value of a field for an asset can be set using the
    /// media library UI or programmatically through upload or update assets API.
    /// </summary>
    Task<CustomMetadataField> Create(CustomMetadataFieldCreateParams parameters);

    /// <summary>
    /// This API updates the label or schema of an existing custom metadata field.
    /// </summary>
    Task<CustomMetadataField> Update(CustomMetadataFieldUpdateParams parameters);

    /// <summary>
    /// This API returns the array of created custom metadata field objects. By default
    /// the API returns only non deleted field objects, but you can include deleted
    /// fields in the API response.
    /// </summary>
    Task<List<CustomMetadataField>> List(CustomMetadataFieldListParams? parameters = null);

    /// <summary>
    /// This API deletes a custom metadata field. Even after deleting a custom metadata
    /// field, you cannot create any new custom metadata field with the same name.
    /// </summary>
    Task<CustomMetadataFieldDeleteResponse> Delete(CustomMetadataFieldDeleteParams parameters);
}
