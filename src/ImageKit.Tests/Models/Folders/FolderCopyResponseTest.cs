using System.Text.Json;
using ImageKit.Core;
using ImageKit.Models.Folders;

namespace ImageKit.Tests.Models.Folders;

public class FolderCopyResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderCopyResponse { JobID = "jobId" };

        string expectedJobID = "jobId";

        Assert.Equal(expectedJobID, model.JobID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderCopyResponse { JobID = "jobId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderCopyResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderCopyResponse { JobID = "jobId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderCopyResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedJobID = "jobId";

        Assert.Equal(expectedJobID, deserialized.JobID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FolderCopyResponse { JobID = "jobId" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderCopyResponse { JobID = "jobId" };

        FolderCopyResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
