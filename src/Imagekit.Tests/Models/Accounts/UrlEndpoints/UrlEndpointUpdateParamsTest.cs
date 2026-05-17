using System;
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Accounts.UrlEndpoints;

namespace Imagekit.Tests.Models.Accounts.UrlEndpoints;

public class UrlEndpointUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UrlEndpointUpdateParams
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointUpdateParamsUrlRewriterCloudinary()
            {
                PreserveAssetDeliveryTypes = true,
            },
        };

        string expectedID = "id";
        string expectedDescription = "My custom URL endpoint";
        List<string> expectedOrigins = ["origin-id-1"];
        string expectedUrlPrefix = "product-images";
        UrlEndpointUpdateParamsUrlRewriter expectedUrlRewriter =
            new UrlEndpointUpdateParamsUrlRewriterCloudinary()
            {
                PreserveAssetDeliveryTypes = true,
            };

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Origins);
        Assert.Equal(expectedOrigins.Count, parameters.Origins.Count);
        for (int i = 0; i < expectedOrigins.Count; i++)
        {
            Assert.Equal(expectedOrigins[i], parameters.Origins[i]);
        }
        Assert.Equal(expectedUrlPrefix, parameters.UrlPrefix);
        Assert.Equal(expectedUrlRewriter, parameters.UrlRewriter);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UrlEndpointUpdateParams
        {
            ID = "id",
            Description = "My custom URL endpoint",
        };

        Assert.Null(parameters.Origins);
        Assert.False(parameters.RawBodyData.ContainsKey("origins"));
        Assert.Null(parameters.UrlPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("urlPrefix"));
        Assert.Null(parameters.UrlRewriter);
        Assert.False(parameters.RawBodyData.ContainsKey("urlRewriter"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UrlEndpointUpdateParams
        {
            ID = "id",
            Description = "My custom URL endpoint",

            // Null should be interpreted as omitted for these properties
            Origins = null,
            UrlPrefix = null,
            UrlRewriter = null,
        };

        Assert.Null(parameters.Origins);
        Assert.False(parameters.RawBodyData.ContainsKey("origins"));
        Assert.Null(parameters.UrlPrefix);
        Assert.False(parameters.RawBodyData.ContainsKey("urlPrefix"));
        Assert.Null(parameters.UrlRewriter);
        Assert.False(parameters.RawBodyData.ContainsKey("urlRewriter"));
    }

    [Fact]
    public void Url_Works()
    {
        UrlEndpointUpdateParams parameters = new()
        {
            ID = "id",
            Description = "My custom URL endpoint",
        };

        var url = parameters.Url(new() { PrivateKey = "My Private Key", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/accounts/url-endpoints/id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UrlEndpointUpdateParams
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointUpdateParamsUrlRewriterCloudinary()
            {
                PreserveAssetDeliveryTypes = true,
            },
        };

        UrlEndpointUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UrlEndpointUpdateParamsUrlRewriterTest : TestBase
{
    [Fact]
    public void CloudinaryValidationWorks()
    {
        UrlEndpointUpdateParamsUrlRewriter value =
            new UrlEndpointUpdateParamsUrlRewriterCloudinary()
            {
                PreserveAssetDeliveryTypes = true,
            };
        value.Validate();
    }

    [Fact]
    public void ImgixValidationWorks()
    {
        UrlEndpointUpdateParamsUrlRewriter value = new UrlEndpointUpdateParamsUrlRewriterImgix();
        value.Validate();
    }

    [Fact]
    public void AkamaiValidationWorks()
    {
        UrlEndpointUpdateParamsUrlRewriter value = new UrlEndpointUpdateParamsUrlRewriterAkamai();
        value.Validate();
    }

    [Fact]
    public void CloudinarySerializationRoundtripWorks()
    {
        UrlEndpointUpdateParamsUrlRewriter value =
            new UrlEndpointUpdateParamsUrlRewriterCloudinary()
            {
                PreserveAssetDeliveryTypes = true,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImgixSerializationRoundtripWorks()
    {
        UrlEndpointUpdateParamsUrlRewriter value = new UrlEndpointUpdateParamsUrlRewriterImgix();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AkamaiSerializationRoundtripWorks()
    {
        UrlEndpointUpdateParamsUrlRewriter value = new UrlEndpointUpdateParamsUrlRewriterAkamai();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UrlEndpointUpdateParamsUrlRewriterCloudinaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlEndpointUpdateParamsUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY");
        bool expectedPreserveAssetDeliveryTypes = true;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedPreserveAssetDeliveryTypes, model.PreserveAssetDeliveryTypes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlEndpointUpdateParamsUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterCloudinary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlEndpointUpdateParamsUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterCloudinary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY");
        bool expectedPreserveAssetDeliveryTypes = true;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedPreserveAssetDeliveryTypes, deserialized.PreserveAssetDeliveryTypes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlEndpointUpdateParamsUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UrlEndpointUpdateParamsUrlRewriterCloudinary { };

        Assert.Null(model.PreserveAssetDeliveryTypes);
        Assert.False(model.RawData.ContainsKey("preserveAssetDeliveryTypes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UrlEndpointUpdateParamsUrlRewriterCloudinary { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UrlEndpointUpdateParamsUrlRewriterCloudinary
        {
            // Null should be interpreted as omitted for these properties
            PreserveAssetDeliveryTypes = null,
        };

        Assert.Null(model.PreserveAssetDeliveryTypes);
        Assert.False(model.RawData.ContainsKey("preserveAssetDeliveryTypes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UrlEndpointUpdateParamsUrlRewriterCloudinary
        {
            // Null should be interpreted as omitted for these properties
            PreserveAssetDeliveryTypes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlEndpointUpdateParamsUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        UrlEndpointUpdateParamsUrlRewriterCloudinary copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlEndpointUpdateParamsUrlRewriterImgixTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UrlEndpointUpdateParamsUrlRewriterImgix();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterImgix>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "IMGIX"
                }
                """
            ),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterImgix>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UrlEndpointUpdateParamsUrlRewriterImgix();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterImgix>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "IMGIX"
                }
                """
            ),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterImgix>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class UrlEndpointUpdateParamsUrlRewriterAkamaiTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UrlEndpointUpdateParamsUrlRewriterAkamai();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterAkamai>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "AKAMAI"
                }
                """
            ),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterAkamai>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UrlEndpointUpdateParamsUrlRewriterAkamai();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterAkamai>(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "AKAMAI"
                }
                """
            ),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterAkamai>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}
