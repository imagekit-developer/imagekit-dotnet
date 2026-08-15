using System;
using Imagekit.Models.NamedTransformations;

namespace Imagekit.Tests.Models.NamedTransformations;

public class NamedTransformationGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NamedTransformationGetParams { ID = "6bZ9x2ZUx" };

        string expectedID = "6bZ9x2ZUx";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        NamedTransformationGetParams parameters = new() { ID = "6bZ9x2ZUx" };

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
        var parameters = new NamedTransformationGetParams { ID = "6bZ9x2ZUx" };

        NamedTransformationGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
