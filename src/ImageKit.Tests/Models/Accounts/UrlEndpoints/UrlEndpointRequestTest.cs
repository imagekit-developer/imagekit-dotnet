using System.Collections.Generic;
using System.Text.Json;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models.Accounts.UrlEndpoints;

namespace ImageKit.Tests.Models.Accounts.UrlEndpoints;

public class UrlEndpointRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlEndpointRequest
        {
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointRequestUrlRewriterCloudinary()
            {
                PreserveAssetDeliveryTypes = true,
            },
        };

        string expectedDescription = "My custom URL endpoint";
        List<string> expectedOrigins = ["origin-id-1"];
        string expectedUrlPrefix = "product-images";
        UrlEndpointRequestUrlRewriter expectedUrlRewriter =
            new UrlEndpointRequestUrlRewriterCloudinary() { PreserveAssetDeliveryTypes = true };

        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Origins);
        Assert.Equal(expectedOrigins.Count, model.Origins.Count);
        for (int i = 0; i < expectedOrigins.Count; i++)
        {
            Assert.Equal(expectedOrigins[i], model.Origins[i]);
        }
        Assert.Equal(expectedUrlPrefix, model.UrlPrefix);
        Assert.Equal(expectedUrlRewriter, model.UrlRewriter);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlEndpointRequest
        {
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointRequestUrlRewriterCloudinary()
            {
                PreserveAssetDeliveryTypes = true,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlEndpointRequest
        {
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointRequestUrlRewriterCloudinary()
            {
                PreserveAssetDeliveryTypes = true,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "My custom URL endpoint";
        List<string> expectedOrigins = ["origin-id-1"];
        string expectedUrlPrefix = "product-images";
        UrlEndpointRequestUrlRewriter expectedUrlRewriter =
            new UrlEndpointRequestUrlRewriterCloudinary() { PreserveAssetDeliveryTypes = true };

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Origins);
        Assert.Equal(expectedOrigins.Count, deserialized.Origins.Count);
        for (int i = 0; i < expectedOrigins.Count; i++)
        {
            Assert.Equal(expectedOrigins[i], deserialized.Origins[i]);
        }
        Assert.Equal(expectedUrlPrefix, deserialized.UrlPrefix);
        Assert.Equal(expectedUrlRewriter, deserialized.UrlRewriter);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlEndpointRequest
        {
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointRequestUrlRewriterCloudinary()
            {
                PreserveAssetDeliveryTypes = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UrlEndpointRequest { Description = "My custom URL endpoint" };

        Assert.Null(model.Origins);
        Assert.False(model.RawData.ContainsKey("origins"));
        Assert.Null(model.UrlPrefix);
        Assert.False(model.RawData.ContainsKey("urlPrefix"));
        Assert.Null(model.UrlRewriter);
        Assert.False(model.RawData.ContainsKey("urlRewriter"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UrlEndpointRequest { Description = "My custom URL endpoint" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UrlEndpointRequest
        {
            Description = "My custom URL endpoint",

            // Null should be interpreted as omitted for these properties
            Origins = null,
            UrlPrefix = null,
            UrlRewriter = null,
        };

        Assert.Null(model.Origins);
        Assert.False(model.RawData.ContainsKey("origins"));
        Assert.Null(model.UrlPrefix);
        Assert.False(model.RawData.ContainsKey("urlPrefix"));
        Assert.Null(model.UrlRewriter);
        Assert.False(model.RawData.ContainsKey("urlRewriter"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UrlEndpointRequest
        {
            Description = "My custom URL endpoint",

            // Null should be interpreted as omitted for these properties
            Origins = null,
            UrlPrefix = null,
            UrlRewriter = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlEndpointRequest
        {
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointRequestUrlRewriterCloudinary()
            {
                PreserveAssetDeliveryTypes = true,
            },
        };

        UrlEndpointRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlEndpointRequestUrlRewriterTest : TestBase
{
    [Fact]
    public void CloudinaryValidationWorks()
    {
        UrlEndpointRequestUrlRewriter value = new UrlEndpointRequestUrlRewriterCloudinary()
        {
            PreserveAssetDeliveryTypes = true,
        };
        value.Validate();
    }

    [Fact]
    public void ImgixValidationWorks()
    {
        UrlEndpointRequestUrlRewriter value = new UrlEndpointRequestUrlRewriterImgix();
        value.Validate();
    }

    [Fact]
    public void AkamaiValidationWorks()
    {
        UrlEndpointRequestUrlRewriter value = new UrlEndpointRequestUrlRewriterAkamai();
        value.Validate();
    }

    [Fact]
    public void CloudinarySerializationRoundtripWorks()
    {
        UrlEndpointRequestUrlRewriter value = new UrlEndpointRequestUrlRewriterCloudinary()
        {
            PreserveAssetDeliveryTypes = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImgixSerializationRoundtripWorks()
    {
        UrlEndpointRequestUrlRewriter value = new UrlEndpointRequestUrlRewriterImgix();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AkamaiSerializationRoundtripWorks()
    {
        UrlEndpointRequestUrlRewriter value = new UrlEndpointRequestUrlRewriterAkamai();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UrlEndpointRequestUrlRewriterCloudinaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlEndpointRequestUrlRewriterCloudinary
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
        var model = new UrlEndpointRequestUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterCloudinary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlEndpointRequestUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterCloudinary>(
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
        var model = new UrlEndpointRequestUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UrlEndpointRequestUrlRewriterCloudinary { };

        Assert.Null(model.PreserveAssetDeliveryTypes);
        Assert.False(model.RawData.ContainsKey("preserveAssetDeliveryTypes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UrlEndpointRequestUrlRewriterCloudinary { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UrlEndpointRequestUrlRewriterCloudinary
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
        var model = new UrlEndpointRequestUrlRewriterCloudinary
        {
            // Null should be interpreted as omitted for these properties
            PreserveAssetDeliveryTypes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlEndpointRequestUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        UrlEndpointRequestUrlRewriterCloudinary copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlEndpointRequestUrlRewriterImgixTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UrlEndpointRequestUrlRewriterImgix();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterImgix>(
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
        var constant = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterImgix>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UrlEndpointRequestUrlRewriterImgix();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterImgix>(
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
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterImgix>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class UrlEndpointRequestUrlRewriterAkamaiTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UrlEndpointRequestUrlRewriterAkamai();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterAkamai>(
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
        var constant = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterAkamai>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UrlEndpointRequestUrlRewriterAkamai();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterAkamai>(
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
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterAkamai>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}
