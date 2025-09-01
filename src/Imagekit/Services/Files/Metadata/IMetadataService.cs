using System.Threading.Tasks;
using Imagekit.Models.Files.Metadata;
using Files = Imagekit.Models.Files;

namespace Imagekit.Services.Files.Metadata;

public interface IMetadataService
{
    /// <summary>
    /// You can programmatically get image EXIF, pHash, and other metadata for uploaded
    /// files in the ImageKit.io media library using this API.
    ///
    /// You can also get the metadata in upload API response by passing `metadata`
    /// in `responseFields` parameter.
    /// </summary>
    Task<Files::Metadata> Get(MetadataGetParams parameters);

    /// <summary>
    /// Get image EXIF, pHash, and other metadata from ImageKit.io powered remote
    /// URL using this API.
    /// </summary>
    Task<Files::Metadata> GetFromURL(MetadataGetFromURLParams parameters);
}
