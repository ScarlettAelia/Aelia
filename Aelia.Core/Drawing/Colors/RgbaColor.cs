using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Drawing.Colors;

/// <summary>
/// Basic RGBA color struct
/// </summary>
public struct RgbaColor
{
    #region Fields

    /// <summary>
    /// Red channel
    /// </summary>
    public byte R = 0xFF;
    /// <summary>
    /// Green channel
    /// </summary>
    public byte G = 0xFF;
    /// <summary>
    /// Blue channel
    /// </summary>
    public byte B = 0xFF;
    /// <summary>
    /// Alpha Channel
    /// </summary>
    public byte A = 0xFF;

    #endregion Fields

    #region Accessors

    /// <summary>
    /// '#RRGGBBAA'
    /// </summary>
    public readonly string HtmlRgba => ToRgbaString();
    /// <summary>
    /// '#RRGGBB'
    /// </summary>
    public readonly string HtmlRgb => ToRgbString();

    #endregion Accessors

    #region Constructors

    public RgbaColor() { }

    public RgbaColor(byte r, byte g, byte b, byte a = 0xFF)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    #endregion Contructors

    #region Functions

    #region Parsing

    /// <summary>
    /// Attempts to parse a <see cref="bool"/> to a <see cref="RgbaColor"/>
    /// </summary>
    /// <param name="input">uint representation of a color</param>
    /// <param name="color">output color</param>
    /// <param name="bigEndian">is the color using big endian?</param>
    /// <returns></returns>
    public static bool TryParseRgba(uint input, out RgbaColor color, bool bigEndian = true)
    {
        if (input > 0XFFFFFFFF)
        {
            color = new RgbaColor();
            return false;
        }

        byte[] bytes = BitConverter.GetBytes(input);

        if (!bigEndian) { bytes = [.. bytes.Reverse()]; }

        color = new RgbaColor(bytes[0], bytes[1], bytes[2], bytes[3]);
        return true;
    }
    /// <summary>
    /// Attempts to parse a <see cref="string"> to a <see cref="RgbaColor"/>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="color"></param>
    /// <returns><b>true</b> if successful parse, else <b>false</b></returns>
    public static bool TryParseRgba(string input, out RgbaColor color)
    {
        string cleanedInput = input.Trim();
        _ = cleanedInput.StartsWith('#') ? cleanedInput.TrimStart('#') : cleanedInput;
        _ = cleanedInput.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase) ? cleanedInput.TrimStart("0x").TrimStart("0X") : cleanedInput;

        byte r = 0xFF;
        byte g = 0xFF;
        byte b = 0xFF;
        byte a = 0xFF;

