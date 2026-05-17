using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Accounts.UrlEndpoints;

namespace ImagekitDiversion.Tests.Models.Accounts.UrlEndpoints;

public class UrlEndpointTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlEndpoint
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointUrlRewriterCloudinary(true),
        };

        string expectedID = "id";
        string expectedDescription = "My custom URL endpoint";
        List<string> expectedOrigins = ["origin-id-1", "origin-id-2"];
        string expectedUrlPrefix = "product-images";
        UrlEndpointUrlRewriter expectedUrlRewriter = new UrlEndpointUrlRewriterCloudinary(true);

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
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
        var model = new UrlEndpoint
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointUrlRewriterCloudinary(true),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpoint>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlEndpoint
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointUrlRewriterCloudinary(true),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpoint>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDescription = "My custom URL endpoint";
        List<string> expectedOrigins = ["origin-id-1", "origin-id-2"];
        string expectedUrlPrefix = "product-images";
        UrlEndpointUrlRewriter expectedUrlRewriter = new UrlEndpointUrlRewriterCloudinary(true);

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
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
        var model = new UrlEndpoint
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointUrlRewriterCloudinary(true),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UrlEndpoint
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
        };

        Assert.Null(model.UrlRewriter);
        Assert.False(model.RawData.ContainsKey("urlRewriter"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UrlEndpoint
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UrlEndpoint
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",

            // Null should be interpreted as omitted for these properties
            UrlRewriter = null,
        };

        Assert.Null(model.UrlRewriter);
        Assert.False(model.RawData.ContainsKey("urlRewriter"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UrlEndpoint
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",

            // Null should be interpreted as omitted for these properties
            UrlRewriter = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlEndpoint
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointUrlRewriterCloudinary(true),
        };

        UrlEndpoint copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlEndpointUrlRewriterTest : TestBase
{
    [Fact]
    public void CloudinaryValidationWorks()
    {
        UrlEndpointUrlRewriter value = new UrlEndpointUrlRewriterCloudinary(true);
        value.Validate();
    }

    [Fact]
    public void ImgixValidationWorks()
    {
        UrlEndpointUrlRewriter value = new UrlEndpointUrlRewriterImgix();
        value.Validate();
    }

    [Fact]
    public void AkamaiValidationWorks()
    {
        UrlEndpointUrlRewriter value = new UrlEndpointUrlRewriterAkamai();
        value.Validate();
    }

    [Fact]
    public void CloudinarySerializationRoundtripWorks()
    {
        UrlEndpointUrlRewriter value = new UrlEndpointUrlRewriterCloudinary(true);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImgixSerializationRoundtripWorks()
    {
        UrlEndpointUrlRewriter value = new UrlEndpointUrlRewriterImgix();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AkamaiSerializationRoundtripWorks()
    {
        UrlEndpointUrlRewriter value = new UrlEndpointUrlRewriterAkamai();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UrlEndpointUrlRewriterCloudinaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlEndpointUrlRewriterCloudinary { PreserveAssetDeliveryTypes = true };

        bool expectedPreserveAssetDeliveryTypes = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY");

        Assert.Equal(expectedPreserveAssetDeliveryTypes, model.PreserveAssetDeliveryTypes);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlEndpointUrlRewriterCloudinary { PreserveAssetDeliveryTypes = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriterCloudinary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlEndpointUrlRewriterCloudinary { PreserveAssetDeliveryTypes = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriterCloudinary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedPreserveAssetDeliveryTypes = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY");

        Assert.Equal(expectedPreserveAssetDeliveryTypes, deserialized.PreserveAssetDeliveryTypes);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlEndpointUrlRewriterCloudinary { PreserveAssetDeliveryTypes = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlEndpointUrlRewriterCloudinary { PreserveAssetDeliveryTypes = true };

        UrlEndpointUrlRewriterCloudinary copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlEndpointUrlRewriterImgixTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UrlEndpointUrlRewriterImgix();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUrlRewriterImgix>(
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
        var constant = JsonSerializer.Deserialize<UrlEndpointUrlRewriterImgix>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UrlEndpointUrlRewriterImgix();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUrlRewriterImgix>(
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
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUrlRewriterImgix>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class UrlEndpointUrlRewriterAkamaiTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UrlEndpointUrlRewriterAkamai();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUrlRewriterAkamai>(
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
        var constant = JsonSerializer.Deserialize<UrlEndpointUrlRewriterAkamai>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UrlEndpointUrlRewriterAkamai();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUrlRewriterAkamai>(
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
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointUrlRewriterAkamai>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}
