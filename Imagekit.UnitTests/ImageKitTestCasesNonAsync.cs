using Imagekit.Constant;
using Imagekit.Sdk;
using Imagekit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Imagekit.UnitTests.FileVersion
{

    public class ImageKitTestCasesNonAsync
    {
        private const string GOOD_PUBLICKEY = "abc";
        private const string GOOD_PRIVATEKEY = "abc";
        private const string GOOD_URLENDPOINT = "https://dasdsad.dad.io/";


        [Fact]
        public void Missing_Key_ExceptionNonAsync()
        {

            Exception actualException = Assert.Throws<Exception>(() => new RestClient("", "https://dasdsad.dad.io/", new HttpClient()));
            Assert.Equal(ErrorMessages.InvalidKey, actualException.Message);
        }
        [Fact]
        public void Missing_URL_ExceptionNonAsync()
        {

            Exception actualException = Assert.Throws<Exception>(() => new RestClient("abc", "", new HttpClient()));
            Assert.Equal(ErrorMessages.InvalidApiUrl, actualException.Message);
        }

        [Fact]
        public void Constructor_TransformationPosition_DefaultNonAsync()
        {
            var imagekit = new ImageKitClient(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            Assert.NotNull(imagekit);
        }
        [Fact]
        public void UrlValidation()
        {
            var imagekit = new ImageKitClient(GOOD_PUBLICKEY, GOOD_PRIVATEKEY, GOOD_URLENDPOINT);
            string path = "/default-image.jpg";
            Transformation trans = new Transformation()
                .Width(400)
                .Height(300)
                .AspectRatio("4-3")
                .Quality(40)
                .Crop("force").CropMode("extract").
                Focus("left").
                Format("jpeg").
                Background("A94D34").
                Border("5-A94D34").
                Rotation(90).
                Blur(10).
                Named("some_name").
                OverlayX(35).
                OverlayY(35).
                OverlayFocus("bottom").
                OverlayHeight(20).
                OverlayHeight(20).
                OverlayImage("/folder/file.jpg"). // leading slash case
                OverlayImageTrim(false).
                OverlayImageAspectRatio("4:3").
                OverlayImageBackground("0F0F0F").
                OverlayImageBorder("10_0F0F0F").
                OverlayImageDpr(2).
                OverlayImageQuality(50).
                OverlayImageCropping("force").
                OverlayText("two words").
                OverlayTextFontSize(20).
                OverlayTextFontFamily("Open Sans").
                OverlayTextColor("00FFFF").
                OverlayTextTransparency(5).
                OverlayTextTypography("b").
                OverlayBackground("00AAFF55").
                OverlayTextEncoded("b3ZlcmxheSBtYWRlIGVhc3k%3D").
                OverlayTextWidth(50).
                OverlayTextBackground("00AAFF55").
                OverlayTextPadding(40).
                OverlayTextInnerAlignment("left").
                OverlayRadius(10).
                Progressive(true).
                Lossless(true).
                Trim(5).
                Metadata(true).
                ColorProfile(true).
                DefaultImage("folder/file.jpg/"). //trailing slash case
                Dpr(3).
                EffectSharpen(10).
                EffectUsm("2-2-0.8-0.024").
                EffectContrast(true).
                EffectGray().
                Original().
                RawTransformation("h-200).w-300).l-image).i-logo.png).l-end")
                ;

            string imageURL = imagekit.Url(trans).Path(path).TransformationPosition("query").Generate();

            Assert.Equal("https://dasdsad.dad.io/default-image.jpg?tr=w-400%2Ch-300%2Car-4-3%2Cq-40%2Cc-force%2Ccm-extract%2Cfo-left%2Cf-jpeg%2Cbg-A94D34%2Cb-5-A94D34%2Crt-90%2Cbl-10%2Cn-some_name%2Cox-35%2Coy-35%2Cofo-bottom%2Coh-20%2Coi-folder%40%40file.jpg%2Coit-false%2Coiar-4%3A3%2Coibg-0F0F0F%2Coib-10_0F0F0F%2Coidpr-2%2Coiq-50%2Coic-force%2Cot-two%20words%2Cots-20%2Cotf-Open%20Sans%2Cotc-00FFFF%2Coa-5%2Cott-b%2Cobg-00AAFF55%2Cote-b3ZlcmxheSBtYWRlIGVhc3k%253D%2Cotw-50%2Cotbg-00AAFF55%2Cotp-40%2Cotia-left%2Cor-10%2Cpr-true%2Clo-true%2Ct-5%2Cmd-true%2Ccp-true%2Cdi-folder%40%40file.jpg%2Cdpr-3%2Ce-sharpen-10%2Ce-usm-2-2-0.8-0.024%2Ce-contrast-true%2Ce-grayscale-true%2Corig-true%2Ch-200%29.w-300%29.l-image%29.i-logo.png%29.l-end", imageURL);
        }

        [Fact]
        public void GetFileRequest_DefaultNonAsync()
        {
            GetFileListRequest ob = new GetFileListRequest();
            ob.limit = 10;
            ob.skip = 0;
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.GetFileListRequest(ob);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void GetFileDetail_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.GetFileDetail("abc");
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void GetFile_ID_Detail_ExceptionNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.GetFileDetail(""));
            Assert.Equal(ErrorMessages.FileIdMissing, ex.Message);
        }



        [Fact]
        public void PurgeCache_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.PurgeCache("abc");
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        [Fact]
        public void PurgeStatus_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.PurgeStatus("abc");
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void DeleteFile_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.DeleteFile("abc");
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        [Fact]
        public void Delete_File_ID_ExceptionNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.DeleteFile(""));
            Assert.Equal(ErrorMessages.FileIdMissing, ex.Message);
        }


        [Fact]
        public void BulkDeleteFiles_DefaultNonAsync()
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

            var response = restClient.BulkDeleteFiles(ob);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        [Fact]
        public void Bulk_Delete_Files_Input_Missing_ExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.BulkDeleteFiles(ob));
            Assert.Equal(ErrorMessages.ListFilesInputMissing, ex.Message);
        }







        [Fact]
        public void Missing_Filed_Null_ExceptionNonAsync()
        {
            TagsRequest ob = new TagsRequest
            {
                Tags = new List<string>()
            };
            ob.Tags.Add("abc");
            ob.FileIds = null;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Message);
        }




        [Fact]
        public void Missing_Remove_Filed_Null_ExceptionNonAsync()
        {
            TagsRequest ob = new TagsRequest
            {
                Tags = new List<string>()
            };
            ob.Tags.Add("abc");
            ob.FileIds = null;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.ManageTags(ob, ""));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Message);
        }


        [Fact]
        public void Missing_AI_Filed_Null_ExceptionNonAsync()
        {
            AiTagsRequest ob = new AiTagsRequest
            {
                AiTags = new List<string>()
            };
            ob.AiTags.Add("abc");
            ob.FileIds = null;

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.RemoveAiTags(ob));
            Assert.Equal(ErrorMessages.InvalidFiledParamValue, ex.Message);
        }

        [Fact]
        public void DeleteFileVersion_DefaultNonAsync()
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

            var response = restClient.DeleteFileVersion(model);
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }

        [Fact]
        public void Missing_Object_FileVersionExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.DeleteFileVersion(model));
            Assert.Equal(ErrorMessages.InvalidDelVerValue, ex.Message);
        }
        [Fact]
        public void Missing_FileId_FileVersionExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.DeleteFileVersion(model));
            Assert.Equal(ErrorMessages.InvalidFieldIdDelVerValue, ex.Message);
        }

        [Fact]
        public void Missing_VersionId_FileVersionExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.DeleteFileVersion(model));
            Assert.Equal(ErrorMessages.InvalidVersionIdDelVerValue, ex.Message);
        }

        [Fact]
        public void CopyFile_DefaultNonAsync()
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
        public void Missing_Obj_CopyFileExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.CopyFile(model));
            Assert.Equal(ErrorMessages.InvalidCopyValue, ex.Message);
        }



        [Fact]
        public void Missing_Source_CopyFileExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.CopyFile(model));
            Assert.Equal(ErrorMessages.InvalidSourceValue, ex.Message);
        }

        [Fact]
        public void Missing_Destination_CopyFileExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.CopyFile(model));
            Assert.Equal(ErrorMessages.InvalidDestinationValue, ex.Message);
        }

        [Fact]
        public void MoveFile_DefaultNonAsync()
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
        public void Missing_Obj_MoveFileExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.MoveFile(model));
            Assert.Equal(ErrorMessages.InvalidCopyValue, ex.Message);
        }

        [Fact]
        public void Missing_Source_MoveFileExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.MoveFile(model));
            Assert.Equal(ErrorMessages.InvalidSourceValue, ex.Message);
        }

        [Fact]
        public void Missing_Destination_MoveFileExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.MoveFile(model));
            Assert.Equal(ErrorMessages.InvalidDestinationValue, ex.Message);
        }

        [Fact]
        public void RenameFile_DefaultNonAsync()
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
        public void Missing_FilePath_RenameFileExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.RenameFile(model));
            Assert.Equal(ErrorMessages.InvalidRenameFilePathValue, ex.Message);
        }
        [Fact]
        public void Missing_NewFileName_RenameFileExceptionNonAsync()
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
            var ex = Assert.Throws<Exception>(() => restClient.RenameFile(model));
            Assert.Equal(ErrorMessages.InvalidRenameNewFileNameValue, ex.Message);
        }


        [Fact]
        public void GetBulkJobStatus_DefaultNonAsync()
        {
            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();
            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);

            var response = restClient.GetBulkJobStatus("abc");
            var result = JsonConvert.DeserializeObject<ResponseMetaData>(response.Raw);
            Assert.Equal(responseObj.Raw, result.Raw);
        }
        [Fact]
        public void Missing_Job_Id_BulkJobStatusExceptionNonAsync()
        {

            var responseObj = TestHelpers.ImagekitResponseFaker.Generate();

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(responseObj))
            };
            var httpClient = TestHelpers.GetTestHttpClient(httpResponse);
            var restClient = new RestClient(GOOD_PUBLICKEY, GOOD_URLENDPOINT, httpClient);
            var ex = Assert.Throws<Exception>(() => restClient.GetBulkJobStatus(""));
            Assert.Equal(ErrorMessages.InvalidJobValue, ex.Message);
        }





    }
}




