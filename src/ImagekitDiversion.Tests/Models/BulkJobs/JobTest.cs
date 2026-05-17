using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.BulkJobs;

namespace ImagekitDiversion.Tests.Models.BulkJobs;

public class JobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Job { JobID = "jobId" };

        string expectedJobID = "jobId";

        Assert.Equal(expectedJobID, model.JobID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Job { JobID = "jobId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Job>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Job { JobID = "jobId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Job>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedJobID = "jobId";

        Assert.Equal(expectedJobID, deserialized.JobID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Job { JobID = "jobId" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Job { JobID = "jobId" };

        Job copied = new(model);

        Assert.Equal(model, copied);
    }
}
