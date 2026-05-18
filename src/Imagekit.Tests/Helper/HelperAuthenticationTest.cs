// Go source: tests/helper_authentication_test.go
// Total test cases in Go: 5

using System;
using System.Text.RegularExpressions;
using Imagekit;
using Imagekit.Models;

namespace Imagekit.Tests.Helper;

public class HelperAuthenticationTest
{
    private static readonly ImageKitClient _client = new() { PrivateKey = "private_key_test" };

    [Fact]
    public void GetAuthenticationParameters_WithTokenAndExpire_ReturnsCorrectParams()
    {
        var token = "your_token";
        var expire = 1582269249L;

        var auth = _client.Helper.GetAuthenticationParameters(token, expire);

        Assert.Equal(token, auth.Token);
        Assert.Equal(expire, auth.Expire);
        Assert.Equal("e71bcd6031016b060d349d212e23e85c791decdd", auth.Signature);
    }

    [Fact]
    public void GetAuthenticationParameters_NoParams_ReturnsRequiredProperties()
    {
        var auth = _client.Helper.GetAuthenticationParameters();

        Assert.Matches(new Regex("^[0-9a-f]{32}$"), auth.Token);
        Assert.True(auth.Expire > DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        Assert.Matches(new Regex("^[a-f0-9]{40}$"), auth.Signature);
    }

    [Fact]
    public void GetAuthenticationParameters_ExpireZero_UsesDefaultExpire()
    {
        var token = "test-token";

        var auth = _client.Helper.GetAuthenticationParameters(token, 0L);

        Assert.Equal(token, auth.Token);
        var expectedExpire = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60 * 30;
        Assert.InRange(auth.Expire, expectedExpire - 10, expectedExpire + 10);
        Assert.Matches(new Regex("^[a-f0-9]{40}$"), auth.Signature);
    }

    [Fact]
    public void GetAuthenticationParameters_EmptyStringToken_GeneratesToken()
    {
        var expire = 1582269249L;

        var auth = _client.Helper.GetAuthenticationParameters("", expire);

        Assert.Matches(new Regex("^[0-9a-f]{32}$"), auth.Token);
        Assert.Equal(expire, auth.Expire);
        Assert.Matches(new Regex("^[a-f0-9]{40}$"), auth.Signature);
    }

    [Fact]
    public void GetAuthenticationParameters_NoPrivateKey_ThrowsWithMessage()
    {
        var noKeyClient = new ImageKitClient { PrivateKey = "" };

        var ex = Assert.ThrowsAny<Exception>(() => noKeyClient.Helper.GetAuthenticationParameters("test", 123L));
        Assert.Equal("private API key is required for authentication parameters generation", ex.Message);
    }
}

