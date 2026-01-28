using System;
using ImageKit.Models.Folders;

namespace ImageKit.Tests.Models.Folders;

public class FolderCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderCreateParams
        {
            FolderName = "summer",
            ParentFolderPath = "/product/images/",
        };

        string expectedFolderName = "summer";
        string expectedParentFolderPath = "/product/images/";

        Assert.Equal(expectedFolderName, parameters.FolderName);
        Assert.Equal(expectedParentFolderPath, parameters.ParentFolderPath);
    }

    [Fact]
    public void Url_Works()
    {
        FolderCreateParams parameters = new()
        {
            FolderName = "summer",
            ParentFolderPath = "/product/images/",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/folder"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderCreateParams
        {
            FolderName = "summer",
            ParentFolderPath = "/product/images/",
        };

        FolderCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
