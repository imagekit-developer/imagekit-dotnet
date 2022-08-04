using Imagekit.Constant;
using Imagekit.Sdk;
using Imagekit.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using Xunit;


namespace Imagekit.UnitTests
{

    public class ManageFolderTestAsync

    {
        private const string GOOD_PUBLICKEY = "abc";
        private const string GOOD_URLENDPOINT = "https://dasdsad.dad.io/";

       
        [Fact]
        public void CreateFolder_Default()
        {
            CreateFolderRequest model = new CreateFolderRequest
            {
                FolderName = "Tst3",
                ParentFolderPath = "Tst3"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.CreateFolderAsync(model).Result;
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
       
        [Fact]
        public void CreateFolderException()
        {
            CreateFolderRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CreateFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCreateFolderValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_FolderName_Exception()
        {
            CreateFolderRequest model = new CreateFolderRequest
            {
                ParentFolderPath = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CreateFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidFolderNameValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_ParentFolderPath_FolderException()
        {
            CreateFolderRequest model = new CreateFolderRequest
            {
                FolderName = "test"
            };
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CreateFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidFolderPathValue, ex.Result.Message);
        }
        [Fact]
        public void DeleteFolder_Default()
        {
            DeleteFolderRequest model = new DeleteFolderRequest
            {
                FolderPath = "Tst3"
            };


            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.DeleteFolderAsync(model).Result;
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        [Fact]
        public void Missing_Folder_Path_Exception()
        {
            DeleteFolderRequest model = new DeleteFolderRequest();
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.DeleteFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidDelFolderValue, ex.Result.Message);
        }


        [Fact]
        public void CopyFolder_Default()
        {
            CopyFolderRequest model = new CopyFolderRequest
            {
                SourceFolderPath = "Tst3",
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

            var response = restClient.CopyFolderAsync(model).Result;
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        
        [Fact]
        public void Missing_Obj_FolderException()
        {
            CopyFolderRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CopyFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopyFolderValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_SourceFolderPath_FolderException()
        {
            CopyFolderRequest model = new CopyFolderRequest
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
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CopyFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopySourceFolderPathValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_Destination_FolderPath_FolderException()
        {
            CopyFolderRequest model = new CopyFolderRequest
            {
                SourceFolderPath = "abc"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.CopyFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopyDestinationPathValue, ex.Result.Message);
        }

        [Fact]
        public void MoveFolder_Default()
        {
            MoveFolderRequest model = new MoveFolderRequest
            {
                SourceFolderPath = "Tst3",
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

            var response = restClient.MoveFolderAsync(model).Result;
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
      
        [Fact]
        public void Missing_Obj_Move_FolderException()
        {
            MoveFolderRequest model = null;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.MoveFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopyFolderValue, ex.Result.Message);
        }

        [Fact]
        public void Missing_SourceFolderPath_MoveFolderException()
        {
            MoveFolderRequest model = new MoveFolderRequest
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
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.MoveFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopySourceFolderPathValue, ex.Result.Message);
        }
        [Fact]
        public void Missing_Destination_FolderPath_MoveFolderException()
        {
            MoveFolderRequest model = new MoveFolderRequest
            {
                SourceFolderPath = "abc"
            };

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.ThrowsAsync<Exception>(async () => await restClient.MoveFolderAsync(model));
            Assert.Equal(ErrorMessages.InvalidCopyDestinationPathValue, ex.Result.Message);
        }
       
    }
}




