using System;
using ImagekitDiversion.Models.SavedExtensions;

namespace ImagekitDiversion.Tests.Models.SavedExtensions;

public class SavedExtensionDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SavedExtensionDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        SavedExtensionDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/saved-extensions/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SavedExtensionDeleteParams { ID = "id" };

        SavedExtensionDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
