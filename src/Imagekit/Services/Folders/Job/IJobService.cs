using System.Threading.Tasks;
using Imagekit.Models.Folders.Job;

namespace Imagekit.Services.Folders.Job;

public interface IJobService
{
    /// <summary>
    /// This API returns the status of a bulk job like copy and move folder operations.
    /// </summary>
    Task<JobGetResponse> Get(JobGetParams parameters);
}
