using System;
using Imagekit.Models.Files;

namespace Imagekit.Tests.Models.Files;

public class FileMoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileMoveParams
        {
            DestinationPath = "/folder/to/move/into/",
            SourceFilePath = "/path/to/file.jpg",
        };

        string expectedDestinationPath = "/folder/to/move/into/";
        string expectedSourceFilePath = "/path/to/file.jpg";

        Assert.Equal(expectedDestinationPath, parameters.DestinationPath);
        Assert.Equal(expectedSourceFilePath, parameters.SourceFilePath);
    }

    [Fact]
    public void Url_Works()
    {
        FileMoveParams parameters = new()
        {
            DestinationPath = "/folder/to/move/into/",
            SourceFilePath = "/path/to/file.jpg",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/move"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileMoveParams
        {
            DestinationPath = "/folder/to/move/into/",
            SourceFilePath = "/path/to/file.jpg",
        };

        FileMoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
