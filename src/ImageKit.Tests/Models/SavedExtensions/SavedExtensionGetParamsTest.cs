using System;
using ImageKit.Models.SavedExtensions;

namespace ImageKit.Tests.Models.SavedExtensions;

public class SavedExtensionGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SavedExtensionGetParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        SavedExtensionGetParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/saved-extensions/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SavedExtensionGetParams { ID = "id" };

        SavedExtensionGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
