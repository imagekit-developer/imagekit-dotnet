using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Accounts.Origins;

namespace ImagekitDiversion.Tests.Models.Accounts.Origins;

public class OriginRequestTest : TestBase
{
    [Fact]
    public void S3ValidationWorks()
    {
        OriginRequest value = new OriginRequestS3()
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };
        value.Validate();
    }

    [Fact]
    public void S3CompatibleValidationWorks()
    {
        OriginRequest value = new OriginRequestS3Compatible()
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
        };
        value.Validate();
    }

    [Fact]
    public void CloudinaryBackupValidationWorks()
    {
        OriginRequest value = new OriginRequestCloudinaryBackup()
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };
        value.Validate();
    }

    [Fact]
    public void WebFolderValidationWorks()
    {
        OriginRequest value = new OriginRequestWebFolder()
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
        };
        value.Validate();
    }

    [Fact]
    public void WebProxyValidationWorks()
    {
        OriginRequest value = new OriginRequestWebProxy()
        {
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };
        value.Validate();
    }

    [Fact]
    public void GcsValidationWorks()
    {
        OriginRequest value = new OriginRequestGcs()
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "products",
        };
        value.Validate();
    }

    [Fact]
    public void AzureBlobValidationWorks()
    {
        OriginRequest value = new OriginRequestAzureBlob()
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "uploads",
        };
        value.Validate();
    }

    [Fact]
    public void AkeneoPimValidationWorks()
    {
        OriginRequest value = new OriginRequestAkeneoPim()
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };
        value.Validate();
    }

    [Fact]
    public void S3SerializationRoundtripWorks()
    {
        OriginRequest value = new OriginRequestS3()
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void S3CompatibleSerializationRoundtripWorks()
    {
        OriginRequest value = new OriginRequestS3Compatible()
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudinaryBackupSerializationRoundtripWorks()
    {
        OriginRequest value = new OriginRequestCloudinaryBackup()
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFolderSerializationRoundtripWorks()
    {
        OriginRequest value = new OriginRequestWebFolder()
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebProxySerializationRoundtripWorks()
    {
        OriginRequest value = new OriginRequestWebProxy()
        {
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GcsSerializationRoundtripWorks()
    {
        OriginRequest value = new OriginRequestGcs()
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "products",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AzureBlobSerializationRoundtripWorks()
    {
        OriginRequest value = new OriginRequestAzureBlob()
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "uploads",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AkeneoPimSerializationRoundtripWorks()
    {
        OriginRequest value = new OriginRequestAkeneoPim()
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequest>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OriginRequestS3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginRequestS3
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };

        string expectedAccessKey = "AKIAIOSFODNN7EXAMPLE";
        string expectedBucket = "product-images";
        string expectedName = "US S3 Storage";
        string expectedSecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
        JsonElement expectedType = JsonSerializer.SerializeToElement("S3");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedPrefix = "raw-assets";

        Assert.Equal(expectedAccessKey, model.AccessKey);
        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSecretKey, model.SecretKey);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedPrefix, model.Prefix);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginRequestS3
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestS3>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginRequestS3
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestS3>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccessKey = "AKIAIOSFODNN7EXAMPLE";
        string expectedBucket = "product-images";
        string expectedName = "US S3 Storage";
        string expectedSecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
        JsonElement expectedType = JsonSerializer.SerializeToElement("S3");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedPrefix = "raw-assets";

        Assert.Equal(expectedAccessKey, deserialized.AccessKey);
        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSecretKey, deserialized.SecretKey);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginRequestS3
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginRequestS3
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginRequestS3
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginRequestS3
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
            Prefix = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginRequestS3
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
            Prefix = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginRequestS3
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };

        OriginRequestS3 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginRequestS3CompatibleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginRequestS3Compatible
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
        };

        string expectedAccessKey = "AKIAIOSFODNN7EXAMPLE";
        string expectedBucket = "product-images";
        string expectedEndpoint = "https://s3.eu-central-1.wasabisys.com";
        string expectedName = "US S3 Storage";
        string expectedSecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
        JsonElement expectedType = JsonSerializer.SerializeToElement("S3_COMPATIBLE");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedPrefix = "raw-assets";
        bool expectedS3ForcePathStyle = true;

        Assert.Equal(expectedAccessKey, model.AccessKey);
        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedEndpoint, model.Endpoint);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSecretKey, model.SecretKey);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.Equal(expectedS3ForcePathStyle, model.S3ForcePathStyle);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginRequestS3Compatible
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestS3Compatible>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginRequestS3Compatible
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestS3Compatible>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccessKey = "AKIAIOSFODNN7EXAMPLE";
        string expectedBucket = "product-images";
        string expectedEndpoint = "https://s3.eu-central-1.wasabisys.com";
        string expectedName = "US S3 Storage";
        string expectedSecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
        JsonElement expectedType = JsonSerializer.SerializeToElement("S3_COMPATIBLE");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedPrefix = "raw-assets";
        bool expectedS3ForcePathStyle = true;

        Assert.Equal(expectedAccessKey, deserialized.AccessKey);
        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedEndpoint, deserialized.Endpoint);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSecretKey, deserialized.SecretKey);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.Equal(expectedS3ForcePathStyle, deserialized.S3ForcePathStyle);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginRequestS3Compatible
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginRequestS3Compatible
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
        Assert.Null(model.S3ForcePathStyle);
        Assert.False(model.RawData.ContainsKey("s3ForcePathStyle"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginRequestS3Compatible
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginRequestS3Compatible
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
            Prefix = null,
            S3ForcePathStyle = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
        Assert.Null(model.S3ForcePathStyle);
        Assert.False(model.RawData.ContainsKey("s3ForcePathStyle"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginRequestS3Compatible
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
            Prefix = null,
            S3ForcePathStyle = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginRequestS3Compatible
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
        };

        OriginRequestS3Compatible copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginRequestCloudinaryBackupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginRequestCloudinaryBackup
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };

        string expectedAccessKey = "AKIAIOSFODNN7EXAMPLE";
        string expectedBucket = "product-images";
        string expectedName = "US S3 Storage";
        string expectedSecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedPrefix = "raw-assets";

        Assert.Equal(expectedAccessKey, model.AccessKey);
        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSecretKey, model.SecretKey);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedPrefix, model.Prefix);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginRequestCloudinaryBackup
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestCloudinaryBackup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginRequestCloudinaryBackup
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestCloudinaryBackup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccessKey = "AKIAIOSFODNN7EXAMPLE";
        string expectedBucket = "product-images";
        string expectedName = "US S3 Storage";
        string expectedSecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedPrefix = "raw-assets";

        Assert.Equal(expectedAccessKey, deserialized.AccessKey);
        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSecretKey, deserialized.SecretKey);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginRequestCloudinaryBackup
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginRequestCloudinaryBackup
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginRequestCloudinaryBackup
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginRequestCloudinaryBackup
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
            Prefix = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginRequestCloudinaryBackup
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
            Prefix = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginRequestCloudinaryBackup
        {
            AccessKey = "AKIAIOSFODNN7EXAMPLE",
            Bucket = "product-images",
            Name = "US S3 Storage",
            SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "raw-assets",
        };

        OriginRequestCloudinaryBackup copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginRequestWebFolderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginRequestWebFolder
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
        };

        string expectedBaseUrl = "https://images.example.com/assets";
        string expectedName = "US S3 Storage";
        JsonElement expectedType = JsonSerializer.SerializeToElement("WEB_FOLDER");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedForwardHostHeaderToOrigin = false;
        bool expectedIncludeCanonicalHeader = false;

        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedForwardHostHeaderToOrigin, model.ForwardHostHeaderToOrigin);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginRequestWebFolder
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestWebFolder>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginRequestWebFolder
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestWebFolder>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBaseUrl = "https://images.example.com/assets";
        string expectedName = "US S3 Storage";
        JsonElement expectedType = JsonSerializer.SerializeToElement("WEB_FOLDER");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedForwardHostHeaderToOrigin = false;
        bool expectedIncludeCanonicalHeader = false;

        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedForwardHostHeaderToOrigin, deserialized.ForwardHostHeaderToOrigin);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginRequestWebFolder
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginRequestWebFolder
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.ForwardHostHeaderToOrigin);
        Assert.False(model.RawData.ContainsKey("forwardHostHeaderToOrigin"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginRequestWebFolder
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginRequestWebFolder
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            ForwardHostHeaderToOrigin = null,
            IncludeCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.ForwardHostHeaderToOrigin);
        Assert.False(model.RawData.ContainsKey("forwardHostHeaderToOrigin"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginRequestWebFolder
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            ForwardHostHeaderToOrigin = null,
            IncludeCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginRequestWebFolder
        {
            BaseUrl = "https://images.example.com/assets",
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
        };

        OriginRequestWebFolder copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginRequestWebProxyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginRequestWebProxy
        {
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };

        string expectedName = "US S3 Storage";
        JsonElement expectedType = JsonSerializer.SerializeToElement("WEB_PROXY");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;

        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginRequestWebProxy
        {
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestWebProxy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginRequestWebProxy
        {
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestWebProxy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "US S3 Storage";
        JsonElement expectedType = JsonSerializer.SerializeToElement("WEB_PROXY");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginRequestWebProxy
        {
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginRequestWebProxy { Name = "US S3 Storage" };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginRequestWebProxy { Name = "US S3 Storage" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginRequestWebProxy
        {
            Name = "US S3 Storage",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginRequestWebProxy
        {
            Name = "US S3 Storage",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginRequestWebProxy
        {
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };

        OriginRequestWebProxy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginRequestGcsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginRequestGcs
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "products",
        };

        string expectedBucket = "gcs-media";
        string expectedClientEmail = "service-account@project.iam.gserviceaccount.com";
        string expectedName = "US S3 Storage";
        string expectedPrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...";
        JsonElement expectedType = JsonSerializer.SerializeToElement("GCS");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedPrefix = "products";

        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedClientEmail, model.ClientEmail);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrivateKey, model.PrivateKey);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedPrefix, model.Prefix);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginRequestGcs
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "products",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestGcs>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginRequestGcs
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "products",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestGcs>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBucket = "gcs-media";
        string expectedClientEmail = "service-account@project.iam.gserviceaccount.com";
        string expectedName = "US S3 Storage";
        string expectedPrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...";
        JsonElement expectedType = JsonSerializer.SerializeToElement("GCS");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedPrefix = "products";

        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedClientEmail, deserialized.ClientEmail);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrivateKey, deserialized.PrivateKey);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginRequestGcs
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "products",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginRequestGcs
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginRequestGcs
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginRequestGcs
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
            Prefix = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginRequestGcs
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
            Prefix = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginRequestGcs
        {
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            Name = "US S3 Storage",
            PrivateKey = "-----BEGIN PRIVATE KEY-----\\nMIIEv...",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "products",
        };

        OriginRequestGcs copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginRequestAzureBlobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginRequestAzureBlob
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "uploads",
        };

        string expectedAccountName = "account123";
        string expectedContainer = "images";
        string expectedName = "US S3 Storage";
        string expectedSasToken = "?sv=2023-01-03&sr=c&sig=abc123";
        JsonElement expectedType = JsonSerializer.SerializeToElement("AZURE_BLOB");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedPrefix = "uploads";

        Assert.Equal(expectedAccountName, model.AccountName);
        Assert.Equal(expectedContainer, model.Container);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSasToken, model.SasToken);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedPrefix, model.Prefix);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginRequestAzureBlob
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "uploads",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestAzureBlob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginRequestAzureBlob
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "uploads",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestAzureBlob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountName = "account123";
        string expectedContainer = "images";
        string expectedName = "US S3 Storage";
        string expectedSasToken = "?sv=2023-01-03&sr=c&sig=abc123";
        JsonElement expectedType = JsonSerializer.SerializeToElement("AZURE_BLOB");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedPrefix = "uploads";

        Assert.Equal(expectedAccountName, deserialized.AccountName);
        Assert.Equal(expectedContainer, deserialized.Container);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSasToken, deserialized.SasToken);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginRequestAzureBlob
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "uploads",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginRequestAzureBlob
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginRequestAzureBlob
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginRequestAzureBlob
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
            Prefix = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginRequestAzureBlob
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
            Prefix = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginRequestAzureBlob
        {
            AccountName = "account123",
            Container = "images",
            Name = "US S3 Storage",
            SasToken = "?sv=2023-01-03&sr=c&sig=abc123",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
            Prefix = "uploads",
        };

        OriginRequestAzureBlob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginRequestAkeneoPimTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginRequestAkeneoPim
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };

        string expectedBaseUrl = "https://akeneo.company.com";
        string expectedClientID = "akeneo-client-id";
        string expectedClientSecret = "akeneo-client-secret";
        string expectedName = "US S3 Storage";
        string expectedPassword = "strongpassword123";
        JsonElement expectedType = JsonSerializer.SerializeToElement("AKENEO_PIM");
        string expectedUsername = "integration-user";
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;

        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPassword, model.Password);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUsername, model.Username);
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginRequestAkeneoPim
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestAkeneoPim>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginRequestAkeneoPim
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginRequestAkeneoPim>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBaseUrl = "https://akeneo.company.com";
        string expectedClientID = "akeneo-client-id";
        string expectedClientSecret = "akeneo-client-secret";
        string expectedName = "US S3 Storage";
        string expectedPassword = "strongpassword123";
        JsonElement expectedType = JsonSerializer.SerializeToElement("AKENEO_PIM");
        string expectedUsername = "integration-user";
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedIncludeCanonicalHeader = false;

        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPassword, deserialized.Password);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUsername, deserialized.Username);
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginRequestAkeneoPim
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginRequestAkeneoPim
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginRequestAkeneoPim
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginRequestAkeneoPim
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.IncludeCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("includeCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginRequestAkeneoPim
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            IncludeCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginRequestAkeneoPim
        {
            BaseUrl = "https://akeneo.company.com",
            ClientID = "akeneo-client-id",
            ClientSecret = "akeneo-client-secret",
            Name = "US S3 Storage",
            Password = "strongpassword123",
            Username = "integration-user",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            IncludeCanonicalHeader = false,
        };

        OriginRequestAkeneoPim copied = new(model);

        Assert.Equal(model, copied);
    }
}
