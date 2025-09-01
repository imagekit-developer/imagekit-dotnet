using OriginRequestProperties = Imagekit.Models.Accounts.Origins.OriginRequestProperties;

namespace Imagekit.Models.Accounts.Origins.OriginRequestVariants;

public sealed record class S3(OriginRequestProperties::S3 Value)
    : OriginRequest,
        IVariant<S3, OriginRequestProperties::S3>
{
    public static S3 From(OriginRequestProperties::S3 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class S3Compatible(OriginRequestProperties::S3Compatible Value)
    : OriginRequest,
        IVariant<S3Compatible, OriginRequestProperties::S3Compatible>
{
    public static S3Compatible From(OriginRequestProperties::S3Compatible value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CloudinaryBackup(OriginRequestProperties::CloudinaryBackup Value)
    : OriginRequest,
        IVariant<CloudinaryBackup, OriginRequestProperties::CloudinaryBackup>
{
    public static CloudinaryBackup From(OriginRequestProperties::CloudinaryBackup value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebFolder(OriginRequestProperties::WebFolder Value)
    : OriginRequest,
        IVariant<WebFolder, OriginRequestProperties::WebFolder>
{
    public static WebFolder From(OriginRequestProperties::WebFolder value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebProxy(OriginRequestProperties::WebProxy Value)
    : OriginRequest,
        IVariant<WebProxy, OriginRequestProperties::WebProxy>
{
    public static WebProxy From(OriginRequestProperties::WebProxy value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class Gcs(OriginRequestProperties::Gcs Value)
    : OriginRequest,
        IVariant<Gcs, OriginRequestProperties::Gcs>
{
    public static Gcs From(OriginRequestProperties::Gcs value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AzureBlob(OriginRequestProperties::AzureBlob Value)
    : OriginRequest,
        IVariant<AzureBlob, OriginRequestProperties::AzureBlob>
{
    public static AzureBlob From(OriginRequestProperties::AzureBlob value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AkeneoPim(OriginRequestProperties::AkeneoPim Value)
    : OriginRequest,
        IVariant<AkeneoPim, OriginRequestProperties::AkeneoPim>
{
    public static AkeneoPim From(OriginRequestProperties::AkeneoPim value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
