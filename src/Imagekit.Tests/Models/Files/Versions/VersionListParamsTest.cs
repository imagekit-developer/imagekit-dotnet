using System;
using Imagekit.Models.Files.Versions;

namespace Imagekit.Tests.Models.Files.Versions;

public class VersionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new VersionListParams { FileID = "fileId" };

        string expectedFileID = "fileId";

        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        VersionListParams parameters = new() { FileID = "fileId" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/fileId/versions"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new VersionListParams { FileID = "fileId" };

        VersionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
