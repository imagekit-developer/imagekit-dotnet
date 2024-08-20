# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [5.0.0]

### Breaking changes

**Overlay syntax update**
* In version 5.0.0, we've removed the old overlay syntax parameters for transformations, such as `oi`, `ot`, `obg`, and [more](https://docs.imagekit.io/features/image-transformations/overlay). These parameters are deprecated and will start returning errors when used in URLs. Please migrate to the new layers syntax that supports overlay nesting, provides better positional control, and allows more transformations at the layer level. You can start with [examples](https://docs.imagekit.io/features/image-transformations/overlay-using-layers#examples) to learn quickly.
* You can migrate to the new layers syntax using the `raw` transformation parameter.

### Added
- Parameters `EffectShadow` and `EffectGradient` for url generation.
- Upload options `transformation` for applying `pre` and `post` transformations, and `checks` to perform server-side validations before file uploads.

## [4.0.1]
### Fixed
- https://github.com/imagekit-developer/imagekit-dotnet/issues/50

## [4.0.0]
### Fixed
- https://github.com/imagekit-developer/imagekit-dotnet/issues/37
- https://github.com/imagekit-developer/imagekit-dotnet/issues/41
- https://github.com/imagekit-developer/imagekit-dotnet/issues/40
- https://github.com/imagekit-developer/imagekit-dotnet/issues/38
- https://github.com/imagekit-developer/imagekit-dotnet/issues/34

## [3.1.6] - 2021-07-21
### Fixed
- Bug Fix

## [3.1.5] - 2021-06-05
### Changed
- Sort, searchQuery options added for ListAPI
- API reponse fields updated

## [3.1.4] - 2021-04-12
### Fixed
- Core package install bug fix

## [3.1.3] - 2020-11-05
### Fixed
- Delete Api bug fix

## [3.1.2] - 2020-11-04
### Fixed
- Upload Api fix

## [3.1.1] - 2020-09-11
### Changed
- Fix issue where tags were not set in some cases when uploading a file
- Allow more ways to set tags when updating file details

## [3.1.0] - 2020-09-03
### Added
- Async methods for all asynchronous calls
- `ClientImagekit` that supports client upload without the private key
- Support for .NET Standard 2.1
- `ImagekitResponse.FileId`
- Some XML documentation

### Changed
- The `Imagekit.Imagekit` class is deprecated; use `ServerImagekit` instead
- Fix issue where `isPrivateFile` was not included on upload
- Fix issue where type of `Gps.GPSLatitude`, `Gps.GPSLongitude`, and `GPSTimeStamp` was incorrect
- Some of the `ArgumentException`s are now `ArgumentNullException` and set the `ParamName` property of the exception. This is not a binary breaking change as `ArgumentNullException` inherits from `ArgumentException`, but if you are specifically looking for the `ArgumentException` type exactly, you may see a runtime issue, although this is very unlikely.
