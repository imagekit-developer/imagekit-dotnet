// <copyright file="Utils.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Util
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    [ExcludeFromCodeCoverage]
    public static class Utils
    {
        public static Dictionary<string, string> GetHeaders()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Accept-Encoding", "application/json" },
                { "Content-Type", "application/json" },
                { "Authorization", "Basic " + "private_FguYxKgB8/Jm9Xs5ZyyLfwIBSFU=" },
            };
            return headers;
        }

        public static ResponseMetaData PopulateResponseMetadata(
            string respBody,
            ResponseMetaData responseMetadata,
            int responseCode,
            Dictionary<string, List<string>> responseHeaders)
        {
            responseMetadata = new ResponseMetaData
            {
                Raw = respBody,

                HttpStatusCode = responseCode,
            };

            return responseMetadata;
        }

        public static long ToUnixTime(DateTime dateTime)
        {
            return (int)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public static string EncodeTo64(string toEncode)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(toEncode + ":");
            string returnValue = Convert.ToBase64String(plainTextBytes);
            return returnValue;
        }

        public static string GetSignatureTimestamp(int seconds)
        {
            if (seconds <= 0)
            {
                return Constants.DefaultTimestamp;
            }

            var timeStamp = ToUnixTime(DateTime.UtcNow);
            return (timeStamp + seconds).ToString();
        }

        public static string CalculateSignature(string input, byte[] key)
        {
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            return myhmacsha1.ComputeHash(stream).Aggregate(string.Empty, (s, e) => s + string.Format("{0:x2}", e), s => s);
        }
    }
}