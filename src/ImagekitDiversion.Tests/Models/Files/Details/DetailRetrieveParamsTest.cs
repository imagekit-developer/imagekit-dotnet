using System;
using ImagekitDiversion.Models.Files.Details;

namespace ImagekitDiversion.Tests.Models.Files.Details;

public class DetailRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DetailRetrieveParams { FileID = "fileId" };

        string expectedFileID = "fileId";

        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        DetailRetrieveParams parameters = new() { FileID = "fileId" };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/fileId/details"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DetailRetrieveParams { FileID = "fileId" };

        DetailRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
