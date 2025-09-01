using Imagekit.Services.Beta.V2.Files;

namespace Imagekit.Services.Beta.V2;

public interface IV2Service
{
    IFileService Files { get; }
}
