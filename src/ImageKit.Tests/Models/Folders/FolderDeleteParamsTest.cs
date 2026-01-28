using System;
using ImageKit.Models.Folders;

namespace ImageKit.Tests.Models.Folders;

public class FolderDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderDeleteParams { FolderPath = "/folder/to/delete/" };

        string expectedFolderPath = "/folder/to/delete/";

        Assert.Equal(expectedFolderPath, parameters.FolderPath);
    }

    [Fact]
    public void Url_Works()
    {
        FolderDeleteParams parameters = new() { FolderPath = "/folder/to/delete/" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/folder"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderDeleteParams { FolderPath = "/folder/to/delete/" };

        FolderDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
