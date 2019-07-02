[![NuGet](https://img.shields.io/nuget/v/imagekit.svg)]()
# DotNET ImageKit.io integration
This is the ImageKit.io integration library for .NET

By using ImageKit, you can experience about 30% improvement in page load time thanks to the tons of image optimizations that work out of the box without you putting in any effort. Migrating to ImageKit is super simple and takes just a few minutes with our Plug-and-Play technology. Images are delivered across the globe using a CDN ensuring lightning fast experience for your users.

ImageKit.io provides ready-to-use image optimisation servers along with dedicated image storage, global CDN, on-the-fly image transformation like resize, crop, rotate directly from the URL and image uploads.

Also you can make [feature request](#support) or [contribute](#contributing) for things you need.


### Features
This library will help you to upload your images to ImageKit.io as easy as possible. Currectly you can upload images  via URL *(URi)*, Path to existing file in your hard disk *(string)*  and byte arrays *(byte[])* which are default format of uploaded files in ASP.NET .
* Image Upload by path
* Image Upload by URL
* GetMetadata of an Uploaded Image
* List Upload Media Files
* Delete a file 
* Purge a file

## Getting Started
These instructions will help you to interact with ImageKit.io services in .NET using ImageKit.io integration library.

### Installing

```
Install-Package Imagekit
```
Open up your project, navigate to Nuget package manager console and add Imagekit package.
Also you can search for [Imagekit](https://www.nuget.org/packages/Imagekit) in Nuget GUI.


### Usage
Add this reference where you want to use imagekit.io services:
```cs
using Imagekit;

```
Then, initialize the imagekit.io service: 
```cs
Client client = new Client(apiKey, apiSecret, imagekitId);
Api api = new Api(client);
```
Notice: You can get the apiKey, apiSecret and ImagekitId from your [Imagekit.io dashboard](https://imagekit.io/dashboard).

#### Upload Image
Uploads an image with the name "my-image" in the folder "/images" in your storage.
```cs
ImagekitResponse R = api.Upload(imagePath, "/images", "my-name.jpg", false);
```
**Notice**: *photo* is your photo or local path on your disk *(string)*. The last parameter is "useUniqueName" which is an optional parameter *(bool)* with the default value of *true*.

**ImagekitResponse** Properties:
| Name  | Description | Type | Sample output |
| ------------- | ------------- |------|------|
| ImagePath  | The path of uploaded picture in your media library  | string | "/images/my-name.jpg" |
| Size  | Size of uploaded photo in bytes  | int | 7117 |
| Height  | Height of uploaded photo  | int | 200 |
| Width  | Width of uploaded photo  | int | 200 |
| ID  | The unique ID of your saved picture  | string | "<imagekitId>/images/my-name.jpg/original" |
| FileFolder  | The real path of uploaded picture in imagekit.io servers  | string | "<imagekitId>/images/my-name.jpg/" |
| Thumbnail  | The thumbnail URL of uploaded picture  | string | "https://ik.imagekit.io/<imagekitId>/tr:n-media_library_thumbnail/images/my-name.jpg" |
| URL  | The public URL to your picture | string | "https://ik.imagekit.io/<imagekitId>/images/my-name.jpg" |
| Name  | The name of uploaded picture in your media library  | string | "my-name.jpg" |
| Transformation  | The applied transformation to your picture  | string | "" |
| Execption | If there is an exception | bool | false |
| statusNumber | Status code returned | int | 200 |
| statusCode | Status code description | string | "" |
| message | Exception message returned | string | "" |


#### Upload Image By URL
Uploads an image with the URL "http://www.example.com/image.jpg" in the folder "/images" in your storage.
```cs
ImagekitResponse R = api.Upload("http://www.example.com/image.jpg", "/images", "my-name.jpg", false);
```

#### Delete Image
Delete an image with the name "my-name.jpg" in the folder "/images" in your storage.
```cs
DeleteAPIResponse R = api.DeleteFile("images/my-name.jpg");
```
**DeleteAPIResponse** Properties:
| Name  | Description | Type | Sample output |
| ------------- | ------------- |------|------|
| success  | Status of Image Upload  | bool | true |
| Execption | If there is an exception | bool | false |
| statusNumber | Status code returned | int | 200 |
| statusCode | Status code description | string | "" |
| message | Exception message returned | string | "" |


#### Purge Image
Invalidate an image with the URL "https://ik.imagekit.io/<imagekitId>/images/my-name.jpg?tr=h-200".
```cs
PurgeAPIResponse R = api.PurgeFile("https://ik.imagekit.io/<imagekitId>/images/my-name.jpg?tr=h-200");
```
**Notice** Image invalidation is transformation sensitive. You'll have to submit different requests for original and transformed images. Check out the [rate limits](https://docs.imagekit.io/#rate-limits). 
**PurgeAPIResponse** Properties:
| Name  | Description | Type | Sample output |
| ------------- | ------------- |------|------|
| requestId  | RequestId retuned for purge request  | string | "" |
| Execption | If there is an exception | bool | false |
| statusNumber | Status code returned | int | 200 |
| statusCode | Status code description | string | "" |
| message | Exception message returned | string | "" |


#### List Media library Files
List Uploaded Media files with skip and limit params.
```cs
List<ListAPIResponse> R = api.ListUploadedMediaFiles(0,1000);
```
**ListAPIResponse** Properties:
| Name  | Description | Type | Sample output |
| ------------- | ------------- |------|------|
| itemType  | Type of content  | string | "file" |
| Name | Filename | string | "my-image.jpg" |
| itemPath | Path of the file | string | "/images/my-image.jpg" |
| url | URL of the file | string | "https://ik.imagekit.io/<imagekitId>/images/my-image.jpg" |
| thumbnail | Thumnail URL of the file | string | "https://ik.imagekit.io/<imagekitId>/tr:n-media_library_thumbnail/images/my-image.jpg" |
| fileType | Content-Type of the file | string | "image" |


#### Image Metadata 
Get Metadata of Uploaded Media File URL
```cs
MetadataRespone R = api.GetMetadata("https://ik.imagekit.io/demo/images/my-image.jpg");
```
**MetadataRespone** Properties:
| Name  | Description | Type | Sample output |
| ------------- | ------------- |------|------|
| format  | Format of the Image  | string | "jpg" |
| size | Size of the Image(bytes) | int | 7118 |
| height | Height of Image | int | 200 |
| width | Width of Image | int | 200 |
| hasColorProfile | Colorprofile check | bool | false |
| quality | Quality of the Image | int | 80 |
| hasTransparency | Transparency Check | bool | false |
| exif | Exif Data of the Image | JObject | {} |
| Execption | If there is an exception | bool | false |
| statusNumber | Status code returned | int | 200 |
| statusCode | Status code description | string | "" |
| message | Exception message returned | string | "" |



## Credits
* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)


## Support
If you have any kind of questions or feature request, you can contact [Imagekit.io](https://imagekit.io) via chat support.
Also you can post the issues in the [issues](https://github.com/imagekit-developer/dotnet-imagekit-integration/issues) part.

## Authors
[contributors](https://github.com/imagekit-developer/dotnet-imagekit-integration/contributors)


## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details








