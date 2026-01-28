using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Imagekit.Models.Files.FileUploadParamsProperties;

namespace Imagekit.Models.Files;

/// <summary>
/// ImageKit.io allows you to upload files directly from both the server and client
/// sides. For server-side uploads, private API key authentication is used. For client-side
/// uploads, generate a one-time `token`, `signature`, and `expire` from your secure
/// backend using private API. [Learn more](/docs/api-reference/upload-file/upload-file#how-to-implement-client-side-file-upload)
/// about how to implement client-side file upload.
///
/// The [V2 API](/docs/api-reference/upload-file/upload-file-v2) enhances security
/// by verifying the entire payload using JWT.
///
/// **File size limit** \ On the free plan, the maximum upload file sizes are 20MB
/// for images, audio, and raw files and 100MB for videos. On the paid plan, these
/// limits increase to 40MB for images, audio, and raw files and 2GB for videos. These
/// limits can be further increased with higher-tier plans.
///
/// **Version limit** \ A file can have a maximum of 100 versions.
///
/// **Demo applications**
///
/// - A full-fledged [upload widget using Uppy](https://github.com/imagekit-samples/uppy-uploader),
/// supporting file selections from local storage, URL, Dropbox, Google Drive, Instagram,
/// and more. - [Quick start guides](/docs/quick-start-guides) for various frameworks
/// and technologies.
/// </summary>
public sealed record class FileUploadParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public Body? Body
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("body", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Body?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/api/v1/files/upload")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IImageKitClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
