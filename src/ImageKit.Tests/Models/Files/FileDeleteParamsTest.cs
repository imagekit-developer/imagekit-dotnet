using System;
using ImageKit.Models.Files;

namespace ImageKit.Tests.Models.Files;

public class FileDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileDeleteParams { FileID = "fileId" };

        string expectedFileID = "fileId";

        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        FileDeleteParams parameters = new() { FileID = "fileId" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/fileId"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileDeleteParams { FileID = "fileId" };

        FileDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
