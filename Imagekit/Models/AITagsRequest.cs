// <copyright file="AITagsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit
{
    using System.Collections.Generic;

    public class AITagsRequest
    {
        public List<string> fileIds
        {
            get;
            set;
        }

        public List<string> AITags
        {
            get;
            set;
        }
    }
}