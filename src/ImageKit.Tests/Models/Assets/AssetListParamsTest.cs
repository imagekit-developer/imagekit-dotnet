using System;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Exceptions;
using Assets = ImageKit.Models.Assets;

namespace ImageKit.Tests.Models.Assets;

public class AssetListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Assets::AssetListParams
        {
            FileType = Assets::FileType.All,
            Limit = 1,
            Path = "path",
            SearchQuery = "searchQuery",
            Skip = 0,
            Sort = Assets::Sort.AscName,
            Type = Assets::Type.File,
        };

        ApiEnum<string, Assets::FileType> expectedFileType = Assets::FileType.All;
        long expectedLimit = 1;
        string expectedPath = "path";
        string expectedSearchQuery = "searchQuery";
        long expectedSkip = 0;
        ApiEnum<string, Assets::Sort> expectedSort = Assets::Sort.AscName;
        ApiEnum<string, Assets::Type> expectedType = Assets::Type.File;

        Assert.Equal(expectedFileType, parameters.FileType);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPath, parameters.Path);
        Assert.Equal(expectedSearchQuery, parameters.SearchQuery);
        Assert.Equal(expectedSkip, parameters.Skip);
        Assert.Equal(expectedSort, parameters.Sort);
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Assets::AssetListParams { };

        Assert.Null(parameters.FileType);
        Assert.False(parameters.RawQueryData.ContainsKey("fileType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawQueryData.ContainsKey("path"));
        Assert.Null(parameters.SearchQuery);
        Assert.False(parameters.RawQueryData.ContainsKey("searchQuery"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Assets::AssetListParams
        {
            // Null should be interpreted as omitted for these properties
            FileType = null,
            Limit = null,
            Path = null,
            SearchQuery = null,
            Skip = null,
            Sort = null,
            Type = null,
        };

        Assert.Null(parameters.FileType);
        Assert.False(parameters.RawQueryData.ContainsKey("fileType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Path);
        Assert.False(parameters.RawQueryData.ContainsKey("path"));
        Assert.Null(parameters.SearchQuery);
        Assert.False(parameters.RawQueryData.ContainsKey("searchQuery"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
        Assert.Null(parameters.Sort);
        Assert.False(parameters.RawQueryData.ContainsKey("sort"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        Assets::AssetListParams parameters = new()
        {
            FileType = Assets::FileType.All,
            Limit = 1,
            Path = "path",
            SearchQuery = "searchQuery",
            Skip = 0,
            Sort = Assets::Sort.AscName,
            Type = Assets::Type.File,
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key" });

        Assert.Equal(
            new Uri(
                "https://api.imagekit.io/v1/files?fileType=all&limit=1&path=path&searchQuery=searchQuery&skip=0&sort=ASC_NAME&type=file"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Assets::AssetListParams
        {
            FileType = Assets::FileType.All,
            Limit = 1,
            Path = "path",
            SearchQuery = "searchQuery",
            Skip = 0,
            Sort = Assets::Sort.AscName,
            Type = Assets::Type.File,
        };

        Assets::AssetListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FileTypeTest : TestBase
{
    [Theory]
    [InlineData(Assets::FileType.All)]
    [InlineData(Assets::FileType.Image)]
    [InlineData(Assets::FileType.NonImage)]
    public void Validation_Works(Assets::FileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Assets::FileType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Assets::FileType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Assets::FileType.All)]
    [InlineData(Assets::FileType.Image)]
    [InlineData(Assets::FileType.NonImage)]
    public void SerializationRoundtrip_Works(Assets::FileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Assets::FileType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Assets::FileType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Assets::FileType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Assets::FileType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SortTest : TestBase
{
    [Theory]
    [InlineData(Assets::Sort.AscName)]
    [InlineData(Assets::Sort.DescName)]
    [InlineData(Assets::Sort.AscCreated)]
    [InlineData(Assets::Sort.DescCreated)]
    [InlineData(Assets::Sort.AscUpdated)]
    [InlineData(Assets::Sort.DescUpdated)]
    [InlineData(Assets::Sort.AscHeight)]
    [InlineData(Assets::Sort.DescHeight)]
    [InlineData(Assets::Sort.AscWidth)]
    [InlineData(Assets::Sort.DescWidth)]
    [InlineData(Assets::Sort.AscSize)]
    [InlineData(Assets::Sort.DescSize)]
    [InlineData(Assets::Sort.AscRelevance)]
    [InlineData(Assets::Sort.DescRelevance)]
    public void Validation_Works(Assets::Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Assets::Sort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Assets::Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Assets::Sort.AscName)]
    [InlineData(Assets::Sort.DescName)]
    [InlineData(Assets::Sort.AscCreated)]
    [InlineData(Assets::Sort.DescCreated)]
    [InlineData(Assets::Sort.AscUpdated)]
    [InlineData(Assets::Sort.DescUpdated)]
    [InlineData(Assets::Sort.AscHeight)]
    [InlineData(Assets::Sort.DescHeight)]
    [InlineData(Assets::Sort.AscWidth)]
    [InlineData(Assets::Sort.DescWidth)]
    [InlineData(Assets::Sort.AscSize)]
    [InlineData(Assets::Sort.DescSize)]
    [InlineData(Assets::Sort.AscRelevance)]
    [InlineData(Assets::Sort.DescRelevance)]
    public void SerializationRoundtrip_Works(Assets::Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Assets::Sort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Assets::Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Assets::Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Assets::Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Assets::Type.File)]
    [InlineData(Assets::Type.FileVersion)]
    [InlineData(Assets::Type.Folder)]
    [InlineData(Assets::Type.All)]
    public void Validation_Works(Assets::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Assets::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Assets::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImageKitInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Assets::Type.File)]
    [InlineData(Assets::Type.FileVersion)]
    [InlineData(Assets::Type.Folder)]
    [InlineData(Assets::Type.All)]
    public void SerializationRoundtrip_Works(Assets::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Assets::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Assets::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Assets::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Assets::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
