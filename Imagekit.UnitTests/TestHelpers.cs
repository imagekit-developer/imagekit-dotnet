using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using Moq;
using Moq.Protected;

namespace Imagekit.UnitTests
{
    public static class TestHelpers
    {
        static TestHelpers()
        {
            Faker.DefaultStrictMode = true;
        }

        public static Faker<MetadataResponse> MetadataResponseFaker = new Faker<MetadataResponse>()
            .RuleFor(u => u.Exif, (f, u) => ExifFaker.Generate())
            .RuleFor(u => u.Image, (f, u) => ImageDataFaker.Generate())
            .RuleFor(u => u.Thumbnail, (f, u) => ThumbnailFaker.Generate())
            .RuleFor(u => u.Gps, (f, u) => GpsFaker.Generate())
            .RuleFor(u => u.errorMessage, (f, u) => f.Random.Int())
            .RuleFor(u => u.Size, (f, u) => f.Random.Int())
            .RuleFor(u => u.Height, (f, u) => f.Random.Int())
            .RuleFor(u => u.Width, (f, u) => f.Random.Int())
            .RuleFor(u => u.Quality, (f, u) => f.Random.Int())
            .RuleFor(u => u.StatusNumber, (f, u) => (int)f.PickRandom<HttpStatusCode>())
            .RuleFor(u => u.StatusCode, (f, u) => u.StatusNumber.ToString())
            .RuleFor(u => u.Format, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Message, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.help, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.HasColorProfile, (f, u) => f.Random.Bool())
            .RuleFor(u => u.HasTransparency, (f, u) => f.Random.Bool())
            .RuleFor(u => u.Exception, (f, u) => f.Random.Bool())
            .RuleFor(u => u.Interoperability, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Makernote, (f, u) => f.Random.Utf16String());

        public static Faker<Exif> ExifFaker = new Faker<Exif>()
            .RuleFor(u => u.Flash, (f, u) => f.Random.Int())
            .RuleFor(u => u.ColorSpace, (f, u) => f.Random.Int())
            .RuleFor(u => u.ExifImageWidth, (f, u) => f.Random.Int())
            .RuleFor(u => u.ExifImageHeight, (f, u) => f.Random.Int())
            .RuleFor(u => u.ExifVersion, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.FlashpixVersion, (f, u) => f.Random.Utf16String());

        public static Faker<ImageData> ImageDataFaker = new Faker<ImageData>()
            .RuleFor(u => u.Orientation, (f, u) => f.Random.Int())
            .RuleFor(u => u.XResolution, (f, u) => f.Random.Int())
            .RuleFor(u => u.YResolution, (f, u) => f.Random.Int())
            .RuleFor(u => u.ResolutionUnit, (f, u) => f.Random.Int())
            .RuleFor(u => u.ExifOffset, (f, u) => f.Random.Int())
            .RuleFor(u => u.ImageDescription, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Software, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.ModifyDate, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Artist, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Copyright, (f, u) => f.Random.Utf16String());

        public static Faker<Thumbnail> ThumbnailFaker = new Faker<Thumbnail>()
            .RuleFor(u => u.Compression, (f, u) => f.Random.Int())
            .RuleFor(u => u.XResolution, (f, u) => f.Random.Int())
            .RuleFor(u => u.YResolution, (f, u) => f.Random.Int())
            .RuleFor(u => u.ResolutionUnit, (f, u) => f.Random.Int())
            .RuleFor(u => u.ThumbnailOffset, (f, u) => f.Random.Int())
            .RuleFor(u => u.ThumbnailLength, (f, u) => f.Random.Int());

