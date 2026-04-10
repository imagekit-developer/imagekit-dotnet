using System;
using ImageKit.Models.Files;

namespace ImageKit.Tests.Models.Files;

public class FileGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileGetParams { FileID = "fileId" };

        string expectedFileID = "fileId";

        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        FileGetParams parameters = new() { FileID = "fileId" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/files/fileId/details"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileGetParams { FileID = "fileId" };

        FileGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
