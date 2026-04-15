using System;
using System.Collections.Generic;
using ImageKit.Models.Files.Bulk;

namespace ImageKit.Tests.Models.Files.Bulk;

public class BulkRemoveAITagsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkRemoveAITagsParams
        {
            AITags = ["t-shirt", "round-neck", "sale2019"],
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
        };

        List<string> expectedAITags = ["t-shirt", "round-neck", "sale2019"];
        List<string> expectedFileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"];

        Assert.Equal(expectedAITags.Count, parameters.AITags.Count);
        for (int i = 0; i < expectedAITags.Count; i++)
        {
            Assert.Equal(expectedAITags[i], parameters.AITags[i]);
        }
        Assert.Equal(expectedFileIds.Count, parameters.FileIds.Count);
        for (int i = 0; i < expectedFileIds.Count; i++)
        {
            Assert.Equal(expectedFileIds[i], parameters.FileIds[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        BulkRemoveAITagsParams parameters = new()
        {
            AITags = ["t-shirt", "round-neck", "sale2019"],
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/files/removeAITags"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BulkRemoveAITagsParams
        {
            AITags = ["t-shirt", "round-neck", "sale2019"],
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
        };

        BulkRemoveAITagsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
