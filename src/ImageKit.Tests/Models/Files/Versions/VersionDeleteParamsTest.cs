using System;
using ImageKit.Models.Files.Versions;

namespace ImageKit.Tests.Models.Files.Versions;

public class VersionDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionDeleteParams { FileID = "fileId", VersionID = "versionId" };

        string expectedFileID = "fileId";
        string expectedVersionID = "versionId";

        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedVersionID, parameters.VersionID);
    }

    [Fact]
    public void Url_Works()
    {
        VersionDeleteParams parameters = new() { FileID = "fileId", VersionID = "versionId" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/files/fileId/versions/versionId"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionDeleteParams { FileID = "fileId", VersionID = "versionId" };

        VersionDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
