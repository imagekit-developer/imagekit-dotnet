// Go source: tests/helper_transformation_test.go
// Total test cases in Go: 10

using System.Collections.Generic;
using Imagekit;
using Imagekit.Models;

namespace Imagekit.Tests.Helper;

public class HelperTransformationTest
{
    private static readonly ImageKitClient _client = new() { PrivateKey = "test-key" };

    [Fact]
    public void BuildTransformationString_NullOrEmpty_ReturnsEmpty()
    {
        Assert.Equal("", _client.Helper.BuildTransformationString(null!));
        Assert.Equal("", _client.Helper.BuildTransformationString(new List<Transformation>()));
    }

    [Fact]
    public void BuildTransformationString_WidthOnly_ReturnsCorrectString()
    {
        var result = _client.Helper.BuildTransformationString([new Transformation { Width = 300.0 }]);

        Assert.Equal("w-300", result);
    }

    [Fact]
    public void BuildTransformationString_MultipleParameters_ReturnsCorrectString()
    {
        var result = _client.Helper.BuildTransformationString(
        [
            new Transformation { Width = 300.0, Height = 200.0 },
        ]);

        Assert.Equal("w-300,h-200", result);
    }

    [Fact]
    public void BuildTransformationString_ChainedTransformations_UsesColonDelimiter()
    {
        var result = _client.Helper.BuildTransformationString(
        [
            new Transformation { Width = 300.0 },
            new Transformation { Height = 200.0 },
        ]);

        Assert.Equal("w-300:h-200", result);
    }

    [Fact]
    public void BuildTransformationString_EmptyTransformationObject_ReturnsEmpty()
    {
        var result = _client.Helper.BuildTransformationString([new Transformation()]);

        Assert.Equal("", result);
    }

    [Fact]
    public void BuildTransformationString_WithTextOverlay_ReturnsLayerString()
    {
        var result = _client.Helper.BuildTransformationString(
        [
            new Transformation { Overlay = new TextOverlay("Hello") },
        ]);

        Assert.Equal("l-text,i-Hello,l-end", result);
    }

    [Fact]
    public void BuildTransformationString_RawParameter_ReturnsRawValue()
    {
        var result = _client.Helper.BuildTransformationString(
        [
            new Transformation { Raw = "custom-transform-123" },
        ]);

        Assert.Equal("custom-transform-123", result);
    }

    [Fact]
    public void BuildTransformationString_MixedWithRaw_CombinesCorrectly()
    {
        var result = _client.Helper.BuildTransformationString(
        [
            new Transformation { Width = 300.0, Raw = "custom-param-123" },
        ]);

        Assert.Equal("w-300,custom-param-123", result);
    }

    [Fact]
    public void BuildTransformationString_Quality_ReturnsQualityParam()
    {
        var result = _client.Helper.BuildTransformationString(
        [
            new Transformation { Quality = 80.0 },
        ]);

        Assert.Equal("q-80", result);
    }

    [Fact]
    public void BuildTransformationString_AspectRatio_ReturnsAspectRatioParam()
    {
        var result = _client.Helper.BuildTransformationString(
        [
            new Transformation { AspectRatio = "4:3" },
        ]);

        Assert.Equal("ar-4:3", result);
    }
}

