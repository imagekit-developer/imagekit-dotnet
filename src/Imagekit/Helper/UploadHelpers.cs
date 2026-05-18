using System;
using System.Collections.Generic;
using System.Net.Http;
using Imagekit.Core;

namespace Imagekit.Helper;

internal static class UploadHelpers
{
    const string UploadBaseUrl = "https://upload.imagekit.io";

    internal static string GetUploadBaseUrl(string configuredBaseUrl) =>
        string.Equals(
            configuredBaseUrl,
            EnvironmentUrl.Production,
            StringComparison.OrdinalIgnoreCase
        )
            ? UploadBaseUrl
            : configuredBaseUrl;

    internal static HttpContent SerializeUploadBody(
        IReadOnlyDictionary<string, MultipartJsonElement> rawData
    )
    {
        var data = new Dictionary<string, MultipartJsonElement>();
        foreach (var kvp in rawData)
            data[kvp.Key] = kvp.Value;

        SerializeFieldAsJsonString(data, "extensions");
        SerializeFieldAsJsonString(data, "customMetadata");
        SerializeFieldAsJsonString(data, "transformation");

        return MultipartJsonSerializer.Serialize(data);
    }

    private static void SerializeFieldAsJsonString(
        Dictionary<string, MultipartJsonElement> data,
        string key
    )
    {
        if (data.TryGetValue(key, out var element))
            data[key] = MultipartJsonSerializer.SerializeToElement(element.Json.GetRawText());
    }
}
