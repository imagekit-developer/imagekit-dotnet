using System;
using Imagekit.Models.NamedTransformations;

namespace Imagekit.Tests.Models.NamedTransformations;

public class NamedTransformationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NamedTransformationCreateParams
        {
            Name = "small_thumbnail",
            Transformation = "w-150,h-150,fo-center,cm-resize",
            Enabled = true,
        };

        string expectedName = "small_thumbnail";
        string expectedTransformation = "w-150,h-150,fo-center,cm-resize";
        bool expectedEnabled = true;

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedTransformation, parameters.Transformation);
        Assert.Equal(expectedEnabled, parameters.Enabled);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NamedTransformationCreateParams
        {
            Name = "small_thumbnail",
            Transformation = "w-150,h-150,fo-center,cm-resize",
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NamedTransformationCreateParams
        {
            Name = "small_thumbnail",
            Transformation = "w-150,h-150,fo-center,cm-resize",

            // Null should be interpreted as omitted for these properties
            Enabled = null,
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
    }

    [Fact]
    public void Url_Works()
    {
        NamedTransformationCreateParams parameters = new()
        {
            Name = "small_thumbnail",
            Transformation = "w-150,h-150,fo-center,cm-resize",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/named-transformations"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NamedTransformationCreateParams
        {
            Name = "small_thumbnail",
            Transformation = "w-150,h-150,fo-center,cm-resize",
            Enabled = true,
        };

        NamedTransformationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
