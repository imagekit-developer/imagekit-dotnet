using System;
using System.Collections.Generic;
using Imagekit.Models;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class HelperService : IHelperService
{
    readonly IImageKitClient _client;

    internal HelperService(IImageKitClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public string BuildUrl(SrcOptions options)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public string BuildTransformationString(IReadOnlyList<Transformation> transformations)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public AuthenticationParameters GetAuthenticationParameters(
        string? token = null,
        long? expires = null
    )
    {
        throw new NotImplementedException();
    }
}
