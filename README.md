# DotNET Imagekit integration
This is the Imagekit integration library for .NET

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
```
using Imagekit;
```
Then, initialize the imagekit service using this code, when your app starts(example: ASP: Global.asax, WPF: app.xaml.cs): 
```
ConnectionHelper.Initialize("API-public", "API-Private", "ID");
```
Notice: API-public is your API public key, API-private is your API private key, and ID is your imagekit ID. You can get all of them from your [Imagekit dashboard](https://imagekit.io/dashboard).

After that you can upload your image:
```
Upload.Picture(photo, "/path/", "name.jpg",true);
```
Notice: photo is your photo which can be a byte array (byte[]) of your photo or local path on your disk(string). "/path/" is the desired path of uploaded file. "name.jpg" is the desired name of uploaded file. The last parameter is "useUniqueName" which is an optional parameter with the default value of true.

Done; You uploaded your picture.
Whoa! It was fast, wasn't it?

## Credits

* [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) - JSON parser

## Contributing

This library is an open source project, so all the modifications and contributions are welcome! Just make a fork of this repo, do your changes and make a pull request. We'll check your code ASAP.

## Support

If you have any kind of questions or feature request, you can contact [Mohsens22@outlook.com](mailto:Mohsens22@outlook.com) or contact [Imagekit.io](https://imagekit.io) via chat support.
Also you can post the issues in the [issues](https://github.com/imagekit-developer/dotnet-imagekit-integration/issues) part.

## Authors

* **Mohsen Seifi** - *Core development* - [@mohsens22](https://github.com/mohsens22)

See also the list of [contributors](https://github.com/github.com/imagekit-developer/dotnet-imagekit-integration/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details








