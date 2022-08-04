using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using global::Imagekit.Constant;
using global::Imagekit.Util;

[ExcludeFromCodeCoverage]
public class Url
{
    public Dictionary<string, object> Options = new Dictionary<string, object>();

    private bool isSrcParameterUsedForUrl;
    private Uri parsedUrl;
    private Uri parsedHost;

    public Url(Dictionary<string, object> client)
    {
        this.Options = client;
    }

    public string UrlBuilder(string transformationString)
    {
        Dictionary<string, string> urlObject = new Dictionary<string, string>();

        if (this.Options.ContainsKey("path") && this.Options.ContainsKey("src"))
        {
            throw new Exception("Either path or src is required.");
        }
        else if (this.Options.ContainsKey("path"))
        {
            string path = this.AddLeadingSlash((string)this.Options["path"]);
            this.parsedUrl = new Uri((string)this.Options["urlEndpoint"] + path);
            this.parsedHost = new Uri((string)this.Options["urlEndpoint"]);
            urlObject.Add("protocol", this.parsedHost.Scheme);
            urlObject.Add("host", this.Options["urlEndpoint"].ToString().Replace(this.parsedHost.Scheme + "://", string.Empty));
            urlObject.Add("pathname", path.Split('?')[0]);
        }
        else if (this.Options.ContainsKey("src"))
        {
            this.parsedUrl = new Uri((string)this.Options["src"]);
            this.isSrcParameterUsedForUrl = true;
            urlObject.Add("protocol", this.parsedUrl.Scheme);
            urlObject.Add("host", this.parsedUrl.Host);
            urlObject.Add("pathname", this.parsedUrl.AbsolutePath);
        }
        else
        {
            throw new Exception("Either path or src is required.");
        }

        // Create correct query parameters
        List<string> queryParameters = new List<string>();

        // Parse query params which are part of the URL
        if (this.parsedUrl.Query != null && this.parsedUrl.Query.Length > 1)
        {
            string[] queryList = this.parsedUrl.Query.Split(new char[] { '&', '?' });
            foreach (var param in queryList)
            {
                if (string.IsNullOrEmpty(param))
                {
                    continue;
                }

                int index = param.IndexOf('=');
                if (index < 0)
                {
                    continue;
                }

                queryParameters.Add(this.GetParam(param.Substring(0, index), param.Substring(index + 1)));
            }
        }

        // parse param passed as queryParameters list
        if (this.Options.ContainsKey("queryParameters"))
        {
            foreach (var param in (string[])this.Options["queryParameters"])
            {
                if (string.IsNullOrEmpty(param))
                {
                    continue;
                }

                int index = param.IndexOf('=');
                if (index < 0)
                {
                    throw new Exception(string.Format("Couldn't parse '{0}'!", param));
                }

                queryParameters.Add(this.GetParam(param.Substring(0, index), param.Substring(index + 1)));
            }
        }

        if (!string.IsNullOrEmpty(transformationString))
        {
            if (this.isSrcParameterUsedForUrl || this.AddAsQueryParameter())
            {
                queryParameters.Add(this.GetParam(Constants.TransformationParameter, transformationString));
            }
            else
            {
                urlObject["pathname"] = "/tr:" + transformationString + urlObject["pathname"];
            }
        }

        urlObject["host"] = this.RemoveTrailingSlash(urlObject["host"]);

        if (queryParameters.Count > 0)
        {
            urlObject["query"] = string.Join("&", queryParameters);
        }

        if (this.Options.ContainsKey("signed") && this.Options["signed"].Equals(true))
        {
            string expiryTimestamp = this.Options.ContainsKey("expireSeconds") ? Utils.GetSignatureTimestamp((int)this.Options["expireSeconds"]) : Constants.DefaultTimestamp;
            if (expiryTimestamp != Constants.DefaultTimestamp)
            {
                queryParameters.Add(this.GetParam(Constants.TimestampParameter, expiryTimestamp));
            }

            string intermediateUrl = this.GenrateUrl(urlObject);
            queryParameters.Add(this.GetParam(Constants.SignatureParameter, this.GetSignature(intermediateUrl, expiryTimestamp)));

            if (queryParameters.Count > 0)
            {
                urlObject["query"] = string.Join("&", queryParameters);
            }
        }

        return this.GenrateUrl(urlObject);
    }

    public string GenrateUrl(Dictionary<string, string> urlObject)
    {
        if (urlObject.ContainsKey("query"))
        {
            return urlObject["protocol"] + "://" + urlObject["host"] + urlObject["pathname"] + "?" + urlObject["query"];
        }
        else
        {
            return urlObject["protocol"] + "://" + urlObject["host"] + urlObject["pathname"];
        }
    }

    public string RemoveTrailingSlash(string str)
    {
        return str.TrimEnd(new[] { '/' });
    }

    public string AddLeadingSlash(string str)
    {
        str = str.TrimStart('/');
        str = "/" + str;
        return str;
    }

    public string GetParam(string key, string param)
    {
        return $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(param)}";
    }

    public bool AddAsQueryParameter()
    {
        if (this.Options["transformationPosition"].ToString() == "query")
        {
            return true;
        }

        return false;
    }

    public string GetSignature(string url, string expiryTimestamp)
    {
        var endPoint = this.RemoveTrailingSlash((string)this.Options["urlEndpoint"]);
        string str = Regex.Replace(url, endPoint + "/", string.Empty) + expiryTimestamp;
        try
        {
            var privateKey = (string)this.Options["privateKey"];
        }
        catch
        {
            throw new ArgumentNullException(ErrorMessages.PrivateKeyMissing);
        }

        return Utils.CalculateSignature(str, Encoding.ASCII.GetBytes((string)this.Options["privateKey"]));
    }
}
