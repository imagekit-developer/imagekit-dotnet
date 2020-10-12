using System;
using System.Text;
using Imagekit.Util;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Imagekit
{
    public class Url
    {
        
        public Dictionary<string, object> options = new Dictionary<string, object>();
        
        private bool isSrcParameterUsedForURL;
        private Uri parsedURL, parsedHost;

        public Url(Dictionary<string, object> client)
        {
            options = client;
        }


        public string UrlBuilder(string transformationString)
        {
            
            Dictionary<string, string> urlObject = new Dictionary<string, string>();

            if (options.ContainsKey("path") && options.ContainsKey("src"))
            {
                throw new ArgumentException("Either path or src is required.");
            } else if(options.ContainsKey("path"))
            {
                if (!options["path"].ToString().StartsWith("/"))
                {
                    throw new ArgumentException("Path must start with \"/\".");
                }
                parsedURL = new Uri((string)options["urlEndpoint"] + (string)options["path"]);
                parsedHost = new Uri((string)options["urlEndpoint"]);
                urlObject.Add("protocol", parsedHost.Scheme);
                urlObject.Add("host", options["urlEndpoint"].ToString().Replace(parsedHost.Scheme + "://", ""));
                urlObject.Add("pathname", ((string)options["path"]).Split('?')[0]);
            } else if (options.ContainsKey("src"))
            {
                parsedURL = new Uri((string)options["src"]);
                isSrcParameterUsedForURL = true;
                urlObject.Add("protocol", parsedURL.Scheme);
                urlObject.Add("host", parsedURL.Host);
                urlObject.Add("pathname", parsedURL.AbsolutePath);
            } else
            {
                throw new ArgumentException("Either path or src is required.");
            }

            
            //Create correct query parameters
            SortedSet<string> queryParameters = new SortedSet<string>();
            // Parse queyr params which are part of the URL
            if (parsedURL.Query != null && parsedURL.Query.Length > 1)
            {
                string[] QueryList = parsedURL.Query.Split(new char[] { '&', '?' });
                foreach (var param in QueryList)
                {
                    if (string.IsNullOrEmpty(param)) continue;
                    int index = param.IndexOf('=');
                    if (index < 0) continue;
                    queryParameters.Add(GetParam(param.Substring(0, index), param.Substring(index + 1)));
                }
            }

            // parse param passed as queryParameters list
            if (options.ContainsKey("queryParameters"))
            {
                foreach (var param in (string[])options["queryParameters"])
                {
                    if (string.IsNullOrEmpty(param)) continue;
                    int index = param.IndexOf('=');
                    if (index < 0) throw new ArgumentException(String.Format("Couldn't parse '{0}'!", param));
                    queryParameters.Add(GetParam(param.Substring(0, index), param.Substring(index + 1)));
                }
            }

            if (isSrcParameterUsedForURL || AddAsQueryParameter())
            {
                if (!string.IsNullOrEmpty(transformationString))
                {
                    queryParameters.Add(GetParam(Constants.TRANSFORMATION_PARAMETER, transformationString));
                }
            } else if (!string.IsNullOrEmpty(transformationString))
            {
                urlObject["pathname"] = "/tr:" + transformationString + urlObject["pathname"];
            }

            urlObject["host"] = RemoveTrailingSlash(urlObject["host"]);
            urlObject["pathname"] = AddLeadingSlash(urlObject["pathname"]);

            if (queryParameters.Count > 0)
            {
                urlObject["query"] = string.Join("&", queryParameters);
            }
            
            if ( options.ContainsKey("signed") && options["signed"].Equals(true))
            {
                List<string> queryParametersSigned = new List<string>();
                string expiryTimestamp = options.ContainsKey("expireSeconds") ? Utils.GetSignatureTimestamp((int)options["expireSeconds"]) : Constants.DEFAULT_TIMESTAMP;
                if (expiryTimestamp != Constants.DEFAULT_TIMESTAMP)
                {
                    queryParametersSigned.Add(GetParam(Constants.TIMESTAMP_PARAMETER, expiryTimestamp));
                }
                string intermediateURL = GenrateUrl(urlObject);
                queryParametersSigned.Add(GetParam(Constants.SIGNATURE_PARAMETER, GetSignature(intermediateURL, expiryTimestamp)));

                if (queryParameters.Count > 0)
                {
                    urlObject["query"] = string.Join("&", queryParameters) + "&" + string.Join("&", queryParametersSigned);
                } else
                {
                    urlObject["query"] = string.Join("&", queryParametersSigned);
                }
                
            }

            return GenrateUrl(urlObject);
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
            if (!str[0].Equals('/'))
            {
                str = "/" + str;
            }
            return str;
        }

        public string GetParam(string key, string param)
        {
            return $"{Uri.UnescapeDataString(key)}={Uri.UnescapeDataString(param)}";
        }

        public bool AddAsQueryParameter()
        {
            if (options["transformationPosition"].ToString() == "query")
            {
                return true;
            }
            return false;
        }

        public string GetSignature(string url, string expiryTimestamp)
        {
            if (string.IsNullOrEmpty((string)options["privateKey"]) || string.IsNullOrEmpty((string)options["urlEndpoint"])) 
            { 
                throw new ArgumentNullException(errorMessages.PRIVATE_KEY_MISSING); 
            }
            string str = Regex.Replace(url, options["urlEndpoint"] + "/", "") + expiryTimestamp;
            return Utils.calculateSignature(str, Encoding.ASCII.GetBytes((string)options["privateKey"]));
        }
    }
}
