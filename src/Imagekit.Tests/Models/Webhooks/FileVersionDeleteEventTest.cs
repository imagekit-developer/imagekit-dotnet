using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Webhooks;

namespace Imagekit.Tests.Models.Webhooks;

public class FileVersionDeleteEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileVersionDeleteEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        FileVersionDeleteEventFileVersionDeleteEventData expectedData = new()
        {
            FileID = "fileId",
            VersionID = "versionId",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileVersionDeleteEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileVersionDeleteEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileVersionDeleteEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileVersionDeleteEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        FileVersionDeleteEventFileVersionDeleteEventData expectedData = new()
        {
            FileID = "fileId",
            VersionID = "versionId",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileVersionDeleteEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileVersionDeleteEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };

        FileVersionDeleteEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileVersionDeleteEventFileVersionDeleteEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileVersionDeleteEventFileVersionDeleteEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        FileVersionDeleteEventFileVersionDeleteEventData expectedData = new()
        {
            FileID = "fileId",
            VersionID = "versionId",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("file-version.deleted");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileVersionDeleteEventFileVersionDeleteEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileVersionDeleteEventFileVersionDeleteEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileVersionDeleteEventFileVersionDeleteEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileVersionDeleteEventFileVersionDeleteEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        FileVersionDeleteEventFileVersionDeleteEventData expectedData = new()
        {
            FileID = "fileId",
            VersionID = "versionId",
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("file-version.deleted");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileVersionDeleteEventFileVersionDeleteEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileVersionDeleteEventFileVersionDeleteEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new() { FileID = "fileId", VersionID = "versionId" },
        };

        FileVersionDeleteEventFileVersionDeleteEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileVersionDeleteEventFileVersionDeleteEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileVersionDeleteEventFileVersionDeleteEventData
        {
            FileID = "fileId",
            VersionID = "versionId",
        };

        string expectedFileID = "fileId";
        string expectedVersionID = "versionId";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedVersionID, model.VersionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileVersionDeleteEventFileVersionDeleteEventData
        {
            FileID = "fileId",
            VersionID = "versionId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FileVersionDeleteEventFileVersionDeleteEventData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileVersionDeleteEventFileVersionDeleteEventData
        {
            FileID = "fileId",
            VersionID = "versionId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FileVersionDeleteEventFileVersionDeleteEventData>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFileID = "fileId";
        string expectedVersionID = "versionId";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedVersionID, deserialized.VersionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileVersionDeleteEventFileVersionDeleteEventData
        {
            FileID = "fileId",
            VersionID = "versionId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileVersionDeleteEventFileVersionDeleteEventData
        {
            FileID = "fileId",
            VersionID = "versionId",
        };

        FileVersionDeleteEventFileVersionDeleteEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}
