using System;
using ImageKit.Models.CustomMetadataFields;

namespace ImageKit.Tests.Models.CustomMetadataFields;

public class CustomMetadataFieldListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomMetadataFieldListParams
        {
            FolderPath = "folderPath",
            IncludeDeleted = true,
        };

        string expectedFolderPath = "folderPath";
        bool expectedIncludeDeleted = true;

        Assert.Equal(expectedFolderPath, parameters.FolderPath);
        Assert.Equal(expectedIncludeDeleted, parameters.IncludeDeleted);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomMetadataFieldListParams { };

        Assert.Null(parameters.FolderPath);
        Assert.False(parameters.RawQueryData.ContainsKey("folderPath"));
        Assert.Null(parameters.IncludeDeleted);
        Assert.False(parameters.RawQueryData.ContainsKey("includeDeleted"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomMetadataFieldListParams
        {
            // Null should be interpreted as omitted for these properties
            FolderPath = null,
            IncludeDeleted = null,
        };

        Assert.Null(parameters.FolderPath);
        Assert.False(parameters.RawQueryData.ContainsKey("folderPath"));
        Assert.Null(parameters.IncludeDeleted);
        Assert.False(parameters.RawQueryData.ContainsKey("includeDeleted"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomMetadataFieldListParams parameters = new()
        {
            FolderPath = "folderPath",
            IncludeDeleted = true,
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(
            new Uri(
                "https://api.imagekit.io/v1/customMetadataFields?folderPath=folderPath&includeDeleted=true"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomMetadataFieldListParams
        {
            FolderPath = "folderPath",
            IncludeDeleted = true,
        };

        CustomMetadataFieldListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
