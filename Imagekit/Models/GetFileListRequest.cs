// <copyright file="GetFileListRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Imagekit.Models
{
    public class GetFileListRequest
    {
        public string Name { get; set; }    
        public string Type { get; set; }

        public string Sort { get; set; }

        public string Path { get; set; }

        public string SearchQuery { get; set; }

        public string FileType { get; set; }

        public int Limit { get; set; }

        public int Skip { get; set; }

        public string[] Tags { get; set; }
    }
}