        public static Faker<Gps> GpsFaker = new Faker<Gps>()
            .RuleFor(u => u.GPSLatitudeRef, (f, u) => f.Random.ArrayElement(new string[] { "N", "S" }))
            .RuleFor(u => u.GPSLongitudeRef, (f, u) => f.Random.ArrayElement(new string[] { "W", "E" }))
            .RuleFor(u => u.GPSImgDirectionRef, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.GPSDateStamp, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.GPSAltitudeRef, (f, u) => f.Random.Int())
            .RuleFor(u => u.GPSAltitude, (f, u) => f.Random.Int())
            .RuleFor(u => u.GPSImgDirection, (f, u) => f.Random.Float())
            .RuleFor(u => u.GPSLatitude, (f, u) => CoordinateToRational(f.Address.Latitude()))
            .RuleFor(u => u.GPSLongitude, (f, u) => CoordinateToRational(f.Address.Longitude()))
            .RuleFor(u => u.GPSTimeStamp, (f, u) => GetRationalTime(f.Date.Timespan()));

        private static double[] GetRationalTime(TimeSpan time)
        {
            var seconds = (double)time.Seconds;
            var milliseconds = (double)time.Milliseconds / 1000;
            return new double[] { time.Hours, time.Minutes, seconds + milliseconds};
        }

        private static double[] CoordinateToRational(double coordinate)
        {
            double temp;
            temp = Math.Abs(coordinate);
            var degrees = (int)Math.Truncate(temp);
            temp = (temp - degrees) * 60;
            var minutes = (int)Math.Truncate(temp);
            temp = (temp - minutes) * 60;
            var seconds = Math.Round(Math.Truncate(1000 * temp) / 1000, 1);
            return new double[] { degrees, minutes, seconds };
        }

        public static Faker<ImagekitResponse> ImagekitResponseFaker = new Faker<ImagekitResponse>()
            .RuleFor(u => u.FileId, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Field, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Name, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.URL, (f, u) => f.Internet.UrlWithPath(fileExt: ".png"))
            .RuleFor(u => u.Thumbnail, (f, u) => f.Internet.UrlWithPath(fileExt: ".png"))
            .RuleFor(u => u.FileType, (f, u) => f.Random.ArrayElement(new string[] { "image", "non-image" }))
            .RuleFor(u => u.FilePath, (f, u) => f.System.FilePath())
            .RuleFor(u => u.Size, (f, u) => f.Random.Int())
            .RuleFor(u => u.Height, (f, u) => f.Random.Int())
            .RuleFor(u => u.Width, (f, u) => f.Random.Int())
            .RuleFor(u => u.Tags, (f, u) => new string[] { f.Random.Utf16String(), f.Random.Utf16String() })
            .RuleFor(u => u.IsPrivateFile, (f, u) => f.Random.Bool())
            .RuleFor(u => u.CustomCoordinates, (f, u) => f.Random.Bool())
            .RuleFor(u => u.exception, (f, u) => f.Random.Bool())
            .RuleFor(u => u.statusNumber, (f, u) => (int)f.PickRandom<HttpStatusCode>())
            .RuleFor(u => u.statusCode, (f, u) => u.statusNumber.ToString())
            .RuleFor(u => u.message, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.help, (f, u) => f.Random.Utf16String())
            .RuleFor(u => u.Metadata, (f, u) => MetadataResponseFaker.Generate());

        /// <summary>
        /// Get a test http client that response to the specified request.
        /// </summary>
        /// <param name="response">The response to return from the request.</param>
        /// <returns></returns>
        public static HttpClient GetTestHttpClient(Expression requestMatcher, HttpResponseMessage response)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                // Setup the PROTECTED method to mock
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    requestMatcher,
                    ItExpr.IsAny<CancellationToken>()
                )
                // prepare the expected response of the mocked http call
                .ReturnsAsync(response)
                .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object);
            return httpClient;
        }

        /// <summary>
        /// Get a test http client that response to any request.
        /// </summary>
        /// <param name="response">The response to return from the request.</param>
        /// <returns></returns>
        public static HttpClient GetTestHttpClient(HttpResponseMessage response)
        {
            return GetTestHttpClient(ItExpr.IsAny<HttpRequestMessage>(), response);
        }
    }
}