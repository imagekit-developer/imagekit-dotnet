using System;
using ImageKit.Models.CustomMetadataFields;

namespace ImageKit.Tests.Models.CustomMetadataFields;

public class CustomMetadataFieldDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomMetadataFieldDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomMetadataFieldDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/customMetadataFields/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomMetadataFieldDeleteParams { ID = "id" };

        CustomMetadataFieldDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
