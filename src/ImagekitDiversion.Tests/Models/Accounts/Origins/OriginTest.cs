using System.Text.Json;
using ImagekitDiversion.Core;
using ImagekitDiversion.Models.Accounts.Origins;

namespace ImagekitDiversion.Tests.Models.Accounts.Origins;

public class OriginTest : TestBase
{
    [Fact]
    public void S3ValidationWorks()
    {
        Origin value = new S3()
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        value.Validate();
    }

    [Fact]
    public void S3CompatibleValidationWorks()
    {
        Origin value = new S3Compatible()
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
        Origin value = new CloudinaryBackup()
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        value.Validate();
    }

    [Fact]
    public void WebFolderValidationWorks()
    {
        Origin value = new WebFolder()
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
        Origin value = new WebProxy()
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
        Origin value = new Gcs()
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
        Origin value = new AzureBlob()
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
        Origin value = new AkeneoPim()
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
        Origin value = new S3()
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Origin>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void S3CompatibleSerializationRoundtripWorks()
    {
        Origin value = new S3Compatible()
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
        var deserialized = JsonSerializer.Deserialize<Origin>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudinaryBackupSerializationRoundtripWorks()
    {
        Origin value = new CloudinaryBackup()
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Origin>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFolderSerializationRoundtripWorks()
    {
        Origin value = new WebFolder()
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Origin>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebProxySerializationRoundtripWorks()
    {
        Origin value = new WebProxy()
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Origin>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GcsSerializationRoundtripWorks()
    {
        Origin value = new Gcs()
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
        var deserialized = JsonSerializer.Deserialize<Origin>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AzureBlobSerializationRoundtripWorks()
    {
        Origin value = new AzureBlob()
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
        var deserialized = JsonSerializer.Deserialize<Origin>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AkeneoPimSerializationRoundtripWorks()
    {
        Origin value = new AkeneoPim()
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Origin>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class S3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new S3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string expectedID = "id";
        string expectedBucket = "product-images";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "raw-assets";
        JsonElement expectedType = JsonSerializer.SerializeToElement("S3");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new S3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<S3>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new S3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<S3>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBucket = "product-images";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "raw-assets";
        JsonElement expectedType = JsonSerializer.SerializeToElement("S3");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new S3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new S3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new S3
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
        var model = new S3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new S3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new S3
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        S3 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class S3CompatibleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new S3Compatible
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
        var model = new S3Compatible
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
        var deserialized = JsonSerializer.Deserialize<S3Compatible>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new S3Compatible
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
        var deserialized = JsonSerializer.Deserialize<S3Compatible>(
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
        var model = new S3Compatible
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
        var model = new S3Compatible
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
        var model = new S3Compatible
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
        var model = new S3Compatible
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
        var model = new S3Compatible
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
        var model = new S3Compatible
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

        S3Compatible copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CloudinaryBackupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string expectedID = "id";
        string expectedBucket = "product-images";
        bool expectedIncludeCanonicalHeader = false;
        string expectedName = "US S3 Storage";
        string expectedPrefix = "raw-assets";
        JsonElement expectedType = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
        string expectedBaseUrlForCanonicalHeader = "https://cdn.example.com";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBucket, model.Bucket);
        Assert.Equal(expectedIncludeCanonicalHeader, model.IncludeCanonicalHeader);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, model.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudinaryBackup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudinaryBackup>(
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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBucket, deserialized.Bucket);
        Assert.Equal(expectedIncludeCanonicalHeader, deserialized.IncludeCanonicalHeader);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedBaseUrlForCanonicalHeader, deserialized.BaseUrlForCanonicalHeader);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudinaryBackup
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
        var model = new CloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        Assert.Null(model.BaseUrlForCanonicalHeader);
        Assert.False(model.RawData.ContainsKey("baseUrlForCanonicalHeader"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",

            // Null should be interpreted as omitted for these properties
            BaseUrlForCanonicalHeader = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudinaryBackup
        {
            ID = "id",
            Bucket = "product-images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "raw-assets",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        CloudinaryBackup copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebFolderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFolder
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
        var model = new WebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFolder>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFolder>(
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
        var model = new WebFolder
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
        var model = new WebFolder
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
        var model = new WebFolder
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
        var model = new WebFolder
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
        var model = new WebFolder
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
        var model = new WebFolder
        {
            ID = "id",
            BaseUrl = "https://images.example.com/assets",
            ForwardHostHeaderToOrigin = false,
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        WebFolder copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebProxyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebProxy
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
        var model = new WebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebProxy>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebProxy>(
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
        var model = new WebProxy
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
        var model = new WebProxy
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
        var model = new WebProxy
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
        var model = new WebProxy
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
        var model = new WebProxy
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
        var model = new WebProxy
        {
            ID = "id",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        WebProxy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GcsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Gcs
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
        var model = new Gcs
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
        var deserialized = JsonSerializer.Deserialize<Gcs>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Gcs
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
        var deserialized = JsonSerializer.Deserialize<Gcs>(element, ModelBase.SerializerOptions);
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
        var model = new Gcs
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
        var model = new Gcs
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
        var model = new Gcs
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
        var model = new Gcs
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
        var model = new Gcs
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
        var model = new Gcs
        {
            ID = "id",
            Bucket = "gcs-media",
            ClientEmail = "service-account@project.iam.gserviceaccount.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "products",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        Gcs copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AzureBlobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AzureBlob
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
        var model = new AzureBlob
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
        var deserialized = JsonSerializer.Deserialize<AzureBlob>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AzureBlob
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
        var deserialized = JsonSerializer.Deserialize<AzureBlob>(
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
        var model = new AzureBlob
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
        var model = new AzureBlob
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
        var model = new AzureBlob
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
        var model = new AzureBlob
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
        var model = new AzureBlob
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
        var model = new AzureBlob
        {
            ID = "id",
            AccountName = "account123",
            Container = "images",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            Prefix = "uploads",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        AzureBlob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AkeneoPimTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AkeneoPim
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
        var model = new AkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AkeneoPim>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AkeneoPim>(
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
        var model = new AkeneoPim
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
        var model = new AkeneoPim
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
        var model = new AkeneoPim
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
        var model = new AkeneoPim
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
        var model = new AkeneoPim
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
        var model = new AkeneoPim
        {
            ID = "id",
            BaseUrl = "https://akeneo.company.com",
            IncludeCanonicalHeader = false,
            Name = "US S3 Storage",
            BaseUrlForCanonicalHeader = "https://cdn.example.com",
        };

        AkeneoPim copied = new(model);

        Assert.Equal(model, copied);
    }
}
