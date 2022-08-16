namespace ImagekitSample
{
    using System;
    using System.Collections.Generic;
    using Imagekit;
    using Imagekit.Models;
    using Imagekit.Models.Response;
    using Imagekit.Sdk;
    using Newtonsoft.Json.Linq;
    using static Imagekit.Models.CustomMetaDataFieldSchemaObject;

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create Instance of ImageKit
            ImagekitClient imagekit = new ImagekitClient("public_PvB5TVigSimCxloLyxYC4TqMFpE=", "private_FguYxKgB8/Jm9Xs5ZyyLfwIBSFU=", "https://api.imagekit.io/");

           

            #region File Management

           

            //Get File by FileId

            Result res1 = imagekit.GetFileDetail("62f7f57e13af5de519c1251f");

            

            #endregion

           
        }

    }
}
