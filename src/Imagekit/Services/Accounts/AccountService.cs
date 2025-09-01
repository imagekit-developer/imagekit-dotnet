using System;
using Imagekit.Services.Accounts.Origins;
using Imagekit.Services.Accounts.URLEndpoints;
using Imagekit.Services.Accounts.Usage;

namespace Imagekit.Services.Accounts;

public sealed class AccountService : IAccountService
{
    public AccountService(IImageKitClient client)
    {
        _usage = new(() => new UsageService(client));
        _origins = new(() => new OriginService(client));
        _urlEndpoints = new(() => new URLEndpointService(client));
    }

    readonly Lazy<IUsageService> _usage;
    public IUsageService Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<IOriginService> _origins;
    public IOriginService Origins
    {
        get { return _origins.Value; }
    }

    readonly Lazy<IURLEndpointService> _urlEndpoints;
    public IURLEndpointService URLEndpoints
    {
        get { return _urlEndpoints.Value; }
    }
}
