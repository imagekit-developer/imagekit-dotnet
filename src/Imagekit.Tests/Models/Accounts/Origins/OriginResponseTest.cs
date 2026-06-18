using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Accounts.Origins;

namespace Imagekit.Tests.Models.Accounts.Origins;

public class OriginResponseTest : TestBase
{
    [Fact]
    public void S3ValidationWorks()
    {
        OriginResponse value = new OriginResponseS3()
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };
        value.Validate();
    }

    [Fact]
    public void S3CompatibleValidationWorks()
    {
        OriginResponse value = new OriginResponseS3Compatible()
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        value.Validate();
    }

    [Fact]
    public void CloudinaryBackupValidationWorks()
    {
        OriginResponse value = new OriginResponseCloudinaryBackup()
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };
        value.Validate();
    }

    [Fact]
    public void WebFolderValidationWorks()
    {
        OriginResponse value = new OriginResponseWebFolder()
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        value.Validate();
    }

    [Fact]
    public void WebProxyValidationWorks()
    {
        OriginResponse value = new OriginResponseWebProxy()
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        value.Validate();
    }

    [Fact]
    public void GcsValidationWorks()
    {
        OriginResponse value = new OriginResponseGcs()
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        value.Validate();
    }

    [Fact]
    public void AzureBlobValidationWorks()
    {
        OriginResponse value = new OriginResponseAzureBlob()
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        value.Validate();
    }

    [Fact]
    public void AkeneoPimValidationWorks()
    {
        OriginResponse value = new OriginResponseAkeneoPim()
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        value.Validate();
    }

    [Fact]
    public void S3SerializationRoundtripWorks()
    {
        OriginResponse value = new OriginResponseS3()
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void S3CompatibleSerializationRoundtripWorks()
    {
        OriginResponse value = new OriginResponseS3Compatible()
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudinaryBackupSerializationRoundtripWorks()
    {
        OriginResponse value = new OriginResponseCloudinaryBackup()
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFolderSerializationRoundtripWorks()
    {
        OriginResponse value = new OriginResponseWebFolder()
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebProxySerializationRoundtripWorks()
    {
        OriginResponse value = new OriginResponseWebProxy()
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GcsSerializationRoundtripWorks()
    {
        OriginResponse value = new OriginResponseGcs()
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AzureBlobSerializationRoundtripWorks()
    {
        OriginResponse value = new OriginResponseAzureBlob()
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AkeneoPimSerializationRoundtripWorks()
    {
        OriginResponse value = new OriginResponseAkeneoPim()
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OriginResponseS3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginResponseS3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };

        string expectedID = "id";
        string expectedBucket = "product-images";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "raw-assets";
        JsonElement expectedType = JsonSerializer.SerializeToElement("S3");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedUseIamRole = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedUseIamRole, model.UseIamRole);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginResponseS3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseS3>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginResponseS3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseS3>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBucket = "product-images";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "raw-assets";
        JsonElement expectedType = JsonSerializer.SerializeToElement("S3");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedUseIamRole = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedUseIamRole, deserialized.UseIamRole);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginResponseS3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginResponseS3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.UseIamRole);
        Assert.False(model.RawData.ContainsKey("useIAMRole"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginResponseS3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginResponseS3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            UseIamRole = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.UseIamRole);
        Assert.False(model.RawData.ContainsKey("useIAMRole"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginResponseS3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            UseIamRole = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginResponseS3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };

        OriginResponseS3 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginResponseS3CompatibleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginResponseS3Compatible
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string expectedID = "id";
        string expectedBucket = "product-images";
        string expectedEndpoint = "https://s3.eu-central-1.wasabisys.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "raw-assets";
        bool expectedS3ForcePathStyle = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("S3_COMPATIBLE");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedEndpoint, model.Endpoint);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.Equal(expectedS3ForcePathStyle, model.S3ForcePathStyle);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginResponseS3Compatible
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseS3Compatible>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginResponseS3Compatible
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseS3Compatible>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBucket = "product-images";
        string expectedEndpoint = "https://s3.eu-central-1.wasabisys.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "raw-assets";
        bool expectedS3ForcePathStyle = true;
        JsonElement expectedType = JsonSerializer.SerializeToElement("S3_COMPATIBLE");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedEndpoint, deserialized.Endpoint);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.Equal(expectedS3ForcePathStyle, deserialized.S3ForcePathStyle);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginResponseS3Compatible
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginResponseS3Compatible
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginResponseS3Compatible
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginResponseS3Compatible
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginResponseS3Compatible
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginResponseS3Compatible
        {
            ID = "id",
            Bucket = "product-images",
            Endpoint = "https://s3.eu-central-1.wasabisys.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            S3ForcePathStyle = true,
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        OriginResponseS3Compatible copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginResponseCloudinaryBackupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginResponseCloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };

        string expectedID = "id";
        string expectedBucket = "product-images";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "raw-assets";
        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedUseIamRole = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedUseIamRole, model.UseIamRole);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginResponseCloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseCloudinaryBackup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginResponseCloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseCloudinaryBackup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBucket = "product-images";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "raw-assets";
        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";
        bool expectedUseIamRole = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
        Assert.Equal(expectedUseIamRole, deserialized.UseIamRole);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginResponseCloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginResponseCloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.UseIamRole);
        Assert.False(model.RawData.ContainsKey("useIAMRole"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginResponseCloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginResponseCloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            UseIamRole = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
        Assert.Null(model.UseIamRole);
        Assert.False(model.RawData.ContainsKey("useIAMRole"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginResponseCloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
            UseIamRole = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginResponseCloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
            UseIamRole = true,
        };

        OriginResponseCloudinaryBackup copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginResponseWebFolderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginResponseWebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string expectedID = "id";
        string expectedBaseUrl = "https://images.example.com/assets";
        bool expectedForwardHostHeaderToOrigin = false;
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        JsonElement expectedType = JsonSerializer.SerializeToElement("WEB_FOLDER");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.Equal(expectedForwardHostHeaderToOrigin, model.ForwardHostHeaderToOrigin);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginResponseWebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseWebFolder>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginResponseWebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseWebFolder>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBaseUrl = "https://images.example.com/assets";
        bool expectedForwardHostHeaderToOrigin = false;
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        JsonElement expectedType = JsonSerializer.SerializeToElement("WEB_FOLDER");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.Equal(expectedForwardHostHeaderToOrigin, deserialized.ForwardHostHeaderToOrigin);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginResponseWebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginResponseWebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginResponseWebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginResponseWebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginResponseWebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginResponseWebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        OriginResponseWebFolder copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginResponseWebProxyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginResponseWebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string expectedID = "id";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        JsonElement expectedType = JsonSerializer.SerializeToElement("WEB_PROXY");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginResponseWebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseWebProxy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginResponseWebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseWebProxy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        JsonElement expectedType = JsonSerializer.SerializeToElement("WEB_PROXY");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginResponseWebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginResponseWebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginResponseWebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginResponseWebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginResponseWebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginResponseWebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        OriginResponseWebProxy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginResponseGcsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginResponseGcs
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string expectedID = "id";
        string expectedBucket = "gcs-media";
        string expectedClientEmail = "service-account@project.iam.gserviceaccount.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "products";
        JsonElement expectedType = JsonSerializer.SerializeToElement("GCS");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedClientEmail, model.ClientEmail);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginResponseGcs
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseGcs>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginResponseGcs
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseGcs>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBucket = "gcs-media";
        string expectedClientEmail = "service-account@project.iam.gserviceaccount.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "products";
        JsonElement expectedType = JsonSerializer.SerializeToElement("GCS");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedClientEmail, deserialized.ClientEmail);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginResponseGcs
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginResponseGcs
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginResponseGcs
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginResponseGcs
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginResponseGcs
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginResponseGcs
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        OriginResponseGcs copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginResponseAzureBlobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginResponseAzureBlob
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string expectedID = "id";
        string expectedAccountName = "account123";
        string expectedContainer = "images";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "uploads";
        JsonElement expectedType = JsonSerializer.SerializeToElement("AZURE_BLOB");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountName, model.AccountName);
        Assert.Equal(expectedContainer, model.Container);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginResponseAzureBlob
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseAzureBlob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginResponseAzureBlob
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseAzureBlob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAccountName = "account123";
        string expectedContainer = "images";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "uploads";
        JsonElement expectedType = JsonSerializer.SerializeToElement("AZURE_BLOB");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountName, deserialized.AccountName);
        Assert.Equal(expectedContainer, deserialized.Container);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginResponseAzureBlob
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginResponseAzureBlob
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginResponseAzureBlob
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginResponseAzureBlob
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginResponseAzureBlob
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginResponseAzureBlob
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        OriginResponseAzureBlob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginResponseAkeneoPimTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OriginResponseAkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string expectedID = "id";
        string expectedBaseUrl = "https://akeneo.company.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        JsonElement expectedType = JsonSerializer.SerializeToElement("AKENEO_PIM");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBaseUrl, model.BaseUrl);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OriginResponseAkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseAkeneoPim>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OriginResponseAkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OriginResponseAkeneoPim>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBaseUrl = "https://akeneo.company.com";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        JsonElement expectedType = JsonSerializer.SerializeToElement("AKENEO_PIM");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBaseUrl, deserialized.BaseUrl);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OriginResponseAkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OriginResponseAkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OriginResponseAkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OriginResponseAkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OriginResponseAkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OriginResponseAkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        OriginResponseAkeneoPim copied = new(model);

        Assert.Equal(model, copied);
    }
}
