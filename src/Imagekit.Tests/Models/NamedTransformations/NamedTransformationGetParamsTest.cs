using System;
using Imagekit.Models.NamedTransformations;

namespace Imagekit.Tests.Models.NamedTransformations;

public class NamedTransformationGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NamedTransformationGetParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        NamedTransformationGetParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/named-transformations/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NamedTransformationGetParams { ID = "id" };

        NamedTransformationGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
