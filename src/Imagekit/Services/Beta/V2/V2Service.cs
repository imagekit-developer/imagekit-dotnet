using System;
using Imagekit.Services.Beta.V2.Files;

namespace Imagekit.Services.Beta.V2;

public sealed class V2Service : IV2Service
{
    public V2Service(IImageKitClient client)
    {
        _files = new(() => new FileService(client));
    }

    readonly Lazy<IFileService> _files;
    public IFileService Files
    {
        get { return _files.Value; }
    }
}
