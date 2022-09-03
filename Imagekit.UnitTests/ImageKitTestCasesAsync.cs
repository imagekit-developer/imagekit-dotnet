using Imagekit.Constant;
using Imagekit.Sdk;
using Imagekit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Imagekit.UnitTests
{

    public class ImageKitTestCasesAsync
    {
        private const string GOOD_PUBLICKEY = "abc";
        private const string GOOD_PRIVATEKEY = "abc";
        private const string GOOD_URLENDPOINT = "https://dasdsad.dad.io/";

        [Fact]
        public void Missing_Key_Exception()
        {

            Exception actualException = Assert.Throws<Exception>(() => new RestClient("", "https://dasdsad.dad.io/", new HttpClient()));
            Assert.Equal(ErrorMessages.InvalidKey, actualException.Message);
        }
        [Fact]
        public void Missing_URL_Exception()
        {

            Exception actualException = Assert.Throws<Exception>(() => new RestClient("abc", "", new HttpClient()));
            Assert.Equal(ErrorMessages.InvalidApiUrl, actualException.Message);
        }

        [Fact]
        public void Constructor_TransformationPosition_Default()
        {
            var imagekit = new ImagekitClient(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            Assert.NotNull(imagekit);
        }

        [Fact]
        public void GetFileRequest_Default()
        {
            GetFileListRequest ob = new GetFileListRequest
            {
                Limit = 10,
                Skip = 0
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (ResultList)restClient.GetFileListRequestAsync(ob).Result;

            Assert.Equal(responseObj.Raw, response.Raw);
        }

        [Fact]
        public void GetFileDetail_Default()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (Result)restClient.GetFileDetailAsync("abc").Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void GetFile_ID_Detail_Exception()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.GetFileDetailAsync(""));
            Assert.Equal(ErrorMessages.FileIdMissing, ex.Result.Message);
        }

        [Fact]
        public void PurgeCache_Default()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.PurgeCacheAsync("abc").Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void PurgeStatus_Default()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.PurgeStatusAsync("abc").Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void DeleteFile_Default()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (ResultDelete)restClient.DeleteFileAsync("abc").Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Delete_File_ID_Exception()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.DeleteFileAsync(""));
            Assert.Equal(ErrorMessages.FileIdMissing, ex.Result.Message);
        }


        [Fact]
        public void BulkDeleteFiles_Default()
        {
            List<string> ob = new List<string>
            {
                "abc",
                "abcd"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = (ResultFileDelete)restClient.BulkDeleteFilesAsync(ob).Result;

            Assert.Equal(responseObj.Raw, response.Raw);
        }
        [Fact]
        public void Bulk_Delete_Files_Input_Missing_Exception()
        {
            List<string> ob = new List<string>();
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.BulkDeleteFilesAsync(ob));
            Assert.Equal(ErrorMessages.ListFilesInputMissing, ex.Result.Message);
        }

        [Fact]
        public void Missing_Filed_Null_Exception()
        {
            TagsRequest ob = new TagsRequest
            {
                tags = new List<string> { "abc" },
                fileIds = null
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.ManageTagsAsync(ob, ""));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Result.Message);
        }




        [Fact]
        public void Missing_Remove_Filed_Null_Exception()
        {
            TagsRequest ob = new TagsRequest
            {
                tags = new List<string> { "abc" },
                fileIds = null
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.ManageTagsAsync(ob, ""));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Result.Message);
        }


        [Fact]
        public void Missing_AI_Filed_Null_Exception()
        {
            AITagsRequest ob = new AITagsRequest
            {
                AITags = new List<string> { "abc" },
                fileIds = null
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.RemoveAITagsAsync(ob));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Result.Message);
        }

        [Fact]
        public void DeleteFileVersion_Default()
        {
            DeleteFileVersionRequest model = new DeleteFileVersionRequest
            {
                FileId = "Tst3",
                VersionId = "Tst3"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.DeleteFileVersionAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }

        [Fact]
        public void Missing_Object_FileVersionException()
        {
            DeleteFileVersionRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.DeleteFileVersionAsync(model));
            Assert.Equal(ErrorMessages.InvalidDelVerValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_FileId_FileVersionException()
        {
            DeleteFileVersionRequest model = new DeleteFileVersionRequest
            {
                VersionId = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.DeleteFileVersionAsync(model));
            Assert.Equal(ErrorMessages.InvalidFieldIdDelVerValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_VersionId_FileVersionException()
        {
            DeleteFileVersionRequest model = new DeleteFileVersionRequest
            {
                VersionId = "",
                FileId = "sas"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.DeleteFileVersionAsync(model));
            Assert.Equal(ErrorMessages.InvalidVersionIdDelVerValue, ex.Result.Message);
        }

        [Fact]
        public void CopyFile_Default()
        {
            CopyFileRequest model = new CopyFileRequest
            {
                sourceFilePath = "Tst3",
                destinationPath = "Tst3",
                includeFileVersions = true
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CopyFileAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Missing_Obj_CopyFileException()
        {
            CopyFileRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CopyFileAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopyValue, ex.Result.Message);
        }



        [Fact]
        public void Missing_Source_CopyFileException()
        {
            CopyFileRequest model = new CopyFileRequest
            {
                destinationPath = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CopyFileAsync(model));
            Assert.Equal(ErrorMessages.InvalidSourceValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_Destination_CopyFileException()
        {
            CopyFileRequest model = new CopyFileRequest
            {
                sourceFilePath = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CopyFileAsync(model));
            Assert.Equal(ErrorMessages.InvalidDestinationValue, ex.Result.Message);
        }

        [Fact]
        public void MoveFile_Default()
        {
            MoveFileRequest model = new MoveFileRequest
            {
                sourceFilePath = "Tst3",
                destinationPath = "Tst3"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.MoveFileAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Missing_Obj_MoveFileException()
        {
            MoveFileRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.MoveFileAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopyValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_Source_MoveFileException()
        {
            MoveFileRequest model = new MoveFileRequest
            {
                destinationPath = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.MoveFileAsync(model));
            Assert.Equal(ErrorMessages.InvalidSourceValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_Destination_MoveFileException()
        {
            MoveFileRequest model = new MoveFileRequest
            {
                sourceFilePath = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.MoveFileAsync(model));
            Assert.Equal(ErrorMessages.InvalidDestinationValue, ex.Result.Message);
        }

        [Fact]
        public void RenameFile_Default()
        {
            RenameFileRequest model = new RenameFileRequest
            {
                filePath = "Tst3",
                newFileName = "Tst4",
                purgeCache = false
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.RenameFileAsync(model).Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Missing_FilePath_RenameFileException()
        {
            RenameFileRequest model = new RenameFileRequest
            {
                newFileName = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.RenameFileAsync(model));
            Assert.Equal(ErrorMessages.InvalidRenameFilePathValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_NewFileName_RenameFileException()
        {
            RenameFileRequest model = new RenameFileRequest
            {
                filePath = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.RenameFileAsync(model));
            Assert.Equal(ErrorMessages.InvalidRenameNewFileNameValue, ex.Result.Message);
        }


        [Fact]
        public void GetBulkJobStatus_Default()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.GetBulkJobStatusAsync("abc").Result;
            var responseObj1 = JsonConvert.SerializeObject(responseObj);
            Assert.Equal(responseObj1, response.Raw);
        }
        [Fact]
        public void Missing_Job_Id_BulkJobStatusException()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.GetBulkJobStatusAsync(""));
            Assert.Equal(ErrorMessages.InvalidJobValue, ex.Result.Message);
        }
    }
}




