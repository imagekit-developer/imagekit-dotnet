using System;
using ImageKit.Models.Folders;

namespace ImageKit.Tests.Models.Folders;

public class FolderCopyParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderCopyParams
        {
            DestinationPath = "/path/of/destination/folder",
            SourceFolderPath = "/path/of/source/folder",
            IncludeVersions = true,
        };

        string expectedDestinationPath = "/path/of/destination/folder";
        string expectedSourceFolderPath = "/path/of/source/folder";
        bool expectedIncludeVersions = true;

        Assert.Equal(expectedDestinationPath, parameters.DestinationPath);
        Assert.Equal(expectedSourceFolderPath, parameters.SourceFolderPath);
        Assert.Equal(expectedIncludeVersions, parameters.IncludeVersions);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FolderCopyParams
        {
            DestinationPath = "/path/of/destination/folder",
            SourceFolderPath = "/path/of/source/folder",
        };

        Assert.Null(parameters.IncludeVersions);
        Assert.False(parameters.RawBodyData.ContainsKey("includeVersions"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FolderCopyParams
        {
            DestinationPath = "/path/of/destination/folder",
            SourceFolderPath = "/path/of/source/folder",

            // Null should be interpreted as omitted for these properties
            IncludeVersions = null,
        };

        Assert.Null(parameters.IncludeVersions);
        Assert.False(parameters.RawBodyData.ContainsKey("includeVersions"));
    }

    [Fact]
    public void Url_Works()
    {
        FolderCopyParams parameters = new()
        {
            DestinationPath = "/path/of/destination/folder",
            SourceFolderPath = "/path/of/source/folder",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/bulkJobs/copyFolder"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderCopyParams
        {
            DestinationPath = "/path/of/destination/folder",
            SourceFolderPath = "/path/of/source/folder",
            IncludeVersions = true,
        };

        FolderCopyParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
