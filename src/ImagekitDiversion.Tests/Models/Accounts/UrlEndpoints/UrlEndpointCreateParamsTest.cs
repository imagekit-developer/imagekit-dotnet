using System;
using System.Collections.Generic;
using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Accounts.UrlEndpoints;

namespace ImagekitDiversion.Tests.Models.Accounts.UrlEndpoints;

public class UrlEndpointCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UrlEndpointCreateParams
        {
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1"],
            UrlPrefix = "product-images",
            UrlRewriter = new Cloudinary() { PreserveAssetDeliveryTypes = true },
        };

        string expectedDescription = "My custom URL endpoint";
        List<string> expectedOrigins = ["origin-id-1"];
        string expectedUrlPrefix = "product-images";
        UrlRewriter expectedUrlRewriter = new Cloudinary() { PreserveAssetDeliveryTypes = true };

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
        var parameters = new UrlEndpointCreateParams { Description = "My custom URL endpoint" };

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
        var parameters = new UrlEndpointCreateParams
        {
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
        UrlEndpointCreateParams parameters = new() { Description = "My custom URL endpoint" };

        var url = parameters.Url(new() { Username = "My Username", Password = "My Password" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.imagekit.io/v1/accounts/url-endpoints"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UrlEndpointCreateParams
        {
            Description = "My custom URL endpoint",
            Origins = ["origin-id-1"],
            UrlPrefix = "product-images",
            UrlRewriter = new Cloudinary() { PreserveAssetDeliveryTypes = true },
        };

        UrlEndpointCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UrlRewriterTest : TestBase
{
    [Fact]
    public void CloudinaryValidationWorks()
    {
        UrlRewriter value = new Cloudinary() { PreserveAssetDeliveryTypes = true };
        value.Validate();
    }

    [Fact]
    public void ImgixValidationWorks()
    {
        UrlRewriter value = new Imgix();
        value.Validate();
    }

    [Fact]
    public void AkamaiValidationWorks()
    {
        UrlRewriter value = new Akamai();
        value.Validate();
    }

    [Fact]
    public void CloudinarySerializationRoundtripWorks()
    {
        UrlRewriter value = new Cloudinary() { PreserveAssetDeliveryTypes = true };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImgixSerializationRoundtripWorks()
    {
        UrlRewriter value = new Imgix();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AkamaiSerializationRoundtripWorks()
    {
        UrlRewriter value = new Akamai();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlRewriter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CloudinaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cloudinary { PreserveAssetDeliveryTypes = true };

        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY");
        bool expectedPreserveAssetDeliveryTypes = true;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedPreserveAssetDeliveryTypes, model.PreserveAssetDeliveryTypes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cloudinary { PreserveAssetDeliveryTypes = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cloudinary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cloudinary { PreserveAssetDeliveryTypes = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cloudinary>(
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
        var model = new Cloudinary { PreserveAssetDeliveryTypes = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Cloudinary { };

        Assert.Null(model.PreserveAssetDeliveryTypes);
        Assert.False(model.RawData.ContainsKey("preserveAssetDeliveryTypes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Cloudinary { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Cloudinary
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
        var model = new Cloudinary
        {
            // Null should be interpreted as omitted for these properties
            PreserveAssetDeliveryTypes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cloudinary { PreserveAssetDeliveryTypes = true };

        Cloudinary copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImgixTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new Imgix();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<Imgix>(
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
        var constant = JsonSerializer.Deserialize<Imgix>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new Imgix();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Imgix>(element, ModelBase.SerializerOptions);

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Imgix>(
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
        var deserialized = JsonSerializer.Deserialize<Imgix>(element, ModelBase.SerializerOptions);

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Imgix>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Imgix>(element, ModelBase.SerializerOptions);

        Assert.Equal(constant, deserialized);
    }
}

public class AkamaiTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new Akamai();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<Akamai>(
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
        var constant = JsonSerializer.Deserialize<Akamai>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<ImagekitDiversionInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new Akamai();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Akamai>(element, ModelBase.SerializerOptions);

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Akamai>(
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
        var deserialized = JsonSerializer.Deserialize<Akamai>(element, ModelBase.SerializerOptions);

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<Akamai>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Akamai>(element, ModelBase.SerializerOptions);

        Assert.Equal(constant, deserialized);
    }
}
