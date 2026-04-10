using System;
using ImageKit.Models.Files.Metadata;

namespace ImageKit.Tests.Models.Files.Metadata;

public class MetadataGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MetadataGetParams { FileID = "fileId" };

        string expectedFileID = "fileId";

        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        MetadataGetParams parameters = new() { FileID = "fileId" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/files/fileId/metadata"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MetadataGetParams { FileID = "fileId" };

        MetadataGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
