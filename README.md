# Image Kit C# API Library

> [!NOTE]
> The Image Kit C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/stainless-sdks/imagekit-csharp/issues/new).

The Image Kit C# SDK provides convenient access to the [Image Kit REST API](https://imagekit.io/docs) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [imagekit.io](https://imagekit.io/docs).

## Installation

```bash
git clone git@github.com:stainless-sdks/imagekit-csharp.git
dotnet add reference imagekit-csharp/src/Imagekit
```

## Requirements

This library requires .NET 8 or later.

> [!NOTE]
> The library is currently in **beta**. The requirements will be lowered in the future.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Imagekit;
using Imagekit.Models.Files;

// Configured using the IMAGEKIT_PRIVATE_API_KEY, OPTIONAL_IMAGEKIT_IGNORES_THIS, IMAGEKIT_WEBHOOK_SECRET and IMAGE_KIT_BASE_URL environment variables
ImageKitClient client = new();

FileUploadParams parameters = new()
{
    File = "a value",
    FileName = "file-name.jpg",
};

var response = await client.Files.Upload(parameters);

Console.WriteLine(response);
```

## Client Configuration

Configure the client using environment variables:

```csharp
using Imagekit;

// Configured using the IMAGEKIT_PRIVATE_API_KEY, OPTIONAL_IMAGEKIT_IGNORES_THIS, IMAGEKIT_WEBHOOK_SECRET and IMAGE_KIT_BASE_URL environment variables
ImageKitClient client = new();
```

Or manually:

```csharp
using Imagekit;

ImageKitClient client = new()
{
    PrivateAPIKey = "My Private API Key",
    Password = "My Password",
};
```

Or using a combination of the two approaches.

See this table for the available options:

| Property        | Environment variable             | Required | Default value               |
| --------------- | -------------------------------- | -------- | --------------------------- |
| `PrivateAPIKey` | `IMAGEKIT_PRIVATE_API_KEY`       | true     | -                           |
| `Password`      | `OPTIONAL_IMAGEKIT_IGNORES_THIS` | false    | `"do_not_set"`              |
| `WebhookSecret` | `IMAGEKIT_WEBHOOK_SECRET`        | false    | -                           |
| `BaseUrl`       | `IMAGE_KIT_BASE_URL`             | true     | `"https://api.imagekit.io"` |

## Requests and responses

To send a request to the Image Kit API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Files.Upload` should be called with an instance of `FileUploadParams`, and it will return an instance of `Task<FileUploadResponse>`.

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/stainless-sdks/imagekit-csharp/issues) with questions, bugs, or suggestions.
