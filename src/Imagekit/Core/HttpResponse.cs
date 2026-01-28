using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Imagekit.Exceptions;

namespace Imagekit.Core;

public sealed class HttpResponse : IDisposable
{
    public required HttpResponseMessage Message { get; init; }

    public async Task<T> Deserialize<T>()
    {
        try
        {
            return JsonSerializer.Deserialize<T>(
                    await Message.Content.ReadAsStreamAsync().ConfigureAwait(false),
                    ModelBase.SerializerOptions
                ) ?? throw new ImageKitInvalidDataException("Response cannot be null");
        }
        catch (HttpRequestException e)
        {
            throw new ImageKitIOException("I/O Exception", e);
        }
    }

    public void Dispose()
    {
        this.Message.Dispose();
    }
}
