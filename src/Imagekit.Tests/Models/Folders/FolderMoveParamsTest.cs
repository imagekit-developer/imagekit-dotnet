using System;
using Imagekit.Models.Folders;

namespace Imagekit.Tests.Models.Folders;

public class FolderMoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderMoveParams
        {
            DestinationPath = "/path/of/destination/folder",
            SourceFolderPath = "/path/of/source/folder",
        };

        string expectedDestinationPath = "/path/of/destination/folder";
        string expectedSourceFolderPath = "/path/of/source/folder";

        Assert.Equal(expectedDestinationPath, parameters.DestinationPath);
        Assert.Equal(expectedSourceFolderPath, parameters.SourceFolderPath);
    }

    [Fact]
    public void Url_Works()
    {
        FolderMoveParams parameters = new()
        {
            DestinationPath = "/path/of/destination/folder",
            SourceFolderPath = "/path/of/source/folder",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/bulkJobs/moveFolder"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderMoveParams
        {
            DestinationPath = "/path/of/destination/folder",
            SourceFolderPath = "/path/of/source/folder",
        };

        FolderMoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
