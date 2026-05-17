using System;
using System.Collections.Generic;
using ImagekitDiversion.Models.Files.Batch;

namespace ImagekitDiversion.Tests.Models.Files.Batch;

public class BatchDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BatchDeleteParams
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
        BatchDeleteParams parameters = new()
        {
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.imagekit.io/v1/files/batch/deleteByFileIds"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BatchDeleteParams
        {
            FileIds = ["598821f949c0a938d57563bd", "598821f949c0a938d57563be"],
        };

        BatchDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
