using System;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using Files = ImagekitDiversion.Models.Files;

namespace ImagekitDiversion.Tests.Models.Files;

public class FileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Files::FileListParams
        {
            FileType = Files::FileType.All,
            Limit = 1,
            Path = "path",
            SearchQuery = "searchQuery",
            Skip = 0,
            Sort = Files::Sort.AscName,
            Type = Files::Type.File,
        };

        ApiEnum<string, Files::FileType> expectedFileType = Files::FileType.All;
        long expectedLimit = 1;
        string expectedPath = "path";
        string expectedSearchQuery = "searchQuery";
        long expectedSkip = 0;
        ApiEnum<string, Files::Sort> expectedSort = Files::Sort.AscName;
        ApiEnum<string, Files::Type> expectedType = Files::Type.File;

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
        var parameters = new Files::FileListParams { };

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
        var parameters = new Files::FileListParams
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
        Files::FileListParams parameters = new()
        {
            FileType = Files::FileType.All,
            Limit = 1,
            Path = "path",
            SearchQuery = "searchQuery",
            Skip = 0,
            Sort = Files::Sort.AscName,
            Type = Files::Type.File,
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.imagekit.io/v1/files?fileType=all&limit=1&path=path&searchQuery=searchQuery&skip=0&sort=ASC_NAME&type=file"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Files::FileListParams
        {
            FileType = Files::FileType.All,
            Limit = 1,
            Path = "path",
            SearchQuery = "searchQuery",
            Skip = 0,
            Sort = Files::Sort.AscName,
            Type = Files::Type.File,
        };

        Files::FileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FileTypeTest : TestBase
{
    [Theory]
    [InlineData(Files::FileType.All)]
    [InlineData(Files::FileType.Image)]
    [InlineData(Files::FileType.NonImage)]
    public void Validation_Works(Files::FileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::FileType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::FileType.All)]
    [InlineData(Files::FileType.Image)]
    [InlineData(Files::FileType.NonImage)]
    public void SerializationRoundtrip_Works(Files::FileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FileType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::FileType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::FileType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::FileType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SortTest : TestBase
{
    [Theory]
    [InlineData(Files::Sort.AscName)]
    [InlineData(Files::Sort.DescName)]
    [InlineData(Files::Sort.AscCreated)]
    [InlineData(Files::Sort.DescCreated)]
    [InlineData(Files::Sort.AscUpdated)]
    [InlineData(Files::Sort.DescUpdated)]
    [InlineData(Files::Sort.AscHeight)]
    [InlineData(Files::Sort.DescHeight)]
    [InlineData(Files::Sort.AscWidth)]
    [InlineData(Files::Sort.DescWidth)]
    [InlineData(Files::Sort.AscSize)]
    [InlineData(Files::Sort.DescSize)]
    [InlineData(Files::Sort.AscRelevance)]
    [InlineData(Files::Sort.DescRelevance)]
    public void Validation_Works(Files::Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::Sort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::Sort.AscName)]
    [InlineData(Files::Sort.DescName)]
    [InlineData(Files::Sort.AscCreated)]
    [InlineData(Files::Sort.DescCreated)]
    [InlineData(Files::Sort.AscUpdated)]
    [InlineData(Files::Sort.DescUpdated)]
    [InlineData(Files::Sort.AscHeight)]
    [InlineData(Files::Sort.DescHeight)]
    [InlineData(Files::Sort.AscWidth)]
    [InlineData(Files::Sort.DescWidth)]
    [InlineData(Files::Sort.AscSize)]
    [InlineData(Files::Sort.DescSize)]
    [InlineData(Files::Sort.AscRelevance)]
    [InlineData(Files::Sort.DescRelevance)]
    public void SerializationRoundtrip_Works(Files::Sort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::Sort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::Sort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::Sort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Files::Type.File)]
    [InlineData(Files::Type.FileVersion)]
    [InlineData(Files::Type.Folder)]
    [InlineData(Files::Type.All)]
    public void Validation_Works(Files::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::Type.File)]
    [InlineData(Files::Type.FileVersion)]
    [InlineData(Files::Type.Folder)]
    [InlineData(Files::Type.All)]
    public void SerializationRoundtrip_Works(Files::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
