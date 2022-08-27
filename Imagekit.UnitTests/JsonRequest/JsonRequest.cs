using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagekit.UnitTests.JsonRequest
{
    public static class JsonRequest
    {
        public static string json = "Content-Disposition: form-data; name=\"fileName\""+
        "sample-cat-image.png"+
        "Content-Disposition: form-data; name=\"file\""+
        "https://homepages.cae.wisc.edu/~ece533/images/cat.png";
                                   

        public static string GetPurgeCacheRequest = "{\"url\":\"path\"}";
        public static string GetBulkDeleteRequest = "{\"fileIds\":[\"fileId1\",\"fileId2\"]}";
        public static string GetManageTagsRequest = "{\"FileIds\":[\"abc\"],\"Tags\":[\"abc\",\"abc\"]}";
        public static string GetAITagsRequest = "{\"FileIds\":[\"abc\"],\"AiTags\":[\"abc\",\"abc\"]}";
        public static string GetCustomMetaDataFieldsRequest = "{\n    \"name\": \"Tst3\",\n    \"label\": \"Test3\",\n    \"schema\": {\n        \"type\": \"Imagekit.Models.CustomMetaDataFieldSchemaObject\",\n        \"minValue\": \"1000\",\n        \"maxValue\": \"3000\"\n    }\n}";
        public static string GetUpdateCustomMetaDataFieldsRequest = "{\n    \"schema\": {\n        \"type\": \"Imagekit.Models.CustomMetaDataFieldSchemaObject\",\n        \"minValue\": 1000,\n        \"maxValue\": 3000\n    }\n}";

        public static string GetCopyFileRequest =
            "{\"SourceFilePath\":\"Tst3\",\"DestinationPath\":\"Tst3\",\"IncludeFileVersions\":true}";

        public static string GetMoveFileRequest = "{\"SourceFilePath\":\"Tst3\",\"DestinationPath\":\"Tst3\"}";

        public static string GetRenameFileRequest = "{\"FilePath\":\"Tst3\",\"NewFileName\":\"Tst4\",\"PurgeCache\":false}";
        
        public static string GetDeleteFileRequest = "{\"FilePath\":\"Tst3\",\"NewFileName\":\"Tst4\",\"PurgeCache\":false}";

        public static string GetCopyFolder = "{\"SourceFolderPath\":\"Tst3\",\"DestinationPath\":\"Tst3\",\"IncludeFileVersions\":true}";

        public static string GetMoveFolder = "{\"SourceFolderPath\":\"Tst3\",\"DestinationPath\":\"Tst3\"}";

    }
}
