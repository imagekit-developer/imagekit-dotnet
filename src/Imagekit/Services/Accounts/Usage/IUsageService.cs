using System.Threading.Tasks;
using Imagekit.Models.Accounts.Usage;

namespace Imagekit.Services.Accounts.Usage;

public interface IUsageService
{
    /// <summary>
    /// Get the account usage information between two dates. Note that the API response
    /// includes data from the start date while excluding data from the end date.
    /// In other words, the data covers the period starting from the specified start
    /// date up to, but not including, the end date.
    /// </summary>
    Task<UsageGetResponse> Get(UsageGetParams parameters);
}
