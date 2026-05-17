using System;
using ImagekitDiversion.Models.BulkJobs;

namespace ImagekitDiversion.Tests.Models.BulkJobs;

public class BulkJobMoveFolderParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkJobMoveFolderParams
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
        BulkJobMoveFolderParams parameters = new()
        {
            DestinationPath = "/path/of/destination/folder",
            SourceFolderPath = "/path/of/source/folder",
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/bulkJobs/moveFolder"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BulkJobMoveFolderParams
        {
            DestinationPath = "/path/of/destination/folder",
            SourceFolderPath = "/path/of/source/folder",
        };

        BulkJobMoveFolderParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
