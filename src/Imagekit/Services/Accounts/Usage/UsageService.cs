using System.Net.Http;
using System.Threading.Tasks;
using Imagekit.Core;
using Imagekit.Models.Accounts.Usage;

namespace Imagekit.Services.Accounts.Usage;

public sealed class UsageService : IUsageService
{
    readonly IImageKitClient _client;

    public UsageService(IImageKitClient client)
    {
        _client = client;
    }

    public async Task<UsageGetResponse> Get(UsageGetParams parameters)
    {
        HttpRequest<UsageGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var usage = await response.Deserialize<UsageGetResponse>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            usage.Validate();
        }
        return usage;
    }
}
