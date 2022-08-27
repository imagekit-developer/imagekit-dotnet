// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ImagekitSample
{
    using System;
    using System.Collections.Generic;
    using Imagekit;
    using Imagekit.Models;
    using Imagekit.Models.Response;
    using Imagekit.Sdk;
    using Newtonsoft.Json.Linq;
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
                Url = new Uri(@"http://www.google.com/images/logos/ps_logo2.png"),
                FileName = "file_name.jpg",
            };
            Result resp1 = imagekit.Upload(request);

            // Upload by bytes
            byte[] bytes = System.IO.File.ReadAllBytes(@"image file path");

            FileCreateRequest ob = new FileCreateRequest
            {
                Bytes = bytes,
                FileName = Guid.NewGuid().ToString(),
            };
            List<string> tags = new List<string>
                {
                    "Software",
                    "Developer",
                    "Engineer"
                };
            ob.Tags = tags;

            string customCoordinates = "10,10,20,20";
            ob.CustomCoordinates = customCoordinates;
            List<string> responseFields = new List<string>
                {
                    "isPrivateFile",
                    "tags",
                    "customCoordinates"
                };
            ob.ResponseFields = responseFields;
            List<Extension> ext = new List<Extension>();
            BackGroundImage bck1 = new BackGroundImage
            {
                Name = "remove-bg",
                Options = new Options() { Add_shadow = true, Semitransparency = false, Bg_color = "green", Bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            ext.Add(bck1);
            ob.WebhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            Hashtable model2 = new Hashtable
            {
                { "price", 2000 }
            };
            ob.CustomMetadata = model2;
            Result resp2 = imagekit.Upload(ob);

            // Get Base64
            byte[] imageArray = System.IO.File.ReadAllBytes(@"image file path");
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            // Upload by Base64
            FileCreateRequest ob2 = new FileCreateRequest
            {
                Base64 = base64ImageRepresentation,
                FileName = Guid.NewGuid().ToString(),
            };
            Result resp = imagekit.Upload(ob2);
            #endregion

            #region UpdateFile

            // Update File Request
            FileUpdateRequest updateob = new FileUpdateRequest
            {
                FileId = "file_Id",

            };
            List<string> updatetags = new List<string>
            {
                "Software",
                "Developer",
                "Engineer"
            };
            updateob.Tags = updatetags;

            string updatecustomCoordinates = "10,10,20,20";
            updateob.CustomCoordinates = updatecustomCoordinates;
            List<string> updateresponseFields = new List<string>
            {
                "isPrivateFile",
                "tags",
                "customCoordinates"
            };
            ob.ResponseFields = updateresponseFields;
            List<Extension> extModel = new List<Extension>();
            BackGroundImage bck = new BackGroundImage
            {
                Name = "remove-bg",
                Options = new Options() { Add_shadow = true, Semitransparency = false, Bg_color = "green", Bg_image_url = "http://www.google.com/images/logos/ps_logo2.png" }
            };
            extModel.Add(bck);
            ob.WebhookUrl = "https://webhook.site/c78d617f-33bc-40d9-9e61-608999721e2e";
            Hashtable updatemodel = new Hashtable
            {
                { "price", 2000 }
            };
            ob.CustomMetadata = updatemodel;
            Result updateresp = imagekit.UpdateFileDetail(updateob);

            #endregion

            #region File Management

            // List and search files
            GetFileListRequest model = new GetFileListRequest
            {
                Type = "file",
                Limit = 10,
                Skip = 0,
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
                SourceFilePath = "path_1",
                DestinationPath = "path_2",
                IncludeFileVersions = true,
            };
            ResultNoContent resultNoContent = imagekit.CopyFile(cpyRequest);

            // MoveFile
            MoveFileRequest moveFile = new MoveFileRequest
            {
                SourceFilePath = "path_1",
                DestinationPath = "path_2",
            };
            ResultNoContent resultNoContentMoveFile = imagekit.MoveFile(moveFile);

            // RenameFile
            RenameFileRequest renameFileRequest = new RenameFileRequest
            {
                FilePath = "path_1",
                NewFileName = "file_name",
                PurgeCache = false,
            };
            ResultRenameFile resultRenameFile = imagekit.RenameFile(renameFileRequest);

            #endregion

            #region  Tags
            TagsRequest tagsRequest = new TagsRequest
            {
                Tags = new List<string>
                {
                    "tag_1",
                    "tag_2",
                },
                FileIds = new List<string>
                {
                    "field_1",
                },
            };
            ResultTags resultTags = imagekit.AddTags(tagsRequest);

            TagsRequest removeTagsRequest = new TagsRequest
            {
                Tags = new List<string>
                {
                    "tag_1",
                    "tag_2",
                },
                FileIds = new List<string>
                {
                    "field_1",
                },
            };
            ResultTags removeTags = imagekit.RemoveTags(removeTagsRequest);

            AiTagsRequest removeAiTagsRequest = new AiTagsRequest
            {
                AiTags = new List<string>
                {
                    "tag_1",
                    "tag_2",
                },
                FileIds = new List<string>
                {
                    "field_1",
                },
            };
            ResultTags removeAiTags = imagekit.RemoveAiTags(removeAiTagsRequest);

            #endregion

            #region FileVersionRequest
            DeleteFileVersionRequest delRequest = new DeleteFileVersionRequest
            {
                FileId = "file_Id",
                VersionId = "version_Id",
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
                FolderName = "folder_name",
                ParentFolderPath = "source/folder/path",
            };
            ResultEmptyBlock resultEmptyBlock = imagekit.CreateFolder(createFolderRequest);

            // DeleteFolderRequest
            DeleteFolderRequest deleteFolderRequest = new DeleteFolderRequest
            {
                FolderPath = "source/folder/path/folder_name",
            };
            ResultNoContent resultNoContent2 = imagekit.DeleteFolder(deleteFolderRequest);

            // CopyFolder
            CopyFolderRequest cpyFolderRequest = new CopyFolderRequest
            {
                SourceFolderPath = "path_1",
                DestinationPath = "path_2",
                IncludeFileVersions = true,
            };

            ResultOfFolderActions resultOfFolderActions = imagekit.CopyFolder(cpyFolderRequest);

            // MoveFolder
            MoveFolderRequest moveFolderRequest = new MoveFolderRequest
            {
                SourceFolderPath = "path_1",
                DestinationPath = "path_2",
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
            CustomMetaDataFieldCreateRequest requestModel = new CustomMetaDataFieldCreateRequest
            {
                Name = "field_name",
                Label = "field_lable",
            };
            CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataFieldSchemaObject.CustomMetaDataTypeEnum.Number,
                MinValue = 1000,
                MaxValue = 3000,
                MinLength = 500,
                MaxLength = 600,
                IsValueRequired = false,
            };

            requestModel.Schema = schema;
            ResultCustomMetaDataField resultCustomMetaDataField = imagekit.CreateCustomMetaDataFields(requestModel);

            // UpdateCustomMetaDataFields
            CustomMetaDataFieldUpdateRequest requestUpdateModel = new CustomMetaDataFieldUpdateRequest
            {
                Id = "field_id",
            };
            CustomMetaDataFieldSchemaObject updateschema = new CustomMetaDataFieldSchemaObject
            {
                Type = CustomMetaDataFieldSchemaObject.CustomMetaDataTypeEnum.Number,
                MinValue = 1000,
                MaxValue = 3000,
                MinLength = 500,
                MaxLength = 600,
                IsValueRequired = false,
            };

            requestUpdateModel.Schema = schema;
            ResultCustomMetaDataField resultCustomMetaDataFieldUpdate = imagekit.UpdateCustomMetaDataFields(requestUpdateModel);

            // Delete Custom MetaData
            ResultNoContent resultNoContentDel = imagekit.DeleteCustomMetaDataField("field_id");
            #endregion
        }
    }
}
