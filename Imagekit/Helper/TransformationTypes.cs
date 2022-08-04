// <copyright file="TransformationTypes.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class Transformation
    {
        /// <summary>Width of a transformed image</summary>
        /// <param name="value"></param>
        public Transformation Width(int value)
        {
            return this.Add("w", value);
        }

        /// <summary>Height of a transformed image</summary>
        /// <param name="value"></param>
        public Transformation Height(int value)
        {
            return this.Add("h", value);
        }

        /// <summary>Aspect Ratio of a transformed image</summary>
        /// <param name="value"></param>
        public Transformation AspectRatio(string value)
        {
            return this.Add("ar", value);
        }

        /// <summary>
        /// JPG compression quality. 1 is the lowest quality and 100 is the highest. The default is the
        /// original image's quality or 80% if not available.
        /// </summary>
        /// <param name="value"></param>
        public Transformation Quality(int value)
        {
            return this.Add("q", value);
        }

        /// <summary>Crop Transformation.</summary>
        /// <param name="value"></param>
        public Transformation Crop(string value)
        {
            return this.Add("c", value);
        }

        /// <summary>Crop Mode</summary>
        /// <param name="value"></param>
        public Transformation CropMode(string value)
        {
            return this.Add("cm", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation X(int value)
        {
            return this.Add("x", this.ConvertCoordinateParam(value));
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Y(int value)
        {
            return this.Add("y", this.ConvertCoordinateParam(value));
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Focus(string value)
        {
            return this.Add("fo", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Format(string value)
        {
            return this.Add("f", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Radius(object value)
        {
            return this.Add("r", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Background(string value)
        {
            return this.Add("bg", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Border(string value)
        {
            return this.Add("b", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Rotation(object value)
        {
            return this.Add("rt", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Rotate(object value)
        {
            return this.Add("rt", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Blur(int value)
        {
            return this.Add("bl", value);
        }

        /// <summary>Add named transformation.</summary>
        /// <param name="value">named transformation.</param>
        public Transformation Named(string value)
        {
            return this.Add("n", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayImage(string value)
        {
            return this.Add("oi", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayX(int value)
        {
            return this.Add("ox", this.ConvertCoordinateParam(value));
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayY(int value)
        {
            return this.Add("oy", this.ConvertCoordinateParam(value));
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayFocus(string value)
        {
            return this.Add("ofo", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayHeight(int value)
        {
            return this.Add("oh", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayWidth(int value)
        {
            return this.Add("ow", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayText(string value)
        {
            return this.Add("ot", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayTextFontSize(int value)
        {
            return this.Add("ots", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayTextFontFamily(string value)
        {
            return this.Add("otf", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayTextColor(string value)
        {
            return this.Add("otc", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverylayAlpha(int value)
        {
            return this.Add("oa", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayTextTypography(string value)
        {
            return this.Add("ott", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayTextTransparency(int value)
        {
            return this.Add("oa", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayTextBackground(string value)
        {
            return this.Add("otbg", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayTextEncoded(string value)
        {
            return this.Add("ote", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayTextWidth(int value)
        {
            return this.Add("otw", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayTextPadding(int value)
        {
            return this.Add("otp", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayTextInnerAlignment(string value)
        {
            return this.Add("otia", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayRadius(int value)
        {
            return this.Add("or", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayBackground(string value)
        {
            return this.Add("obg", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayImageTrim(bool value)
        {
            return this.Add("oit", value.ToString().ToLower());
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayImageAspectRatio(string value)
        {
            return this.Add("oiar", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayImageBackground(string value)
        {
            return this.Add("oibg", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayImageBorder(string value)
        {
            return this.Add("oib", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayImageDpr(object value)
        {
            return this.Add("oidpr", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayImageQuality(int value)
        {
            return this.Add("oiq", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation OverlayImageCropping(string value)
        {
            return this.Add("oic", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Progressive(bool value)
        {
            return this.Add("pr", value.ToString().ToLower());
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Lossless(bool value)
        {
            return this.Add("lo", value.ToString().ToLower());
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Trim(int value)
        {
            return this.Add("t", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Metadata(bool value)
        {
            return this.Add("md", value.ToString().ToLower());
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation ColorProfile(bool value)
        {
            return this.Add("cp", value.ToString().ToLower());
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation DefaultImage(string value)
        {
            return this.Add("di", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation Dpr(object value)
        {
            return this.Add("dpr", value);
        }

        /// <summary></summary>
        public Transformation EffectSharpen()
        {
            return this.Add("e-sharpen", string.Empty);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation EffectSharpen(int value)
        {
            return this.Add("e-sharpen", value);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation EffectUsm(string value)
        {
            return this.Add("e-usm", value);
        }

        /// <summary></summary>
        public Transformation EffectContrast()
        {
            return this.Add("e-contrast", string.Empty);
        }

        /// <summary></summary>
        /// <param name="value"></param>
        public Transformation EffectContrast(object value)
        {
            return this.Add("e-contrast", value.ToString().ToLower());
        }

        /// <summary></summary>
        public Transformation EffectGray()
        {
            return this.Add("e-grayscale", "true");
        }

        /// <summary></summary>
        public Transformation Original()
        {
            return this.Add("orig", "true");
        }

        /// <summary>
        /// Pass an raw transformation string (including chained transformations)
        /// </summary>
        /// <param name="value">A raw transformation string.</param>
        public Transformation RawTransformation(string value)
        {
            return this.Add(value, string.Empty);
        }

        private string ConvertCoordinateParam(int paramValue)
        {
            return paramValue < 0
                ? $"N{Math.Abs(paramValue)}"
                : $"{paramValue}";
        }
    }
