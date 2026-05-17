using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Accounts.UrlEndpoints;

namespace Imagekit.Tests.Models.Accounts.UrlEndpoints;

public class UrlEndpointResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlEndpointResponse
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointResponseUrlRewriterCloudinary(true),
        };

        string expectedID = "id";
        string expectedDescription = "My custom URL endpoint";
        List<string> expectedOrigins = ["origin-id-1", "origin-id-2"];
        string expectedUrlPrefix = "product-images";
        UrlEndpointResponseUrlRewriter expectedUrlRewriter =
            new UrlEndpointResponseUrlRewriterCloudinary(true);

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
        var model = new UrlEndpointResponse
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointResponseUrlRewriterCloudinary(true),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlEndpointResponse
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointResponseUrlRewriterCloudinary(true),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDescription = "My custom URL endpoint";
        List<string> expectedOrigins = ["origin-id-1", "origin-id-2"];
        string expectedUrlPrefix = "product-images";
        UrlEndpointResponseUrlRewriter expectedUrlRewriter =
            new UrlEndpointResponseUrlRewriterCloudinary(true);

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
        var model = new UrlEndpointResponse
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointResponseUrlRewriterCloudinary(true),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UrlEndpointResponse
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
        var model = new UrlEndpointResponse
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
        var model = new UrlEndpointResponse
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
        var model = new UrlEndpointResponse
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
        var model = new UrlEndpointResponse
        {
            ID = "id",
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1", "origin-id-2"],
            UrlPrefix = "product-images",
            UrlRewriter = new UrlEndpointResponseUrlRewriterCloudinary(true),
        };

        UrlEndpointResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlEndpointResponseUrlRewriterTest : TestBase
{
    [Fact]
    public void CloudinaryValidationWorks()
    {
        UrlEndpointResponseUrlRewriter value = new UrlEndpointResponseUrlRewriterCloudinary(true);
        value.Validate();
    }

    [Fact]
    public void ImgixValidationWorks()
    {
        UrlEndpointResponseUrlRewriter value = new UrlEndpointResponseUrlRewriterImgix();
        value.Validate();
    }

    [Fact]
    public void AkamaiValidationWorks()
    {
        UrlEndpointResponseUrlRewriter value = new UrlEndpointResponseUrlRewriterAkamai();
        value.Validate();
    }

    [Fact]
    public void CloudinarySerializationRoundtripWorks()
    {
        UrlEndpointResponseUrlRewriter value = new UrlEndpointResponseUrlRewriterCloudinary(true);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImgixSerializationRoundtripWorks()
    {
        UrlEndpointResponseUrlRewriter value = new UrlEndpointResponseUrlRewriterImgix();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AkamaiSerializationRoundtripWorks()
    {
        UrlEndpointResponseUrlRewriter value = new UrlEndpointResponseUrlRewriterAkamai();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UrlEndpointResponseUrlRewriterCloudinaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlEndpointResponseUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        bool expectedPreserveAssetDeliveryTypes = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY");

        Assert.Equal(expectedPreserveAssetDeliveryTypes, model.PreserveAssetDeliveryTypes);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlEndpointResponseUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterCloudinary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlEndpointResponseUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterCloudinary>(
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
        var model = new UrlEndpointResponseUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlEndpointResponseUrlRewriterCloudinary
        {
            PreserveAssetDeliveryTypes = true,
        };

        UrlEndpointResponseUrlRewriterCloudinary copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlEndpointResponseUrlRewriterImgixTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UrlEndpointResponseUrlRewriterImgix();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterImgix>(
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
        var constant = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterImgix>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UrlEndpointResponseUrlRewriterImgix();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterImgix>(
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
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterImgix>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterImgix>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class UrlEndpointResponseUrlRewriterAkamaiTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UrlEndpointResponseUrlRewriterAkamai();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterAkamai>(
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
        var constant = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterAkamai>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImageKitInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UrlEndpointResponseUrlRewriterAkamai();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterAkamai>(
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
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterAkamai>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlEndpointResponseUrlRewriterAkamai>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}
