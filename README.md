# ImageKit.io C# SDK

The ImageKit C# SDK is a comprehensive library designed to simplify the integration of ImageKit into your server-side applications. It provides powerful tools for working with the [ImageKit REST API](https://imagekit.io/docs/api-reference), including building and transforming URLs, generating signed URLs for secure content delivery, and handling file uploads.

For additional details, refer to the [ImageKit REST API documentation](https://imagekit.io/docs/api-reference).

## Table of Contents

- [Installation](#installation)
- [Requirements](#requirements)
- [Usage](#usage)
- [Client configuration](#client-configuration)
- [Requests and responses](#requests-and-responses)
- [Raw responses](#raw-responses)
- [URL generation](#url-generation)
  - [Basic URL generation](#basic-url-generation)
  - [URL generation with transformations](#url-generation-with-transformations)
  - [URL generation with image overlay](#url-generation-with-image-overlay)
  - [URL generation with text overlay](#url-generation-with-text-overlay)
  - [URL generation with multiple overlays](#url-generation-with-multiple-overlays)
  - [Signed URLs for secure delivery](#signed-urls-for-secure-delivery)
  - [Using Raw transformations for undocumented features](#using-raw-transformations-for-undocumented-features)
- [Authentication parameters for client-side uploads](#authentication-parameters-for-client-side-uploads)
- [Webhook verification](#webhook-verification)
- [Error handling](#error-handling)
- [Network options](#network-options)
  - [Retries](#retries)
  - [Timeouts](#timeouts)
  - [Proxies](#proxies)
- [Undocumented API functionality](#undocumented-api-functionality)
- [Semantic versioning](#semantic-versioning)

## Installation

Install the package from [NuGet](https://www.nuget.org/packages/Imagekit):

```bash
dotnet add package Imagekit
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

```csharp
using System;
using Imagekit;
using Imagekit.Models.Files;

ImageKitClient client = new()
{
    PrivateKey = "private_key_xxx",
};

FileUploadParams parameters = new()
{
    File = new System.IO.FileStream("/path/to/your/image.jpg", System.IO.FileMode.Open),
    FileName = "uploaded-image.jpg",
};

var response = await client.Files.Upload(parameters);

Console.WriteLine(response);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Imagekit;

// Configured using the IMAGEKIT_PRIVATE_KEY, IMAGEKIT_WEBHOOK_SECRET and IMAGE_KIT_BASE_URL environment variables
ImageKitClient client = new();
```

Or manually:

```csharp
using Imagekit;

ImageKitClient client = new()
{
    PrivateKey = "My Private Key",
};
```

Or using a combination of the two approaches.

See this table for the available options:

| Property        | Environment variable             | Required | Default value               |
| --------------- | -------------------------------- | -------- | --------------------------- |
| `PrivateKey`    | `IMAGEKIT_PRIVATE_KEY`           | true     | -                           |
| `WebhookSecret` | `IMAGEKIT_WEBHOOK_SECRET`        | false    | -                           |
| `BaseUrl`       | `IMAGE_KIT_BASE_URL`             | true     | `"https://api.imagekit.io"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .Files.Upload(parameters);

Console.WriteLine(response);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Image Kit API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Files.Upload` should be called with an instance of `FileUploadParams`, and it will return an instance of `Task<FileUploadResponse>`.

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.Files.Upload(parameters);
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using Imagekit.Models.Files;

var response = await client.WithRawResponse.Files.Upload(parameters);
FileUploadResponse deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

## URL generation

The ImageKit SDK provides a powerful `Helper.BuildUrl()` method for generating optimized image and video URLs with transformations. Here are examples ranging from simple URLs to complex transformations with overlays and signed URLs.

### Basic URL generation

Generate a simple URL without any transformations:

```csharp
using Imagekit;
using Imagekit.Models;

ImageKitClient client = new()
{
    PrivateKey = "private_key_xxx",
};

string url = client.Helper.BuildUrl(new SrcOptions
{
    UrlEndpoint = "https://ik.imagekit.io/your_imagekit_id",
    Src = "/path/to/image.jpg",
});
Console.WriteLine(url);
// Result: https://ik.imagekit.io/your_imagekit_id/path/to/image.jpg
```

### URL generation with transformations

Apply common transformations like resizing, cropping, and format conversion:

```csharp
using Imagekit;
using Imagekit.Models;

string url = client.Helper.BuildUrl(new SrcOptions
{
    UrlEndpoint = "https://ik.imagekit.io/your_imagekit_id",
    Src = "/path/to/image.jpg",
    Transformation =
    [
        new Transformation
        {
            Width = 400,
            Height = 300,
            Crop = Crop.MaintainRatio,
            Quality = 80,
            Format = Format.Webp,
        },
    ],
});
Console.WriteLine(url);
// Result: https://ik.imagekit.io/your_imagekit_id/path/to/image.jpg?tr=w-400,h-300,q-80,c-maintain_ratio,f-webp
```

### URL generation with image overlay

Add image overlays to your base image:

```csharp
using Imagekit;
using Imagekit.Models;

string url = client.Helper.BuildUrl(new SrcOptions
{
    UrlEndpoint = "https://ik.imagekit.io/your_imagekit_id",
    Src = "/path/to/base-image.jpg",
    Transformation =
    [
        new Transformation
        {
            Width = 500,
            Height = 400,
            Overlay = new ImageOverlay("/path/to/overlay-logo.png")
            {
                Position = new OverlayPosition { X = "10", Y = "10" },
                Transformation = [new Transformation { Width = 100, Height = 50 }],
            },
        },
    ],
});
Console.WriteLine(url);
// Result: URL with image overlay positioned at x:10, y:10
```

### URL generation with text overlay

Add customized text overlays:

```csharp
using Imagekit;
using Imagekit.Models;

string url = client.Helper.BuildUrl(new SrcOptions
{
    UrlEndpoint = "https://ik.imagekit.io/your_imagekit_id",
    Src = "/path/to/base-image.jpg",
    Transformation =
    [
        new Transformation
        {
            Width = 600,
            Height = 400,
            Overlay = new TextOverlay("Sample Text Overlay")
            {
                Position = new OverlayPosition { X = "50", Y = "50", Focus = Focus.Center },
                Transformation =
                [
                    new TextOverlayTransformation
                    {
                        FontSize = 40,
                        FontFamily = "Arial",
                        FontColor = "FFFFFF",
                        Typography = "b", // bold
                    },
                ],
            },
        },
    ],
});
Console.WriteLine(url);
// Result: URL with bold white Arial text overlay at center position
```

### URL generation with multiple overlays

Combine multiple overlays for complex compositions:

```csharp
using Imagekit;
using Imagekit.Models;

string url = client.Helper.BuildUrl(new SrcOptions
{
    UrlEndpoint = "https://ik.imagekit.io/your_imagekit_id",
    Src = "/path/to/base-image.jpg",
    Transformation =
    [
        new Transformation
        {
            Width = 800,
            Height = 600,
            Overlay = new TextOverlay("Header Text")
            {
                Position = new OverlayPosition { X = "20", Y = "20" },
                Transformation =
                [
                    new TextOverlayTransformation { FontSize = 30, FontColor = "000000" },
                ],
            },
        },
        new Transformation
        {
            Overlay = new ImageOverlay("/watermark.png")
            {
                Position = new OverlayPosition { Focus = Focus.BottomRight },
                Transformation = [new Transformation { Width = 100, Opacity = 70 }],
            },
        },
    ],
});
Console.WriteLine(url);
// Result: URL with text overlay at top-left and semi-transparent watermark at bottom-right
```

### Signed URLs for secure delivery

Generate signed URLs that expire after a specified time for secure content delivery:

```csharp
using Imagekit;
using Imagekit.Models;

// Generate a signed URL that expires in 1 hour (3600 seconds)
string url = client.Helper.BuildUrl(new SrcOptions
{
    UrlEndpoint = "https://ik.imagekit.io/your_imagekit_id",
    Src = "/private/secure-image.jpg",
    Transformation = [new Transformation { Width = 400, Height = 300, Quality = 90 }],
    Signed = true,
    ExpiresIn = 3600, // URL expires in 1 hour
});
Console.WriteLine(url);
// Result: URL with signature parameters (?ik-t=timestamp&ik-s=signature)

// Generate a signed URL that doesn't expire
string permanentSignedUrl = client.Helper.BuildUrl(new SrcOptions
{
    UrlEndpoint = "https://ik.imagekit.io/your_imagekit_id",
    Src = "/private/secure-image.jpg",
    Signed = true,
    // No ExpiresIn means the URL won't expire
});
Console.WriteLine(permanentSignedUrl);
// Result: URL with signature parameter (?ik-s=signature)
```

### Using Raw transformations for undocumented features

ImageKit frequently adds new transformation parameters that might not yet be documented in the SDK. You can use the `Raw` parameter to access these features or create custom transformation strings:

```csharp
using Imagekit;
using Imagekit.Models;

string url = client.Helper.BuildUrl(new SrcOptions
{
    UrlEndpoint = "https://ik.imagekit.io/your_imagekit_id",
    Src = "/path/to/image.jpg",
    Transformation =
    [
        new Transformation { Width = 400, Height = 300 },
        new Transformation { Raw = "something-new" },
    ],
});
Console.WriteLine(url);
// Result: https://ik.imagekit.io/your_imagekit_id/path/to/image.jpg?tr=w-400,h-300:something-new
```

## Authentication parameters for client-side uploads

Generate authentication parameters for secure client-side file uploads:

```csharp
using Imagekit;

ImageKitClient client = new()
{
    PrivateKey = "private_key_xxx",
};

// Generate authentication parameters for client-side uploads
var authParams = client.Helper.GetAuthenticationParameters();
Console.WriteLine(authParams);
// Result: AuthenticationParameters { Token = "<uuid-token>", Expire = <timestamp>, Signature = "<hmac-signature>" }

// Generate with custom token and expiry (seconds from now)
var customAuthParams = client.Helper.GetAuthenticationParameters("my-custom-token", 1800);
Console.WriteLine(customAuthParams);
// Result: AuthenticationParameters { Token = "my-custom-token", Expire = 1800, Signature = "<hmac-signature>" }
```

These authentication parameters can be used in client-side upload forms to securely upload files without exposing your private API key.

## Webhook verification

For detailed information about webhook setup, signature verification, and handling different webhook events, refer to the [ImageKit webhook documentation](https://imagekit.io/docs/webhooks).

## Error handling

The SDK throws custom unchecked exception types:

- `ImageKitApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                               |
| ------ | --------------------------------------- |
| 400    | `ImageKitBadRequestException`           |
| 401    | `ImageKitUnauthorizedException`         |
| 403    | `ImageKitForbiddenException`            |
| 404    | `ImageKitNotFoundException`             |
| 422    | `ImageKitUnprocessableEntityException`  |
| 429    | `ImageKitRateLimitException`            |
| 5xx    | `ImageKit5xxException`                  |
| others | `ImageKitUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `ImageKit4xxException`.

- `ImageKitIOException`: I/O networking errors.

- `ImageKitInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `ImageKitException`: Base class for all exceptions.

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Imagekit;

ImageKitClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .Files.Upload(parameters);

Console.WriteLine(response);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Imagekit;

ImageKitClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .Files.Upload(parameters);

Console.WriteLine(response);
```

### Proxies

To route requests through a proxy, configure your client with a custom [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-10.0):

```csharp
using System.Net;
using System.Net.Http;
using Imagekit;

var httpClient = new HttpClient
(
    new HttpClientHandler
    {
        Proxy = new WebProxy("https://example.com:8080")
    }
);

ImageKitClient client = new() { HttpClient = httpClient };
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Parameters

To set undocumented parameters, a constructor exists that accepts dictionaries for additional header, query, and body values. If the method type doesn't support request bodies (e.g. `GET` requests), the constructor will only accept a header and query dictionary.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Core;
using Imagekit.Models.Files;

FileUploadParams parameters = new
(
    rawHeaderData: new Dictionary<string, JsonElement>()
    {
        { "Custom-Header", JsonSerializer.SerializeToElement(42) }
    },

    rawQueryData: new Dictionary<string, JsonElement>()
    {
        { "custom_query_param", JsonSerializer.SerializeToElement(42) }
    },

    rawBodyData: new Dictionary<string, MultipartJsonElement>()
    {
        { "custom_body_param", JsonSerializer.SerializeToElement(42) }
    }
)
{
    // Documented properties can still be added here.
    // In case of conflict, these parameters take precedence over the custom parameters.
    Expire = 0
};
```

The raw parameters can also be accessed through the `RawHeaderData`, `RawQueryData`, and `RawBodyData` (if available) properties.

This can also be used to set a documented parameter to an undocumented or not yet supported _value_, as long as the parameter is optional. If the parameter is required, omitting its `init` property will result in a compile-time error. To work around this, the `FromRawUnchecked` method can be used:

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Models.Files;

var parameters = FileUploadParams.FromRawUnchecked
(

    rawHeaderData: new Dictionary<string, JsonElement>(),
    rawQueryData: new Dictionary<string, JsonElement>(),
    rawBodyData: new Dictionary<string, JsonElement>
    {
        {
            "file",
            JsonSerializer.SerializeToElement("custom value")
        }
    }
);
```

### Nested Parameters

Undocumented properties, or undocumented values of documented properties, on nested parameters can be set similarly, using a dictionary in the constructor of the nested parameter.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Models.Files;

FileUploadParams parameters = new()
{
    Transformation = new
    (
        new Dictionary<string, JsonElement>
        {
            { "custom_nested_param", JsonSerializer.SerializeToElement(42) }
        }
    )
};
```

Required properties on the nested parameter can also be changed or omitted using the `FromRawUnchecked` method:

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Imagekit.Models.Files;

FileUploadParams parameters = new()
{
    Transformation = Transformation.FromRawUnchecked
    (
        new Dictionary<string, JsonElement>
        {
            { "required_property", JsonSerializer.SerializeToElement("custom value") }
        }
    )
};
```

### Response properties

To access undocumented response properties, the `RawData` property can be used:

```csharp
using System.Text.Json;

var response = await client.Files.Upload(parameters);
if (response.RawData.TryGetValue("my_custom_key", out JsonElement value))
{
    // Do something with `value`
}
```

`RawData` is a `IReadonlyDictionary<string, JsonElement>`. It holds the full data received from the API server.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `ImageKitInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var response = await client.Files.Upload(parameters);
response.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Imagekit;

ImageKitClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var response = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .Files.Upload(parameters);

Console.WriteLine(response);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/imagekit-developer/imagekit-dotnet/issues) with questions, bugs, or suggestions.
