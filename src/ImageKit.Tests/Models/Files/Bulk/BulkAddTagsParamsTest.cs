using System;
using System.Collections.Generic;
using ImageKit.Models.Files.Bulk;

namespace ImageKit.Tests.Models.Files.Bulk;

public class BulkAddTagsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkAddTagsParams
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
        BulkAddTagsParams parameters = new()
        {
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
            Tags = ["t-shirt", "round-neck", "sale2019"],
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/files/addTags"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BulkAddTagsParams
        {
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
            Tags = ["t-shirt", "round-neck", "sale2019"],
        };

        BulkAddTagsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
