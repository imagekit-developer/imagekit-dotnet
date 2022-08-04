[<img width="250" alt="ImageKit.io" src="https://raw.githubusercontent.com/imagekit-developer/imagekit-javascript/master/assets/imagekit-light-logo.svg"/>](https://imagekit.io)

# DotNET (NET45/Standard/Core) SDK for ImageKit
[![CI Pipeline](https://github.com/imagekit-developer/imagekit-dotnet/workflows/CI%20Pipeline/badge.svg?branch=master)](https://github.com/imagekit-developer/imagekit-dotnet)
[![NuGet](https://img.shields.io/nuget/v/imagekit.svg)](https://www.nuget.org/packages/Imagekit) 
[![codecov](https://codecov.io/gh/imagekit-developer/imagekit-dotnet/branch/master/graph/badge.svg)](https://codecov.io/gh/imagekit-developer/imagekit-dotnet)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Twitter Follow](https://img.shields.io/twitter/follow/imagekitio?label=Follow&style=social)](https://twitter.com/ImagekitIo)

ImageKit DotNET SDK allows you to use [image resizing](https://docs.imagekit.io/features/image-transformations), [optimization](https://docs.imagekit.io/features/image-optimization), [file uploading](https://docs.imagekit.io/api-reference/upload-file-api) and other [ImageKit APIs](https://docs.imagekit.io/api-reference/api-introduction) from applications written in server-side C#.

##### Table of contents
* [Installation](#installation)
* [Initialization](#initialization)
* [URL generation](#url-generation)
* [File upload](#file-upload)
* [File management](#file-management)
* [Utility functions](#utility-functions)
* [Support](#support)
* [Links](#links)

## Installation

Package Manager
```
Install-Package Imagekit
```

PackageReference
```
<PackageReference Include="Imagekit" Version="3.1.6">
</PackageReference>
```
.Net CLI
```
dotnet add package Imagekit --version 3.1.6
```


Open up your project, navigate to the Nuget package manager console, and add the Imagekit package.
Also, you can search for [Imagekit](https://www.nuget.org/packages/Imagekit) in Nuget GUI.


## Initialization
Add this reference where you want to use imagekit.io services:
```cs
using Imagekit;

ServerImagekit imagekit = new ServerImagekit(publicKey, privateKey, urlEndPoint, "path");
```

**Note**: You can get the `apiKey`, `apiSecret`, and ImagekitId from your [Imagekit.io dashboard](https://imagekit.io/dashboard).

## Demo application
The fastest way to get started is by running the demo application in the [Sample](/Imagekit/Sample) folder.


## Usage
You can use this DotNET SDK for three different functions: URL generation, file uploads, and file management. The usage of the SDK has been explained below.

### URL Generation

**1. Using image path and image hostname or endpoint**

This method allows you to create a URL using the `path` where the image exists and the URL endpoint (`urlEndpoint`) you want to use to access the image. You can refer to the documentation [here](https://docs.imagekit.io/integration/url-endpoints) to read more about URL endpoints in ImageKit and the section about [image origins](https://docs.imagekit.io/integration/configure-origin) to understand paths with different kinds of origins.

```csharp
string imageURL = imagekit.Url(new Transformation().Width(400).Height(300))
    .Path("/default-image.jpg")
    .UrlEndpoint("https://ik.imagekit.io/your_imagekit_id/endpoint")
    .TransformationPosition("query")
    .Generate();
```

This results in a URL like

```
https://ik.imagekit.io/your_imagekit_id/endpoint/tr:h-300,w-400/default-image.jpg
```

**2. Using full image URL**

This method allows you to add transformation parameters to an existing, complete URL that is already mapped to ImageKit using the `src` parameter. This method should be used if you have the complete URL mapped to ImageKit stored in your database.


```csharp
string imageURL = imagekit.Url(new Transformation().Width(400).Height(300))
    .Src("https://ik.imagekit.io/your_imagekit_id/endpoint/default-image.jpg")
    .Generate();
```

This results in a URL like

```
https://ik.imagekit.io/your_imagekit_id/endpoint/default-image.jpg?tr=h-300,w-400
```


The `.Url()` method accepts the following parameters.

| Option           | Description                    |
| :----------------| :----------------------------- |
| urlEndpoint      | Optional. The base URL to be appended before the path of the image. If not specified, the URL Endpoint specified at the time of SDK initialization is used. For example, `https://ik.imagekit.io/your_imagekit_id/endpoint/` |
| path             | Conditional. This is the path at which the image exists. For example, `/path/to/image.jpg`. Either the `path` or `src` parameter needs to be specified for URL generation. |
| src              | Conditional. This is the complete URL of an image already mapped to ImageKit. For example, `https://ik.imagekit.io/your_imagekit_id/endpoint/path/to/image.jpg`. Either the `path` or `src` parameter needs to be specified for URL generation. |
| transformation   | Optional. An array of objects specifying the transformation to be applied in the URL. The transformation name and the value should be specified as a key-value pair in the object. Different steps of a [chained transformation](https://docs.imagekit.io/features/image-transformations/chained-transformations) can be specified as the array's different objects. The complete list of supported transformations in the SDK and some examples of using them are given later. If you use a transformation name that is not specified in the SDK, it gets applied as it is in the URL. |
| transformationPosition | Optional. The default value is `path` that places the transformation string as a URL path parameter. It can also be specified as `query`, which adds the transformation string as the URL's query parameter `tr`. If you use the `src` parameter to create the URL, then the transformation string is always added as a query parameter. |
| queryParameters  | Optional. These are the other query parameters that you want to add to the final URL. These can be any query parameters and not necessarily related to ImageKit. Especially useful if you want to add some versioning parameters to your URLs. |
| signed           | Optional. Boolean. Default is `false`. If set to `true`, the SDK generates a signed image URL adding the image signature to the image URL. This can only be used if you create the URL with the `urlEndpoint` and `path` parameters, not with the `src` parameter. |
| expireSeconds    | Optional. Integer. Meant to be used along with the `signed` parameter to specify the time in seconds from now when the URL should expire. If specified, the URL contains the expiry timestamp in the URL, and the image signature is modified accordingly. |



#### Examples of generating URLs

**1. Chained Transformations as a query parameter**
```csharp
Transformation transformation = new Transformation()
    .Width(400).Height(300)
    .Chain()
    .Rotation(90);

string imageURL = imagekit.Url(transformation)
    .Path("/default-image.jpg")
    .UrlEndpoint("https://ik.imagekit.io/your_imagekit_id/endpoint")
    .TransformationPosition("query")
    .Generate();
```

```
https://ik.imagekit.io/your_imagekit_id/endpoint/default-image.jpg?tr=h-300,w-400:rt-90
```

**2. Sharpening and contrast transforms and a progressive JPG image**

There are some transforms like [Sharpening](https://docs.imagekit.io/features/image-transformations/image-enhancement-and-color-manipulation) that can be added to the URL with or without any other value.

```cs
string src = "https://ik.imagekit.io/your_imagekit_id/endpoint/default-image.jpg";

Transformation trans = new Transformation()
    .Format("jpg")
    .Progressive(true)
    .EffectSharpen()
    .EffectContrast(1);

string imageURL = imagekit.Url(trans)
.Src(src)
.Generate();
```
**Note**: Because `src` parameter was used, the transformation string gets added as a query parameter `tr`.

```
https://ik.imagekit.io/your_imagekit_id/endpoint/default-image.jpg?tr=f-jpg,pr-true,e-sharpen,e-contrast-1
```


**3. Signed URL that expires in 300 seconds with the default URL endpoint and other query parameters**
```cs
Transformation trans = new Transformation()
    .Height(300).Width(400);
string[] queryParams = { "v=123" };

string imageURL = imagekit.Url(trans)
    .Path("/default-image.jpg")
    .QueryParameters(queryParams)
    .Signed(true).ExpireSeconds(300)
    .Generate();
```
```
https://ik.imagekit.io/your_imagekit_id/tr:h-300,w-400/default-image.jpg?v=123&ik-t=1567358667&ik-s=f2c7cdacbe7707b71a83d49cf1c6110e3d701054
```

#### List of supported transformations

The complete list of transformations supported and their usage in ImageKit can be found [here](https://docs.imagekit.io/features/image-transformations). The SDK gives a name to each transformation parameter, making the code simpler and readable. If a transformation is supported in ImageKit, but a name for it cannot be found in the table below, then use the transformation code from ImageKit docs as the name when using in the `url` function.

| Supported Transformation Name | Translates to parameter |
|-------------------------------|-------------------------|
| height | h |
| width | w |
| aspectRatio | ar |
| quality | q |
| crop | c |
| cropMode | cm |
| x | x |
| y | y |
| focus | fo |
| format | f |
| radius | r |
| background | bg |
| border | b |
| rotation | rt |
| blur | bl |
| named | n |
| overlayX | ox |
| overlayY | oy |
| overlayFocus | ofo |
| overlayHeight | oh |
| overlayWidth | ow |
| overlayImage | oi |
| overlayImageTrim | oit |
| overlayImageAspectRatio | oiar |
| overlayImageBackground | oibg |
| overlayImageBorder | oib |
| overlayImageDPR | oidpr |
| overlayImageQuality | oiq |
| overlayImageCropping | oic |
| overlayImageTrim | oit |
| overlayText | ot |
| overlayTextFontSize | ots |
| overlayTextFontFamily | otf |
| overlayTextColor | otc |
| overlayTextTransparency | oa |
| overlayAlpha | oa |
| overlayTextTypography | ott |
| overlayBackground | obg |
| overlayTextEncoded | ote |
| overlayTextWidth | otw |
| overlayTextBackground | otbg |
| overlayTextPadding | otp |
| overlayTextInnerAlignment | otia |
| overlayRadius | or |
| progressive | pr |
| lossless | lo |
| trim | t |
| metadata | md |
| colorProfile | cp |
| defaultImage | di |
| dpr | dpr |
| effectSharpen | e-sharpen |
| effectUSM | e-usm |
| effectContrast | e-contrast |
| effectGray | e-grayscale |
| original | orig |



### File Upload

The SDK provides a simple interface using the `.upload()` method to upload files to the ImageKit Media Library. It accepts all the parameters supported by the [ImageKit Upload API](https://docs.imagekit.io/api-reference/upload-file-api/server-side-file-upload).

The `upload()` method requires at least the `file` and the `fileName` parameter to upload a file. You can pass other parameters supported by the ImageKit upload API using the same parameter name as specified in the upload API documentation. For example, to specify tags for a file at the time of upload, use the `tags` parameter as specified in the [documentation here](https://docs.imagekit.io/api-reference/upload-file-api/server-side-file-upload).

Sample usage
```cs
ResponseMetaData resp = await imagekit .UploadAsync(<fullPath|url|base_64|binary>,"my_file_name.jpg");
```

**Note**: Upload argument can be a local fullPath or URL or byte array (byte[]) or Base64String of a file.


### File Management

The SDK provides a simple interface for all the [media APIs mentioned here](https://docs.imagekit.io/api-reference/media-api) to manage your files.

**1. List & Search Files**

Accepts an object specifying the parameters to be used to list and search files. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/list-and-search-files) can be passed as it is with the correct values to get the results.

```cs
ResponseMetaData resp = await imagekit.GetFileListRequestAsync();
```




**2. Get File Details**

Accepts the file ID and fetches the details as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/get-file-details).

```cs
Task<ResponseMetaData> resp = await imagekit.GetFileDetailsAsync(fileId);
```

**3. Get File Versions**

Accepts the file ID and fetches the details as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/get-file-versions).

```.net
String fileId = "62a04834c10d49825c6de9e8";
ResponseMetaData resultFileVersions = ImageKit.getFileVersions(fileId);

```

**4. Get File Version details**

Accepts the file ID and version ID and fetches the details as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/get-file-version-details).

```java
String fileId = "62a04834c10d49825c6de9e8";
String versionId = "62a04834c10d49825c6de9e8";
ResponseMetaData resultFileVersionDetails = ImageKit.getFileVersionDetails(fileId, versionId);

```

**5. Update File Details**

Accepts an object of class `FileUpdateRequest` specifying the parameters to be used to update file details. All parameters specified in the [documentation here] (https://docs.imagekit.io/api-reference/media-api/update-file-details) can be passed via their setter functions to get the results.

```java
List<String> tags = new ArrayList<>();
tags.add("Software");
tags.add("Developer");
tags.add("Engineer");

List<String> aiTags = new ArrayList<>();
aiTags.add("Plant");
FileUpdateRequest fileUpdateRequest = new FileUpdateRequest("fileId");
fileUpdateRequest.Tags(tags);
fileUpdateRequest.AITags=aiTags;
ResponseMetaData result=ImageKit.updateFileDetail(fileUpdateRequest);
 
```

**6. Add tags**

Accepts an object of class `TagsRequest` specifying the parameters to be used to add tags. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/add-tags-bulk) can be passed via their setter functions to get the results.

```java
List<String> fileIds = new ArrayList<>();
fileIds.add("FileId");
List<String> tags = new ArrayList<>();
tags.add("tag-to-add-1");
tags.add("tag-to-add-2");
ResponseMetaData resultTags=ImageKit.addTags(new TagsRequest(fileIds, tags));

```

**7. Remove tags**

Accepts an object of class `TagsRequest` specifying the parameters to be used to remove tags. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/remove-tags-bulk) can be passed via their setter functions to get the results.

```java
List<String> fileIds = new ArrayList<>();
fileIds.add("FileId");
List<String> tags = new ArrayList<>();
tags.add("tag-to-remove-1");
tags.add("tag-to-remove-2");
ResponseMetaData resultTags=ImageKit.removeTags(new TagsRequest(fileIds, tags));

```

**8. Remove AI tags**

Accepts an object of class `AITagsRequest` specifying the parameters to be used to remove AI tags. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/remove-aitags-bulk) can be passed via their setter functions to get the results.

```java
List<String> fileIds = new ArrayList<>();
fileIds.add("629f3de17eb0fe4053615450");
List<String> aiTags = new ArrayList<>();
aiTags.add("Rectangle");
AITagsRequest aiTagsRequest =new AITagsRequest();
aiTagsRequest.FileIds=fileIds;
aiTagsRequest.AITags=aiTags;
ResponseMetaData resultTags = ImageKit.getInstance().removeAITags(aiTagsRequest);

```

**9. Delete File**

Accepts the file ID and delete a file as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/delete-file).

```java
String fileId="your-file-id";
ResponseMetaData result=ImageKit.deleteFile(fileId);

```

**10. Delete FileVersion**

Accepts an object of class `DeleteFileVersionRequest` specifying the parameters to be used to delete file version. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/delete-file-version) can be passed via their setter functions to get the results.

```java
DeleteFileVersionRequest deleteFileVersionRequest = new DeleteFileVersionRequest();
deleteFileVersionRequest.FileId="629d95278482ba129fd17c97";
deleteFileVersionRequest.VersionId="629d953ebd24e8ceca911a66";
ResponseMetaData resultNoContent = ImageKit.deleteFileVersion(deleteFileVersionRequest);

```

**11. Delete files (bulk)**

Accepts the file IDs to delete files as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/delete-files-bulk).

```java
List<String> fileIds = new ArrayList<>();
fileIds.add("your-file-id");
fileIds.add("your-file-id");
fileIds.add("your-file-id");

ResponseMetaData result=ImageKit.bulkDeleteFiles(fileIds);

```

**12. Copy file**

Accepts an object of class `CopyFileRequest` specifying the parameters to be used to copy file. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/copy-file) can be passed via their setter functions to get the results.

```java
CopyFileRequest copyFileRequest = new CopyFileRequest();
copyFileRequest.SourceFilePath="/w2_image.png";
copyFileRequest.DestinationPath="/Gallery/";
copyFileRequest.IncludeFileVersions=true;
ResultNoContent resultNoContent = ImageKit.copyFile(copyFileRequest);

```

**13. Move file**

Accepts an object of class `MoveFileRequest` specifying the parameters to be used to move file. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/move-file) can be passed via their setter functions to get the results.

```java
MoveFileRequest moveFileRequest = new MoveFileRequest();
moveFileRequest.SourceFilePath="/Gallery/w2_image.png";
moveFileRequest.DestinationPath="/";
ResponseMetaData resultNoContent = ImageKit.moveFile(moveFileRequest);

```

**14. Rename file**

Accepts an object of class `RenameFileRequest` specifying the parameters to be used to rename file. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/rename-file) can be passed via their setter functions to get the results.

```java
RenameFileRequest renameFileRequest = new RenameFileRequest();
renameFileRequest.FilePath="/w2_image.png";
renameFileRequest.NewFileName="w2_image_s.png";
renameFileRequest.setPurgeCache=true;
ResponseMetaData resultRenameFile = ImageKit.renameFile(renameFileRequest);
 
```

**15. Restore file Version**

Accepts the fileId and versionId to restore file version as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/restore-file-version).

```java
ResponseMetaData result = ImageKit.restoreFileVersion("fileId", "versionId");

```

**16. Create Folder**

Accepts an object of class `CreateFolderRequest` specifying the parameters to be used to create folder. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/create-folder) can be passed via their setter functions to get the results.

```java
CreateFolderRequest createFolderRequest = new CreateFolderRequest();
createFolderRequest.FolderName="test1";
createFolderRequest.ParentFolderPath="/";
ResponseMetaData resultEmptyBlock = ImageKit.createFolder(createFolderRequest);

```

**17. Delete Folder**

Accepts an object of class `DeleteFolderRequest` specifying the parameters to be used to delete folder. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/delete-folder) can be passed via their setter functions to get the results.

```java
DeleteFolderRequest deleteFolderRequest = new DeleteFolderRequest();
deleteFolderRequest.FolderPath="/test1";
ResultNoContent resultNoContent = ImageKit.deleteFolder(deleteFolderRequest);

```

**18. Copy Folder**

Accepts an object of class `CopyFolderRequest` specifying the parameters to be used to copy folder. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/copy-folder) can be passed via their setter functions to get the results.

```java
CopyFolderRequest copyFolderRequest = new CopyFolderRequest();
copyFolderRequest.SourceFolderPath="/Gallery/test";
copyFolderRequest.DestinationPath="/";
ResponseMetaData resultOfFolderActions = ImageKit.copyFolder(copyFolderRequest);

```

**19. Move Folder**

Accepts an object of class `MoveFolderRequest` specifying the parameters to be used to move folder. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/media-api/move-folder) can be passed via their setter functions to get the results.

```java
MoveFolderRequest moveFolderRequest = new MoveFolderRequest();
moveFolderRequest.SourceFolderPath="/Gallery/test";
moveFolderRequest.DestinationPath="/";
ResponseMetaData resultOfFolderActions = ImageKit.moveFolder(moveFolderRequest);

```

**20. Get Bulk Job Status**

Accepts the jobId to get bulk job status as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/copy-move-folder-status).

```java
String jobId = "629f44ac7eb0fe8173622d4b";
ResponseMetaData resultBulkJobStatus = ImageKit.getBulkJobStatus(jobId);

```

**21. Purge Cache**

Accepts a full URL of the file for which the cache has to be cleared as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/purge-cache).

```java
ResponseMetaData result=ImageKit.purgeCache("https://ik.imagekit.io/imagekit-id/default-image.jpg");

```

**22. Purge Cache Status**

Accepts a request ID and fetch purge cache status as per the [API documentation here](https://docs.imagekit.io/api-reference/media-api/purge-cache-status)

```java
String requestId="cache-requestId";
ResponseMetaData result=ImageKit.getPurgeCacheStatus(requestId);

```

**23. Get File Metadata**

Accepts the file ID and fetches the metadata as per the [API documentation here](https://docs.imagekit.io/api-reference/metadata-api/get-image-metadata-for-uploaded-media-files)

```java
String fileId="your-file-id";
ResponseMetaData result=ImageKit.getFileMetadata(fileId);

```

Another way to get metadata from a remote file URL as per the [API documentation here](https://docs.imagekit.io/api-reference/metadata-api/get-image-metadata-from-remote-url). This file should be accessible over the ImageKit.io URL-endpoint.
```java
String url="Remote File URL";
ResponseMetaData result=ImageKit.getRemoteFileMetadata(url);


**24. Create CustomMetaDataFields**

Accepts an object of class `CustomMetaDataFieldCreateRequest` specifying the parameters to be used to create cusomMetaDataFields. All parameters specified in the [documentation here](https://docs.imagekit.io/api-reference/custom-metadata-fields-api/create-custom-metadata-field) can be passed as-is with the correct values to get the results.

Check for the [Allowed Values In The Schema](https://docs.imagekit.io/api-reference/custom-metadata-fields-api/create-custom-metadata-field#allowed-values-in-the-schema-object).

#### Examples:

```java
CustomMetaDataFieldSchemaObject schemaObject = new CustomMetaDataFieldSchemaObject();
schemaObject.Type="Number";
schemaObject.MinValue=10;
schemaObject.MaxValue=200;
CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest = new CustomMetaDataFieldCreateRequest();
customMetaDataFieldCreateRequest.Name="Name";
customMetaDataFieldCreateRequest.Label="Label";
customMetaDataFieldCreateRequest.Schema=schemaObject;
ResponseMetaData ResponseMetaData=ImageKit.createCustomMetaDataFields(customMetaDataFieldCreateRequest);
```

- Date type Exmample:

```java
CustomMetaDataFieldSchemaObject customMetaDataFieldSchemaObject = new CustomMetaDataFieldSchemaObject();
customMetaDataFieldSchemaObject.setType="Date";
 // required if isValueRequired set to true
customMetaDataFieldSchemaObject.MinValue="2022-11-30T10:11:10+00:00";
customMetaDataFieldSchemaObject.MaxValue="2022-12-30T10:11:10+00:00";

CustomMetaDataFieldCreateRequest customMetaDataFieldCreateRequest = new CustomMetaDataFieldCreateRequest();
customMetaDataFieldCreateRequest.Name="Name";
customMetaDataFieldCreateRequest.Label="Label";
customMetaDataFieldCreateRequest.Schema=customMetaDataFieldSchemaObject;

ResponseMetaData resultCustomMetaDataField = ImageKit.getInstance()
       .createCustomMetaDataFields(customMetaDataFieldCreateRequest);
```


**25. Get CustomMetaDataFields**

Accepts the includeDeleted boolean and fetches the metadata as per the [API documentation here](https://docs.imagekit.io/api-reference/custom-metadata-fields-api/get-custom-metadata-field)

```java
ResponseMetaData resultCustomMetaDataFieldList=ImageKit.getCustomMetaDataFields(false);
 
```

**26. Edit CustomMetaDataFields**

Accepts an ID of customMetaDataField and object of class `CustomMetaDataFieldUpdateRequest` specifying the parameters to be used to edit cusomMetaDataFields as per the [API documentation here](https://docs.imagekit.io/api-reference/custom-metadata-fields-api/update-custom-metadata-field).

```java
CustomMetaDataFieldSchemaObject schemaObject = new CustomMetaDataFieldSchemaObject();
schemaObject.setMinValue(10);
schemaObject.setMaxValue(200);

CustomMetaDataFieldUpdateRequest customMetaDataFieldUpdateRequest = new CustomMetaDataFieldUpdateRequest();
customMetaDataFieldUpdateRequest.Id="id";
customMetaDataFieldUpdateRequest.Label="label";
customMetaDataFieldUpdateRequest.Schema=schemaObject;
ResponseMetaData resultCustomMetaDataField=ImageKit.updateCustomMetaDataFields(customMetaDataFieldUpdateRequest);

```

**27. Delete CustomMetaDataFields**

Accepts the id to delete the customMetaDataFields as per the [API documentation here](https://docs.imagekit.io/api-reference/custom-metadata-fields-api/delete-custom-metadata-field).

```java
ResponseMetaData resultNoContent=ImageKit.deleteCustomMetaDataField("id");


## Utility functions

We have included the following commonly used utility functions in this library.

### Authentication Parameter Generation

If you are looking to implement client-side file upload, you will need a token, expiry timestamp, and a valid signature for that upload. The SDK provides a simple method that you can use in your code to generate these authentication parameters for you.

*Note: The Private API Key should never be exposed in any client-side code. You must always generate these authentication parameters on the server-side*

```csharp
AuthParamResponse resp = imagekit.GetAuthenticationParameters();
```

Returns
```json
{
    "token" : "unique_token",
    "expire" : "valid_expiry_timestamp",
    "signature" : "generated_signature"
}
```

Both the `token` and `expire` parameters are optional. If not specified, the SDK uses the [uuid](https://www.npmjs.com/package/uuid) package to generate a random token and also generates a valid expiry timestamp internally. The value of the `token` and `expire` used to generate the signature is always returned in the response, no matter if they are provided as an input to this method or not.

### Distance calculation between two pHash values

Perceptual hashing allows you to construct a hash value that uniquely identifies an input image based on an image's contents. [ImageKit.io metadata API](https://docs.imagekit.io/api-reference/metadata-api) returns the pHash value of an image in the response. You can use this value to [find a duplicate (or similar) image](https://docs.imagekit.io/api-reference/metadata-api#using-phash-to-find-similar-or-duplicate-images) by calculating the distance between the two images' pHash value.

This SDK exposes `PHashDistance` function to calculate the distance between two pHash values. It accepts two pHash hexadecimal strings and returns a numeric value indicative of the level of difference between the two images.

```
public static int CalculateDistance() {
    // asynchronously fetch metadata of two uploaded image files
    // ...
    // Extract pHash strings from both: say 'firstHash' and 'secondHash'
    // ...
    // Calculate the distance between them:
    int distance = imagekit.PHashDistance(firstHash, secondHash);
    return distance;
}
```
#### Distance calculation examples

```
imagekit.PHashDistance('f06830ca9f1e3e90', 'f06830ca9f1e3e90');
// output: 0 (same image)

imagekit.PHashDistance('2d5ad3936d2e015b', '2d6ed293db36a4fb');
// output: 17 (similar images)

imagekit.PHashDistance('a4a65595ac94518b', '7838873e791f8400');
// output: 37 (dissimilar images)
```
## Support

For any feedback or to report any issues or general implementation support, please reach out to [support@imagekit.io](mailto:support@imagekit.io)

## Links
* [Documentation](https://docs.imagekit.io)
* [Main website](https://imagekit.io)

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) File for details