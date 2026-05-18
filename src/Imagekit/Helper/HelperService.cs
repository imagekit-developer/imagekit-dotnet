using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using SysEncoding = System.Text.Encoding;
using Imagekit.Models;

namespace Imagekit.Services;

/// <inheritdoc/>
public sealed class HelperService : IHelperService
{
    readonly IImageKitClient _client;

    private static readonly Regex SimpleOverlayPathRegex = new(@"^[a-zA-Z0-9-._/ ]*$", RegexOptions.Compiled);
    private static readonly Regex SimpleOverlayTextRegex = new(@"^[a-zA-Z0-9-._ ]*$", RegexOptions.Compiled);
    private static readonly Regex MultiSlashRegex = new(@"/+", RegexOptions.Compiled);
    private const long DefaultTimestamp = 9999999999L;

    internal HelperService(IImageKitClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public AuthenticationParameters GetAuthenticationParameters(string? token = null, long? expires = null)
    {
        if (string.IsNullOrEmpty(_client.PrivateKey))
            throw new InvalidOperationException("private API key is required for authentication parameters generation");

        string finalToken = token ?? "";
        if (string.IsNullOrEmpty(finalToken))
        {
            var bytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            finalToken = BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }

        long finalExpire = expires ?? 0L;
        if (finalExpire == 0L)
            finalExpire = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60 * 30;

        string signature = HmacSha1(_client.PrivateKey, finalToken + finalExpire.ToString(CultureInfo.InvariantCulture));

        return new AuthenticationParameters { Token = finalToken, Expire = finalExpire, Signature = signature };
    }

    /// <inheritdoc/>
    public string BuildTransformationString(IReadOnlyList<Transformation> transformations)
    {
        if (transformations == null || transformations.Count == 0)
            return "";

        var steps = new List<string>();
        foreach (var t in transformations)
        {
            var parts = new List<string>();

            // Width
            if (t.Width != null)
            {
                if (t.Width.TryPickDouble(out var d)) parts.Add("w-" + Fmt(d!.Value));
                else if (t.Width.TryPickString(out var s)) parts.Add("w-" + s);
            }
            // Height
            if (t.Height != null)
            {
                if (t.Height.TryPickDouble(out var d)) parts.Add("h-" + Fmt(d!.Value));
                else if (t.Height.TryPickString(out var s)) parts.Add("h-" + s);
            }
            // Quality
            if (t.Quality != null) parts.Add("q-" + Fmt(t.Quality.Value));
            // AspectRatio
            if (t.AspectRatio != null)
            {
                if (t.AspectRatio.TryPickDouble(out var d)) parts.Add("ar-" + Fmt(d!.Value));
                else if (t.AspectRatio.TryPickString(out var s)) parts.Add("ar-" + s);
            }
            // Crop
            if (t.Crop != null) parts.Add("c-" + t.Crop.Raw());
            // CropMode
            if (t.CropMode != null) parts.Add("cm-" + t.CropMode.Raw());
            // Focus
            if (!string.IsNullOrEmpty(t.Focus)) parts.Add("fo-" + t.Focus);
            // Format
            if (t.Format != null) parts.Add("f-" + t.Format.Raw());
            // Radius
            if (t.Radius != null)
            {
                if (t.Radius.TryPickMax(out _)) parts.Add("r-max");
                else if (t.Radius.TryPickString(out var s)) parts.Add("r-" + s);
                else if (t.Radius.TryPickDouble(out var d)) parts.Add("r-" + Fmt(d!.Value));
            }
            // Background
            if (!string.IsNullOrEmpty(t.Background)) parts.Add("bg-" + t.Background);
            // Border
            if (!string.IsNullOrEmpty(t.Border)) parts.Add("b-" + t.Border);
            // ColorReplace
            if (!string.IsNullOrEmpty(t.ColorReplace)) parts.Add("cr-" + t.ColorReplace);
            // DefaultImage
            if (t.DefaultImage != null)
            {
                var di = t.DefaultImage.Trim('/');
                if (!string.IsNullOrEmpty(di))
                    parts.Add("di-" + di.Replace("/", "@@"));
            }
            // Dpr
            if (t.Dpr != null) parts.Add("dpr-" + Fmt(t.Dpr.Value));
            // X
            if (t.X != null)
            {
                if (t.X.TryPickDouble(out var d)) parts.Add("x-" + Fmt(d!.Value));
                else if (t.X.TryPickString(out var s)) parts.Add("x-" + s);
            }
            // Y
            if (t.Y != null)
            {
                if (t.Y.TryPickDouble(out var d)) parts.Add("y-" + Fmt(d!.Value));
                else if (t.Y.TryPickString(out var s)) parts.Add("y-" + s);
            }
            // XCenter
            if (t.XCenter != null)
            {
                if (t.XCenter.TryPickDouble(out var d)) parts.Add("xc-" + Fmt(d!.Value));
                else if (t.XCenter.TryPickString(out var s)) parts.Add("xc-" + s);
            }
            // YCenter
            if (t.YCenter != null)
            {
                if (t.YCenter.TryPickDouble(out var d)) parts.Add("yc-" + Fmt(d!.Value));
                else if (t.YCenter.TryPickString(out var s)) parts.Add("yc-" + s);
            }
            // Opacity
            if (t.Opacity != null) parts.Add("o-" + Fmt(t.Opacity.Value));
            // Zoom
            if (t.Zoom != null) parts.Add("z-" + Fmt(t.Zoom.Value));
            // Rotation
            if (t.Rotation != null)
            {
                if (t.Rotation.TryPickDouble(out var d)) parts.Add("rt-" + Fmt(d!.Value));
                else if (t.Rotation.TryPickString(out var s)) parts.Add("rt-" + s);
            }
            // Blur
            if (t.Blur != null) parts.Add("bl-" + Fmt(t.Blur.Value));
            // Named
            if (!string.IsNullOrEmpty(t.Named)) parts.Add("n-" + t.Named);
            // Progressive
            if (t.Progressive != null) parts.Add("pr-" + t.Progressive.Value.ToString().ToLowerInvariant());
            // Lossless
            if (t.Lossless != null) parts.Add("lo-" + t.Lossless.Value.ToString().ToLowerInvariant());
            // Flip
            if (t.Flip != null) parts.Add("fl-" + t.Flip.Raw());
            // Trim
            if (t.Trim != null)
            {
                if (t.Trim.TryPickDefault(out _)) parts.Add("t-true");
                else if (t.Trim.TryPickDouble(out var d)) parts.Add("t-" + Fmt(d!.Value));
            }
            // Metadata
            if (t.Metadata != null) parts.Add("md-" + t.Metadata.Value.ToString().ToLowerInvariant());
            // ColorProfile
            if (t.ColorProfile != null) parts.Add("cp-" + t.ColorProfile.Value.ToString().ToLowerInvariant());
            // VideoCodec
            if (t.VideoCodec != null) parts.Add("vc-" + t.VideoCodec.Raw());
            // AudioCodec
            if (t.AudioCodec != null) parts.Add("ac-" + t.AudioCodec.Raw());
            // StartOffset
            if (t.StartOffset != null)
            {
                if (t.StartOffset.TryPickDouble(out var d)) parts.Add("so-" + Fmt(d!.Value));
                else if (t.StartOffset.TryPickString(out var s)) parts.Add("so-" + s);
            }
            // EndOffset
            if (t.EndOffset != null)
            {
                if (t.EndOffset.TryPickDouble(out var d)) parts.Add("eo-" + Fmt(d!.Value));
                else if (t.EndOffset.TryPickString(out var s)) parts.Add("eo-" + s);
            }
            // Duration
            if (t.Duration != null)
            {
                if (t.Duration.TryPickDouble(out var d)) parts.Add("du-" + Fmt(d!.Value));
                else if (t.Duration.TryPickString(out var s)) parts.Add("du-" + s);
            }
            // StreamingResolutions
            if (t.StreamingResolutions != null && t.StreamingResolutions.Count > 0)
                parts.Add("sr-" + string.Join("_", t.StreamingResolutions.Select(r => r.Raw())));

            // AI boolean flags
            if (t.Grayscale?.Raw() == true) parts.Add("e-grayscale");
            if (t.AIUpscale?.Raw() == true) parts.Add("e-upscale");
            if (t.AIRetouch?.Raw() == true) parts.Add("e-retouch");
            if (t.AIVariation?.Raw() == true) parts.Add("e-genvar");
            if (t.AIRemoveBackground?.Raw() == true) parts.Add("e-bgremove");
            if (t.AIRemoveBackgroundExternal?.Raw() == true) parts.Add("e-removedotbg");
            if (t.ContrastStretch?.Raw() == true) parts.Add("e-contrast");

            // AIDropShadow
            if (t.AIDropShadow != null)
            {
                if (t.AIDropShadow.TryPickDefault(out _)) parts.Add("e-dropshadow");
                else if (t.AIDropShadow.TryPickString(out var s) && !string.IsNullOrEmpty(s)) parts.Add("e-dropshadow-" + s);
            }
            // AIChangeBackground
            if (!string.IsNullOrEmpty(t.AIChangeBackground)) parts.Add("e-changebg-" + t.AIChangeBackground);
            // AIEdit
            if (!string.IsNullOrEmpty(t.AIEdit)) parts.Add("e-edit-" + t.AIEdit);

            // Shadow
            if (t.Shadow != null)
            {
                if (t.Shadow.TryPickDefault(out _)) parts.Add("e-shadow");
                else if (t.Shadow.TryPickString(out var s) && !string.IsNullOrEmpty(s)) parts.Add("e-shadow-" + s);
            }
            // Sharpen
            if (t.Sharpen != null)
            {
                if (t.Sharpen.TryPickDefault(out _)) parts.Add("e-sharpen");
                else if (t.Sharpen.TryPickDouble(out var d)) parts.Add("e-sharpen-" + Fmt(d!.Value));
            }
            // UnsharpMask
            if (t.UnsharpMask != null)
            {
                if (t.UnsharpMask.TryPickDefault(out _)) parts.Add("e-usm");
                else if (t.UnsharpMask.TryPickString(out var s) && !string.IsNullOrEmpty(s)) parts.Add("e-usm-" + s);
            }
            // Gradient
            if (t.Gradient != null)
            {
                if (t.Gradient.TryPickDefault(out _)) parts.Add("e-gradient");
                else if (t.Gradient.TryPickString(out var s) && !string.IsNullOrEmpty(s)) parts.Add("e-gradient-" + s);
            }
            // Colorize
            if (!string.IsNullOrEmpty(t.Colorize)) parts.Add("e-colorize-" + t.Colorize);
            // Distort
            if (!string.IsNullOrEmpty(t.Distort)) parts.Add("e-distort-" + t.Distort);

            // Original
            if (t.Original == true) parts.Add("orig-true");

            // Page
            if (t.Page != null)
            {
                if (t.Page.TryPickDouble(out var d)) parts.Add("pg-" + Fmt(d!.Value));
                else if (t.Page.TryPickString(out var s)) parts.Add("pg-" + s);
            }

            // Overlay
            if (t.Overlay != null)
            {
                var overlayStr = ProcessOverlay(t.Overlay);
                if (!string.IsNullOrEmpty(overlayStr))
                    parts.Add(overlayStr);
            }

            // Raw (always last)
            if (!string.IsNullOrEmpty(t.Raw)) parts.Add(t.Raw);

            if (parts.Count > 0)
                steps.Add(string.Join(",", parts));
        }

        return string.Join(":", steps);
    }

    /// <inheritdoc/>
    public string BuildUrl(SrcOptions options)
    {
        if (string.IsNullOrEmpty(options.Src))
            return "";

        var src = options.Src;
        bool isAbsoluteUrl = src.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                          || src.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
        bool isSrcUsedForUrl = isAbsoluteUrl;

        var trPos = options.TransformationPosition?.Value() ?? TransformationPosition.Query;
        bool addAsQuery = trPos == TransformationPosition.Query || isSrcUsedForUrl;

        var trStr = BuildTransformationString(options.Transformation ?? new List<Transformation>());

        ParseUrl(isAbsoluteUrl ? src : options.UrlEndpoint,
                 out string scheme, out string host, out string basePath, out string existingQuery);

        // Merge query parameters (sorted alphabetically)
        var queryParams = new SortedDictionary<string, string>(StringComparer.Ordinal);
        foreach (var kv in ParseQueryString(existingQuery))
            queryParams[kv.Key] = kv.Value;
        if (options.QueryParameters != null)
            foreach (var kv in options.QueryParameters)
                queryParams[kv.Key] = kv.Value;

        // Build path
        string finalPath;
        if (!isAbsoluteUrl)
        {
            string encodedSrc = EncodePathSegments(src);
            if (!string.IsNullOrEmpty(trStr) && !addAsQuery)
                finalPath = NormalizePath(basePath + "/tr:" + trStr + "/" + encodedSrc);
            else
                finalPath = NormalizePath(basePath + "/" + encodedSrc);
        }
        else
        {
            // Absolute URL: basePath comes from Uri.AbsolutePath, already percent-encoded
            finalPath = basePath;
        }

        string finalUrl = scheme + "://" + host + finalPath;

        // Add sorted query params
        if (queryParams.Count > 0)
            finalUrl += "?" + string.Join("&", queryParams.Select(kv =>
                Uri.EscapeDataString(kv.Key) + "=" + Uri.EscapeDataString(kv.Value)));

        // Add transformation as query param
        if (!string.IsNullOrEmpty(trStr) && addAsQuery)
            finalUrl += (finalUrl.Contains('?') ? "&" : "?") + "tr=" + trStr;

        // Signing
        bool shouldSign = options.Signed == true || (options.ExpiresIn != null && options.ExpiresIn > 0);
        if (shouldSign)
        {
            long expiryTimestamp = (options.ExpiresIn != null && options.ExpiresIn > 0)
                ? DateTimeOffset.UtcNow.ToUnixTimeSeconds() + (long)options.ExpiresIn.Value
                : DefaultTimestamp;

            string signature = GetSignature(finalUrl, options.UrlEndpoint, expiryTimestamp);
            string sep = finalUrl.Contains('?') ? "&" : "?";
            if (expiryTimestamp != DefaultTimestamp)
                finalUrl += sep + "ik-t=" + expiryTimestamp + "&ik-s=" + signature;
            else
                finalUrl += sep + "ik-s=" + signature;
        }

        return finalUrl;
    }

    private string GetSignature(string finalUrl, string urlEndpoint, long expiryTimestamp)
    {
        if (string.IsNullOrEmpty(_client.PrivateKey)) return "";
        string endpointWithSlash = urlEndpoint.TrimEnd('/') + "/";
        string relative = finalUrl.StartsWith(endpointWithSlash, StringComparison.Ordinal)
            ? finalUrl.Substring(endpointWithSlash.Length)
            : finalUrl;
        return HmacSha1(_client.PrivateKey, relative + expiryTimestamp.ToString(CultureInfo.InvariantCulture));
    }

    private static string HmacSha1(string key, string data)
    {
        using var hmac = new HMACSHA1(SysEncoding.UTF8.GetBytes(key));
        return BitConverter.ToString(hmac.ComputeHash(SysEncoding.UTF8.GetBytes(data))).Replace("-", "").ToLowerInvariant();
    }

    private static string Fmt(double value) => value.ToString("G", CultureInfo.InvariantCulture);

    private static void ParseUrl(string url, out string scheme, out string host, out string path, out string query)
    {
        var uri = new Uri(url);
        scheme = uri.Scheme;
        host = uri.IsDefaultPort ? uri.Host : uri.Host + ":" + uri.Port;
        path = uri.AbsolutePath;
        query = uri.Query.TrimStart('?');
    }

    private static string NormalizePath(string path) => MultiSlashRegex.Replace(path, "/");

    private static string EncodePathSegments(string path) =>
        string.Join("/", path.Split('/').Select(Uri.EscapeDataString));

    private static IEnumerable<KeyValuePair<string, string>> ParseQueryString(string query)
    {
        if (string.IsNullOrEmpty(query)) yield break;
        foreach (var part in query.Split('&'))
        {
            int eq = part.IndexOf('=');
            if (eq < 0) yield return new KeyValuePair<string, string>(Uri.UnescapeDataString(part), "");
            else yield return new KeyValuePair<string, string>(
                Uri.UnescapeDataString(part.Substring(0, eq)),
                Uri.UnescapeDataString(part.Substring(eq + 1)));
        }
    }

    private string ProcessOverlay(Overlay overlay)
    {
        var entries = new List<string>();
        string trStr = "";
        string? layerMode = null;
        OverlayPosition? position = null;
        OverlayTiming? timing = null;

        if (overlay.TryPickText(out var textOverlay))
        {
            if (string.IsNullOrEmpty(textOverlay!.Text)) return "";
            var enc = textOverlay.Encoding?.Raw() ?? "auto";
            entries.Add("l-text");
            entries.Add(ProcessText(textOverlay.Text, enc));
            layerMode = textOverlay.LayerMode?.Raw();
            position = textOverlay.Position;
            timing = textOverlay.Timing;
            if (textOverlay.Transformation?.Count > 0)
                trStr = BuildTextOverlayTransformation(textOverlay.Transformation);
        }
        else if (overlay.TryPickImage(out var imageOverlay))
        {
            if (string.IsNullOrEmpty(imageOverlay!.Input)) return "";
            var enc = imageOverlay.Encoding?.Raw() ?? "auto";
            entries.Add("l-image");
            entries.Add(ProcessInputPath(imageOverlay.Input, enc));
            layerMode = imageOverlay.LayerMode?.Raw();
            position = imageOverlay.Position;
            timing = imageOverlay.Timing;
            if (imageOverlay.Transformation?.Count > 0)
                trStr = BuildTransformationString(imageOverlay.Transformation);
        }
        else if (overlay.TryPickVideo(out var videoOverlay))
        {
            if (string.IsNullOrEmpty(videoOverlay!.Input)) return "";
            var enc = videoOverlay.Encoding?.Raw() ?? "auto";
            entries.Add("l-video");
            entries.Add(ProcessInputPath(videoOverlay.Input, enc));
            layerMode = videoOverlay.LayerMode?.Raw();
            position = videoOverlay.Position;
            timing = videoOverlay.Timing;
            if (videoOverlay.Transformation?.Count > 0)
                trStr = BuildTransformationString(videoOverlay.Transformation);
        }
        else if (overlay.TryPickSubtitle(out var subtitleOverlay))
        {
            if (string.IsNullOrEmpty(subtitleOverlay!.Input)) return "";
            var enc = subtitleOverlay.Encoding?.Raw() ?? "auto";
            entries.Add("l-subtitles");
            entries.Add(ProcessInputPath(subtitleOverlay.Input, enc));
            layerMode = subtitleOverlay.LayerMode?.Raw();
            position = subtitleOverlay.Position;
            timing = subtitleOverlay.Timing;
            if (subtitleOverlay.Transformation?.Count > 0)
                trStr = BuildSubtitleOverlayTransformation(subtitleOverlay.Transformation);
        }
        else if (overlay.TryPickSolidColor(out var solidColorOverlay))
        {
            if (string.IsNullOrEmpty(solidColorOverlay!.Color)) return "";
            entries.Add("l-image");
            entries.Add("i-ik_canvas");
            entries.Add("bg-" + solidColorOverlay.Color);
            layerMode = solidColorOverlay.LayerMode?.Raw();
            position = solidColorOverlay.Position;
            timing = solidColorOverlay.Timing;
            if (solidColorOverlay.Transformation?.Count > 0)
                trStr = BuildSolidColorOverlayTransformation(solidColorOverlay.Transformation);
        }

        if (entries.Count == 0) return "";

        if (!string.IsNullOrEmpty(layerMode)) entries.Add("lm-" + layerMode);

        if (position != null)
        {
            if (position.X != null)
            {
                if (position.X.TryPickDouble(out var d)) entries.Add("lx-" + Fmt(d!.Value));
                else if (position.X.TryPickString(out var s)) entries.Add("lx-" + s);
            }
            if (position.Y != null)
            {
                if (position.Y.TryPickDouble(out var d)) entries.Add("ly-" + Fmt(d!.Value));
                else if (position.Y.TryPickString(out var s)) entries.Add("ly-" + s);
            }
            if (position.XCenter != null)
            {
                if (position.XCenter.TryPickDouble(out var d)) entries.Add("lxc-" + Fmt(d!.Value));
                else if (position.XCenter.TryPickString(out var s)) entries.Add("lxc-" + s);
            }
            if (position.YCenter != null)
            {
                if (position.YCenter.TryPickDouble(out var d)) entries.Add("lyc-" + Fmt(d!.Value));
                else if (position.YCenter.TryPickString(out var s)) entries.Add("lyc-" + s);
            }
            if (position.AnchorPoint != null) entries.Add("lap-" + position.AnchorPoint.Raw());
            if (position.Focus != null) entries.Add("lfo-" + position.Focus.Raw());
        }

        if (timing != null)
        {
            if (timing.Start != null)
            {
                if (timing.Start.TryPickDouble(out var d)) entries.Add("lso-" + Fmt(d!.Value));
                else if (timing.Start.TryPickString(out var s)) entries.Add("lso-" + s);
            }
            if (timing.End != null)
            {
                if (timing.End.TryPickDouble(out var d)) entries.Add("leo-" + Fmt(d!.Value));
                else if (timing.End.TryPickString(out var s)) entries.Add("leo-" + s);
            }
            if (timing.Duration != null)
            {
                if (timing.Duration.TryPickDouble(out var d)) entries.Add("ldu-" + Fmt(d!.Value));
                else if (timing.Duration.TryPickString(out var s)) entries.Add("ldu-" + s);
            }
        }

        if (!string.IsNullOrEmpty(trStr)) entries.Add(trStr);
        entries.Add("l-end");
        return string.Join(",", entries);
    }

    private static string BuildTextOverlayTransformation(IReadOnlyList<TextOverlayTransformation> list)
    {
        var parts = new List<string>();
        foreach (var t in list)
        {
            if (t.Width != null)
            {
                if (t.Width.TryPickDouble(out var d)) parts.Add("w-" + Fmt(d!.Value));
                else if (t.Width.TryPickString(out var s)) parts.Add("w-" + s);
            }
            if (t.FontSize != null)
            {
                if (t.FontSize.TryPickDouble(out var d)) parts.Add("fs-" + Fmt(d!.Value));
                else if (t.FontSize.TryPickString(out var s)) parts.Add("fs-" + s);
            }
            if (!string.IsNullOrEmpty(t.FontFamily))
                parts.Add("ff-" + t.FontFamily.Trim('/').Replace("/", "@@"));
            if (!string.IsNullOrEmpty(t.FontColor)) parts.Add("co-" + t.FontColor);
            if (t.InnerAlignment != null) parts.Add("ia-" + t.InnerAlignment.Raw());
            if (t.Padding != null)
            {
                if (t.Padding.TryPickDouble(out var d)) parts.Add("pa-" + Fmt(d!.Value));
                else if (t.Padding.TryPickString(out var s)) parts.Add("pa-" + s);
            }
            if (t.Alpha != null) parts.Add("al-" + Fmt(t.Alpha.Value));
            if (!string.IsNullOrEmpty(t.Typography)) parts.Add("tg-" + t.Typography);
            if (!string.IsNullOrEmpty(t.Background)) parts.Add("bg-" + t.Background);
            if (t.Radius != null)
            {
                if (t.Radius.TryPickDouble(out var d)) parts.Add("r-" + Fmt(d!.Value));
                else if (t.Radius.TryPickMax(out _)) parts.Add("r-max");
            }
            if (t.Rotation != null)
            {
                if (t.Rotation.TryPickDouble(out var d)) parts.Add("rt-" + Fmt(d!.Value));
                else if (t.Rotation.TryPickString(out var s)) parts.Add("rt-" + s);
            }
            if (t.Flip != null) parts.Add("fl-" + t.Flip.Raw());
            if (t.LineHeight != null)
            {
                if (t.LineHeight.TryPickDouble(out var d)) parts.Add("lh-" + Fmt(d!.Value));
                else if (t.LineHeight.TryPickString(out var s)) parts.Add("lh-" + s);
            }
        }
        return string.Join(",", parts);
    }

    private static string BuildSubtitleOverlayTransformation(IReadOnlyList<SubtitleOverlayTransformation> list)
    {
        var parts = new List<string>();
        foreach (var t in list)
        {
            if (!string.IsNullOrEmpty(t.Background)) parts.Add("bg-" + t.Background);
            if (!string.IsNullOrEmpty(t.Color)) parts.Add("co-" + t.Color);
            if (t.FontSize != null) parts.Add("fs-" + Fmt(t.FontSize.Value));
            if (!string.IsNullOrEmpty(t.FontFamily)) parts.Add("ff-" + t.FontFamily);
            if (!string.IsNullOrEmpty(t.FontOutline)) parts.Add("fol-" + t.FontOutline);
            if (!string.IsNullOrEmpty(t.FontShadow)) parts.Add("fsh-" + t.FontShadow);
            if (t.Typography != null) parts.Add("tg-" + t.Typography.Raw());
        }
        return string.Join(",", parts);
    }

    private static string BuildSolidColorOverlayTransformation(IReadOnlyList<SolidColorOverlayTransformation> list)
    {
        var parts = new List<string>();
        foreach (var t in list)
        {
            if (t.Width != null)
            {
                if (t.Width.TryPickDouble(out var d)) parts.Add("w-" + Fmt(d!.Value));
                else if (t.Width.TryPickString(out var s)) parts.Add("w-" + s);
            }
            if (t.Height != null)
            {
                if (t.Height.TryPickDouble(out var d)) parts.Add("h-" + Fmt(d!.Value));
                else if (t.Height.TryPickString(out var s)) parts.Add("h-" + s);
            }
            if (t.Alpha != null) parts.Add("al-" + Fmt(t.Alpha.Value));
            if (!string.IsNullOrEmpty(t.Background)) parts.Add("bg-" + t.Background);
            if (t.Gradient != null)
            {
                if (t.Gradient.TryPickDefault(out _)) parts.Add("e-gradient");
                else if (t.Gradient.TryPickString(out var s) && !string.IsNullOrEmpty(s)) parts.Add("e-gradient-" + s);
            }
            if (t.Radius != null)
            {
                if (t.Radius.TryPickDouble(out var d)) parts.Add("r-" + Fmt(d!.Value));
                else if (t.Radius.TryPickMax(out _)) parts.Add("r-max");
            }
        }
        return string.Join(",", parts);
    }

    private static string ProcessInputPath(string str, string encoding)
    {
        str = str.Trim('/');
        if (encoding == "plain")
            return "i-" + str.Replace("/", "@@");
        if (encoding == "base64")
            return "ie-" + Uri.EscapeDataString(Convert.ToBase64String(SysEncoding.UTF8.GetBytes(str)));
        if (SimpleOverlayPathRegex.IsMatch(str))
            return "i-" + str.Replace("/", "@@");
        return "ie-" + Uri.EscapeDataString(Convert.ToBase64String(SysEncoding.UTF8.GetBytes(str)));
    }

    private static string ProcessText(string str, string encoding)
    {
        if (encoding == "plain")
            return "i-" + Uri.EscapeDataString(str);
        if (encoding == "base64")
            return "ie-" + Uri.EscapeDataString(Convert.ToBase64String(SysEncoding.UTF8.GetBytes(str)));
        if (SimpleOverlayTextRegex.IsMatch(str))
            return "i-" + Uri.EscapeDataString(str);
        return "ie-" + Uri.EscapeDataString(Convert.ToBase64String(SysEncoding.UTF8.GetBytes(str)));
    }
}
