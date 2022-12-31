using Imagekit.Constant;
using Imagekit.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;
using RichardSzalay.MockHttp;
using Imagekit.Helper;
using static Imagekit.Models.CustomMetaDataFieldSchemaObject;

namespace Imagekit.UnitTests
{
    public class ImageKitRequestModelValidation
    {

        private const string GOOD_PRIVATEKEY = "private_key";
        private const string GOOD_URLENDPOINT = "https://endpoint_url.io/";

        [Fact]
        public void UploadFileRequest_ModelValidation()
        {
            string json = "--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=fileName\r\n\r\ntest.jpg\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=file\r\n\r\nhttps://homepages.cae.wisc.edu/~ece533/images/cat.png\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=useUniqueFileName\r\n\r\ntrue\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=tags\r\n\r\nSoftware,Developer,Engineer\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=folder\r\n\r\ndummy-folder\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=customCoordinates\r\n\r\n10,10,20,20\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=overwriteFile\r\n\r\ntrue\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=overwriteAITags\r\n\r\ntrue\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=overwriteTags\r\n\r\ntrue\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=overwriteCustomMetadata\r\n\r\nfalse\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=extensions\r\n\r\n[{\"options\":{\"add_shadow\":true,\"semitransparency\":false,\"bg_image_url\":\"http://www.google.com/images/logos/ps_logo2.png\"},\"name\":\"remove-bg\"},{\"minConfidence\":95,\"maxTags\":5,\"name\":\"google-auto-tagging\"}]\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=webhookUrl\r\n\r\nhttps://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e\r\n--ImageKit-dLV9Wyq26L\r\nContent-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=customMetadata\r\n\r\n{\"price\":2000}\r\n--ImageKit-dLV9Wyq26L--\r\n";
            string url = "https://upload.imagekit.io/api/v1/files/upload";
            FileCreateRequest ob = new FileCreateRequest
            {
                file = "https://homepages.cae.wisc.edu/~ece533/images/cat.png",
                fileName = "test.jpg",
            };
            List<string> tags = new List<string>
            {
                "Software",
                "Developer",
                "Engineer"
            };
            ob.tags = tags;

            string customCoordinates = "10,10,20,20";
            ob.customCoordinates = customCoordinates;
            List<Extension> model1 = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                name = "remove-bg",
                options = new options() { add_shadow = true, semitransparency = false, bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            AutoTags autoTags = new AutoTags
            {
                name = "google-auto-tagging",
                maxTags = 5,
                minConfidence = 95
            };
            model1.Add(bck);
            model1.Add(autoTags);
            ob.extensions = model1;
            ob.webhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.customMetadata = model;
            ob.useUniqueFileName = true;
            ob.folder = "dummy-folder";
            ob.isPrivateFile = false;
            ob.overwriteFile = true;
            ob.overwriteAITags = true;
            ob.overwriteTags = true;
            ob.overwriteCustomMetadata = true;
            List<string> responseFields = new List<string>
                {
                    "isPrivateFile",
                    "tags",
                    "customCoordinates"
                };
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(json)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");
            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.Upload(ob);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void UpdateFileDetail_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/details", "file-Id");
            FileUpdateRequest ob = new FileUpdateRequest
            {
                fileId = "file-Id",

            };
            List<string> tags = new List<string>
            {
                "Software",
                "Developer",
                "Engineer"
            };
            ob.tags = tags;

            string customCoordinates = "10,10,20,20";
            ob.customCoordinates = customCoordinates;
            List<Extension> modelExt = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                name = "remove-bg",
                options = new options() { add_shadow = true, semitransparency = false, bg_color = "green", bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            AutoTags autoTags = new AutoTags
            {
                name = "google-auto-tagging",
                maxTags = 5,
                minConfidence = 95
            };
            modelExt.Add(autoTags);
            modelExt.Add(bck);
            ob.extensions = modelExt;
            ob.webhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            Hashtable model = new Hashtable
            {
                { "price", 2000 }
            };
            ob.customMetadata = model;
            string result = "{\"fileId\":\"file-Id\",\"webhookUrl\":\"https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e\",\"extensions\":[{\"minConfidence\":95,\"maxTags\":5,\"name\":\"google-auto-tagging\"},{\"options\":{\"add_shadow\":true,\"semitransparency\":false,\"bg_color\":\"green\",\"bg_image_url\":\"http://www.google.com/images/logos/ps_logo2.png\"},\"name\":\"remove-bg\"}],\"tags\":[\"Software\",\"Developer\",\"Engineer\"],\"customCoordinates\":\"10,10,20,20\",\"customMetadata\":{\"price\":2000}}";
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(result)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.UpdateFileDetail(ob);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetFileListRequest_ModelValidation()
        {
            GetFileListRequest ob = new GetFileListRequest
            {
                Limit = 10,
                Skip = 20,
                Type = "Test",
                Path = "Test",
                Sort = "Test",
                SearchQuery = "Test",
                FileType = "Test"

            };
            string param = "sort=Test&path=Test&searchQuery=Test&fileType=Test&limit=10&skip=20";
            string url = string.Format("https://api.imagekit.io/v1/files/?{0}", param);

            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetFileListRequest(ob);
            mockHttp.VerifyNoOutstandingExpectation();
        }
        [Fact]
        public void PurgeCache_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/purge");
            string reqJosn = "{\"url\":\"path\"}";
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.PurgeCache("path");
            mockHttp.VerifyNoOutstandingExpectation();
        }
        [Fact]
        public void DeleteFileRequest_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/", "fileId");

            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Delete))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.DeleteFile("fileId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void PurgeStatusRequest_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/purge/{0}", "purgeRequestId");

            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.PurgeStatus("purgeRequestId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetFileDetailRequest_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/details", "fileId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetFileDetail("fileId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void BulkDeleteFilesRequest_ModelValidation()
        {
            string reqJosn = "{\"fileIds\":[\"fileId1\",\"fileId2\"]}";

            List<string> fileIds = new List<string>
            {
                "fileId1",
                "fileId2"
            };
            string url = string.Format("https://api.imagekit.io/v1/files/batch/deleteByfileIds");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.BulkDeleteFiles(fileIds);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetFileMetaDataRequest_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/metadata", "fileId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetFileMetaData("fileId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetRemoteFileMetaDataRequest_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/metadata?url={0}", "url");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetRemoteFileMetaData("url");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void AddTagsRequest_ModelValidation()
        {
            string reqJosn = "{\"fileIds\":[\"abc\"],\"tags\":[\"abc\",\"abc\"]}";

            TagsRequest tagsRequest = new TagsRequest
            {
                tags = new List<string>
                {
                    "abc",
                    "abc"
                },
                fileIds = new List<string>
                {
                    "abc"
                }
            };
            string url = "https://api.imagekit.io/v1/files/addTags";
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.ManageTags(tagsRequest, "addTags");
            mockHttp.VerifyNoOutstandingExpectation();
        }
        [Fact]
        public void RemoveTagsRequest_ModelValidation()
        {
            string reqJosn = "{\"fileIds\":[\"abc\"],\"tags\":[\"abc\",\"abc\"]}";

            TagsRequest tagsRequest = new TagsRequest
            {
                tags = new List<string>
                {
                    "abc",
                    "abc"
                },
                fileIds = new List<string>
                {
                    "abc"
                }
            };
            string url = string.Format("https://api.imagekit.io/" + UrlHandler.RemoveTags);
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.ManageTags(tagsRequest, "removeTags");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void RemoveAITagsRequest_ModelValidation()
        {
            string reqJosn = "{\"fileIds\":[\"abc\"],\"AITags\":[\"abc\",\"abc\"]}";

            AITagsRequest tagsRequest = new AITagsRequest
            {
                AITags = new List<string>
                {
                    "abc",
                    "abc"
                },
                fileIds = new List<string>
                {
                    "abc"
                }
            };
            string url = string.Format("https://api.imagekit.io/" + UrlHandler.RemoveAITags);
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.RemoveAITags(tagsRequest);
            mockHttp.VerifyNoOutstandingExpectation();
        }
        [Fact]
        public void GetCustomMetaDataFields_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/customMetadataFields?includeDeleted={0}", true);
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetCustomMetaDataFields(true);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetCustomMetaDataFieldsEmpty_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/customMetadataFields?includeDeleted={0}", false);
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetCustomMetaDataFields();
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetCustomMetaDataFieldsFalse_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/customMetadataFields?includeDeleted={0}", false);
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetCustomMetaDataFields(false);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void CreateCustomMetaDataFields_ModelValidation()
        {
            string reqJosn = "{\n    \"name\": \"Tst3\",\n    \"label\": \"Test3\",\n    \"schema\": {\n        \"type\": \"Number\",\n        \"minValue\": 1000,\n        \"maxValue\": 3000,\n        \"isValueRequired\": true,\n        \"defaultValue\": 2500\n    }\n}";
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = "Tst3",
                label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                type = "Number",
                minValue = 1000,
                maxValue = 3000,
                isValueRequired = true,
                defaultValue = 2500

            };
            model.schema = schema;
            string url = "https://api.imagekit.io/v1/customMetadataFields";
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.CreateCustomMetaDataFields(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void CreateCustomMetaDataFields2_ModelValidation()
        {
            string reqJosn = "{\n    \"name\": \"Tst3\",\n    \"label\": \"Test3\",\n    \"schema\": {\n        \"type\": \"Number\",\n        \"minValue\": 1000,\n        \"maxValue\": 3000,\n        \"isValueRequired\": false\n    }\n}";
            CustomMetaDataFieldCreateRequest model = new CustomMetaDataFieldCreateRequest
            {
                name = "Tst3",
                label = "Test3"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                type = "Number",
                minValue = 1000,
                maxValue = 3000

            };
            model.schema = schema;
            string url = "https://api.imagekit.io/v1/customMetadataFields";
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.CreateCustomMetaDataFields(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void UpdateCustomMetaDataFields_ModelValidation()
        {
            string reqJosn = "{\n    \"schema\": {\n        \"type\": \"Number\",\n        \"minValue\": 300,\n        \"maxValue\": 500\n    }\n}";
            CustomMetaDataFieldUpdateRequest requestUpdateModel = new CustomMetaDataFieldUpdateRequest
            {
                Id = "field_Id",
            };
            CustomMetaDataFieldSchemaObject updateschema = new CustomMetaDataFieldSchemaObject
            {
                type = "Number",
                minValue = 300,
                maxValue = 500
            };
            requestUpdateModel.schema = updateschema;

            string url = "https://api.imagekit.io/v1/customMetadataFields/field_Id";
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.UpdateCustomMetaDataFields(requestUpdateModel);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void DeleteCustomMetaDataField_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/customMetadataFields/{0}", "id");

            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Delete))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.DeleteCustomMetaDataField("id");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void DeleteFileVersion_ModelValidation()
        {
            DeleteFileVersionRequest model = new DeleteFileVersionRequest
            {
                fileId = "Tst3",
                versionId = "Tst3"
            };
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/versions/{1}", model.fileId,
                model.versionId);
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Delete))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.DeleteFileVersion(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void CopyFile_ModelValidation()
        {
            string reqJosn = "{\"sourceFilePath\":\"Tst3\",\"destinationPath\":\"Tst3\",\"includeFileVersions\":false}";

            CopyFileRequest model = new CopyFileRequest
            {
                sourceFilePath = "Tst3",
                destinationPath = "Tst3"
            };
            string url = string.Empty;
            url = string.Format("https://api.imagekit.io/v1/files/copy");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.CopyFile(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void CopyFile_includeFileVersions_ModelValidation()
        {
            string reqJosn = "{\"sourceFilePath\":\"Tst3\",\"destinationPath\":\"Tst3\",\"includeFileVersions\":true}";

            CopyFileRequest model = new CopyFileRequest
            {
                sourceFilePath = "Tst3",
                destinationPath = "Tst3",
                includeFileVersions = true
            };
            string url = string.Empty;
            url = string.Format("https://api.imagekit.io/v1/files/copy");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.CopyFile(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void MoveFile_ModelValidation()
        {
            string reqJosn = "{\"sourceFilePath\":\"Tst3\",\"destinationPath\":\"Tst3\"}";
            MoveFileRequest model = new MoveFileRequest
            {
                sourceFilePath = "Tst3",
                destinationPath = "Tst3"
            };

            string url = string.Empty;
            url = string.Format("https://api.imagekit.io/v1/files/move");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.MoveFile(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void RenameFile_ModelValidation()
        {
            string reqJosn = "{\"filePath\":\"Tst3\",\"newFileName\":\"Tst4\",\"purgeCache\":false}";
            RenameFileRequest model = new RenameFileRequest
            {
                filePath = "Tst3",
                newFileName = "Tst4",
                purgeCache = false
            };

            string url = string.Empty;
            url = string.Format("https://api.imagekit.io/v1/files/rename");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Put))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.RenameFile(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void RenameFileTrue_ModelValidation()
        {
            string reqJosn = "{\"filePath\":\"Tst3\",\"newFileName\":\"Tst4\",\"purgeCache\":true}";
            RenameFileRequest model = new RenameFileRequest
            {
                filePath = "Tst3",
                newFileName = "Tst4",
                purgeCache = true
            };

            string url = string.Empty;
            url = string.Format("https://api.imagekit.io/v1/files/rename");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Put))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.RenameFile(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void RenameFileDefaultPurge_ModelValidation()
        {
            string reqJosn = "{\"filePath\":\"Tst3\",\"newFileName\":\"Tst4\",\"purgeCache\":false}";
            RenameFileRequest model = new RenameFileRequest
            {
                filePath = "Tst3",
                newFileName = "Tst4"
            };

            string url = string.Empty;
            url = string.Format("https://api.imagekit.io/v1/files/rename");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Put))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.RenameFile(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }
        [Fact]
        public void CopyFolder_ModelValidation()
        {
            string reqJosn = "{\"sourceFolderPath\":\"Tst3\",\"destinationPath\":\"Tst3\",\"includeFileVersions\":false}";
            CopyFolderRequest model = new CopyFolderRequest
            {
                sourceFolderPath = "Tst3",
                destinationPath = "Tst3"

            };
            string url = string.Format("https://api.imagekit.io/v1/bulkJobs/copyFolder");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.CopyFolder(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void CopyFolder_includeFileVersions_ModelValidation()
        {
            string reqJosn = "{\"sourceFolderPath\":\"Tst3\",\"destinationPath\":\"Tst3\",\"includeFileVersions\":true}";
            CopyFolderRequest model = new CopyFolderRequest
            {
                sourceFolderPath = "Tst3",
                destinationPath = "Tst3",
                includeFileVersions = true

            };
            string url = string.Format("https://api.imagekit.io/v1/bulkJobs/copyFolder");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.CopyFolder(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void MoveFolder_ModelValidation()
        {
            string reqJosn = "{\"sourceFolderPath\":\"Tst3\",\"destinationPath\":\"Tst3\"}";
            MoveFolderRequest model = new MoveFolderRequest
            {
                sourceFolderPath = "Tst3",
                destinationPath = "Tst3"
            };
            string url = string.Format("https://api.imagekit.io/v1/bulkJobs/moveFolder");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Post))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .WithContent(reqJosn)
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.MoveFolder(model);
            mockHttp.VerifyNoOutstandingExpectation();
        }


        [Fact]
        public void GetBulkJobStatus_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/bulkJobs/{0}", "jobId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetBulkJobStatus("jobId");
            mockHttp.VerifyNoOutstandingExpectation();
        }
        [Fact]
        public void GetFileVersions_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/versions", "fileId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetFileVersions("fileId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void GetFileVersionDetails_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/versions/{1}", "fileId", "versionId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Get))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.GetFileVersionDetails("fileId", "versionId");
            mockHttp.VerifyNoOutstandingExpectation();
        }

        [Fact]
        public void RestoreFileVersion_ModelValidation()
        {
            string url = string.Format("https://api.imagekit.io/v1/files/{0}/versions/{1}/restore", "fileId", "versionId");
            var mockHttp = new MockHttpMessageHandler();
            var request = mockHttp.Expect(url)
                .With(a => a.Method.Equals(HttpMethod.Put))
                .WithHeaders("Authorization: Basic cHJpdmF0ZV9rZXk6")
                .Respond("application/json", "{'name' : 'ImageKit Response'}");

            var client = mockHttp.ToHttpClient();
            RestClient rs = new RestClient(GOOD_PRIVATEKEY, GOOD_URLENDPOINT, client);
            var response = rs.RestoreFileVersion("fileId", "versionId");
            mockHttp.VerifyNoOutstandingExpectation();
        }
    }
}
