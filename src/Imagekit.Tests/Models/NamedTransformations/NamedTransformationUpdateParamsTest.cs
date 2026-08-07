using System;
using Imagekit.Models.NamedTransformations;

namespace Imagekit.Tests.Models.NamedTransformations;

public class NamedTransformationUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NamedTransformationUpdateParams
        {
            ID = "id",
            Enabled = true,
            Name = "small_thumbnail_v2",
            Transformation = "w-200,h-200,fo-center,cm-resize",
        };

        string expectedID = "id";
        bool expectedEnabled = true;
        string expectedName = "small_thumbnail_v2";
        string expectedTransformation = "w-200,h-200,fo-center,cm-resize";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedTransformation, parameters.Transformation);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NamedTransformationUpdateParams { ID = "id" };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Transformation);
        Assert.False(parameters.RawBodyData.ContainsKey("transformation"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NamedTransformationUpdateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Enabled = null,
            Name = null,
            Transformation = null,
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Transformation);
        Assert.False(parameters.RawBodyData.ContainsKey("transformation"));
    }

    [Fact]
    public void Url_Works()
    {
        NamedTransformationUpdateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/named-transformations/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NamedTransformationUpdateParams
        {
            ID = "id",
            Enabled = true,
            Name = "small_thumbnail_v2",
            Transformation = "w-200,h-200,fo-center,cm-resize",
        };

        NamedTransformationUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
