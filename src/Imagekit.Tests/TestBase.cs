using System;
using Imagekit;

namespace Imagekit.Tests;

public class TestBase
{
    protected IImageKitClient client;

    public TestBase()
    {
        client = new ImageKitClient()
        {
            BaseUrl = new Uri(
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010"
            ),
            PrivateKey = "My Private Key",
            Password = "My Password",
        };
    }
}
