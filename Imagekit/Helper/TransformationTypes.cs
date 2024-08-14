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
    public Transformation EffectShadow()
    {
        return this.Add("e-shadow", "true");
    }

    /// <summary></summary>
    public Transformation EffectGradient()
    {
        return this.Add("e-gradient", "true");
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
    public Transformation Raw(string value)
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
