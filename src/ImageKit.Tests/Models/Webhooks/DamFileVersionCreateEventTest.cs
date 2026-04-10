using System;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Models.Webhooks;

namespace ImageKit.Tests.Models.Webhooks;

public class DamFileVersionCreateEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DamFileVersionCreateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.True(JsonElement.DeepEquals(expectedData, model.Data));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DamFileVersionCreateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DamFileVersionCreateEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DamFileVersionCreateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DamFileVersionCreateEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedType = "type";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.True(JsonElement.DeepEquals(expectedData, deserialized.Data));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DamFileVersionCreateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DamFileVersionCreateEvent
        {
            ID = "id",
            Type = "type",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        DamFileVersionCreateEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DamFileVersionCreateEventIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DamFileVersionCreateEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedType = JsonSerializer.SerializeToElement("file-version.created");

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.True(JsonElement.DeepEquals(expectedData, model.Data));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DamFileVersionCreateEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DamFileVersionCreateEventIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DamFileVersionCreateEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DamFileVersionCreateEventIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedType = JsonSerializer.SerializeToElement("file-version.created");

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.True(JsonElement.DeepEquals(expectedData, deserialized.Data));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DamFileVersionCreateEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DamFileVersionCreateEventIntersectionMember1
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        DamFileVersionCreateEventIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
