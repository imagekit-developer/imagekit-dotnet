using System;
using ImagekitDiversion.Models.Files;

namespace ImagekitDiversion.Tests.Models.Files;

public class FileRetrieveMetadataParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileRetrieveMetadataParams { FileID = "fileId" };

        string expectedFileID = "fileId";

        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        FileRetrieveMetadataParams parameters = new() { FileID = "fileId" };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/fileId/metadata"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileRetrieveMetadataParams { FileID = "fileId" };

        FileRetrieveMetadataParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
