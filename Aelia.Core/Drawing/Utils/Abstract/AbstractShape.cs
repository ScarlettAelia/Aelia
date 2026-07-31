using Aelia.Core.Drawing.Utils.Interface;
using Aelia.Core.Maths.Vector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aelia.Core.Drawing.Utils.Abstract;

public abstract class AbstractShape : IDrawable
{
    public abstract string DrawHtml();

    public abstract Vector2Double DrawVector();

    public abstract object DrawRaster();
}
