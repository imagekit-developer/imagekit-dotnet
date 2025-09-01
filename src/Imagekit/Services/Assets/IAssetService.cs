using System.Collections.Generic;
using System.Threading.Tasks;
using Imagekit.Models.Assets;

namespace Imagekit.Services.Assets;

public interface IAssetService
{
    /// <summary>
    /// This API can list all the uploaded files and folders in your ImageKit.io
    /// media library. In addition, you can fine-tune your query by specifying various
    /// filters by generating a query string in a Lucene-like syntax and provide
    /// this generated string as the value of the `searchQuery`.
    /// </summary>
    Task<List<AssetListResponse>> List(AssetListParams? parameters = null);
}
