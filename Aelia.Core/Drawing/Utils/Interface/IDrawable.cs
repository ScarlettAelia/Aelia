using Aelia.Core.Maths.Vector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Drawing.Utils.Interface;

public interface IDrawable
{
    /// <summary>
    /// Draw the object as a HTML string.
    /// </summary>
    /// <returns></returns>
    public string DrawHtml();
    /// <summary>
    /// Draw the object as a SVG vector image.
    /// </summary>
    /// <returns></returns>
    public Vector2Double DrawVector();
    /// <summary>
    /// Draw the object as a raster image.
    /// </summary>
    /// <returns></returns>
    public object DrawRaster();
}
