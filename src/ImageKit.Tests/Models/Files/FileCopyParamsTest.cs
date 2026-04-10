using System;
using ImageKit.Models.Files;

namespace ImageKit.Tests.Models.Files;

public class FileCopyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileCopyParams
        {
            DestinationPath = "/folder/to/copy/into/",
            SourceFilePath = "/path/to/file.jpg",
            IncludeFileVersions = false,
        };

        string expectedDestinationPath = "/folder/to/copy/into/";
        string expectedSourceFilePath = "/path/to/file.jpg";
        bool expectedIncludeFileVersions = false;

        Assert.Equal(expectedDestinationPath, parameters.DestinationPath);
        Assert.Equal(expectedSourceFilePath, parameters.SourceFilePath);
        Assert.Equal(expectedIncludeFileVersions, parameters.IncludeFileVersions);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileCopyParams
        {
            DestinationPath = "/folder/to/copy/into/",
            SourceFilePath = "/path/to/file.jpg",
        };

        Assert.Null(parameters.IncludeFileVersions);
        Assert.False(parameters.RawBodyData.ContainsKey("includeFileVersions"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileCopyParams
        {
            DestinationPath = "/folder/to/copy/into/",
            SourceFilePath = "/path/to/file.jpg",

            // Null should be interpreted as omitted for these properties
            IncludeFileVersions = null,
        };

        Assert.Null(parameters.IncludeFileVersions);
        Assert.False(parameters.RawBodyData.ContainsKey("includeFileVersions"));
    }

    [Fact]
    public void Url_Works()
    {
        FileCopyParams parameters = new()
        {
            DestinationPath = "/folder/to/copy/into/",
            SourceFilePath = "/path/to/file.jpg",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/files/copy"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileCopyParams
        {
            DestinationPath = "/folder/to/copy/into/",
            SourceFilePath = "/path/to/file.jpg",
            IncludeFileVersions = false,
        };

        FileCopyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
