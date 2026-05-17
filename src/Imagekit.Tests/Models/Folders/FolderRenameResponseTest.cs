using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Folders;

namespace Imagekit.Tests.Models.Folders;

public class FolderRenameResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FolderRenameResponse { JobID = "jobId" };

        string expectedJobID = "jobId";

        Assert.Equal(expectedJobID, model.JobID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FolderRenameResponse { JobID = "jobId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderRenameResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FolderRenameResponse { JobID = "jobId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FolderRenameResponse>(
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
        var model = new FolderRenameResponse { JobID = "jobId" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FolderRenameResponse { JobID = "jobId" };

        FolderRenameResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
