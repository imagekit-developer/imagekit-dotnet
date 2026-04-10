using System;
using System.Collections.Generic;
using ImageKit.Models.Files.Bulk;

namespace ImageKit.Tests.Models.Files.Bulk;

public class BulkDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkDeleteParams
        {
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
        };

        List<string> expectedFileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"];

        Assert.Equal(expectedFileIds.Count, parameters.FileIds.Count);
        for (int i = 0; i < expectedFileIds.Count; i++)
        {
            Assert.Equal(expectedFileIds[i], parameters.FileIds[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        BulkDeleteParams parameters = new()
        {
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.Equal(new Uri("https://api.imagekit.io/v1/files/batch/deleteByFileIds"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BulkDeleteParams
        {
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
        };

        BulkDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
