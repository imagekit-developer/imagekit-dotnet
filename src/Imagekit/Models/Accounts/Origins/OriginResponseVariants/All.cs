using OriginResponseProperties = Imagekit.Models.Accounts.Origins.OriginResponseProperties;

namespace Imagekit.Models.Accounts.Origins.OriginResponseVariants;

public sealed record class S3(OriginResponseProperties::S3 Value)
    : OriginResponse,
        IVariant<S3, OriginResponseProperties::S3>
{
    public static S3 From(OriginResponseProperties::S3 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class S3Compatible(OriginResponseProperties::S3Compatible Value)
    : OriginResponse,
        IVariant<S3Compatible, OriginResponseProperties::S3Compatible>
{
    public static S3Compatible From(OriginResponseProperties::S3Compatible value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CloudinaryBackup(OriginResponseProperties::CloudinaryBackup Value)
    : OriginResponse,
        IVariant<CloudinaryBackup, OriginResponseProperties::CloudinaryBackup>
{
    public static CloudinaryBackup From(OriginResponseProperties::CloudinaryBackup value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebFolder(OriginResponseProperties::WebFolder Value)
    : OriginResponse,
        IVariant<WebFolder, OriginResponseProperties::WebFolder>
{
    public static WebFolder From(OriginResponseProperties::WebFolder value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebProxy(OriginResponseProperties::WebProxy Value)
    : OriginResponse,
        IVariant<WebProxy, OriginResponseProperties::WebProxy>
{
    public static WebProxy From(OriginResponseProperties::WebProxy value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Gcs(OriginResponseProperties::Gcs Value)
    : OriginResponse,
        IVariant<Gcs, OriginResponseProperties::Gcs>
{
    public static Gcs From(OriginResponseProperties::Gcs value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AzureBlob(OriginResponseProperties::AzureBlob Value)
    : OriginResponse,
        IVariant<AzureBlob, OriginResponseProperties::AzureBlob>
{
    public static AzureBlob From(OriginResponseProperties::AzureBlob value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AkeneoPim(OriginResponseProperties::AkeneoPim Value)
    : OriginResponse,
        IVariant<AkeneoPim, OriginResponseProperties::AkeneoPim>
{
    public static AkeneoPim From(OriginResponseProperties::AkeneoPim value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
