using Imagekit.Services.Accounts.Origins;
using Imagekit.Services.Accounts.URLEndpoints;
using Imagekit.Services.Accounts.Usage;

namespace Imagekit.Services.Accounts;

public interface IAccountService
{
    IUsageService Usage { get; }

    IOriginService Origins { get; }

    IURLEndpointService URLEndpoints { get; }
}
