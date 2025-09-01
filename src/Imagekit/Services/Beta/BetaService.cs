using System;
using Imagekit.Services.Beta.V2;

namespace Imagekit.Services.Beta;

public sealed class BetaService : IBetaService
{
    public BetaService(IImageKitClient client)
    {
        _v2 = new(() => new V2Service(client));
    }

    readonly Lazy<IV2Service> _v2;
    public IV2Service V2
    {
        get { return _v2.Value; }
    }
}
