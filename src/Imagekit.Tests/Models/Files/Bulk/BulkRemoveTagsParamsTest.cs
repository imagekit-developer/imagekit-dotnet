using System;
using System.Collections.Generic;
using Imagekit.Models.Files.Bulk;

namespace Imagekit.Tests.Models.Files.Bulk;

public class BulkRemoveTagsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkRemoveTagsParams
        {
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
            Tags = ["t-shirt", "round-neck", "sale2019"],
        };

        List<string> expectedFileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"];
        List<string> expectedTags = ["t-shirt", "round-neck", "sale2019"];

        Assert.Equal(expectedFileIds.Count, parameters.FileIds.Count);
        for (int i = 0; i < expectedFileIds.Count; i++)
        {
            Assert.Equal(expectedFileIds[i], parameters.FileIds[i]);
        }
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        BulkRemoveTagsParams parameters = new()
        {
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
            Tags = ["t-shirt", "round-neck", "sale2019"],
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/removeTags"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BulkRemoveTagsParams
        {
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
            Tags = ["t-shirt", "round-neck", "sale2019"],
        };

        BulkRemoveTagsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
