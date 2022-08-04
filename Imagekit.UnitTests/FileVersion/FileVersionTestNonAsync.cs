using Imagekit.Constant;
using Imagekit.Sdk;
using Imagekit.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Imagekit.UnitTests.FileVersion
{

    public class FileVersionTestNonAsync

    {
        private const string GOOD_PUBLICKEY = "abc";
        private const string GOOD_URLENDPOINT = "https://dasdsad.dad.io/";

       
        [Fact]
        public void Missing_Object_FileVersionException_NonAsync()
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
            var ex = Assert.Throws<Exception>(() =>  restClient.DeleteFileVersion(model));
            Assert.Equal(ErrorMessages.InvalidDelVerValue, ex.Message);
        }
        [Fact]
        public void Missing_FileId_FileVersionException_NonAsync()
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
            var ex = Assert.Throws<Exception>(() =>  restClient.DeleteFileVersion(model));
            Assert.Equal(ErrorMessages.InvalidFieldIdDelVerValue, ex.Message);
        }

        [Fact]
        public void Missing_VersionId_FileVersionException_NonAsync()
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
            var ex = Assert.Throws<Exception>(() =>  restClient.DeleteFileVersion(model));
            Assert.Equal(ErrorMessages.InvalidVersionIdDelVerValue, ex.Message);
        }

        [Fact]
        public void CopyFile_Default_NonAsync()
        {
            CopyFileRequest model = new CopyFileRequest
            {
                SourceFilePath = "Tst3",
                DestinationPath = "Tst3",
                IncludeFileVersions = true
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CopyFile(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

         
        [Fact]
        public void Missing_Obj_CopyFileException_NonAsync()
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
            var ex = Assert.Throws<Exception>(() =>  restClient.CopyFile(model));
            Assert.Equal(ErrorMessages.InvalidCopyValue, ex.Message);
        }



        [Fact]
        public void Missing_Source_CopyFileException_NonAsync()
        {
            CopyFileRequest model = new CopyFileRequest
            {
                DestinationPath = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CopyFile(model));
            Assert.Equal(ErrorMessages.InvalidSourceValue, ex.Message);
        }

        [Fact]
        public void Missing_Destination_CopyFileException_NonAsync()
        {
            CopyFileRequest model = new CopyFileRequest
            {
                SourceFilePath = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.CopyFile(model));
            Assert.Equal(ErrorMessages.InvalidDestinationValue, ex.Message);
        }

        [Fact]
        public void MoveFile_Default_NonAsync()
        {
            MoveFileRequest model = new MoveFileRequest
            {
                SourceFilePath = "Tst3",
                DestinationPath = "Tst3"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.MoveFile(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

       
        [Fact]
        public void Missing_Obj_MoveFileException_NonAsync()
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
            var ex = Assert.Throws<Exception>(() =>  restClient.MoveFile(model));
            Assert.Equal(ErrorMessages.InvalidCopyValue, ex.Message);
        }

        [Fact]
        public void Missing_Source_MoveFileException_NonAsync()
        {
            MoveFileRequest model = new MoveFileRequest
            {
                DestinationPath = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.MoveFile(model));
            Assert.Equal(ErrorMessages.InvalidSourceValue, ex.Message);
        }

        [Fact]
        public void Missing_Destination_MoveFileException_NonAsync()
        {
            MoveFileRequest model = new MoveFileRequest
            {
                SourceFilePath = "abc"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.MoveFile(model));
            Assert.Equal(ErrorMessages.InvalidDestinationValue, ex.Message);
        }

        [Fact]
        public void RenameFile_Default_NonAsync()
        {
            RenameFileRequest model = new RenameFileRequest
            {
                FilePath = "Tst3",
                NewFileName = "Tst4",
                PurgeCache = false
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.RenameFile(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        
        [Fact]
        public void Missing_FilePath_RenameFileException_NonAsync()
        {
            RenameFileRequest model = new RenameFileRequest
            {
                NewFileName = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.RenameFile(model));
            Assert.Equal(ErrorMessages.InvalidRenameFilePathValue, ex.Message);
        }
        [Fact]
        public void Missing_NewFileName_RenameFileException_NonAsync()
        {
            RenameFileRequest model = new RenameFileRequest
            {
                FilePath = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.RenameFile(model));
            Assert.Equal(ErrorMessages.InvalidRenameNewFileNameValue, ex.Message);
        }


       

        [Fact]
        public void GetFileVersions_Default_NonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.GetFileVersions("abc");
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }


       
        [Fact]
        public void MISSING_FILE_ID_FileVersionsException_NonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.GetFileVersions(""));
            Assert.Equal(ErrorMessages.FileIdMissing, ex.Message);
        }
        [Fact]
        public void RestoreFileVersion_Default_NonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.RestoreFileVersion("abc", "1");
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

 
        [Fact]
        public void Missing_Restore_File_Exception_NonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.RestoreFileVersion("", "123"));
            Assert.Equal(ErrorMessages.InvalidFieldIdDelVerValue, ex.Message);
        }
        [Fact]
        public void Missing_Restore_Version_Exception_NonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.RestoreFileVersion("123", ""));
            Assert.Equal(ErrorMessages.InvalidVersionIdDelVerValue, ex.Message);
        }

        [Fact]
        public void Missing_Restore_File_Version_Exception_NonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.RestoreFileVersion("", ""));
            Assert.Equal(ErrorMessages.InvalidDelVerValue, ex.Message);
        }
        [Fact]
        public void GetFileVersionDetails_Default_NonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.GetFileVersionDetails("abc", "1");
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        [Fact]
        public void Missing_FileVersionDetailsException_NonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.GetFileVersionDetails("", ""));
            Assert.Equal(ErrorMessages.InvalidDelVerValue, ex.Message);
        }
        [Fact]
        public void Missing_FileDetails_Exception_NonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.RestoreFileVersion("", "123"));
            Assert.Equal(ErrorMessages.InvalidFieldIdDelVerValue, ex.Message);
        }
        [Fact]
        public void Missing_VersionDetails_Exception_NonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() =>  restClient.RestoreFileVersion("123", ""));
            Assert.Equal(ErrorMessages.InvalidVersionIdDelVerValue, ex.Message);
        }




    }
}




