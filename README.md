# Image Kit C# API Library

The Image Kit C# SDK provides convenient access to the [Image Kit REST API](https://imagekit.io/docs/api-reference) from applications written in C#.

The REST API documentation can be found on [imagekit.io](https://imagekit.io/docs/api-reference).

## Installation

```bash
git clone git@github.com:stainless-sdks/imagekit-csharp.git
dotnet add reference imagekit-csharp/src/ImageKit
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using System.Text;
using ImageKit;
using ImageKit.Models.Files;

ImageKitClient client = new();

FileUploadParams parameters = new()
{
    File = Encoding.UTF8.GetBytes("https://www.example.com/public-url.jpg"),
    FileName = "file-name.jpg",
};

var response = await client.Files.Upload(parameters);

Console.WriteLine(response);
```

## Client configuration

Configure the client using environment variables:

```csharp
using ImageKit;

// Configured using the IMAGEKIT_PRIVATE_KEY, OPTIONAL_IMAGEKIT_IGNORES_THIS, IMAGEKIT_WEBHOOK_SECRET and IMAGE_KIT_BASE_URL environment variables
ImageKitClient client = new();
```

Or manually:

```csharp
using ImageKit;

ImageKitClient client = new()
{
    PrivateKey = "My Private Key",
    Password = "My Password",
};
```

Or using a combination of the two approaches.

See this table for the available options:

| Property        | Environment variable             | Required | Default value               |
| --------------- | -------------------------------- | -------- | --------------------------- |
| `PrivateKey`    | `IMAGEKIT_PRIVATE_KEY`           | true     | -                           |
| `Password`      | `OPTIONAL_IMAGEKIT_IGNORES_THIS` | false    | `"do_not_set"`              |
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
using ImageKit.Models.Files;

var response = await client.WithRawResponse.Files.Upload(parameters);
FileUploadResponse deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

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

false

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
using ImageKit;

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
using ImageKit;

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
using ImageKit;

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
using ImageKit.Core;
using ImageKit.Models.Files;

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
using ImageKit.Models.Files;

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
using ImageKit.Models.Files;

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
using ImageKit.Models.Files;

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

var response = client.Files.Upload(parameters)
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
var response = client.Files.Upload(parameters);
response.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using ImageKit;

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

We are keen for your feedback; please open an [issue](https://www.github.com/stainless-sdks/imagekit-csharp/issues) with questions, bugs, or suggestions.
