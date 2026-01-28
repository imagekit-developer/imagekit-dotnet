using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Folders.Job;

namespace Imagekit.Services.Folders.Job;

public sealed class JobService : IJobService
{
    readonly IImageKitClient _client;

    public JobService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<JobGetResponse> Get(JobGetParams parameters)
    {
        HttpRequest<JobGetParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var job = await response.Deserialize<JobGetResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            job.Validate();
        }
        return job;
    }
}
