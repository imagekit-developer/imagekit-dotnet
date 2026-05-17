using System;
using ImagekitDiversion.Models.BulkJobs;

namespace ImagekitDiversion.Tests.Models.BulkJobs;

public class BulkJobRetrieveStatusParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkJobRetrieveStatusParams { JobID = "jobId" };

        string expectedJobID = "jobId";

        Assert.Equal(expectedJobID, parameters.JobID);
    }

    [Fact]
    public void Url_Works()
    {
        BulkJobRetrieveStatusParams parameters = new() { JobID = "jobId" };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/bulkJobs/jobId"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BulkJobRetrieveStatusParams { JobID = "jobId" };

        BulkJobRetrieveStatusParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
