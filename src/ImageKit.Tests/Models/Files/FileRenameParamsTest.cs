using System;
using ImageKit.Models.Files;

namespace ImageKit.Tests.Models.Files;

public class FileRenameParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileRenameParams
        {
            FilePath = "/path/to/file.jpg",
            NewFileName = "newFileName.jpg",
            PurgeCache = true,
        };

        string expectedFilePath = "/path/to/file.jpg";
        string expectedNewFileName = "newFileName.jpg";
        bool expectedPurgeCache = true;

        Assert.Equal(expectedFilePath, parameters.FilePath);
        Assert.Equal(expectedNewFileName, parameters.NewFileName);
        Assert.Equal(expectedPurgeCache, parameters.PurgeCache);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileRenameParams
        {
            FilePath = "/path/to/file.jpg",
            NewFileName = "newFileName.jpg",
        };

        Assert.Null(parameters.PurgeCache);
        Assert.False(parameters.RawBodyData.ContainsKey("purgeCache"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileRenameParams
        {
            FilePath = "/path/to/file.jpg",
            NewFileName = "newFileName.jpg",

            // Null should be interpreted as omitted for these properties
            PurgeCache = null,
        };

        Assert.Null(parameters.PurgeCache);
        Assert.False(parameters.RawBodyData.ContainsKey("purgeCache"));
    }

    [Fact]
    public void Url_Works()
    {
        FileRenameParams parameters = new()
        {
            FilePath = "/path/to/file.jpg",
            NewFileName = "newFileName.jpg",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/files/rename"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileRenameParams
        {
            FilePath = "/path/to/file.jpg",
            NewFileName = "newFileName.jpg",
            PurgeCache = true,
        };

        FileRenameParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
