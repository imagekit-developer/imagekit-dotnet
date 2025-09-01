using System;
using System.Net.Http;

namespace Imagekit.Models.Folders.Job;

/// <summary>
/// This API returns the status of a bulk job like copy and move folder operations.
/// </summary>
public sealed record class JobGetParams : ParamsBase
{
    public required string JobID;

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/bulkJobs/{0}", this.JobID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
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
