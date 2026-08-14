using System;
using Imagekit.Models.NamedTransformations;

namespace Imagekit.Tests.Models.NamedTransformations;

public class NamedTransformationDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NamedTransformationDeleteParams { ID = "6bZ9x2ZUx" };

        string expectedID = "6bZ9x2ZUx";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        NamedTransformationDeleteParams parameters = new() { ID = "6bZ9x2ZUx" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.imagekit.io/v1/named-transformations/6bZ9x2ZUx"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NamedTransformationDeleteParams { ID = "6bZ9x2ZUx" };

        NamedTransformationDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
