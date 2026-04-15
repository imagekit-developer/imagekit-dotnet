using System;
using ImageKit.Models.Files.Versions;

namespace ImageKit.Tests.Models.Files.Versions;

public class VersionRestoreParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionRestoreParams { FileID = "fileId", VersionID = "versionId" };

        string expectedFileID = "fileId";
        string expectedVersionID = "versionId";

        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedVersionID, parameters.VersionID);
    }

    [Fact]
    public void Url_Works()
    {
        VersionRestoreParams parameters = new() { FileID = "fileId", VersionID = "versionId" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.imagekit.io/v1/files/fileId/versions/versionId/restore"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionRestoreParams { FileID = "fileId", VersionID = "versionId" };

        VersionRestoreParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
