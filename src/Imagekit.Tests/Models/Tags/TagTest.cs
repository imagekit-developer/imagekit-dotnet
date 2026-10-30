using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Tags;

namespace Imagekit.Tests.Models.Tags;

public class TagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tag
        {
            AssetCount = 0,
            Label = "label",
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        long expectedAssetCount = 0;
        string expectedLabel = "label";
        DateTimeOffset expectedLastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";

        Assert.Equal(expectedAssetCount, model.AssetCount);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedLastUsedAt, model.LastUsedAt);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tag
        {
            AssetCount = 0,
            Label = "label",
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tag>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tag
        {
            AssetCount = 0,
            Label = "label",
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tag>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedAssetCount = 0;
        string expectedLabel = "label";
        DateTimeOffset expectedLastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";

        Assert.Equal(expectedAssetCount, deserialized.AssetCount);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedLastUsedAt, deserialized.LastUsedAt);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tag
        {
            AssetCount = 0,
            Label = "label",
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tag
        {
            AssetCount = 0,
            Label = "label",
            LastUsedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
        };

        Tag copied = new(model);

        Assert.Equal(model, copied);
    }
}
