// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ImagekitSample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net;
    using Imagekit;
    using Imagekit.Models;
    using Imagekit.Models.Response;
    using Imagekit.Sdk;
    using static Imagekit.Models.CustomMetaDataFieldSchemaObject;

    internal class Program
    {
        static void Main(string[] args)
        {

            // Create Instance of ImageKit
            ImagekitClient imagekit = new ImagekitClient("your_public_key", "your_private_key", "https://ik.imagekit.io/your_imagekit_id/endpoint");
            #region URL Generation


            // Generating URLs

            string path = "/default_image.jpg";
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
                OverlayImage("/folder/file_name.jpg"). // leading slash case
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
                DefaultImage("folder/file_name.jpg/"). //trailing slash case
                Dpr(3).
                EffectSharpen(10).
                EffectUsm("2-2-0.8-0.024").
                EffectContrast(true).
                EffectGray().
                Original().
                Raw("h-200,w-300,l-image,i-logo.png,l-end");

            string imageUrl = imagekit.Url(trans).Path(path).TransformationPosition("query").Generate();

            Console.WriteLine("Generated image URL - {0}", imageUrl);

            ///// Generating Signed URL
            var imgUrl1 = "https://ik.imagekit.io/demo/default-image.jpg";
            string[] queryParams = { "b=query", "a=value" };
            try
            {
                var signedUrl = imagekit.Url(new Transformation().Width(400).Height(300))
                .Src(imgUrl1)
                .QueryParameters(queryParams)
                .ExpireSeconds(600)
                .Signed()
                .Generate();
                Console.WriteLine("Signed Url for first image transformed with height: 300, width: 400: - {0}", signedUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region  Upload BY URI| Bytes | Base64

            // Upload By URI
            FileCreateRequest request = new FileCreateRequest
            {
                file = "http://www.google.com/images/logos/ps_logo2.png",
                fileName = "file_name.jpg"
            };
            Result resp1 = imagekit.Upload(request);

            // Upload by bytes
            var webClient = new WebClient();
            byte[] bytes = webClient.DownloadData("http://www.google.com/images/logos/ps_logo2.png");

            FileCreateRequest ob = new FileCreateRequest
            {
                file = bytes,
                fileName = "file_name1.jpg"
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
            List<string> responseFields = new List<string>
            {
                "isPrivateFile",
                "tags",
                "customCoordinates"
            };
            ob.responseFields = responseFields;
            List<Extension> ext = new List<Extension>();
            BackGroundImage bck1 = new BackGroundImage
            {
                name = "remove-bg",
                options = new options()
                { add_shadow = true, semitransparency = false, bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            AutoTags autoTags = new AutoTags
            {
                name = "google-auto-tagging",
                maxTags = 5,
                minConfidence = 95
            };
            ext.Add(bck1);
            ext.Add(autoTags);
            ob.extensions = ext;
            ob.webhookUrl = "https://webhook.site/c78d617f_33bc_40d9_9e61_608999721e2e";
            ob.useUniqueFileName = true;
            ob.folder = "dummy_folder";
            ob.isPrivateFile = false;
            ob.overwriteFile = true;
            ob.overwriteAITags = true;
            ob.overwriteTags = true;
            ob.overwriteCustomMetadata = true;
            Result resp2 = imagekit.Upload(ob);

            // Get Base64
            byte[] bytes1 = webClient.DownloadData("http://www.google.com/images/logos/ps_logo2.png");

            byte[] imageArray = bytes1;
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            // Upload by Base64
            FileCreateRequest ob2 = new FileCreateRequest
            {
                file = base64ImageRepresentation,
                fileName = Guid.NewGuid().ToString()
            };
            Result resp = imagekit.Upload(ob2);
            #endregion

            #region UpdateFile

            //Update File Request
            FileUpdateRequest updateob = new FileUpdateRequest
            {
                fileId = "fileId",
            };
            List<string> updatetags = new List<string>
            {
                "Software",
                "Developer",
                "Engineer"
            };
            updateob.tags = updatetags;

            string updatecustomCoordinates = "10,10,20,20";
            updateob.customCoordinates = updatecustomCoordinates;
            List<string> updateresponseFields = new List<string>
            {
                "isPrivateFile",
                "tags",
                "customCoordinates"
            };

            List<Extension> extModel = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                name = "remove-bg",
                options = new options() { add_shadow = true, semitransparency = false, bg_color = "green" }
            };
            extModel.Add(bck);
            updateob.extensions = extModel;
            updateob.webhookUrl = "https://webhook.site/c78d617f_33bc_40d9_9e61_608999721e2e";

            Result updateresp = imagekit.UpdateFileDetail(updateob);

            #endregion

            #region File Management

            // List and search files
            GetFileListRequest model = new GetFileListRequest
            {
                Name = "file_name.jpg",
                Type = "file",
                Limit = 10,
                Skip = 0,
                Sort = "ASC_CREATED",
                SearchQuery = "createdAt >= \"7d\"",
                FileType = "image",
                Tags = new string[] { "sale", "summer" },
                Path = "/"
            };
            ResultList res = imagekit.GetFileListRequest(model);

            // Get File Details
            Result res1 = imagekit.GetFileDetail("file_Id");

            // Delete File by FileId
            ResultDelete res2 = imagekit.DeleteFile("file_Id");

            // Bulk Delete
            List<string> ob3 = new List<string>();
            ob3.Add("fileId_1");
            ob3.Add("fileId_2");
            ResultFileDelete resultFileDelete = imagekit.BulkDeleteFiles(ob3);

            // Copy File
            CopyFileRequest cpyRequest = new CopyFileRequest
            {
                sourceFilePath = "path_1",
                destinationPath = "path_2"
            };
            ResultNoContent resultNoContent = imagekit.CopyFile(cpyRequest);

            // MoveFile
            MoveFileRequest moveFile = new MoveFileRequest
            {
                sourceFilePath = "path_1",
                destinationPath = "path_2"
            };
            ResultNoContent resultNoContentMoveFile = imagekit.MoveFile(moveFile);

            // RenameFile
            RenameFileRequest renameFileRequest = new RenameFileRequest
            {
                filePath = "path_1",
                newFileName = "file_name",
                purgeCache = false
            };
            ResultRenameFile resultRenameFile = imagekit.RenameFile(renameFileRequest);

            #endregion

            #region  Tags
            TagsRequest tagsRequest = new TagsRequest
            {
                tags = new List<string>
                {
                    "tag_1",
                    "tag_2"
                },
                fileIds = new List<string>
                {
                    "fileId_1",
                },
            };
            ResultTags resultTags = imagekit.AddTags(tagsRequest);

            TagsRequest removeTagsRequest = new TagsRequest
            {
                tags = new List<string>
                {
                    "tag_1",
                    "tag_2"
                },
                fileIds = new List<string>
                {
                    "fileId_1",
                },
            };
            ResultTags removeTags = imagekit.RemoveTags(removeTagsRequest);

            AITagsRequest removeAITagsRequest = new AITagsRequest
            {
                AITags = new List<string>
                {
                    "tag_1",
                    "tag_2"
                },
                fileIds = new List<string>
                {
                    "fileId_1",
                },
            };
            ResultTags removeAITags = imagekit.RemoveAITags(removeAITagsRequest);

            #endregion

            #region FileVersionRequest
            DeleteFileVersionRequest delRequest = new DeleteFileVersionRequest
            {
                fileId = "file_Id",
                versionId = "version_Id"
            };
            ResultNoContent resultNoContent1 = imagekit.DeleteFileVersion(delRequest);

            // RestoreFileVersion
            Result result = imagekit.RestoreFileVersion("file_Id", "version_Id");

            // GetFileVersions
            ResultFileVersions resultFileVersions = imagekit.GetFileVersions("file_Id");

            // GetFileVersionDetails
            ResultFileVersionDetails resultFileVersionDetails = imagekit.GetFileVersionDetails("file_Id", "version_Id");

            #endregion

            #region ManageFolder

            CreateFolderRequest createFolderRequest = new CreateFolderRequest
            {
                folderName = "folder_name",
                parentFolderPath = "source/folder/path"
            };
            ResultEmptyBlock resultEmptyBlock = imagekit.CreateFolder(createFolderRequest);

            // DeleteFolderRequest
            DeleteFolderRequest deleteFolderRequest = new DeleteFolderRequest
            {
                folderPath = "source/folder/path/folder_name",
            };
            ResultNoContent resultNoContent2 = imagekit.DeleteFolder(deleteFolderRequest);

            // CopyFolder
            CopyFolderRequest cpyFolderRequest = new CopyFolderRequest
            {
                sourceFolderPath = "path_1",
                destinationPath = "path_2",
                includeFileVersions = true
            };

            ResultOfFolderActions resultOfFolderActions = imagekit.CopyFolder(cpyFolderRequest);

            // MoveFolder
            MoveFolderRequest moveFolderRequest = new MoveFolderRequest
            {
                sourceFolderPath = "path_1",
                destinationPath = "path_2"
            };

            ResultOfFolderActions resultOfFolderActions1 = imagekit.MoveFolder(moveFolderRequest);

            #endregion

            #region GetBulkJobStatus
            ResultBulkJobStatus resultBulkJobStatus = imagekit.GetBulkJobStatus("job_Id");

            #endregion

            #region  Purge

            ResultCache resultCache = imagekit.PurgeCache("url");

            ResultCacheStatus resultCacheStatus = imagekit.PurgeStatus("request_Id");

            #endregion

            #region  Metadata
            ResultMetaData resultMetaData = imagekit.GetFileMetadata("file_Id");

            ResultMetaData resultMetaData1 = imagekit.GetRemoteFileMetadata("https://ik.imagekit.io/demo/medium_cafe_B1iTdD0C.jpg");

            // CustomMetaDataFields
            ResultCustomMetaDataFieldList resultCustomMetaDataFieldList = imagekit.GetCustomMetaDataFields(true);

            // CreateCustomMetaDataFields
            CustomMetaDataFieldCreateRequest requestModelDate = new CustomMetaDataFieldCreateRequest
            {
                name = "custom_meta_Date",
                label = "TestmetaDat"
            };
            CustomMetaDataFieldSchemaObject schemaDate = new CustomMetaDataFieldSchemaObject
            {
                type = CustomMetaDataTypeEnum.Date.ToString(),
                minValue = "2022-11-30T10:11:10+00:00",
                maxValue = "2022-12-30T10:11:10+00:00",
                isValueRequired = true,
                defaultValue = "2022-12-30T10:11:10+00:00"
            };

            requestModelDate.schema = schemaDate;
            ResultCustomMetaDataField resultCustomMetaDataFieldDate = imagekit.CreateCustomMetaDataFields(requestModelDate);


            CustomMetaDataFieldCreateRequest requestModel = new CustomMetaDataFieldCreateRequest
            {
                name = "custom_meta_1",
                label = "Testmeta"
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                type = CustomMetaDataTypeEnum.Number.ToString(),
                minValue = 2000,
                maxValue = 3000,
                isValueRequired = true,
                defaultValue = 2500
            };

            requestModel.schema = schema;
            ResultCustomMetaDataField resultCustomMetaDataField1 = imagekit.CreateCustomMetaDataFields(requestModel);

            CustomMetaDataFieldCreateRequest requestModel1 = new CustomMetaDataFieldCreateRequest
            {
                name = "custom_meta_2",
                label = "Testmeta"
            };
            CustomMetaDataFieldSchemaObject schema1 = new CustomMetaDataFieldSchemaObject
            {
                type = CustomMetaDataTypeEnum.Text.ToString(),
                minLength = 1000,
                maxLength = 2000,
                isValueRequired = true,
                defaultValue = "2500"
            };

            requestModel1.schema = schema1;
            ResultCustomMetaDataField resultCustomMetaDataField = imagekit.CreateCustomMetaDataFields(requestModel1);

            CustomMetaDataFieldCreateRequest requestModelSelect = new CustomMetaDataFieldCreateRequest
            {
                name = "custom_meta_Select1",
                label = "TestmetaSelect1"
            };
            CustomMetaDataFieldSchemaObject schemaSelect = new CustomMetaDataFieldSchemaObject
            {
                type = CustomMetaDataTypeEnum.SingleSelect.ToString(),
                selectOptions = new string[] { "small", "medium", "large" },
                isValueRequired = true,
                defaultValue = "medium"
            };
            requestModelSelect.schema = schemaSelect;
            ResultCustomMetaDataField resultCustomMetaDataFieldSelect = imagekit.CreateCustomMetaDataFields(requestModelSelect);


            // UpdateCustomMetaDataFields
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
            ResultCustomMetaDataField resultCustomMetaDataFieldUpdate = imagekit.UpdateCustomMetaDataFields(requestUpdateModel);

            //Delete Custom MetaData
            ResultNoContent resultNoContentDel = imagekit.DeleteCustomMetaDataField("field_id");
						
			 /// Get Authentication Token
        var authenticationParameters = imagekit.GetAuthenticationParameters("your_token");
        Console.WriteLine("Authentication Parameters: {0}", JToken.FromObject(authenticationParameters).ToString());
            #endregion
        }
    }
}
