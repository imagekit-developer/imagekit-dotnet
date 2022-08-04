// <copyright file="AITagsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit
{
    using System.Collections.Generic;

    public class AiTagsRequest
    {
        public List<string> FileIds
        {
            get;
            set;
        }

        public List<string> AiTags
        {
            get;
            set;
        }
    }
}