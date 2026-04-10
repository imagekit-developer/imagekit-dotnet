using System;
using ImageKit;

namespace ImageKit.Tests;

public class TestBase
{
    protected IImageKitClient client;

    public TestBase()
    {
        client = new ImageKitClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            PrivateKey = "My Private Key",
            Password = "My Password",
        };
    }
}
