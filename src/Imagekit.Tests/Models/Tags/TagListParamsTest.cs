using System;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Tags;

namespace Imagekit.Tests.Models.Tags;

public class TagListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TagListParams
        {
            Cursor = "cursor",
            FileType = FileType.Image,
            Limit = 1,
            Prefix = "prefix",
            Search = "search",
            Sort = Sort.AscName,
            TagSource = TagSource.User,
        };

        string expectedCursor = "cursor";
        ApiEnum<string, FileType> expectedFileType = FileType.Image;
        long expectedLimit = 1;
        string expectedPrefix = "prefix";
        string expectedSearch = "search";
        ApiEnum<string, Sort> expectedSort = Sort.AscName;
        ApiEnum<string, TagSource> expectedTagSource = TagSource.User;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedFileType, parameters.FileType);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPrefix, parameters.Prefix);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.Equal(expectedSort, parameters.Sort);
        Assert.Equal(expectedTagSource, parameters.TagSource);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TagListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.FileType);
        Assert.False(parameters.RawQueryData.ContainsKey("fileType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Prefix);
        Assert.False(parameters.RawQueryData.ContainsKey("prefix"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
        Assert.Null(parameters.TagSource);
        Assert.False(parameters.RawQueryData.ContainsKey("tagSource"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TagListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            FileType = null,
            Limit = null,
            Prefix = null,
            Search = null,
            Sort = null,
            TagSource = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.FileType);
        Assert.False(parameters.RawQueryData.ContainsKey("fileType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Prefix);
        Assert.False(parameters.RawQueryData.ContainsKey("prefix"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
        Assert.Null(parameters.TagSource);
        Assert.False(parameters.RawQueryData.ContainsKey("tagSource"));
    }

    [Fact]
    public void Url_Works()
    {
        TagListParams parameters = new()
        {
            Cursor = "cursor",
            FileType = FileType.Image,
            Limit = 1,
            Prefix = "prefix",
            Search = "search",
            Sort = Sort.AscName,
            TagSource = TagSource.User,
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.imagekit.io/v1/tags?cursor=cursor&fileType=image&limit=1&prefix=prefix&search=search&sort=ASC_NAME&tagSource=user"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TagListParams
        {
            Cursor = "cursor",
            FileType = FileType.Image,
            Limit = 1,
            Prefix = "prefix",
            Search = "search",
            Sort = Sort.AscName,
            TagSource = TagSource.User,
        };

        TagListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FileTypeTest : TestBase
{
    [Theory]
    [InlineData(FileType.Image)]
    [InlineData(FileType.Video)]
    [InlineData(FileType.Static)]
    [InlineData(FileType.All)]
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
    [InlineData(FileType.Image)]
    [InlineData(FileType.Video)]
    [InlineData(FileType.Static)]
    [InlineData(FileType.All)]
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

public class SortTest : TestBase
{
    [Theory]
    [InlineData(Sort.AscName)]
    [InlineData(Sort.DescName)]
    [InlineData(Sort.AscLastUsed)]
    [InlineData(Sort.DescLastUsed)]
    public void Validation_Works(Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Sort.AscName)]
    [InlineData(Sort.DescName)]
    [InlineData(Sort.AscLastUsed)]
    [InlineData(Sort.DescLastUsed)]
    public void SerializationRoundtrip_Works(Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Sort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TagSourceTest : TestBase
{
    [Theory]
    [InlineData(TagSource.User)]
    [InlineData(TagSource.AI)]
    [InlineData(TagSource.All)]
    public void Validation_Works(TagSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TagSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TagSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TagSource.User)]
    [InlineData(TagSource.AI)]
    [InlineData(TagSource.All)]
    public void SerializationRoundtrip_Works(TagSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TagSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TagSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TagSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TagSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
