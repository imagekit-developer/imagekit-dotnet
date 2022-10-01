[<img width="250" alt="ImageKit.io" src="https://raw.githubusercontent.com/imagekit-developer/imagekit-javascript/master/assets/imagekit-light-logo.svg"/>](https://imagekit.io)

## DotNET (NET45/Standard/Core) SDK for ImageKit

[![CI Pipeline](https://github.com/imagekit-developer/imagekit-dotnet/workflows/CI%20Pipeline/badge.svg?branch=master)](https://github.com/imagekit-developer/imagekit-dotnet) [![NuGet](https://img.shields.io/nuget/v/imagekit.svg)](https://www.nuget.org/packages/Imagekit) [![codecov](https://codecov.io/gh/imagekit-developer/imagekit-dotnet/branch/master/graph/badge.svg)](https://codecov.io/gh/imagekit-developer/imagekit-dotnet) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) [![Twitter Follow](https://img.shields.io/twitter/follow/imagekitio?label=Follow&style=social)](https://twitter.com/ImagekitIo)

ImageKit DotNET SDK allows you to use [image resizing](https://docs.imagekit.io/features/image-transformations), [optimization](https://docs.imagekit.io/features/image-optimization), [file uploading](https://docs.imagekit.io/api-reference/upload-file-api) and other [ImageKit APIs](https://docs.imagekit.io/api-reference/api-introduction) from applications written in server-side C#.

##### Table of contents

*   [Installation](#installation)
*   [Initialization](#initialization)
*   [URL generation](#url-generation)
*   [File Upload](#file-upload)
*   [File Management](#file-management)
*   [Tags](#tags-management)
*   [Manage Folder](#folder-management)
*   [Bulk Job Status](#job-management)
*   [Purge](#purge)
*   [Meta Data](#metadata)
*   [Utility functions](#utility-functions)
*   [Support](#support)
*   [Links](#links)

## Installation

Package Manager

```cs
Install-Package Imagekit
```

PackageReference

```html
<PackageReference Include="Imagekit" Version="3.1.6">
</PackageReference>
```

.Net CLI

```cs
dotnet add package Imagekit --version 3.1.6
```

Open up your project, navigate to the Nuget package manager console, and add the Imagekit package.  
Also, you can search for [Imagekit](https://www.nuget.org/packages/Imagekit) in Nuget GUI.

## Initialization

Add this reference where you want to use imagekit.io services:

```cs
using Imagekit;

ImageKitClient imagekit = new ImageKitClient(publicKey, privateKey, urlEndPoint);
```

**Note**: You can get the `apiKey`, `apiSecret`, and ImagekitId from your [Imagekit.io dashboard](https://imagekit.io/dashboard).

## Demo application

The fastest way to get started is by running the demo application in the [ImageKitSample](/ImageKitSample) folder.

## Usage

You can use this DotNET SDK for three different functions: URL generation, file uploads, and file management. The usage of the SDK has been explained below.

### URL Generation

**1\. Using image path and image hostname or endpoint**

This method allows you to create a URL using the `path` where the image exists and the URL endpoint (`urlEndpoint`) you want to use to access the image. You can refer to the documentation [here](https://docs.imagekit.io/integration/url-endpoints) to read more about URL endpoints in ImageKit and the section about [image origins](https://docs.imagekit.io/integration/configure-origin) to understand paths with different kinds of origins.

```cs
string path = "/default_image.jpg";
Transformation trans = new Transformation()
.Width(400)
.Height(300)
.AspectRatio("4-3")
.Quality(40)
.Crop("force")
.CropMode("extract")
.Focus("left")
.Format("jpeg")  
.Raw("h-200,w-300,l-image,i-logo.png,l-end");

string imageURL = imagekit.Url(trans).Path(path).TransformationPosition("query").Generate();    
```

This results in a URL like

```plaintext
https://ik.imagekit.io/default_image.jpg?tr=w-400%2Ch-300%2Car-4-3%2Cq_40%2Cc-force%2Ccm-extract%2Cfo-left%2Cf-jpeg%2Ch-200%2Cw-300%2Cl-image%2Ci-logo.png%2Cl-end
```

**2\. Using full image URL**

This method allows you to add transformation parameters to an existing, complete URL that is already mapped to ImageKit using the `src` parameter. This method should be used if you have the complete URL mapped to ImageKit stored in your database.

```cs
string imageURL = imagekit.Url(new Transformation().Width(400).Height(300))
    .Src("https://ik.imagekit.io/your_imagekit_id/endpoint/default_image.jpg")
    .Generate();
```

This results in a URL like

```plaintext
https://ik.imagekit.io/your_imagekit_id/endpoint/default_image.jpg?tr=h-300,w-400
```

The `.Url()` method accepts the following parameters.

| Option | Description |
| --- | --- |
| urlEndpoint | Optional. The base URL has to be appended before the path of the image. If not specified, the URL Endpoint specified at the time of SDK initialization is used. For example, `https://ik.imagekit.io/your_imagekit_id/endpoint/` |
| path | Conditional. This is the path on which the image exists. For example, `/path/to/image.jpg`. Either the `path` or `src` parameter needs to be specified for URL generation. |
| src | Conditional. This is the complete URL of an image already mapped to ImageKit. For example, `https://ik.imagekit.io/your_imagekit_id/endpoint/path/to/image.jpg`. Either the `path` or `src` parameter needs to be specified for URL generation. |
| transformation | Optional. An array of objects specifying the transformation to be applied in the URL. The transformation name and the value should be specified as a key-value pair in the object. Different steps of a [chained transformation](https://docs.imagekit.io/features/image-transformations/chained-transformations) can be specified as the array's different objects. The complete list of supported transformations in the SDK and some examples of using them are given later. If you use a transformation name that is not specified in the SDK, it gets applied as it is in the URL. |
| transformationPosition | Optional. The default value is `path` that places the transformation string as a URL path parameter. It can also be specified as `query`, which adds the transformation string as the URL's query parameter `tr`. If you use the `src` parameter to create the URL, then the transformation string is always added as a query parameter. |
| queryParameters | Optional. These are the other query parameters that you want to add to the final URL. These can be any query parameters and not necessarily related to ImageKit. Especially useful if you want to add some versioning parameters to your URLs. |
| signed | Optional. Boolean. Default is `false`. If set to `false`, the SDK generates a signed image URL by adding the image signature to the image URL. This can only be used if you create the URL with the `urlEndpoint` and `path` parameters, not with the `src` parameter. |
| expireSeconds | Optional. Integer. It is meant to be used along with the `signed` parameter to specify the time in seconds from now when the URL should expire. If specified, the URL contains the expiry timestamp in the URL, and the image signature is modified accordingly. |

#### Examples of generating URLs

**1\. Chained Transformations as a query parameter**

```cs
Transformation transformation = new Transformation()
    .Width(400).Height(300)
    .Chain()
    .Rotation(90);
    
string imageURL = imagekit.Url(transformation)
    .Path("/default_image.jpg")
    .UrlEndpoint("https://ik.imagekit.io/your_imagekit_id/endpoint")
    .TransformationPosition("query")
    .Generate();
```

```plaintext
https://ik.imagekit.io/your_imagekit_id/endpoint/default_image.jpg?tr=h-300,w-400:rt-90
```

**2\. Sharpening and contrast transforms and a progressive JPG image**

There are some transforms like [Sharpening](https://docs.imagekit.io/features/image-transformations/image-enhancement-and-color-manipulation) that can be added to the URL with or without any other value.

```cs
string src = "https://ik.imagekit.io/your_imagekit_id/endpoint/default-image.jpg";

Transformation trans = new Transformation()
    .Format("jpg")
    .Progressive(false)
    .EffectSharpen()
    .EffectContrast(1);

string imageURL = imagekit.Url(trans)
    .Src(src)
    .Generate();
```

**Note**: Because `src` parameter was used, the transformation string gets added as a query parameter `tr`.

```plaintext
https://ik.imagekit.io/your_imagekit_id/endpoint/default-image.jpg?tr=f-jpg,pr-false,e-sharpen,e-contrast-1
```

**3\. Signed URL that expires in 600 seconds with the default URL endpoint and other query parameters**

```cs
Transformation trans = new Transformation()
    .Height(300).Width(400);
string[] queryParams = { "v = 123" };

string imageURL = imagekit.Url(trans)
    .Path("/default-image.jpg")
    .QueryParameters(queryParams)
    .Signed(false).ExpireSeconds(600)
    .Generate();
```

```plaintext
https://ik.imagekit.io/your_imagekit_id/tr:h-300,w-400/default-image.jpg?v=123&ik-t=1567358667&ik-s=f2c7cdacbe7707b71a83d49cf1c6110e3d701054
```

#### List of supported transformations

The complete list of transformations supported and their usage in ImageKit can be found [here](https://docs.imagekit.io/features/image-transformations). The SDK gives a name to each transformation parameter, making the code simpler and more readable. If a transformation is supported in ImageKit, but a name for it cannot be found in the table below, then use the transformation code from ImageKit docs as the name when using the `url` function.

| Supported Transformation Name | Translates to parameters |
| --- | --- |
| Height | h |
| Width | w |
| AspectRatio | ar |
| Quality | q |
| Crop | c |
| CropMode | cm |
| X | x |
| Y | y |
| Focus | fo |
| Format | f |
| Radius | r |
| Background | bg |
| Border | b |
| Rotation | rt |
| Blur | bl |
| Named | n |
| OverlayX | ox |
| OverlayY | oy |
| OverlayFocus | ofo |
| OverlayHeight | oh |
| OverlayWidth | ow |
| OverlayImage | oi |
| OverlayImageTrim | oit |
| OverlayImageAspectRatio | oiar |
| OverlayImageBackground | oibg |
| OverlayImageBorder | oib |
| OverlayImageDPR | oidpr |
| OverlayImageQuality | oiq |
| OverlayImageCropping | oic |
| OverlayImageTrim | oit |
| OverlayText | ot |
| OverlayTextFontSize | ots |
| OverlayTextFontFamily | otf |
| OverlayTextColor | otc |
| OverlayTextTransparency | oa |
| OverlayAlpha | oa |
| OverlayTextTypography | ott |
| OverlayBackground | obg |
| OverlayTextEncoded | ote |
| OverlayTextWidth | otw |
| OverlayTextBackground | otbg |
| OverlayTextPadding | otp |
| OverlayTextInnerAlignment | otia |
| OverlayRadius | or |
| Progressive | pr |
| Lossless | lo |
| Trim | t |
| Metadata | md |
| ColorProfile | cp |
| DefaultImage | di |
| Dpr | dpr |
| EffectSharpen | e-sharpen |
| EffectUSM | e-usm |
| EffectContrast | e-contrast |
| EffectGray | e-grayscale |
| Original | orig |
| Raw | `replaced by the parameter value` |

### File Upload

The SDK provides a simple interface using the `.upload()` method to upload files to the ImageKit Media Library. It accepts all the parameters supported by the [ImageKit Upload API](https://docs.imagekit.io/api-reference/upload-file-api/server-side-file-upload).

The `upload()` method requires at least the `file` and the `fileName` parameter to upload a file. You can pass other parameters supported by the ImageKit upload API using the same parameter name as specified in the upload API documentation. For example, to specify tags for a file at the time of upload, use the `tags` parameter as specified in the [documentation here](https://docs.imagekit.io/api-reference/upload-file-api/server-side-file-upload).

Sample usage

```cs
 // Upload By URI
FileCreateRequest request = new FileCreateRequest
{
	file = "http://www.google.com/images/logos/ps_logo2.png",
	fileName = "file_name.jpg",
};
Result resp1 = imagekit.Upload(request);

// Upload by bytes
byte[] bytes = System.IO.File.ReadAllBytes(@"image file path");

FileCreateRequest ob = new FileCreateRequest
{
	file = bytes,
	fileName = Guid.NewGuid().ToString()
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

//Get Base64 
byte[] imageArray = System.IO.File.ReadAllBytes(@"image file path");
string base64ImageRepresentation = Convert.ToBase64String(imageArray);
// Upload by Base64
FileCreateRequest ob2 = new FileCreateRequest
{
	file=base64ImageRepresentation,
	fileName = Guid.NewGuid().ToString()
};
Result resp = imagekit.Upload(ob2);           
```

### File Management

The SDK provides a simple interface for all the [media APIs mentioned here](https://docs.imagekit.io/api-reference/media-afile-uploadpi) to manage your files.

**1 . List & Search Files**

Accepts an object specifying the parameters to be used to list and search files. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/list-and-search-files) can be passed as it is with the correct values to get the results.

```cs
GetFileListRequest model = new GetFileListRequest
{
Type = "file",
Limit = 10,
Skip = 0,
Sort = "ASC_CREATED",
SearchQuery = "name = \"file_name.jpg\"",
FileType = "image",               
Path= "/"
};
ResultList resp = await imagekit.GetFileDetail(model);
```

**2\. Get File Details**

Accepts the file ID and fetches the details as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/get-file-details).

```cs
Result resp = await imagekit.GetFileDetail(file_Id);
```

**3\. File Update**

Accepts an object of class `FileUpdateRequest` specifying the parameters to be used to update file details. All parameters specified in the \[documentation here\] (https://docs.imagekit.io/api-reference/media-api/update-file-details) can be passed via their setter functions to get the results.

```cs
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
```

**4\. Delete File**

Accept the file ID and delete a file as per the [API documentation here](https://docs.imageKit.io/api-reference/media-api/delete-file).

```cs
String fileId = "file_Id";
ResultDelete result = imageKit.deleteFile(fileId);
```

**5\. Delete files (bulk)**

Accepts the file IDs to delete files as per the [API documentation here](https://docs.imageKit.io/api-reference/media-api/delete-files-bulk).

```cs
List<string> ob3 = new List<string>();
ob3.Add("fileId_1");
ob3.Add("fileId_2");
ResultFileDelete resultFileDelete = imagekit.BulkDeleteFiles(ob3);
```

**6\. Copy file**

Accepts an object of class `CopyFileRequest` specifying the parameters to be used to copy a file. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/copy-file) can be passed via their setter functions to get the results.

```cs
CopyFileRequest cpyRequest = new CopyFileRequest
{
	sourceFilePath = "path_1",
	destinationPath = "path_2",
	includeFileVersions = true
};
ResultNoContent resultNoContent = imagekit.CopyFile(cpyRequest);
```

**7\. Move file**

Accepts an object of class `MoveFileRequest` specifying the parameters to be used to move a file. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/move-file) can be passed via their setter functions to get the results.

```cs
MoveFileRequest moveFile = new MoveFileRequest
{
	sourceFilePath = "path_1",
	destinationPath = "path_2"
};
ResultNoContent resultNoContentMoveFile = imagekit.MoveFile(moveFile);
```

**8\. Rename file**

Accepts an object of class `RenameFileRequest` specifying the parameters to be used to rename a file. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/rename-file) can be passed via their setter functions to get the results.

```cs
RenameFileRequest renameFileRequest = new RenameFileRequest
{
	filePath = "path_1",
	newFileName = "file_name",
	purgeCache = false
};
ResultRenameFile resultRenameFile = imagekit.RenameFile(renameFileRequest);
```

### Tags Management

The SDK provides a simple interface to manage your tags.

**9\. Add tags**

Accepts an object of class `TagsRequest` specifying the parameters to be used to add tags. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/add-tags-bulk) can be passed via their setter functions to get the results.

```cs
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
```

**10\. Remove tags**

Accepts an object of class `TagsRequest` specifying the parameters to be used to remove tags. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/remove-tags-bulk) can be passed via their setter functions to get the results.

```cs
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
```

**11\. Remove AI tags**

Accepts an object of class `AITagsRequest` specifying the parameters to be used to remove AI tags. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/remove-aitags-bulk) can be passed via their setter functions to get the results.

```cs
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
	}
};
ResultTags removeAITags = imagekit.RemoveAITags(removeAITagsRequest);
```

**12\. Get File Versions**

Accepts the file ID and fetches the details as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/get-file-versions).

```cs
String fileId = "file_id_1";
ResultFileVersions resultFileVersions = imageKit.getFileVersions(fileId);
```

**13\. Get File Version details**

Accepts the file ID and version ID and fetches the details as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/get-file-version-details).

```cs
String fileId = "file_Id";
String versionId = "version_Id";
ResultFileVersionDetails resultFileVersionDetails = imageKit.getFileVersionDetails(fileId, versionId);
```

**14\. Delete FileVersion**

Accepts an object of class `DeleteFileVersionRequest` specifying the parameters to be used to delete the file version. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/delete-file-version) can be passed via their setter functions to get the results.

```cs
DeleteFileVersionRequest delRequest = new DeleteFileVersionRequest
{
	fileId = "file_Id",
	versionId = "version_Id"
};
ResultNoContent resultNoContent1 = imagekit.DeleteFileVersion(delRequest);
```

**15\. Restore file Version**

Accepts the fileId and versionId to restore the file version as per the [API documentation here](https://docs.imageKit.io/api-reference/media-api/restore-file-version).

```cs
Result result = imagekit.RestoreFileVersion("file_Id", "version_Id");
```

### Folder Management

**16\. Create Folder**

Accepts an object of class `CreateFolderRequest` specifying the parameters to be used to create a folder. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/create-folder) can be passed via their setter functions to get the results.

```cs
CreateFolderRequest createFolderRequest = new CreateFolderRequest
{
	folderName = "folder_name",
	parentFolderPath = "source/folder/path"
};
ResultEmptyBlock resultEmptyBlock = imagekit.CreateFolder(createFolderRequest);
```

**17\. Copy Folder**

Accepts an object of class `CopyFolderRequest` specifying the parameters to be used to copy a folder. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/copy-folder) can be passed via their setter functions to get the results.

```cs
CopyFolderRequest cpyFolderRequest = new CopyFolderRequest
{
	sourceFolderPath = "path_1",
	destinationPath = "path_2",
	includeFileVersions = true
};

ResultOfFolderActions resultOfFolderActions = imagekit.CopyFolder(cpyFolderRequest);
```

**18\. Move Folder**

Accepts an object of class `MoveFolderRequest` specifying the parameters to be used to move a folder. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/move-folder) can be passed via their setter functions to get the results.

```cs
MoveFolderRequest moveFolderRequest = new MoveFolderRequest
{
	sourceFolderPath="path_1",
	destinationPath="path_2"
};

ResultOfFolderActions resultOfFolderActions1 = imagekit.MoveFolder(moveFolderRequest);
```

**19\. Delete Folder**

Accepts an object of class `DeleteFolderRequest` specifying the parameters to be used to delete a folder. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/media-api/delete-folder) can be passed via their setter functions to get the results.

```cs
DeleteFolderRequest deleteFolderRequest = new DeleteFolderRequest
{
	folderPath="source/folder/path/folder_name",
};
ResultNoContent resultNoContent2 = imagekit.DeleteFolder(deleteFolderRequest);
```

### Job Management

**20\. Get Bulk Job Status**

Accepts the jobId to get bulk job status as per the [API documentation here](https://docs.imageKit.io/api-reference/media-api/copy-move-folder-status).

```cs
String jobId = "job_Id";
ResultBulkJobStatus resultBulkJobStatus = imageKit.getBulkJobStatus(jobId);
```

### Purge

**21\. Purge Cache**

Accepts a full URL of the file for which the cache has to be cleared as per the [API documentation here](https://docs.imageKit.io/api-reference/media-api/purge-cache).

```cs
ResultCache result = imageKit.purgeCache("https://ik.imageKit.io/imagekit-id/default-image.jpg");
```

**22\. Purge Cache Status**

Accepts a request ID and fetch purge cache status as per the [API documentation here](https://docs.imageKit.io/api-reference/media-api/purge-cache-status)

```cs
String requestId = "cache_request_Id";
ResultCacheStatus result = imageKit.getPurgeCacheStatus(requestId);
```

### Metadata

Accepts the file ID and fetches the metadata as per the [API documentation here](https://docs.imageKit.io/api-reference/metadata-api/get-image-metadata-for-uploaded-media-files)

**23\. Get File Metadata**

```cs
String fileId = "file_id";
ResultMetaData result = imageKit.getFileMetadata(fileId);
```

Another way to get metadata from a remote file URL as per the [API documentation here](https://docs.imageKit.io/api-reference/metadata-api/get-image-metadata-from-remote-url). This file should be accessible over the imageKit.io URL-endpoint.

```cs
String url = "Remote File URL";
ResultMetaData result = imageKit.getRemoteFileMetadata(url);
```

**24\. Create Custom MetaData Fields**

Accepts an object of class `CustomMetaDataFieldCreateRequest` specifying the parameters to be used to create cusomMetaDataFields. All parameters specified in the [documentation here](https://docs.imageKit.io/api-reference/custom-metadata-fields-api/create-custom-metadata-field) can be passed as-is with the correct values to get the results.

Check for the [Allowed Values In The Schema](https://docs.imageKit.io/api-reference/custom-metadata-fields-api/create-custom-metadata-field#allowed-values-in-the-schema-object).

#### Examples:

```cs
CustomMetaDataFieldCreateRequest requestModel = new CustomMetaDataFieldCreateRequest
{
    name = "custom-meta-1",
    label = "Testmeta"
};
CustomMetaDataFieldSchemaObject schema = new CustomMetaDataFieldSchemaObject
{
    type = "Number",
    minValue = 2000,
    maxValue = 3000,
    isValueRequired = true,
    defaultValue = "2500"
};

requestModel.schema = schema;
ResultCustomMetaDataField resultCustomMetaDataField1 = imagekit.CreateCustomMetaDataFields(requestModel);
```

*   Date type Example:

```cs
CustomMetaDataFieldCreateRequest requestModelDate = new CustomMetaDataFieldCreateRequest
{
    name = "custom_meta_Date",
    label = "TestmetaDate"
};
CustomMetaDataFieldSchemaObject schemaDate = new CustomMetaDataFieldSchemaObject
{
    type = "Date",
    minValue = "2022-11-30T10:11:10+00:00",
    maxValue = "2022-12-30T10:11:10+00:00"
};
requestModelDate.schema = schemaDate;
ResultCustomMetaDataField resultCustomMetaDataFieldDate = imagekit.CreateCustomMetaDataFields(requestModelDate);
```

**25\. Get CustomMetaDataFields**

Accepts the includeDeleted boolean and fetches the metadata as per the [API documentation here](https://docs.imageKit.io/api-reference/custom-metadata-fields-api/get-custom-metadata-field)

```cs
bool includeDeleted = true;
ResultCustomMetaDataFieldList resultCustomMetaDataFieldList = imageKit.getCustomMetaDataFields(includeDeleted); 
```

**26\. Edit Custom MetaData Fields**

Accepts an ID of customMetaDataField and an object of class `CustomMetaDataFieldUpdateRequest` specifying the parameters to be used to edit cusomMetaDataFields as per the [API documentation here](https://docs.imageKit.io/api-reference/custom-metadata-fields-api/update-custom-metadata-field).

```cs
CustomMetaDataFieldUpdateRequest requestUpdateModel = new CustomMetaDataFieldUpdateRequest
{
	Id = "field_id",
};
CustomMetaDataFieldSchemaObject updateschema = new CustomMetaDataFieldSchemaObject
{
	type = "Number",
	minValue = 8000,
	maxValue = 3000
};

requestUpdateModel.schema = updateschema;
ResultCustomMetaDataField resultCustomMetaDataFieldUpdate = imagekit.UpdateCustomMetaDataFields(requestUpdateModel);
```

**27\. Delete Custom MetaData Fields**

Accepts the id to delete the customMetaDataFields as per the [API documentation here](https://docs.imageKit.io/api-reference/custom-metadata-fields-api/delete-custom-metadata-field).

```cs
ResultNoContent resultNoContent = imageKit.DeleteCustomMetaDataField("field_id");
```

## Utility functions

We have included the following commonly used utility functions in this library.

### Authentication Parameter Generation

If you are looking to implement client-side file upload, you will need a token, expiry timestamp, and a valid signature for that upload. The SDK provides a simple method that you can use in your code to generate these authentication parameters for you.

_Note: The Private API Key should never be exposed in any client-side code. You must always generate these authentication parameters on the server-side_

```cs
AuthParamResponse resp = imageKit.GetAuthenticationParameters();
```

Returns

```javascript
{
    "token" : "unique_token",
    "expire" : "valid_expiry_timestamp",
    "signature" : "generated_signature"
}
```

Both the `token` and `expire` parameters are optional. If not specified, the SDK uses the [uuid](https://www.npmjs.com/package/uuid) package to generate a random token and also generates a valid expiry timestamp internally. The value of the `token` and `expire` used to generate the signature is always returned in the response, no matter if they are provided as an input to this method or not.

### Distance calculation between two pHash values

Perceptual hashing allows you to construct a hash value that uniquely identifies an input image based on an image's contents. [imageKit.io metadata API](https://docs.imageKit.io/api-reference/metadata-api) returns the pHash value of an image in the response. You can use this value to [find a duplicate (or similar) image](https://docs.imageKit.io/api-reference/metadata-api#using-phash-to-find-similar-or-duplicate-images) by calculating the distance between the two images' pHash value.

This SDK exposes `PHashDistance` function to calculate the distance between two pHash values. It accepts two pHash hexadecimal strings and returns a numeric value indicative of the level of difference between the two images.

```cs
public static int CalculateDistance() {
    // asynchronously fetch metadata of two uploaded image files
    // ...
    // Extract pHash strings from both: say 'firstHash' and 'secondHash'
    // ...
    // Calculate the distance between them:
    int distance = imageKit.PHashDistance(firstHash, secondHash);
    return distance;
}
```

#### Distance calculation examples

```cs
imageKit.PHashDistance('firstHash', 'secondHash');
// output: 0 (same image)

imageKit.PHashDistance('firstHash', 'secondHash');
// output: 17 (similar images)

imageKit.PHashDistance('firstHash', 'secondHash');
// output: 37 (dissimilar images)
```

## Handling errors

Catch and respond to invalid data, internal problems, and more.

Imagekit .Net SDK raises exceptions for many reasons, such as being not found, invalid parameters, authentication errors, and internal server errors. We recommend writing code that gracefully handles all possible API exceptions.

#### Example:

```cs
try
{
    // Use ImageKit's SDK to make requests...
}
catch (InvalidOperationException ex)
{
    Console.Write("Invalid operation. Please try again.");
}
catch (FormatException ex)
{
    Console.Write("Not a valid format. Please try again.");
}
catch (WebServiceException webEx)
{
    /*
    webEx.StatusCode        = 400
    webEx.StatusDescription = ArgumentNullException
    webEx.ErrorCode         = ArgumentNullException
    webEx.ErrorMessage      = Value cannot be null. Parameter name: Name
    webEx.StackTrace        = (your Server Exception StackTrace - in DebugMode)
    webEx.ResponseDto       = (your populated Response DTO)
    webEx.ResponseStatus    = (your populated Response Status DTO)
    webEx.GetFieldErrors()  = (individual errors for each field if any)
    */
}
```

## Access request-id, other response headers and HTTP status code

You can access success or error object to access the HTTP status code and response headers.

```cs
// Success
var response = await imagekit.PurgeStatus(requestId);
console.Write(response.statusCode); // 200
// {'content-type': 'application/json', 'x-request-id': 'ee560df4-d44f-455e-a48e-29dfda49aec5'}
console.Write(response.Raw);
try 
{
    await imagekit.PurgeStatus(requestId);
} 
catch (Exception ex) 
{
    console.Write(ex.Message); 
 // {'content-type': 'application/json', 'x-request-id': 'ee560df4-d44f-455e-a48e-29dfda49aec5'}
}
```

## Support

For any feedback or to report any issues or general implementation support, please reach out to [support@imageKit.io](mailto:support@imageKit.io)

## Links

*   [Documentation](https://docs.imageKit.io)
*   [Main website](https://imageKit.io)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) File for details