namespace Imagekit.Helper;

/// <summary>
/// Authentication parameters for client-side file uploads.
/// </summary>
public record AuthenticationParameters
{
    /// <summary>A unique token for this upload request.</summary>
    public required string Token { get; init; }

    /// <summary>Unix timestamp (seconds) at which the signature expires. 0 means no expiry.</summary>
    public required long Expire { get; init; }

    /// <summary>HMAC-SHA1 signature of <c>token + expire</c> using the private API key.</summary>
    public required string Signature { get; init; }
}
