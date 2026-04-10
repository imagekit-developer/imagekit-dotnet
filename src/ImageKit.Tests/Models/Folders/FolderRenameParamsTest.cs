using System;
using ImageKit.Models.Folders;

namespace ImageKit.Tests.Models.Folders;

public class FolderRenameParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FolderRenameParams
        {
            FolderPath = "/path/of/folder",
            NewFolderName = "new-folder-name",
            PurgeCache = true,
        };

        string expectedFolderPath = "/path/of/folder";
        string expectedNewFolderName = "new-folder-name";
        bool expectedPurgeCache = true;

        Assert.Equal(expectedFolderPath, parameters.FolderPath);
        Assert.Equal(expectedNewFolderName, parameters.NewFolderName);
        Assert.Equal(expectedPurgeCache, parameters.PurgeCache);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FolderRenameParams
        {
            FolderPath = "/path/of/folder",
            NewFolderName = "new-folder-name",
        };

        Assert.Null(parameters.PurgeCache);
        Assert.False(parameters.RawBodyData.ContainsKey("purgeCache"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FolderRenameParams
        {
            FolderPath = "/path/of/folder",
            NewFolderName = "new-folder-name",

            // Null should be interpreted as omitted for these properties
            PurgeCache = null,
        };

        Assert.Null(parameters.PurgeCache);
        Assert.False(parameters.RawBodyData.ContainsKey("purgeCache"));
    }

    [Fact]
    public void Url_Works()
    {
        FolderRenameParams parameters = new()
        {
            FolderPath = "/path/of/folder",
            NewFolderName = "new-folder-name",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/bulkJobs/renameFolder"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FolderRenameParams
        {
            FolderPath = "/path/of/folder",
            NewFolderName = "new-folder-name",
            PurgeCache = true,
        };

        FolderRenameParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