        switch (input.Length)
        {
            case 3: // #RGB
                _ = byte.TryParse($"{input[0]}{input[0]}", out r);
                _ = byte.TryParse($"{input[1]}{input[1]}", out g);
                _ = byte.TryParse($"{input[2]}{input[2]}", out b);
                color = new RgbaColor(r, g, b, a);
                return true;
            case 4: // #RGBA
                _ = byte.TryParse($"{input[0]}{input[0]}", out r);
                _ = byte.TryParse($"{input[1]}{input[1]}", out g);
                _ = byte.TryParse($"{input[2]}{input[2]}", out b);
                _ = byte.TryParse($"{input[3]}{input[3]}", out a);
                color = new RgbaColor(r, g, b, a);
                return true;
            case 6: // #RRGGBB
                _ = byte.TryParse(cleanedInput[0..1], out r);
                _ = byte.TryParse(cleanedInput[2..3], out g);
                _ = byte.TryParse(cleanedInput[4..5], out b);
                color = new RgbaColor(r, g, b, a);
                return true;
            case 8: // #RRGGBBAA
                _ = byte.TryParse(cleanedInput[0..1], out r);
                _ = byte.TryParse(cleanedInput[2..3], out g);
                _ = byte.TryParse(cleanedInput[4..5], out b);
                _ = byte.TryParse(cleanedInput[6..7], out a);
                color = new RgbaColor(r, g, b, a);
                return true;
            default:
                color = new RgbaColor(r, g, b, a);
                return false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static RgbaColor ParseRgba(uint input)
    {
        bool success = TryParseRgba(input, out RgbaColor color);

        if (success)
            return color;
        else
            throw new ArgumentException($"Could not parse '{input}' to RgbaColor");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static RgbaColor ParseRgba(string input)
    {
        bool success = TryParseRgba(input, out RgbaColor color);

        if (success)
            return color;
        else
            throw new ArgumentException($"Could not parse '{input}' to RgbaColor");
    }

    #endregion Parsing

    #region Conversions

    /// <summary>
    /// Convert a set of <see cref="byte"/> to <see cref="string"/> representation of a color used in html
    /// </summary>
    /// <param name="r">Red channel</param>
    /// <param name="g">Green channel</param>
    /// <param name="b">Blue channel</param>
    /// <param name="a">Alpha channel</param>
    /// <returns><see cref="string"/> representation of a <see cref="RgbaColor"/> in the form '#RRGGBBAA'</returns>
    public static string ToRgbaString(byte r, byte g, byte b, byte a = 0xFF)
        => $"#{r:x2}{g:x2}{b:x2}{a:x2}";
    /// <summary>
    /// Convert a <see cref="RgbaColor"/> to <see cref="string"/> representation of a color used in html
    /// </summary>
    /// <inheritdoc cref="ToRgbaString(byte, byte, byte, byte)"/>
    public static string ToRgbaString(RgbaColor color) => ToRgbaString(color.R, color.G, color.B, color.A);
    /// <inheritdoc cref="ToRgbaString(RgbaColor)"/>
    public readonly string ToRgbaString() => ToRgbaString(R, G, B, A);

    /// <summary>
    /// Convert a set of <see cref="byte"/> to <see cref="string"/> representation of a color used in html
    /// </summary>
    /// <param name="r">Red channel</param>
    /// <param name="g">Green channel</param>
    /// <param name="b">Blue channel</param>
    /// <returns><see cref="string"/> representation of a <see cref="RgbaColor"/> in the form '#RRGGBB'</returns>
    public static string ToRgbString(byte r, byte g, byte b)
        => $"#{r:x2}{g:x2}{b:x2}";
    /// <summary>
    /// Convert a <see cref="RgbaColor"/> to <see cref="string"/> representation of a color used in html
    /// </summary>
    /// <inheritdoc cref="ToRgbString(byte, byte, byte)"/>
    public static string ToRgbString(RgbaColor color) => ToRgbString(color.R, color.G, color.B);
    /// <inheritdoc cref="ToRgbString(RgbaColor)"/>
    public readonly string ToRgbString() => ToRgbString(R, G, B);

    #endregion Conversions

    #region Color Manipulation

    /// <summary>
    /// Converts a set of <see cref="byte"> to greyscale.
    /// </summary>
    /// <param name="r">Red channel</param>
    /// <param name="g">Green channel</param>
    /// <param name="b">Blue channel</param>
    /// <param name="a">Alpha channel</param>
    /// <returns>Greyscale <see cref="RgbaColor"/></returns>
    public static RgbaColor ToGreyscale(byte r, byte g, byte b, byte a = 0xFF)
    {
        byte v = GreyscaleValue(r, g, b);

        return new RgbaColor(v, v, v, a);
    }
    /// <summary>
    /// Converts a <see cref="RgbaColor"/> to greyscale.
    /// </summary>
    /// <param name="color">Original color</param>
    /// <returns>Greyscale <see cref="RgbaColor"/></returns>
    public static RgbaColor ToGreyscale(RgbaColor color) => ToGreyscale(color.R, color.G, color.B, color.A);
    /// <inheritdoc cref="ToGreyscale(RgbaColor)"/>
    public readonly RgbaColor ToGreyscale() => ToGreyscale(this.R, this.G, this.B, this.A);

    /// <summary>
    /// Calculates the value of a rgb color
    /// </summary>
    /// <param name="r">Red channel</param>
    /// <param name="g">Green channel</param>
    /// <param name="b">Blue channel</param>
    /// <returns></returns>
    public static byte GreyscaleValue(byte r, byte g, byte b) => (byte)((0.299 * r) + (0.587 * g) + (0.114 * b));
    /// <inheritdoc cref="GreyscaleValue(byte, byte, byte)"/>
    public readonly byte GreyscaleValue() => GreyscaleValue(this.R, this.G, this.B);

    #endregion Color Manipulation

    #region Utilities

    private static byte AddChannel(byte left, byte right) => (byte)Math.Clamp(left + right, 0, 0xFF);
    private static byte SubtractChannel(byte left, byte right) => (byte)Math.Clamp(left - right, 0, 0xFF);
    private static byte MultiplyChannel(byte left, byte right) => (byte)Math.Clamp(left * right, 0, 0xFF);
    private static byte DivideChannel(byte left, byte right) => (byte)Math.Clamp(left / right, 0, 0xFF);

    #endregion Utilities

    #endregion Functions

    #region Operators

    #region Add

    public static RgbaColor Add(RgbaColor left, RgbaColor right)
        => new(
            r: AddChannel(left.R, right.R),
            g: AddChannel(left.G, right.G),
            b: AddChannel(left.B, right.B),
            a: AddChannel(left.A, right.A));
    public readonly RgbaColor Add(RgbaColor other) => Add(this, other);
    public static RgbaColor Add(RgbaColor left, byte right)
        => new(
            r: AddChannel(left.R, right),
            g: AddChannel(left.G, right),
            b: AddChannel(left.B, right),
            a: AddChannel(left.A, right));
    public readonly RgbaColor Add(byte other) => Add(this, other);

    public static RgbaColor operator +(RgbaColor left, RgbaColor right) => Add(left, right);
    public static RgbaColor operator +(RgbaColor left, byte right) => Add(left, right);

    #endregion Add

    #region Subtract

    public static RgbaColor Subtract(RgbaColor left, RgbaColor right)
        => new(
            r: SubtractChannel(left.R, right.R),
            g: SubtractChannel(left.G, right.G),
            b: SubtractChannel(left.B, right.B),
            a: SubtractChannel(left.A, right.A));
    public readonly RgbaColor Subtract(RgbaColor other) => Subtract(this, other);
    public static RgbaColor Subtract(RgbaColor left, byte right)
        => new(
            r: SubtractChannel(left.R, right),
            g: SubtractChannel(left.G, right),
            b: SubtractChannel(left.B, right),
            a: SubtractChannel(left.A, right));
    public readonly RgbaColor Subtract(byte other) => Subtract(this, other);

    public static RgbaColor operator -(RgbaColor left, RgbaColor right) => Subtract(left, right);
    public static RgbaColor operator -(RgbaColor left, byte right) => Subtract(left, right);

    #endregion Subtract

    #region Multiply

    public static RgbaColor Multiply(RgbaColor left, RgbaColor right)
        => new(
            r: MultiplyChannel(left.R, right.R),
            g: MultiplyChannel(left.G, right.G),
            b: MultiplyChannel(left.B, right.B),
            a: MultiplyChannel(left.A, right.A));
    public readonly RgbaColor Multiply(RgbaColor other) => Multiply(this, other);
    public static RgbaColor Multiply(RgbaColor left, byte right)
        => new(
            r: MultiplyChannel(left.R, right),
            g: MultiplyChannel(left.G, right),
            b: MultiplyChannel(left.B, right),
            a: MultiplyChannel(left.A, right));
    public readonly RgbaColor Multiply(byte other) => Multiply(this, other);

    public static RgbaColor operator *(RgbaColor left, RgbaColor right) => Multiply(left, right);
    public static RgbaColor operator *(RgbaColor left, byte right) => Multiply(left, right);

    #endregion Multiply

    #region Divide

    public static RgbaColor Divide(RgbaColor left, RgbaColor right)
        => new(
            r: DivideChannel(left.R, right.R),
            g: DivideChannel(left.G, right.G),
            b: DivideChannel(left.B, right.B),
            a: DivideChannel(left.A, right.A));
    public readonly RgbaColor Divide(RgbaColor other) => Divide(this, other);
    public static RgbaColor Divide(RgbaColor left, byte right)
        => new(
            r: DivideChannel(left.R, right),
            g: DivideChannel(left.G, right),
            b: DivideChannel(left.B, right),
            a: DivideChannel(left.A, right));
    public readonly RgbaColor Divide(byte other) => Divide(this, other);

    public static RgbaColor operator /(RgbaColor left, RgbaColor right) => Divide(left, right);
    public static RgbaColor operator /(RgbaColor left, byte right) => Divide(left, right);

    #endregion Divide

    #region Equals

    public readonly override bool Equals(object? other) => (other is RgbaColor) && Equals(other) || (other is byte) && Equals(other);
    public static bool Equals(RgbaColor left, RgbaColor right)
        => left.R == right.R && left.G == right.G && left.B == right.B && left.A == right.A;
    public readonly bool Equals(RgbaColor other) => Equals(this, other);
    public static bool Equals(RgbaColor left, byte right)
        => left.R == right && left.G == right && left.B == right && left.A == right;
    public readonly bool Equals(byte other) => Equals(this, other);

    public static bool operator ==(RgbaColor left, RgbaColor right) => Equals(left, right);
    public static bool operator ==(RgbaColor left, byte right) => Equals(left, right);
    public static bool operator ==(byte left, RgbaColor right) => Equals(right, left);

    #endregion Equals

    #region Not Equals

    public static bool NotEquals(RgbaColor left, RgbaColor right)
        => left.R != right.R || left.G != right.G || left.B != right.B || left.A != right.A;
    public readonly bool NotEquals(RgbaColor other) => NotEquals(this, other);
    public static bool NotEquals(RgbaColor left, byte right)
        => left.R == right && left.G == right && left.B == right && left.A == right;
    public readonly bool NotEquals(byte other) => NotEquals(this, other);

    public static bool operator !=(RgbaColor left, RgbaColor right) => NotEquals(left, right);
    public static bool operator !=(RgbaColor left, byte right) => NotEquals(left, right);
    public static bool operator !=(byte left, RgbaColor right) => NotEquals(right, left);

    #endregion Not Equals

    #endregion Operators

    #region Overrides

    public readonly override string ToString() => HtmlRgba;

    public override readonly int GetHashCode()
        => HashCode.Combine(R, G, B, A);

    #endregion Overrides

    #region Convesions



    #endregion Conversions
}
