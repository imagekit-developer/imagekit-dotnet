using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models;

namespace Imagekit.Tests.Models;

public class ResponsiveImageAttributesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };

        string expectedSrc = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840";
        string expectedSizes = "100vw";
        string expectedSrcSet =
            "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w";
        double expectedWidth = 400;

        Assert.Equal(expectedSrc, model.Src);
        Assert.Equal(expectedSizes, model.Sizes);
        Assert.Equal(expectedSrcSet, model.SrcSet);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponsiveImageAttributes>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResponsiveImageAttributes>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSrc = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840";
        string expectedSizes = "100vw";
        string expectedSrcSet =
            "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w";
        double expectedWidth = 400;

        Assert.Equal(expectedSrc, deserialized.Src);
        Assert.Equal(expectedSizes, deserialized.Sizes);
        Assert.Equal(expectedSrcSet, deserialized.SrcSet);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
        };

        Assert.Null(model.Sizes);
        Assert.False(model.RawData.ContainsKey("sizes"));
        Assert.Null(model.SrcSet);
        Assert.False(model.RawData.ContainsKey("srcSet"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",

            // Null should be interpreted as omitted for these properties
            Sizes = null,
            SrcSet = null,
            Width = null,
        };

        Assert.Null(model.Sizes);
        Assert.False(model.RawData.ContainsKey("sizes"));
        Assert.Null(model.SrcSet);
        Assert.False(model.RawData.ContainsKey("srcSet"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",

            // Null should be interpreted as omitted for these properties
            Sizes = null,
            SrcSet = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ResponsiveImageAttributes
        {
            Src = "https://ik.imagekit.io/demo/image.jpg?tr=w-3840",
            Sizes = "100vw",
            SrcSet =
                "https://ik.imagekit.io/demo/image.jpg?tr=w-640 640w, https://ik.imagekit.io/demo/image.jpg?tr=w-1080 1080w, https://ik.imagekit.io/demo/image.jpg?tr=w-1920 1920w",
            Width = 400,
        };

        ResponsiveImageAttributes copied = new(model);

        Assert.Equal(model, copied);
    }
}
