using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Api.V1.Files;
using Dummy = ImagekitDiversion.Models.Dummy;

namespace ImagekitDiversion.Tests.Models.Api.V1.Files;

public class FileUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileUploadParams
        {
            File = file,
            FileName = "fileName",
            Token = "token",
            Checks = "\"request.folder\" : \"marketing/\"\n",
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "brand", JsonSerializer.SerializeToElement("bar") },
                { "color", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "Running shoes",
            Expire = 0,
            Extensions =
            [
                new Dummy::RemovedotBgExtension()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new Dummy::AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = Dummy::Name.GoogleAutoTagging,
                },
                new Dummy::AutoDescriptionExtension(),
                new Dummy::AITasksExtension(
                    [
                        new Dummy::SelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
                        new Dummy::YesNo()
                        {
                            Instruction = "Is this a luxury or high-end fashion item?",
                            OnNo = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                            OnUnknown = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                            OnYes = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                        },
                    ]
                ),
                new Dummy::SavedExtension("ext_abc123"),
            ],
            Folder = "folder",
            IsPrivateFile = true,
            IsPublished = true,
            OverwriteAITags = true,
            OverwriteCustomMetadata = true,
            OverwriteFile = true,
            OverwriteTags = true,
            PublicKey = "publicKey",
            ResponseFields =
            [
                ResponseField.Tags,
                ResponseField.CustomCoordinates,
                ResponseField.IsPrivateFile,
            ],
            Signature = "signature",
            Tags = ["t-shirt", "round-neck", "men"],
            Transformation = new()
            {
                Post =
                [
                    new Thumbnail() { Value = "w-150,h-150" },
                    new Abs() { Protocol = Protocol.Dash, Value = "sr-240_360_480_720_1080" },
                ],
                Pre = "w-300,h-300,q-80",
            },
            UseUniqueFileName = true,
            WebhookUrl = "https://example.com",
        };

        BinaryContent expectedFile = file;
        string expectedFileName = "fileName";
        string expectedToken = "token";
        string expectedChecks = "\"request.folder\" : \"marketing/\"\n";
        string expectedCustomCoordinates = "customCoordinates";
        Dictionary<string, JsonElement> expectedCustomMetadata = new()
        {
            { "brand", JsonSerializer.SerializeToElement("bar") },
            { "color", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedDescription = "Running shoes";
        long expectedExpire = 0;
        List<Dummy::ExtensionsItem> expectedExtensions =
        [
            new Dummy::RemovedotBgExtension()
            {
                Options = new()
                {
                    AddShadow = true,
                    BgColor = "bg_color",
                    BgImageUrl = "bg_image_url",
                    Semitransparency = true,
                },
            },
            new Dummy::AutoTaggingExtension()
            {
                MaxTags = 5,
                MinConfidence = 95,
                Name = Dummy::Name.GoogleAutoTagging,
            },
            new Dummy::AutoDescriptionExtension(),
            new Dummy::AITasksExtension(
                [
                    new Dummy::SelectTags()
                    {
                        Instruction = "What types of clothing items are visible in this image?",
                        MaxSelections = 1,
                        MinSelections = 0,
                        Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                    },
                    new Dummy::YesNo()
                    {
                        Instruction = "Is this a luxury or high-end fashion item?",
                        OnNo = new()
                        {
                            AddTags = ["luxury", "premium"],
                            RemoveTags = ["budget", "affordable"],
                            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                            UnsetMetadata = [new("price_range")],
                        },
                        OnUnknown = new()
                        {
                            AddTags = ["luxury", "premium"],
                            RemoveTags = ["budget", "affordable"],
                            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                            UnsetMetadata = [new("price_range")],
                        },
                        OnYes = new()
                        {
                            AddTags = ["luxury", "premium"],
                            RemoveTags = ["budget", "affordable"],
                            SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                            UnsetMetadata = [new("price_range")],
                        },
                    },
                ]
            ),
            new Dummy::SavedExtension("ext_abc123"),
        ];
        string expectedFolder = "folder";
        bool expectedIsPrivateFile = true;
        bool expectedIsPublished = true;
        bool expectedOverwriteAITags = true;
        bool expectedOverwriteCustomMetadata = true;
        bool expectedOverwriteFile = true;
        bool expectedOverwriteTags = true;
        string expectedPublicKey = "publicKey";
        List<ApiEnum<string, ResponseField>> expectedResponseFields =
        [
            ResponseField.Tags,
            ResponseField.CustomCoordinates,
            ResponseField.IsPrivateFile,
        ];
        string expectedSignature = "signature";
        List<string> expectedTags = ["t-shirt", "round-neck", "men"];
        TransformationObject expectedTransformation = new()
        {
            Post =
            [
                new Thumbnail() { Value = "w-150,h-150" },
                new Abs() { Protocol = Protocol.Dash, Value = "sr-240_360_480_720_1080" },
            ],
            Pre = "w-300,h-300,q-80",
        };
        bool expectedUseUniqueFileName = true;
        string expectedWebhookUrl = "https://example.com";

        Assert.Equal(expectedFile, parameters.File);
        Assert.Equal(expectedFileName, parameters.FileName);
        Assert.Equal(expectedToken, parameters.Token);
        Assert.Equal(expectedChecks, parameters.Checks);
        Assert.Equal(expectedCustomCoordinates, parameters.CustomCoordinates);
        Assert.NotNull(parameters.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, parameters.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(parameters.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.CustomMetadata[item.Key]));
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedExpire, parameters.Expire);
        Assert.NotNull(parameters.Extensions);
        Assert.Equal(expectedExtensions.Count, parameters.Extensions.Count);
        for (int i = 0; i < expectedExtensions.Count; i++)
        {
            Assert.Equal(expectedExtensions[i], parameters.Extensions[i]);
        }
        Assert.Equal(expectedFolder, parameters.Folder);
        Assert.Equal(expectedIsPrivateFile, parameters.IsPrivateFile);
        Assert.Equal(expectedIsPublished, parameters.IsPublished);
        Assert.Equal(expectedOverwriteAITags, parameters.OverwriteAITags);
        Assert.Equal(expectedOverwriteCustomMetadata, parameters.OverwriteCustomMetadata);
        Assert.Equal(expectedOverwriteFile, parameters.OverwriteFile);
        Assert.Equal(expectedOverwriteTags, parameters.OverwriteTags);
        Assert.Equal(expectedPublicKey, parameters.PublicKey);
        Assert.NotNull(parameters.ResponseFields);
        Assert.Equal(expectedResponseFields.Count, parameters.ResponseFields.Count);
        for (int i = 0; i < expectedResponseFields.Count; i++)
        {
            Assert.Equal(expectedResponseFields[i], parameters.ResponseFields[i]);
        }
        Assert.Equal(expectedSignature, parameters.Signature);
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
        Assert.Equal(expectedTransformation, parameters.Transformation);
        Assert.Equal(expectedUseUniqueFileName, parameters.UseUniqueFileName);
        Assert.Equal(expectedWebhookUrl, parameters.WebhookUrl);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileUploadParams { File = file, FileName = "fileName" };

        Assert.Null(parameters.Token);
        Assert.False(parameters.RawBodyData.ContainsKey("token"));
        Assert.Null(parameters.Checks);
        Assert.False(parameters.RawBodyData.ContainsKey("checks"));
        Assert.Null(parameters.CustomCoordinates);
        Assert.False(parameters.RawBodyData.ContainsKey("customCoordinates"));
        Assert.Null(parameters.CustomMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("customMetadata"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Expire);
        Assert.False(parameters.RawBodyData.ContainsKey("expire"));
        Assert.Null(parameters.Extensions);
        Assert.False(parameters.RawBodyData.ContainsKey("extensions"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.IsPrivateFile);
        Assert.False(parameters.RawBodyData.ContainsKey("isPrivateFile"));
        Assert.Null(parameters.IsPublished);
        Assert.False(parameters.RawBodyData.ContainsKey("isPublished"));
        Assert.Null(parameters.OverwriteAITags);
        Assert.False(parameters.RawBodyData.ContainsKey("overwriteAITags"));
        Assert.Null(parameters.OverwriteCustomMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("overwriteCustomMetadata"));
        Assert.Null(parameters.OverwriteFile);
        Assert.False(parameters.RawBodyData.ContainsKey("overwriteFile"));
        Assert.Null(parameters.OverwriteTags);
        Assert.False(parameters.RawBodyData.ContainsKey("overwriteTags"));
        Assert.Null(parameters.PublicKey);
        Assert.False(parameters.RawBodyData.ContainsKey("publicKey"));
        Assert.Null(parameters.ResponseFields);
        Assert.False(parameters.RawBodyData.ContainsKey("responseFields"));
        Assert.Null(parameters.Signature);
        Assert.False(parameters.RawBodyData.ContainsKey("signature"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.Transformation);
        Assert.False(parameters.RawBodyData.ContainsKey("transformation"));
        Assert.Null(parameters.UseUniqueFileName);
        Assert.False(parameters.RawBodyData.ContainsKey("useUniqueFileName"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileUploadParams
        {
            File = file,
            FileName = "fileName",

            // Null should be interpreted as omitted for these properties
            Token = null,
            Checks = null,
            CustomCoordinates = null,
            CustomMetadata = null,
            Description = null,
            Expire = null,
            Extensions = null,
            Folder = null,
            IsPrivateFile = null,
            IsPublished = null,
            OverwriteAITags = null,
            OverwriteCustomMetadata = null,
            OverwriteFile = null,
            OverwriteTags = null,
            PublicKey = null,
            ResponseFields = null,
            Signature = null,
            Tags = null,
            Transformation = null,
            UseUniqueFileName = null,
            WebhookUrl = null,
        };

        Assert.Null(parameters.Token);
        Assert.False(parameters.RawBodyData.ContainsKey("token"));
        Assert.Null(parameters.Checks);
        Assert.False(parameters.RawBodyData.ContainsKey("checks"));
        Assert.Null(parameters.CustomCoordinates);
        Assert.False(parameters.RawBodyData.ContainsKey("customCoordinates"));
        Assert.Null(parameters.CustomMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("customMetadata"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Expire);
        Assert.False(parameters.RawBodyData.ContainsKey("expire"));
        Assert.Null(parameters.Extensions);
        Assert.False(parameters.RawBodyData.ContainsKey("extensions"));
        Assert.Null(parameters.Folder);
        Assert.False(parameters.RawBodyData.ContainsKey("folder"));
        Assert.Null(parameters.IsPrivateFile);
        Assert.False(parameters.RawBodyData.ContainsKey("isPrivateFile"));
        Assert.Null(parameters.IsPublished);
        Assert.False(parameters.RawBodyData.ContainsKey("isPublished"));
        Assert.Null(parameters.OverwriteAITags);
        Assert.False(parameters.RawBodyData.ContainsKey("overwriteAITags"));
        Assert.Null(parameters.OverwriteCustomMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("overwriteCustomMetadata"));
        Assert.Null(parameters.OverwriteFile);
        Assert.False(parameters.RawBodyData.ContainsKey("overwriteFile"));
        Assert.Null(parameters.OverwriteTags);
        Assert.False(parameters.RawBodyData.ContainsKey("overwriteTags"));
        Assert.Null(parameters.PublicKey);
        Assert.False(parameters.RawBodyData.ContainsKey("publicKey"));
        Assert.Null(parameters.ResponseFields);
        Assert.False(parameters.RawBodyData.ContainsKey("responseFields"));
        Assert.Null(parameters.Signature);
        Assert.False(parameters.RawBodyData.ContainsKey("signature"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
        Assert.Null(parameters.Transformation);
        Assert.False(parameters.RawBodyData.ContainsKey("transformation"));
        Assert.Null(parameters.UseUniqueFileName);
        Assert.False(parameters.RawBodyData.ContainsKey("useUniqueFileName"));
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhookUrl"));
    }

    [Fact]
    public void Url_Works()
    {
        FileUploadParams parameters = new()
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            FileName = "fileName",
        };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/api/v1/files/upload"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileUploadParams
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            FileName = "fileName",
            Token = "token",
            Checks = "\"request.folder\" : \"marketing/\"\n",
            CustomCoordinates = "customCoordinates",
            CustomMetadata = new Dictionary<string, JsonElement>()
            {
                { "brand", JsonSerializer.SerializeToElement("bar") },
                { "color", JsonSerializer.SerializeToElement("bar") },
            },
            Description = "Running shoes",
            Expire = 0,
            Extensions =
            [
                new Dummy::RemovedotBgExtension()
                {
                    Options = new()
                    {
                        AddShadow = true,
                        BgColor = "bg_color",
                        BgImageUrl = "bg_image_url",
                        Semitransparency = true,
                    },
                },
                new Dummy::AutoTaggingExtension()
                {
                    MaxTags = 5,
                    MinConfidence = 95,
                    Name = Dummy::Name.GoogleAutoTagging,
                },
                new Dummy::AutoDescriptionExtension(),
                new Dummy::AITasksExtension(
                    [
                        new Dummy::SelectTags()
                        {
                            Instruction = "What types of clothing items are visible in this image?",
                            MaxSelections = 1,
                            MinSelections = 0,
                            Vocabulary = ["shirt", "tshirt", "dress", "trousers", "jacket"],
                        },
                        new Dummy::YesNo()
                        {
                            Instruction = "Is this a luxury or high-end fashion item?",
                            OnNo = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                            OnUnknown = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                            OnYes = new()
                            {
                                AddTags = ["luxury", "premium"],
                                RemoveTags = ["budget", "affordable"],
                                SetMetadata = [new() { Field = "price_range", Value = "premium" }],
                                UnsetMetadata = [new("price_range")],
                            },
                        },
                    ]
                ),
                new Dummy::SavedExtension("ext_abc123"),
            ],
            Folder = "folder",
            IsPrivateFile = true,
            IsPublished = true,
            OverwriteAITags = true,
            OverwriteCustomMetadata = true,
            OverwriteFile = true,
            OverwriteTags = true,
            PublicKey = "publicKey",
            ResponseFields =
            [
                ResponseField.Tags,
                ResponseField.CustomCoordinates,
                ResponseField.IsPrivateFile,
            ],
            Signature = "signature",
            Tags = ["t-shirt", "round-neck", "men"],
            Transformation = new()
            {
                Post =
                [
                    new Thumbnail() { Value = "w-150,h-150" },
                    new Abs() { Protocol = Protocol.Dash, Value = "sr-240_360_480_720_1080" },
                ],
                Pre = "w-300,h-300,q-80",
            },
            UseUniqueFileName = true,
            WebhookUrl = "https://example.com",
        };

        FileUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ResponseFieldTest : TestBase
{
    [Theory]
    [InlineData(ResponseField.Tags)]
    [InlineData(ResponseField.CustomCoordinates)]
    [InlineData(ResponseField.IsPrivateFile)]
    [InlineData(ResponseField.EmbeddedMetadata)]
    [InlineData(ResponseField.IsPublished)]
    [InlineData(ResponseField.CustomMetadata)]
    [InlineData(ResponseField.Metadata)]
    [InlineData(ResponseField.SelectedFieldsSchema)]
    public void Validation_Works(ResponseField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResponseField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResponseField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ResponseField.Tags)]
    [InlineData(ResponseField.CustomCoordinates)]
    [InlineData(ResponseField.IsPrivateFile)]
    [InlineData(ResponseField.EmbeddedMetadata)]
    [InlineData(ResponseField.IsPublished)]
    [InlineData(ResponseField.CustomMetadata)]
    [InlineData(ResponseField.Metadata)]
    [InlineData(ResponseField.SelectedFieldsSchema)]
    public void SerializationRoundtrip_Works(ResponseField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ResponseField> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResponseField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ResponseField>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ResponseField>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
