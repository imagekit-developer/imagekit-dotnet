# DotNET Imagekit integration
This is the Imagekit integration library for .NET

### Features
This library will help you to upload your images and files to Imagekit as easy as possible. Currectly you can upload images or files via URL *(URi)*, Path to existing file in your hard disk *(string)*  and byte arrays *(byte[])* which are default format of uploaded files in ASP.NET .
Also you can make [feature request](#support) or [contribute](#contributing) for things you need.

## Getting Started
These instructions will help you to interact with Imagekit.io services in .NET using the brand new Imagekit integration library.

### Installing
There are a couple of ways to get started with this integration library.

Way one:
Open up your project, navigate to Nuget package manager console and add Imagekit.
```
Install-Package Imagekit
```
Also you can search for [Imagekit](https://www.nuget.org/packages/Imagekit/1.0.0) in Nuget GUI.

Way two:

1-Clone this repo or download the zip file.

2-Add it to your solution

3-Reference your host project to Imagekit.

### Usage
Now that everything's installed and set up, you can start using ImageKit on your .NET project!
First, add this reference where you want to use imagekit
```cs
using Imagekit;
```
Then, initialize the imagekit service using this code, when your app starts(example: ASP: Global.asax, WPF: app.xaml.cs): 
```cs
ConnectionHelper.Initialize("API-public", "API-Private", "ID");
```
Notice: API-public is your API public key, API-private is your API private key, and ID is your imagekit ID. You can get all of them from your [Imagekit dashboard](https://imagekit.io/dashboard).

####Upload pictures
now you can upload your image using this code:
```cs
ImagekitResponse R = Upload.Picture(photo, "/path/", "name.jpg",true);
```
**Notice**: *photo* is your photo which can be a byte array *(byte[])* or your photo or local path on your disk *(string)* or a URL to an existing picture on the web *(URi)*. *"/path/"* is the desired path of uploaded file *(string)* . *"name.jpg"* is the desired name of uploaded file *(string)*. The last parameter is "useUniqueName" which is an optional parameter *(bool)* with the default value of *true*.

This method retunes you an object with the type of **ImagekitResponse** which is the information about the uploaded file.

| Name  | Description | Type | Sample output |
| ------------- | ------------- |------|------|
| ImagePath  | The path of uploaded picture in your media library  | string | "/avatar/sample_HJN0fTUtb.jpg" |
| Size  | Size of uploaded photo in bytes  | int | 7117 |
| Height  | Height of uploaded photo  | int | 200 |
| Width  | Width of uploaded photo  | int | 200 |
| ID  | The unique ID of your saved picture  | string | "HkiFvuZKZ/avatar/sample_HJN0fTUtb.jpg/original" |
| FileFolder  | The real path of uploaded picture in imagekit servers  | string | "/HkiFvuZKZ/avatar/sample_HJN0fTUtb.jpg/" |
| Thumbnail  | The thumbnail URL of uploaded picture  | string | "https://ik.imagekit.io/xeamo/tr:n-media_library_thumbnail/avatar/sample_HJN0fTUtb.jpg" |
| URL  | The public URL to your picture | string | "https://ik.imagekit.io/xeamo/avatar/sample_HJN0fTUtb.jpg" |
| Name  | The name of uploaded picture in your media library  | string | "sample_HJN0fTUtb.jpg" |
| Transformation  | The applied transformation to your picture  | string | "" |

Done; You uploaded your picture.
Whoa! It was so fast, wasn't it?

## Credits

* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)

## Contributing

This library is an open source project, so all the modifications and contributions are welcome! Just make a fork of this repo, do your changes and make a pull request. We'll check your code ASAP.

## Support

If you have any kind of questions or feature request, you can contact [Mohsens22@outlook.com](mailto:Mohsens22@outlook.com) or contact [Imagekit.io](https://imagekit.io) via chat support.
Also you can post the issues in the [issues](https://github.com/imagekit-developer/dotnet-imagekit-integration/issues) part.

## Authors

* **Mohsen Seifi** - *Core development* - [@mohsens22](https://github.com/mohsens22)

See also the list of [contributors](https://github.com/imagekit-developer/dotnet-imagekit-integration/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details








