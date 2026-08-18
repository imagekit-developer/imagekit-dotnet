using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.AIFilterSearch;

namespace Imagekit.Tests.Models.AIFilterSearch;

public class AIFilterSearchCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AIFilterSearchCreateResponse
        {
            FileType = FileType.Undefined,
            IsVersionIncludedInSearch = true,
            SearchQuery = "searchQuery",
        };

        ApiEnum<string, FileType> expectedFileType = FileType.Undefined;
        bool expectedIsVersionIncludedInSearch = true;
        string expectedSearchQuery = "searchQuery";

        Assert.Equal(expectedFileType, model.FileType);
        Assert.Equal(expectedIsVersionIncludedInSearch, model.IsVersionIncludedInSearch);
        Assert.Equal(expectedSearchQuery, model.SearchQuery);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AIFilterSearchCreateResponse
        {
            FileType = FileType.Undefined,
            IsVersionIncludedInSearch = true,
            SearchQuery = "searchQuery",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIFilterSearchCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AIFilterSearchCreateResponse
        {
            FileType = FileType.Undefined,
            IsVersionIncludedInSearch = true,
            SearchQuery = "searchQuery",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AIFilterSearchCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, FileType> expectedFileType = FileType.Undefined;
        bool expectedIsVersionIncludedInSearch = true;
        string expectedSearchQuery = "searchQuery";

        Assert.Equal(expectedFileType, deserialized.FileType);
        Assert.Equal(expectedIsVersionIncludedInSearch, deserialized.IsVersionIncludedInSearch);
        Assert.Equal(expectedSearchQuery, deserialized.SearchQuery);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AIFilterSearchCreateResponse
        {
            FileType = FileType.Undefined,
            IsVersionIncludedInSearch = true,
            SearchQuery = "searchQuery",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AIFilterSearchCreateResponse { };

        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("fileType"));
        Assert.Null(model.IsVersionIncludedInSearch);
        Assert.False(model.RawData.ContainsKey("isVersionIncludedInSearch"));
        Assert.Null(model.SearchQuery);
        Assert.False(model.RawData.ContainsKey("searchQuery"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AIFilterSearchCreateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AIFilterSearchCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            FileType = null,
            IsVersionIncludedInSearch = null,
            SearchQuery = null,
        };

        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("fileType"));
        Assert.Null(model.IsVersionIncludedInSearch);
        Assert.False(model.RawData.ContainsKey("isVersionIncludedInSearch"));
        Assert.Null(model.SearchQuery);
        Assert.False(model.RawData.ContainsKey("searchQuery"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AIFilterSearchCreateResponse
        {
            // Null should be interpreted as omitted for these properties
            FileType = null,
            IsVersionIncludedInSearch = null,
            SearchQuery = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AIFilterSearchCreateResponse
        {
            FileType = FileType.Undefined,
            IsVersionIncludedInSearch = true,
            SearchQuery = "searchQuery",
        };

        AIFilterSearchCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileTypeTest : TestBase
{
    [Theory]
    [InlineData(FileType.Undefined)]
    [InlineData(FileType.Images)]
    [InlineData(FileType.Videos)]
    [InlineData(FileType.CssJs)]
    [InlineData(FileType.Others)]
    public void Validation_Works(FileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FileType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FileType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FileType.Undefined)]
    [InlineData(FileType.Images)]
    [InlineData(FileType.Videos)]
    [InlineData(FileType.CssJs)]
    [InlineData(FileType.Others)]
    public void SerializationRoundtrip_Works(FileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FileType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FileType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FileType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FileType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
