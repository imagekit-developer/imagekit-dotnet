using System;
using ImageKit.Models.Folders.Job;

namespace ImageKit.Tests.Models.Folders.Job;

public class JobGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JobGetParams { JobID = "jobId" };

        string expectedJobID = "jobId";

        Assert.Equal(expectedJobID, parameters.JobID);
    }

    [Fact]
    public void Url_Works()
    {
        JobGetParams parameters = new() { JobID = "jobId" };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/bulkJobs/jobId"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JobGetParams { JobID = "jobId" };

        JobGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
